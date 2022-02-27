using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Topic of theme plan
    /// </summary>
    public partial class PlanTopic : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<HoursList<LevelsList<HashList<Pair<string, string>>>>>
    {
        public HoursList<LevelsList<HashList<Pair<string, string>>>> Raw()
        {
            return new HoursList<LevelsList<HashList<Pair<string, string>>>>(TopicName, TopicHours)
            {
                Values = Themes.GetRaw()
            };
        }

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region AutoIndexing Logic
        public void ParentAutoIndexing()
        {
            ushort i;
            for (i = 0; i < ThemePlan.Count; i++)
            {
                ThemePlan[i].Index((i + 1).ToUInt());
            }
            //Additor.Index((i + 1).ToUInt());
        }

        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < ThemePlan.Count; i++)
            {
                Themes[i].Index((i + 1).ToUInt());
            }
            ThemeAdditor.Index((i + 1).ToUInt());
        }
        #endregion

        #region PlanTopic Members
        private ObservableCollection<PlanTopic> _themePlan;
        public ObservableCollection<PlanTopic> ThemePlan
        {
            get => _themePlan;
            set
            {
                _themePlan = value;
                OnPropertyChanged();
            }
        }

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
            Index(1);
            Themes = new ObservableCollection<PlanTheme>();
        }

        private void DropTopic(object sender, RoutedEventArgs e)
        {
            _ = ThemePlan.Remove(this);
            ParentAutoIndexing();
            OnPropertyChanged(nameof(ThemePlan));
        }

        #region ThemesGroup Members
        public void DropTheme(PlanTheme source)
        {
            _ = Themes.Remove(source);
            AutoIndexing();
            OnPropertyChanged(nameof(Themes));
        }

        public void AddRecord(PlanTheme record)
        {
            Themes.Add(record);
            OnPropertyChanged(nameof(Themes));
        }
        #endregion

        public void SetElement(HoursList<LevelsList<HashList<Pair<string, string>>>> topic)
        {
            TopicName = topic.Name;
            
            for (byte i = 0; i < topic.Values.Count; i++)
            {
                PlanTheme theme = new PlanTheme
                {
                    No = (i + 1).ToUInt(),
                    Topic = this
                };
                theme.SetElement(topic.Values[i]);
                Themes.Add(theme);
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