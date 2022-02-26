using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Easy way to observe auto-indexing records
    /// </summary>
    public partial class AutoPanel : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            RecordsProperty = DependencyProperty.Register(nameof(Records),
                typeof(ObservableCollection<IOptionableIndexing>), typeof(AutoPanel),
                new PropertyMetadata(OnRecordsChangedCallBack));

        public static readonly DependencyProperty
            AdditorProperty = DependencyProperty.Register(nameof(Additor),
                typeof(IOptionableIndexing), typeof(AutoPanel));

        #region AutoPanel Members
        public ObservableCollection<IOptionableIndexing> Records
        {
            get => GetValue(RecordsProperty) as ObservableCollection<IOptionableIndexing>;
            set => SetValue(RecordsProperty, value);
        }

        internal IOptionableIndexing Additor
        {
            get => GetValue(AdditorProperty) as IOptionableIndexing;
            set => SetValue(AdditorProperty, value);
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
                CheckAuto();
            }
        }

        public bool IsManual => Mode == Indexing.MANUAL;
        #endregion

        public AutoPanel()
        {
            InitializeComponent();
            Mode = Indexing.MANUAL;
        }

        #region AutoIndexing Logic
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
        #endregion

        /// <summary>
        /// Removes the first occurence of a specific object
        /// from the ObservableCollection<IOptionableIndexing>
        /// </summary>
        /// <param name="record">An item with indexing options.</param>
        internal void DropRecord(IOptionableIndexing record)
        {
            _ = Records.Remove(record);
            CheckAuto();
            RegisterEdit();
        }

        /// <summary>
        /// Adds an object to the end of ObservableCollection<IOptionableIndexing>
        /// </summary>
        /// <param name="record">An item with indexing options.</param>
        /// <returns>true if indexing mode is NEW_ONLY; otherwise, false.</returns>
        internal bool AddRecord(IOptionableIndexing record)
        {
            Records.Add(record);
            CheckAuto();
            RegisterEdit();
            return Mode == Indexing.NEW_ONLY;
        }

        public void RegisterEdit()
        {
            OnPropertyChanged(nameof(Records));
            GetBindingExpression(RecordsProperty).UpdateSource();
        }

        #region RecordsCallBack Members
        private static void
            OnRecordsChangedCallBack(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            if (sender is AutoPanel collection)
            {
                collection?.OnRecordsChanged();
            }
        }

        protected virtual void OnRecordsChanged()
        {
            foreach (IOptionableIndexing optionable in Records)
            {
                optionable.Options ??= this;
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