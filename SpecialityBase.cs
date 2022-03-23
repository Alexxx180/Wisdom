using System.Collections.Generic;
using ControlMaterials.Tables;

namespace ControlMaterials
{
    public class SpecialityBase
    {
        public SpecialityBase()
        {
            Name = "";
            GeneralCompetetions = new
                List<Competetion>();
            ProfessionalCompetetions = new
                List<List<Competetion>>();
        }

        public SpecialityBase(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Competetion>
            GeneralCompetetions { get; set; }
        public List<List<Competetion>>
            ProfessionalCompetetions { get; set; }
    }
}