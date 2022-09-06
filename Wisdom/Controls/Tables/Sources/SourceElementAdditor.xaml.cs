using ControlMaterials.Tables;
using ControlMaterials.Total;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.Sources.SourceTypes;
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
