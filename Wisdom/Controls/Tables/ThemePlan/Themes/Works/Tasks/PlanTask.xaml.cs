using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Tables;
using System.Windows.Input;
using Wisdom.Controls.Templates;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of theme's work
    /// </summary>
    public partial class PlanTask : OldItem<IndexedHour>, INotifyPropertyChanged, IWrapFields
    {
        #region IWrapFields Members
        private bool _isWrap;
        public bool IsWrap
        {
            get => _isWrap;
            set
            {
                _isWrap = value;
                OnPropertyChanged();
            }
        }

        public void WrapFields()
        {
            IsWrap = !IsWrap;
        }
        #endregion

        public PlanTask()
        {
            InitializeComponent();
            IsWrap = false;
        }
    }
}
