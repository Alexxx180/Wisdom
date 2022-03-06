using System.Collections.Generic;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Model.Tables
{
    public class Competetion
    {
        public string PrefixNo { get; set; }
        public string Name { get; set; }

        public List<Task> Abilities { get; set; }
    }
}