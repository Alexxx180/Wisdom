using System.Collections.Generic;

namespace Wisdom.Model
{
    public class DisciplineBase
    {
        public DisciplineBase()
        {
            TotalHours = new List<Pair<string, ushort>>();
            MetaData = new List<Pair<string, string>>();
            Sources = new List<Pair<string, List<string>>>();
            GeneralCompetetions = new List<HoursList<Pair<string, string>>>();
            ProfessionalCompetetions = new List<List<HoursList<Pair<string, string>>>>();
            Plan = new List<HoursList<LevelsList<HashList<Pair<string, string>>>>>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public DisciplineBase(string name,
            List<HoursList<LevelsList<HashList<Pair<string, string>>>>> plan,
            List<Pair<string, List<string>>> sources,
            List<Pair<string, string>> metaData)
        {
            Name = name;
            Plan = plan;
            Sources = sources;
            MetaData = metaData;
        }

        public string Name { get; set; }
        public List<Pair<string, ushort>> TotalHours { get; set; }
        public List<HoursList<LevelsList<HashList<Pair<string, string>>>>> Plan { get; set; }
        public List<Pair<string, string>> MetaData { get; set; }
        public List<Pair<string, List<string>>> Sources { get; set; }
        public List<HoursList<Pair<string, string>>> GeneralCompetetions { get; set; }
        public List<List<HoursList<Pair<string, string>>>> ProfessionalCompetetions { get; set; }
    }
}