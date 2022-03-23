using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ControlMaterials.Tables.ThemePlan
{
    internal class Work
    {
        public Work()
        {

        }

        public Work(string type, List<Task> tasks)
        {
            Type = type;
            Tasks = tasks;
        }

        public Work(string type, Task task)
        {
            Type = type;
            Tasks = new List<Task>
            {
                task
            };
        }

        internal string Type { get; set; }
        internal List<Task> Tasks { get; set; }
    }
}