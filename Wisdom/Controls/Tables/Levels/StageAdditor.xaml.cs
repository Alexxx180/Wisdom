using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.Levels
{
    /// <summary>
    /// Adds new education level when used
    /// </summary>
    public partial class StageAdditor : NewItem<Level>
    {
        public StageAdditor()
        {
            InitializeComponent();
            Data = new Level();
        }
    }
}
