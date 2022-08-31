using System.Runtime.CompilerServices;

namespace ControlMaterials.Tables.ThemePlan
{
    public struct Task
    {
        public Task(string name, string hours)
        {
            Name = name;
            Hours = hours;
        }

        public string Name { get; set; }
        public string Hours { get; set; }
    }
}