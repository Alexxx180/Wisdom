using System.Collections.Generic;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Model
{
    public class DisciplineBase : SpecialityBase
    {
        public DisciplineBase()
        {
            TotalHours = new List<Hour>();
            MetaData = new List<Task>();
            Sources = new List<Source>();
            Plan = new List<Topic>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public DisciplineBase(
            string name,
            List<Topic> plan,
            List<Source> sources,
            List<Task> metaData
            )
        {
            Name = name;
            Plan = plan;
            Sources = sources;
            MetaData = metaData;
        }

        public List<Hour> TotalHours { get; set; }
        public List<Topic> Plan { get; set; }
        public List<Task> MetaData { get; set; }
        public List<Source> Sources { get; set; }
    }
}