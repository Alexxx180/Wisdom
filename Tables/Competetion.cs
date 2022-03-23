using System.Collections.Generic;
using ControlMaterials.Tables.ThemePlan;

namespace ControlMaterials.Tables
{
    public class Competetion
    {
        public string PrefixNo { get; set; }
        public string Name { get; set; }

        public List<Task> Abilities { get; set; }
    }
}