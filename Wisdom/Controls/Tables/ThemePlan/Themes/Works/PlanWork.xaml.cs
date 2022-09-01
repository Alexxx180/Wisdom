using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : UserControl, INotifyPropertyChanged, IRawData<Work>, IExtendableItems
    {
        #region IRawData Members
        public Work Raw()
        {
            return null;//new Work(WorkType, "Tasks");
        }

        public void SetElement(Work work)
        {
            //WorkType = work.Type;

            ushort i;
            for (i = 0; i < work.Tasks.Count; i++)
            {
                PlanTask task = new PlanTask
                {
                    No = (i + 1).ToUInt(),
                    Work = this
                };
                task.SetElement(work.Tasks[i]);
                Tasks.Add(task);
            }
            TaskAdditor.Index((i + 1).ToUInt());
        }
        #endregion

        #region AutoIndexing Logic
        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < Tasks.Count; i++)
            {
                Tasks[i].Index((i + 1).ToUInt());
            }
            TaskAdditor.Index((i + 1).ToUInt());
        }
        #endregion

        #region PlanWork Members
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

        private ObservableCollection<PlanTask> _tasks;
        public ObservableCollection<PlanTask> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Tasks));
            Theme.RefreshHours();
        }
        #endregion

        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

        public PlanWork()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<PlanTask>();
            Extended = true;
        }

        private void DropRecord(object sender, RoutedEventArgs e)
        {
            Theme.DropWork(this);
        }

        #region TasksGroup Members
        public void DropTask(PlanTask task)
        {
            _ = Tasks.Remove(task);
            OnPropertyChanged(nameof(Tasks));
        }

        public void AddRecord(PlanTask task)
        {
            Tasks.Add(task);
            OnPropertyChanged(nameof(Tasks));
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