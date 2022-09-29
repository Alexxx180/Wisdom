using System.Collections.Generic;
using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections.Nodes;

namespace ControlMaterials
{
    public class DisciplineBase : SpecialityBase
    {
        public DisciplineBase() : base()
        {
            SelfWorks = new List<Work>();
            ClassWorks = new List<Work>();
            MetaData = new List<Metadata>();
            Sources = new List<HybridNode<IndexedLabel>>();
            Plan = new List<Topic>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public List<Work> SelfWorks { get; set; }
        public List<Work> ClassWorks { get; set; }
        public List<Metadata> MetaData { get; set; }
        public List<Topic> Plan { get; set; }
        public List<HybridNode<IndexedLabel>> Sources { get; set; }
    }
}