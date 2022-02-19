using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Special component to add new task to work
    /// </summary>
    public partial class PlanTaskAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        private PlanWork _work;
        public PlanWork Work
        {
            get => _work;
            set
            {
                _work = value;
                OnPropertyChanged();
            }
        }

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

        #region PlanTaskAdditor Members
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

        public string _taskHours = "";
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
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            PlanTask task = new PlanTask
            {
                TaskName = TaskName,
                TaskHours = TaskHours
            };
            // Work.AddRecord(task);
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