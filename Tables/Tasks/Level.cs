using ControlMaterials.Total;

namespace ControlMaterials.Tables.Tasks
{
    public class Level : Metadata, ICloneable<Level>
    {
        public Level() { }

        public Level(ushort no, string name, string data) :
            base(name, data)
        {
            No = no;
        }

        public ushort No { get; set; }

        public override Level Copy()
        {
            return new Level(No, Name, Data);
        }
    }
}
