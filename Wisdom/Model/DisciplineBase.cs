using System.Collections.Generic;

namespace Wisdom.Model
{
    public class DisciplineBase
    {
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
        public List<HoursList<LevelsList<HashList<String2>>>> Plan { get; set; }
        public string Relation { get; set; }
        public string PracticePrepare { get; set; }
        public string DistanceEducation { get; set; }
        public List<HashList<string>> Sources { get; set; }
    }
}
