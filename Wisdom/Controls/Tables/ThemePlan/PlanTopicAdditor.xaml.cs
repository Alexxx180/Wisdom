using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Special component to add new topic to theme plan
    /// </summary>
    public partial class PlanTopicAdditor : UserControl, IAutoIndexing, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ThemePlanProperty = DependencyProperty.Register(nameof(ThemePlan),
                typeof(ObservableCollection<PlanTopic>), typeof(PlanTopicAdditor));

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
        public ObservableCollection<PlanTopic> ThemePlan
        {
            get => GetValue(ThemePlanProperty) as ObservableCollection<PlanTopic>;
            set => SetValue(ThemePlanProperty, value);
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
                ThemePlan = ThemePlan
            };

            ThemePlan.Add(topic);
            Index(No + 1);
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