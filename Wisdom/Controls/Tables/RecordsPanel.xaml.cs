using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Easy way to observe auto-indexing records
    /// </summary>
    public partial class RecordsPanel : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            RecordsProperty = DependencyProperty.Register(nameof(Records),
                typeof(ObservableCollection<IRecordsIndexing>), typeof(RecordsPanel),
                new PropertyMetadata(OnRecordsChangedCallBack));

        public static readonly DependencyProperty
            AdditorProperty = DependencyProperty.Register(nameof(Additor),
                typeof(IRecordsIndexing), typeof(RecordsPanel));

        #region RecordsPanel Members
        public ObservableCollection<IRecordsIndexing> Records
        {
            get => GetValue(RecordsProperty) as ObservableCollection<IRecordsIndexing>;
            set => SetValue(RecordsProperty, value);
        }

        internal IRecordsIndexing Additor
        {
            get => GetValue(AdditorProperty) as IRecordsIndexing;
            set => SetValue(AdditorProperty, value);
        }
        #endregion

        #region AutoIndexing Logic
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

        public RecordsPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the first occurence of a specific object
        /// from the ObservableCollection<IOptionableIndexing>
        /// </summary>
        /// <param name="record">An item with indexing options.</param>
        internal void DropRecord(IRecordsIndexing record)
        {
            _ = Records.Remove(record);
            AutoIndexing();
            RegisterEdit();
        }

        /// <summary>
        /// Adds an object to the end of ObservableCollection<IOptionableIndexing>
        /// </summary>
        /// <param name="record">An item with indexing options.</param>
        internal void AddRecord(IRecordsIndexing record)
        {
            Records.Add(record);
            RegisterEdit();
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
            if (sender is RecordsPanel collection)
            {
                collection?.OnRecordsChanged();
            }
        }

        protected virtual void OnRecordsChanged()
        {
            Additor.Index((Records.Count + 1).ToUInt());
            foreach (IRecordsIndexing optionable in Records)
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