using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes;
using Wisdom.Customing;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Topic of theme plan
    /// </summary>
    public partial class PlanTopic : UserControl, INotifyPropertyChanged, IRecordsIndexing, IRawData<Topic>
    {
        #region IRawData Members
        public Topic Raw()
        {
            return new Topic
            {
                Themes = Themes.GetRaw()
            };
        }

        public void SetElement(Topic topic)
        {
            TopicName = topic.Name;
            TopicHours = topic.Hours;

            ushort i;
            for (i = 0; i < topic.Themes.Count; i++)
            {
                PlanTheme theme = new PlanTheme
                {
                    No = (i + 1).ToUInt(),
                    Topic = this
                };
                theme.SetElement(topic.Themes[i]);
                Themes.Add(theme);
            }
            ThemeAdditor.Index((i + 1).ToUInt());
            RefreshHours();
        }
        #endregion

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
        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < Themes.Count; i++)
            {
                Themes[i].Index((i + 1).ToUInt());
            }
            ThemeAdditor.Index((i + 1).ToUInt());
        }
        #endregion

        #region PlanTopic Members
        public RecordsPanel _options;
        public RecordsPanel Options
        {
            get => _options;
            set
            {
                _options = value;
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
                Options?.RegisterEdit();
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

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Themes));
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
            Options.DropRecord(this);
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