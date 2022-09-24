using System.Collections.Generic;
using ControlMaterials.Tables.Hours;
using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.ThemePlan;

namespace ControlMaterials
{
    public class DisciplineBase : SpecialityBase
    {
        public DisciplineBase() : base()
        {
            SelfHours = new List<Hour>();
            ClassHours = new List<Hour>();
            MetaData = new List<Task>();
            Sources = new List<Source>();
            Plan = new List<HoursNode<Theme>>();
        }

        public DisciplineBase(string name) : this()
        {
            Name = name;
        }

        public List<Hour> SelfHours { get; set; }
        public List<Hour> ClassHours { get; set; }
        public List<Task> MetaData { get; set; }
        public List<HoursNode<Theme>> Plan { get; set; }
        public List<Source> Sources { get; set; }
    }
}