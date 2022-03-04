using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Auto indexing options selector
    /// </summary>
    public partial class AutoIndexer : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            OptionsProperty = DependencyProperty.Register(nameof(Options),
                typeof(AutoPanel), typeof(AutoIndexer));

        #region AutoIndexer Members
        public AutoPanel Options
        {
            get => GetValue(OptionsProperty) as AutoPanel;
            set => SetValue(OptionsProperty, value);
        }

        private int _selected;
        public int Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
                if (Options != null)
                    Options.Mode = value.ToMode();
            }
        }
        #endregion

        public AutoIndexer()
        {
            InitializeComponent();
            Selected = 1;
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