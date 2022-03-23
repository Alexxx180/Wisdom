using System.Collections.Generic;
using ControlMaterials.Tables;
using ControlMaterials.Tables.ThemePlan;

namespace ControlMaterials.Documents
{
    public class DisciplineProgram : DisciplineBase, IDocument
    {
        public Document DocumentType => Document.DISIPLINE_PROGRAM;

        public DisciplineProgram() : base()
        {
            MaxHours = "-";
            StudyLevels = new List<Task>();
            MetaData = new List<Task>();
            Sources = new List<Source>();
            Plan = new List<Topic>();
        }

        // Speciality
        public string ProfessionName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }

        public List<Task> StudyLevels { get; set; }
    }
}