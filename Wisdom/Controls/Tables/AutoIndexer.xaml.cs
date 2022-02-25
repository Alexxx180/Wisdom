using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.Customing.Converters;
using System.Windows;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Auto indexing options selector
    /// </summary>
    public partial class AutoIndexer : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ModeProperty = DependencyProperty.Register("Mode",
                typeof(Indexing), typeof(AutoIndexer));

        #region AutoIndexer Members
        public Indexing Mode
        {
            get => GetValue(ModeProperty).ToMode();
            set
            {
                SetValue(ModeProperty, value);
                OnPropertyChanged();
            }
        }

        private int _selected = 0;
        public int Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                Mode = value.ToMode();
                OnPropertyChanged();
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