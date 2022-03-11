using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Special component to add new topic to theme plan
    /// </summary>
    public partial class PlanTopicAdditor : UserControl, IRecordsIndexing, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            OptionsProperty = DependencyProperty.Register(nameof(Options),
                typeof(RecordsPanel), typeof(PlanTopicAdditor));

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

        #region TopicAdditor Members
        public RecordsPanel Options
        {
            get => GetValue(OptionsProperty) as RecordsPanel;
            set => SetValue(OptionsProperty, value);
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
        #endregion

        public PlanTopicAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            PlanTopic topic = new PlanTopic
            {
                No = No,
                TopicName = TopicName,
                TopicHours = TopicHours,
                Options = Options
            };

            Options.AddRecord(topic);
            Index(No);
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