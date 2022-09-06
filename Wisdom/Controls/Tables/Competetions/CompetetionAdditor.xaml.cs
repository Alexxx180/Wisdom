using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using ControlMaterials.Tables;
using ControlMaterials.Tables.ThemePlan;
using static Wisdom.Customing.Converters;
using CompetetionModel = ControlMaterials.Tables.Competetion;

namespace Wisdom.Controls.Tables.Competetions
{
    /// <summary>
    /// General competetion related to speciality-discipline
    /// </summary>
    public partial class Competetion : OldItem<CompetetionModel>
    {
        public Competetion()
        {
            InitializeComponent();
            Extended = true;
            IsWrap = false;
        }
    }
}
