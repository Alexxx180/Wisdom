using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Customing;
using Wisdom.Controls.Tables.Competetions;
using ControlMaterials.Tables;

namespace Wisdom.Controls.Tables.Levels
{
    /// <summary>
    /// Adds new education level when used
    /// </summary>
    public partial class StageAdditor : NewItem<Level>, INotifyPropertyChanged
    {
        public StageAdditor()
        {
            InitializeComponent();
            Data = new Level();
        }
    }
}
