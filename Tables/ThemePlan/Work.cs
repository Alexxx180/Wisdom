using ControlMaterials.Tables.Hours;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Numeration;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work : HoursNode<IndexedHour>, ISum, INumerable, ICloneable<Work>
    {
        public Work() : base(new IndexedHour()) { }

        public Work(OptionableCollection<IndexedHour> items) : base(items) { }

        public Work(string name) : this()
        {
            Name = name;
        }

        public void SetHours(ushort count)
        {
            Hours = count;
        }

        public override Work Copy()
        {
            return new Work(_items)
            {
                No = No,
                Name = Name,
                Hours = Hours
            };
        }
    }
}