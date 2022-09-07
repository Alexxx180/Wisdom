﻿using ControlMaterials.Tables;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Special component to add new task to work
    /// </summary>
    public partial class PlanTaskAdditor : NewItem<IndexedHour>
    {
        public PlanTaskAdditor()
        {
            InitializeComponent();
            Data = new IndexedHour();
        }
    }
}
