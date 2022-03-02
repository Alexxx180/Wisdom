using System.Collections.Generic;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Model
{
    public class DisciplineProgram
    {
        public DisciplineProgram()
        {
            ProfessionName = "";
            DisciplineName = "";
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

        // Competetions: Knowledge, Skills, Experience (only professional)
        public List<Competetion> GeneralCompetetions { get; set; }
        public List<List<Competetion>> ProfessionalCompetetions { get; set; }

        // Discipline
        public string DisciplineName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }
        public List<Pair<string, ushort>> Hours { get; set; }

        // Educational program other useful information
        public List<Task> MetaData { get; set; }
        public List<Pair<string, List<string>>> Sources { get; set; }

        // Theme plan: Topics -> Themes -> Works -> Tasks
        public List<Topic> Plan { get; set; }
        public List<Task> StudyLevels { get; set; }
    }
}