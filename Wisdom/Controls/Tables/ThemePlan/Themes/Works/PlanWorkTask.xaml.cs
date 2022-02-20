using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with single task of theme plan
    /// </summary>
    public partial class PlanWorkTask : UserControl, INotifyPropertyChanged, IRawData<HashList<Pair<string, string>>>
    {
        public HashList<Pair<string, string>> Raw()
        {
            return new HashList<Pair<string, string>>(
               WorkType, new List<Pair<string, string>> {
                   new Pair<string, string>(TaskName, TaskHours)
               });
        }

        #region PlanWorkTask Members
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

        public PlanWorkTask()
        {
            InitializeComponent();
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetElement(HashList<Pair<string, string>> workTask)
        {
            WorkType = workTask.Name;
            if (workTask.Values.Count < 1)
                return;
            TaskName = workTask.Values[0].Name;
            TaskHours = workTask.Values[0].Value;
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