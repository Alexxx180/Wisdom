using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ControlMaterials.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with single task of theme plan
    /// </summary>
    public partial class PlanWorkTask : UserControl, INotifyPropertyChanged, IRawData<Work>
    {
        #region IRawData Members
        public Work Raw()
        {
            return new Work(WorkType, new Task(TaskName, TaskHours));
        }

        public void SetElement(Work workTask)
        {
            WorkType = workTask.Type;
            if (workTask.Tasks is null ||
                workTask.Tasks.Count < 1)
                return;

            Task task = workTask.Tasks[0];
            TaskName = task.Name;
            TaskHours = task.Hours;
        }
        #endregion

        #region PlanWorkTask Members
        private PlanTheme _theme;
        public PlanTheme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                OnPropertyChanged();
            }
        }

        private string _workType;
        public string WorkType
        {
            get => _workType;
            set
            {
                _workType = value;
                OnPropertyChanged();
            }
        }

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
                Theme?.RefreshHours();
            }
        }
        #endregion

        public PlanWorkTask()
        {
            InitializeComponent();
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Theme.DropWork(this);
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