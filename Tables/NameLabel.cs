using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class NameLabel : ICloneable<NameLabel>
    {
        public NameLabel() { }

        public NameLabel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual NameLabel Copy()
        {
            return new NameLabel(Name);
        }
    }
}
