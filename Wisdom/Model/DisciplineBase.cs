using System.Collections.Generic;

namespace Wisdom.Model
{
    public class DisciplineBase
    {
        public DisciplineBase()
        {
            MetaData = new Dictionary<string, string>();
            TotalHours = new Dictionary<string, ushort>();
            Sources = new List<HashList<string>>();
            Plan = new List<HoursList<LevelsList<HashList<String2>>>>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public DisciplineBase(string name, HeaderHours hours,
            List<HoursList<LevelsList<HashList<String2>>>> plan,
            string relation, string prepare, string distanceEdu,
            List<HashList<string>> sources)
        {
            Name = name;
            Hours = hours;
            Plan = plan;
            Relation = relation;
            PracticePrepare = prepare;
            DistanceEducation = distanceEdu;
            Sources = sources;
        }
        public string Name { get; set; }
        public HeaderHours Hours { get; set; }
        public Dictionary<string, ushort> TotalHours { get; set; }
        public List<HoursList<LevelsList<HashList<String2>>>> Plan { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public string Relation { get; set; }
        public string PracticePrepare { get; set; }
        public string DistanceEducation { get; set; }
        public List<HashList<string>> Sources { get; set; }
    }
}
