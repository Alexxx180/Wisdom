using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work : HoursNode<IndexedHour>, ISum, INumerable
    {
        public Work() : base() { }

        public Work(string name) : this()
        {
            Name = name;
        }

        public void SetHours(ushort count)
        {
            Hours = count;
        }
    }
}