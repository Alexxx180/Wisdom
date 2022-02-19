using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Auto indexing options selector
    /// </summary>
    public partial class AutoIndexer : UserControl, INotifyPropertyChanged
    {
        #region AutoIndexer Members
        private Indexing _mode;
        public Indexing Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnPropertyChanged();
            }
        }

        private int _selected = 0;
        internal int Selected
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