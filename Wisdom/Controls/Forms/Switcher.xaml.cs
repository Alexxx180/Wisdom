using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Customing;
using Wisdom.ViewModel;

namespace Wisdom.Controls.Forms
{
    /// <summary>
    /// UIElements switcher
    /// </summary>
    public partial class Switcher : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            GroupProperty = DependencyProperty.Register("Group",
                typeof(SwitchGroup), typeof(Switcher));

        public static readonly DependencyProperty
            ElementProperty = DependencyProperty.Register("Element",
                typeof(FrameworkElement), typeof(Switcher));

        public static readonly DependencyProperty
            IsNotPressedProperty = DependencyProperty.Register("IsNotPressed",
                typeof(bool), typeof(Switcher));

        //private SwitchGroup _group;
        internal SwitchGroup Group
        {
            get => GetValue(GroupProperty) as SwitchGroup; //_group
            set
            {
                SetValue(GroupProperty, value);
                //OnPropertyChanged();
            }
        }

        //private FrameworkElement _element;
        public FrameworkElement Element
        {
            get => GetValue(ElementProperty) as FrameworkElement;
            set
            {
                SetValue(ElementProperty, value);
                //OnPropertyChanged();
            }
        }

        //private bool _isNotPressed;
        public bool IsNotPressed
        {
            get => GetValue(IsNotPressedProperty).ToBool();
            set
            {
                SetValue(IsNotPressedProperty, value);
                if (!value)
                    Group.SwitchElement(this, Element);
                OnPropertyChanged();
            }
        }

        #region Switcher Members
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                System.Diagnostics.Trace.WriteLine(value);
                OnPropertyChanged();
            }
        }

        private Style _viewStyle;
        public Style ViewStyle
        {
            get => _viewStyle;
            set
            {
                _viewStyle = value;
                System.Diagnostics.Trace.WriteLine(value);
                OnPropertyChanged();
            }
        }
        #endregion

        public Switcher()
        {
            InitializeComponent();
            IsNotPressed = true;
        }

        private void Switch(object sender, RoutedEventArgs e)
        {
            IsNotPressed = false;
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