using System.Collections.Generic;

namespace Wisdom.Model.Tables.ThemePlan
{
    public class Topic
    {
        public string Name { get; set; }
        public string Hours { get; set; }
        public List<Theme> Themes { get; set; }
    }
}