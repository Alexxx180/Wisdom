using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using Wisdom.Customing;
using static Wisdom.Customing.Converters;

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

        #region PlanWork Members
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
            }
        }

        private ObservableCollection<IRawData<Pair<string, string>>> _tasks;
        public ObservableCollection<IRawData<Pair<string, string>>> Tasks
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
            Tasks = new ObservableCollection<IRawData<Pair<string, string>>>();
        }

        private void DropRecord(object sender, RoutedEventArgs e)
        {
            
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