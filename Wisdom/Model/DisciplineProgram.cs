using System.Collections.Generic;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Model
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
            Sources = new List<Pair<string, List<string>>>();
            Plan = new List<Topic>();
        }

        private void SetHours()
        {
            MaxHours = "-";
            EduHours = "-";
            SelfHours = "-";
            Hours = new List<Pair<string, ushort>>();
        }

        // Speciality
        public string ProfessionName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }
        public List<Pair<string, ushort>> Hours { get; set; }

        public List<Task> StudyLevels { get; set; }
    }
}