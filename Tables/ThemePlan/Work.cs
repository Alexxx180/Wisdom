using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work : NameLabel, ICloneable<Work>
    {
        public Work() { }

        public Work(string name, ushort hours) : base(name)
        {
            Hours = hours;
        }

        public ushort Hours { get; set; }
        
        public override Work Copy()
        {
            return new Work(Name, Hours);
        }
    }
}