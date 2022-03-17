using System.Collections.Generic;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Model.Documents
{
    public class DisciplineProgram : DisciplineBase, IDocument
    {
        public Document DocumentType => Document.DISIPLINE_PROGRAM;

        public DisciplineProgram()
        {
            ProfessionName = "";
            GeneralCompetetions = new List<Competetion>();
            ProfessionalCompetetions = new List<List<Competetion>>();

            SetHours();
            StudyLevels = new List<Task>();
            MetaData = new List<Task>();
            Sources = new List<Source>();
            Plan = new List<Topic>();
        }

        private void SetHours()
        {
            MaxHours = "-";
            SelfHours = new List<Hour>();
            ClassHours = new List<Hour>();
        }

        // Speciality
        public string ProfessionName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }
        public List<Hour> SelfHours { get; set; }
        public List<Hour> ClassHours { get; set; }

        public List<Task> StudyLevels { get; set; }
    }
}