using System.Collections.Generic;

namespace Wisdom.Model
{
    public class SpecialityBase
    {
        public SpecialityBase()
        {
            GeneralCompetetions = new List<HoursList<Pair<string, string>>>();
            ProfessionalCompetetions = new List<List<HoursList<Pair<string, string>>>>();
        }

        public SpecialityBase(string name) : this()
        {
            Name = name;
        }

        public SpecialityBase(string name,
            List<HoursList<Pair<string, string>>> generalCompetetions,
            List<List<HoursList<Pair<string, string>>>> professionalCompetetions)
        {
            Name = name;
            GeneralCompetetions = generalCompetetions;
            ProfessionalCompetetions = professionalCompetetions;
        }
        public string Name { get; set; }
        public List<HoursList<Pair<string, string>>> GeneralCompetetions { get; set; }
        public List<List<HoursList<Pair<string, string>>>> ProfessionalCompetetions { get; set; }
    }
}
