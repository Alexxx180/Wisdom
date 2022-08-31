using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work
    {
        public Work()
        {

        }

        public Work(string type, ObservableCollection<Task> tasks)
        {
            Type = type;
            Tasks = tasks;
        }

        public Work(string type, Task task)
        {
            Type = type;
            Tasks = new ObservableCollection<Task>
            {
                task
            };
        }

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Task> Tasks { get; }
        
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
