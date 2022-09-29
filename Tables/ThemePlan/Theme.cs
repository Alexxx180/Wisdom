using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Theme : Topic, ICloneable<Theme>
    {
        public Theme() { }

        public Theme(ushort no, string name, ushort hours, ushort level) :
            base(no, name, hours)
        {
            Level = level;
        }

        public ushort Level { get; set; }

        public override Theme Copy()
        {
            return new Theme(No, Name, Hours, Level);
        }
    }
}
