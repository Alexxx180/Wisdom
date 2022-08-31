using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work : NameLabel
    {
        public Work() { }

        public Work(string name, ObservableCollection<Task> tasks)
        {
            Name = name;
            Tasks = tasks;
        }

        public Work(string name, Task task)
        {
            Name = name;
            Tasks = new ObservableCollection<Task>
            {
                task
            };
        }
        
        public ObservableCollection<Task> Tasks { get; }
    }
}
