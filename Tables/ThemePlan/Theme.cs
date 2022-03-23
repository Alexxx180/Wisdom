using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("UnitTests")]
namespace ControlMaterials.Tables.ThemePlan
{
    internal class Theme
    {
        internal string Name { get; set; }
        internal string Hours { get; set; }
        internal string Competetions { get; set; }
        internal string Level { get; set; }
        internal List<Work> Works { get; set; }
    }
}