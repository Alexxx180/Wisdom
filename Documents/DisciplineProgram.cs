using System.Collections.Generic;
using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections.Nodes;

namespace ControlMaterials.Documents
{
    public class DisciplineProgram : DisciplineBase, IDocument
    {
        public Document DocumentType => Document.DISIPLINE_PROGRAM;

        public DisciplineProgram() : base()
        {
            MaxHours = "-";
            StudyLevels = new List<Metadata>();
            MetaData = new List<Metadata>();
            Sources = new List<HybridNode<IndexedLabel>>();
            Plan = new List<Topic>();
        }

        // Speciality
        public string ProfessionName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }

        public List<Metadata> StudyLevels { get; set; }
    }
}