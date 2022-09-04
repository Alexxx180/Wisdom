using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.MetaData
{
    /// <summary>
    /// Special component to add new metadata
    /// </summary>
    public partial class MetaElementAdditor : NewItem<Task>
    {
        public MetaElementAdditor()
        {
            InitializeComponent();
            Data = new Task();
        }
    }
}