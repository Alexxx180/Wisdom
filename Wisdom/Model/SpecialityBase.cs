using System.Collections.Generic;

namespace Wisdom.Model
{
    public class SpecialityBase
    {
        public SpecialityBase()
        {
            GeneralCompetetions = new List<HoursList<String2>>();
            ProfessionalCompetetions = new List<List<HoursList<String2>>>();
        }

        public SpecialityBase(string name) : this()
        {
            Name = name;
        }

        public SpecialityBase(string name,
            List<HoursList<String2>> generalCompetetions,
            List<List<HoursList<String2>>> professionalCompetetions)
        {
            Name = name;
            GeneralCompetetions = generalCompetetions;
            ProfessionalCompetetions = professionalCompetetions;
        }
        public string Name { get; set; }
        public List<HoursList<String2>> GeneralCompetetions { get; set; }
        public List<List<HoursList<String2>>> ProfessionalCompetetions { get; set; }
    }
}
