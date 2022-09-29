using ControlMaterials.Total;

namespace ControlMaterials.Tables.Tasks
{
    public class Competetion : NameLabel, ICloneable<Competetion>
    {
        public Competetion() { }

        public Competetion(string prefix, ushort no, string name) : base(name)
        {
            Prefix = prefix;
            No = no;
        }

        public ushort No { get; set; }
        public string Prefix { get; set; }

        public override Competetion Copy()
        {
            return new Competetion(Prefix, No, Name);
        }
    }
}
