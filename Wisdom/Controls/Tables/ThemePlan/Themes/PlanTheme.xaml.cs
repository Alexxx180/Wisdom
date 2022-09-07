using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;
using Wisdom.Controls.Templates;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Theme of theme plan's topic
    /// </summary>
    public partial class PlanTheme : OldItem<Theme>, IExtendableItems, IWrapFields
    {
        #region Dependency Properties              
        public static readonly DependencyProperty
            RemoveWorkProperty = DependencyProperty.Register(nameof(RemoveWork),
                typeof(ICommand), typeof(PlanTheme));
        
        public ICommand RemoveWork
        {
            get => GetValue(RemoveWorkProperty) as ICommand;
            set => SetValue(RemoveWorkProperty, value);
        }
        #endregion
        
        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

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

        public PlanTheme()
        {
            InitializeComponent();
            Extended = true;
            IsWrap = false;
        }
    }
}
