using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using Wisdom.Customing;
using static Wisdom.Customing.Converters;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : UserControl, INotifyPropertyChanged, IRawData<HashList<Pair<string, string>>>
    {
        public HashList<Pair<string, string>> Raw()
        {
            return new HashList<Pair<string, string>>(WorkType, Tasks.GetRaw());
        }

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
        #endregion

        public PlanWork()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<PlanTask>();
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

        public void SetElement(HashList<Pair<string, string>> work)
        {
            WorkType = work.Name;

            ushort i;
            for (i = 0; i < work.Values.Count; i++)
            {
                PlanTask task = new PlanTask
                {
                    No = (i + 1).ToUInt(),
                    Work = this
                };
                task.SetElement(work.Values[i]);
                Tasks.Add(task);
            }
            TaskAdditor.Index((i + 1).ToUInt());
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