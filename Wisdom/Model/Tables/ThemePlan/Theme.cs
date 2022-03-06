using System.Collections.Generic;

namespace Wisdom.Model.Tables.ThemePlan
{
    public class Theme
    {
        public string Name { get; set; }
        public string Hours { get; set; }
        public string Competetions { get; set; }
        public string Level { get; set; }
        public List<Work> Works { get; set; }
    }
}