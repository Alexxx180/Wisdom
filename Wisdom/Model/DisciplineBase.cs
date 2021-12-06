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

        public DisciplineBase(string name,
            List<HoursList<LevelsList<HashList<String2>>>> plan,
            List<HashList<string>> sources,
            Dictionary<string, string> metaData)
        {
            Name = name;
            Plan = plan;
            Sources = sources;
            MetaData = metaData;
        }
        public string Name { get; set; }
        public Dictionary<string, ushort> TotalHours { get; set; }
        public List<HoursList<LevelsList<HashList<String2>>>> Plan { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public List<HashList<string>> Sources { get; set; }
    }
}
