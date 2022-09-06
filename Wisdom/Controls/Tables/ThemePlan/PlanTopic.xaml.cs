using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Topic of theme plan
    /// </summary>
    public partial class PlanTopic : UserControl, INotifyPropertyChanged, IExtendableItems, IWrapFields
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(HoursNode<Theme>), typeof(PlanTopic));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(PlanTopic));
                
        public static readonly DependencyProperty
            RemoveThemeProperty = DependencyProperty.Register(nameof(RemoveTheme),
                typeof(ICommand), typeof(PlanTopic));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
        
        public ICommand RemoveTheme
        {
            get => GetValue(RemoveThemeProperty) as ICommand;
            set => SetValue(RemoveThemeProperty, value);
        }
        
        public HoursNode<Theme> Data
        {
            get => GetValue(DataProperty) as HoursNode<Theme>;
            set => SetValue(DataProperty, value);
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

        public PlanTopic()
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
