using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ControlMaterials.Tables.ThemePlan;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Special component to add new task to work
    /// </summary>
    public partial class PlanTaskAdditor : NewItem<Task>, INotifyPropertyChanged, IAutoIndexing
    {
        public PlanTaskAdditor()
        {
            InitializeComponent();
            Data = new Task();
        }
    }
}
