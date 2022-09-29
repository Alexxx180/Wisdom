using ControlMaterials.Total;

namespace ControlMaterials.Tables.Tasks
{
    public class Metadata : NameLabel, ICloneable<Metadata>
    {
        public Metadata() { }

        public Metadata(string name, string data) : base(name)
        {
            Data = data;
        }

        public string Data { get; set; }

        public override Metadata Copy()
        {
            return new Metadata(Name, Data);
        }
    }
}
