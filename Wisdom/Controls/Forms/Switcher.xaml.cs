using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.ViewModel;

namespace Wisdom.Controls.Forms
{
    /// <summary>
    /// UIElements switcher
    /// </summary>
    public partial class Switcher : UserControl, INotifyPropertyChanged
    {
        private SwitchGroup _group;
        internal SwitchGroup Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        private FrameworkElement _element;
        public FrameworkElement Element
        {
            get => _element;
            set
            {
                _element = value;
                OnPropertyChanged();
            }
        }

        private bool _isNotPressed;
        public bool IsNotPressed
        {
            get => _isNotPressed;
            set
            {
                _isNotPressed = value;
                if (!value)
                    Group.SwitchElement(this, Element);
                OnPropertyChanged();
            }
        }

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