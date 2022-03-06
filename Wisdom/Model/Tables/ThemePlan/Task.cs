using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Experiments")]
namespace Wisdom.Model.Tables.ThemePlan
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