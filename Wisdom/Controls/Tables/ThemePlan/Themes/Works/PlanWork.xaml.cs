using System.Collections.Generic;
using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks;
using System.Windows;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : UserControl, INotifyPropertyChanged, IRawData<HashList<Pair<string, string>>>
    {
        public HashList<Pair<string, string>> Raw()
        {
            return new HashList<Pair<string, string>>(
               WorkType, new List<Pair<string, string>> {
                   new Pair<string, string>(TaskName, TaskHours)
               });
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
        #endregion

        public PlanWork()
        {
            InitializeComponent();
        }

        private List<Pair<string, string>> Tasks()
        {
            List<Pair<string, string>> tasks = new List<Pair<string, string>>();
            for (byte i = 0; i < TasksPanel.Children.Count - 1; i++)
            {
                PlanTask task = TasksPanel.Children[i] as PlanTask;
                tasks.Add(task.Raw());
            }
            return tasks;
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