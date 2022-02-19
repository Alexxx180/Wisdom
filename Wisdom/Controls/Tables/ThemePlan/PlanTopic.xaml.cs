using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Topic of theme plan
    /// </summary>
    public partial class PlanTopic : UserControl, IAutoIndexing, INotifyPropertyChanged, IRawData<HoursList<LevelsList<HashList<Pair<string, string>>>>>
    {
        public HoursList<LevelsList<HashList<Pair<string, string>>>> Raw()
        {
            return new HoursList<LevelsList<HashList<Pair<string, string>>>>(TopicName, TopicHours)
            {
                Values = GetThemes()
            };
        }

        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TopicHeader));
            }
        }

        #region PlanTopic Members
        public string TopicHeader => $"Раздел {No}.";

        private string _topicName;
        public string TopicName
        {
            get => _topicName;
            set
            {
                _topicName = value;
                OnPropertyChanged();
            }
        }

        private string _topicHours;
        public string TopicHours
        {
            get => _topicHours;
            set
            {
                _topicHours = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlanTheme> _themes;
        public ObservableCollection<PlanTheme> Themes
        {
            get => _themes;
            set
            {
                _themes = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public PlanTopic()
        {
            InitializeComponent();
            No = 1;
            Themes = new ObservableCollection<PlanTheme>();
        }

        private List<LevelsList<HashList<Pair<string, string>>>> GetThemes()
        {
            List<LevelsList<HashList<Pair<string, string>>>> themes = new
                List<LevelsList<HashList<Pair<string, string>>>>();
            for (ushort i = 0; i < Themes.Count - 1; i++)
            {
                themes.Add(Themes[i].Raw());
            }
            return themes;
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void DropTopic(object sender, RoutedEventArgs e)
        {
            // ViewModel.DropTopic();
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            //binding.UpdateTarget();
        }

        public void SetElement(HoursList<LevelsList<HashList<Pair<string, string>>>> topic)
        {
            TopicName = topic.Name;
            Themes.Clear();
            for (byte i = 0; i < topic.Values.Count; i++)
            {
                PlanTheme theme = new PlanTheme
                {
                    ThemeName = topic.Values[i].Name,
                    ThemeHours = topic.Values[i].Hours,
                    ThemeCompetetions = topic.Values[i].Competetions,
                    ThemeLevel = topic.Values[i].Level,
                    
                };

                Themes.Add(topic.Values[i]);
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
