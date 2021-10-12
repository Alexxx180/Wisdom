using System.Collections.Generic;

namespace Wisdom.Model
{
    public class SpecialityBase
    {
        public SpecialityBase(string name,
            List<HoursList<String2>> generalCompetetions,
            List<HoursList<String2>> professionalCompetetions)
        {
            Name = name;
            GeneralCompetetions = generalCompetetions;
            ProfessionalCompetetions = professionalCompetetions;
        }
        public string Name { get; set; }
        public List<HoursList<String2>> GeneralCompetetions { get; set; }
        public List<HoursList<String2>> ProfessionalCompetetions { get; set; }
    }
}
