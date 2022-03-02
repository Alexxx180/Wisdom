using System.Collections.Generic;

namespace Wisdom.Model
{
    public class SpecialityBase
    {
        public SpecialityBase()
        {
            GeneralCompetetions = new List<Competetion>();
            ProfessionalCompetetions = new List<List<Competetion>>();
        }

        public SpecialityBase(string name) : this()
        {
            Name = name;
        }

        public SpecialityBase(string name,
            List<Competetion> generalCompetetions,
            List<List<Competetion>> professionalCompetetions)
        {
            Name = name;
            GeneralCompetetions = generalCompetetions;
            ProfessionalCompetetions = professionalCompetetions;
        }

        public string Name { get; set; }
        public List<Competetion> GeneralCompetetions { get; set; }
        public List<List<Competetion>> ProfessionalCompetetions { get; set; }
    }
}
