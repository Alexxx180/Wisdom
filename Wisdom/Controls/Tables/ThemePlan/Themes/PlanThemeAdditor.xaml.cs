using ControlMaterials.Tables.ThemePlan;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Special component to add new theme to topic
    /// </summary>
    public partial class PlanThemeAdditor : NewItem<Theme>
    {
        public PlanThemeAdditor()
        {
            InitializeComponent();
            Data = new Theme();
        }
    }
}
