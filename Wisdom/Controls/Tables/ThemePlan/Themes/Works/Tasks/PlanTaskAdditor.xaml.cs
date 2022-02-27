using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Special component to add new task to work
    /// </summary>
    public partial class PlanTaskAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        public static readonly DependencyProperty
            WorkProperty = DependencyProperty.Register(nameof(Work),
                typeof(PlanWork), typeof(PlanTaskAdditor));

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TaskHeader));
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region PlanTaskAdditor Members
        public PlanWork Work
        {
            get => GetValue(WorkProperty) as PlanWork;
            set => SetValue(WorkProperty, value);
        }

        public string TaskHeader => $"{No}.";

        public string _taskName;
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }

        public string _taskHours;
        public string TaskHours
        {
            get => _taskHours;
            set
            {
                _taskHours = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public PlanTaskAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            PlanTask task = new PlanTask
            {
                No = No,
                TaskName = TaskName,
                TaskHours = TaskHours,
                Work = Work
            };

            Work.AddRecord(task);
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