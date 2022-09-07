using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Templates;
using ControlMaterials.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Special component to add new work to theme
    /// </summary>
    public partial class PlanWorkAdditor : NewItem<Work>, INotifyPropertyChanged
    {
        public PlanWorkAdditor()
        {
            InitializeComponent();
            Data = new Work();
        }
    }
}
