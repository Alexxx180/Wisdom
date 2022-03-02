using System.Collections.Generic;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Model
{
    public class Competetion
    {
        public string PrefixNo { get; set; }
        public string Name { get; set; }
        public List<Task> Abilities { get; set; }
    }
}