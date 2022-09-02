using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of theme's work
    /// </summary>
    public partial class PlanTask : UserControl, INotifyPropertyChanged, IAutoIndexing, IWrapFields //IRawData<Task>,
    {
        //#region IRawData Members
        //public Task Raw()
        //{
        //    return new Task(TaskName, TaskHours);
        //}

        //public void SetElement(Task task)
        //{
        //    TaskName = task.Name;
        //    //TaskHours = task.Hours;
        //}
        //#endregion

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

        #region IWrapFields Members
        private bool _isWrap;
        public bool IsWrap
        {
            get => _isWrap;
            set
            {
                _isWrap = value;
                OnPropertyChanged();
            }
        }

        public void WrapFields()
        {
            IsWrap = !IsWrap;
        }
        #endregion

        public PlanTask()
        {
            InitializeComponent();
            Index(1);
            IsWrap = false;
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Work.DropTask(this);
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