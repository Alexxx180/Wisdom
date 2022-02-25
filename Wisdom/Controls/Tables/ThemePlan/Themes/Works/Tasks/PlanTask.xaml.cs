using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of work
    /// </summary>
    public partial class PlanTask : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<Pair<string, string>>
    {
        public Pair<string, string> Raw()
        {
            return new Pair<string, string>(TaskName, TaskHours);
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

        #region PlanTask Members
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
            }
        }
        #endregion

        public PlanTask()
        {
            InitializeComponent();
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            // Drop from work logic here...
        }

        public void SetElement(Pair<string, string> task)
        {
            TaskName = task.Name;
            TaskHours = task.Value;
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