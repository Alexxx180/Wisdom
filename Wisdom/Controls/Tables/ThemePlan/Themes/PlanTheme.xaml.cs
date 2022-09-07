using System.Windows;
using Wisdom.Controls.Templates;
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

        public static readonly DependencyProperty
            AddWorkProperty = DependencyProperty.Register(nameof(AddWork),
                typeof(ICommand), typeof(PlanTheme));

        public ICommand AddWork
        {
            get => GetValue(AddWorkProperty) as ICommand;
            set => SetValue(AddWorkProperty, value);
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
