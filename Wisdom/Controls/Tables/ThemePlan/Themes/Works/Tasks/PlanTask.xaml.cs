using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of work
    /// </summary>
    public partial class PlanTask : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<Task>
    {
        public Task Raw()
        {
            return new Task(TaskName, TaskHours);
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
                OnPropertyChanged(nameof(TaskHeader));
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region PlanTask Members
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

        public string TaskHeader => $"{No}.";

        private string _taskName;
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }

        private string _taskHours;
        public string TaskHours
        {
            get => _taskHours;
            set
            {
                _taskHours = value;
                OnPropertyChanged();
                Work?.RefreshHours();
            }
        }
        #endregion

        public PlanTask()
        {
            InitializeComponent();
            Index(1);
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Work.DropTask(this);
        }

        public void SetElement(Task task)
        {
            TaskName = task.Name;
            TaskHours = task.Hours;
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