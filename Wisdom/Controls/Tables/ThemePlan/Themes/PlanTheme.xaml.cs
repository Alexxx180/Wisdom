using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Theme of theme plan's topic
    /// </summary>
    public partial class PlanTheme : UserControl, INotifyPropertyChanged, IExtendableItems, IWrapFields
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(Theme), typeof(PlanTheme));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(PlanTheme));
                
        public static readonly DependencyProperty
            RemoveWorkProperty = DependencyProperty.Register(nameof(RemoveWork),
                typeof(ICommand), typeof(PlanTheme));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
        
        public ICommand RemoveWork
        {
            get => GetValue(RemoveWorkProperty) as ICommand;
            set => SetValue(RemoveWorkProperty, value);
        }
        
        public Theme Data
        {
            get => GetValue(DataProperty) as Theme;
            set => SetValue(DataProperty, value);
        }
        #endregion

        #region Theme Members
        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Works));
            //Topic.RefreshHours();
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

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
