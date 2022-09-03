using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work : NameNode<IndexedHour>
    {
        public Work() : base() { }

        public Work(string name) : this()
        {
            Name = name;
        }
    }
}