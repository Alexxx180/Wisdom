using System.Collections.Generic;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Model
{
    public class DisciplineBase
    {
        public DisciplineBase()
        {
            TotalHours = new List<Pair<string, ushort>>();
            MetaData = new List<Task>();
            Sources = new List<Pair<string, List<string>>>();
            GeneralCompetetions = new List<Competetion>();
            ProfessionalCompetetions = new List<List<Competetion>>();
            Plan = new List<Topic>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public DisciplineBase(string name,
            List<Topic> plan,
            List<Pair<string, List<string>>> sources,
            List<Task> metaData)
        {
            Name = name;
            Plan = plan;
            Sources = sources;
            MetaData = metaData;
        }

        public string Name { get; set; }
        public List<Pair<string, ushort>> TotalHours { get; set; }
        public List<Topic> Plan { get; set; }
        public List<Task> MetaData { get; set; }
        public List<Pair<string, List<string>>> Sources { get; set; }
        public List<Competetion> GeneralCompetetions { get; set; }
        public List<List<Competetion>> ProfessionalCompetetions { get; set; }
    }
}