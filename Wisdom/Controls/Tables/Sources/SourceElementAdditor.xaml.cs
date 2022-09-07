using ControlMaterials.Total;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.Sources
{
    /// <summary>
    /// Special component to add new source
    /// </summary>
    public partial class SourceElementAdditor : NewItem<IndexedLabel>
    {
        public SourceElementAdditor()
        {
            InitializeComponent();
            Data = new IndexedLabel();
        }
    }
}
