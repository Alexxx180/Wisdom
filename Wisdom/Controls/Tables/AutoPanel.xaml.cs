using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Easy way to observe auto-indexing records
    /// </summary>
    public partial class AutoPanel : UserControl
    {
        #region AutoIndexing Members
        private ObservableCollection<IAutoIndexing> _records;
        internal ObservableCollection<IAutoIndexing> Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged();
            }
        }

        private IAutoIndexing _additor;
        internal IAutoIndexing Additor
        {
            get => _additor;
            set
            {
                _additor = value;
                OnPropertyChanged();
            }
        }

        private Indexing _mode;
        public Indexing Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsManual));
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

        public bool IsManual => Mode == Indexing.MANUAL;
        #endregion

        public AutoPanel()
        {
            InitializeComponent();
        }

        private void CheckAuto()
        {
            if (Mode == Indexing.AUTO)
                AutoIndexing();
        }

        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < Records.Count; i++)
            {
                Records[i].Index((i + 1).ToUInt());
            }
            Additor.Index((i + 1).ToUInt());
        }

        internal void DropRecord(IAutoIndexing record)
        {
            Records.Remove(record);
            OnPropertyChanged(nameof(Records));
            CheckAuto();
        }

        internal bool AddRecord(IAutoIndexing record)
        {
            Records.Add(record);
            OnPropertyChanged(nameof(Records));
            CheckAuto();
            return Mode == Indexing.NEW_ONLY;
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