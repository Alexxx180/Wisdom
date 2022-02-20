using System.Collections.Generic;

namespace Wisdom.Model
{
    public class DisciplineProgram
    {
        public DisciplineProgram()
        {
            ProfessionName = "";
            DisciplineName = "";
            SetHours();
            StudyLevels = new List<Pair<string, string>>();
            MetaData = new List<Pair<string, string>>();
            Sources = new List<Pair<string, List<string>>>();
            Plan = new List<HoursList<LevelsList<HashList<Pair<string, string>>>>>();
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
        public List<HoursList<Pair<string, string>>> GeneralCompetetions { get; set; }
        public List<List<HoursList<Pair<string, string>>>> ProfessionalCompetetions { get; set; }

        // Discipline
        public string DisciplineName { get; set; }

        // Total hours count (user preset)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }
        public List<Pair<string, ushort>> Hours { get; set; }

        // Educational program other useful information
        public List<Pair<string, string>> MetaData { get; set; }
        public List<Pair<string, List<string>>> Sources { get; set; }

        // Theme plan: Topics -> Themes -> Works -> Tasks
        public List<HoursList<LevelsList<HashList<Pair<string, string>>>>> Plan { get; set; }
        public List<Pair<string, string>> StudyLevels { get; set; }
    }
}