using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Topic : Work, ICloneable<Topic>
    {
        public Topic() { }

        public Topic(ushort no, string name, ushort hours) : base(name, hours)
        {
            No = no;
        }

        public ushort No { get; set; }

        public override Topic Copy()
        {
            return new Topic(No, Name, Hours);
        }
    }
}
