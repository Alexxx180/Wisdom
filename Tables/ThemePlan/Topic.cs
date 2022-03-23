using System.Collections.Generic;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Topic
    {
        public string Name { get; set; }
        public string Hours { get; set; }
        internal List<Theme> Themes { get; set; }
    }
}