using System.Collections.Generic;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Model.Documents
{
    public class DisciplineProgram : DisciplineBase
    {
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
            EduHours = "-";
            SelfHours = "-";
            Hours = new List<Hour>();
        }

        // Speciality
        public string ProfessionName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }
        public List<Hour> Hours { get; set; }

        public List<Task> StudyLevels { get; set; }
    }
}