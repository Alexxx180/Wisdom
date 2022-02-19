using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.Sources.SourceTypes;

namespace Wisdom.Controls.Tables.Sources
{
    /// <summary>
    /// Special component to add new source
    /// </summary>
    public partial class SourceElementAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        private SourceTypeElement _sourceType;
        public SourceTypeElement SourceType
        {
            get => _sourceType;
            set
            {
                _sourceType = value;
                OnPropertyChanged();
            }
        }

        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SourceHeader));
            }
        }

        #region SourceAdditor Members
        public string SourceHeader => $"{No}.";

        public string _value;
        public string Source
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public SourceElementAdditor()
        {
            InitializeComponent();
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void AddSource(object sender, RoutedEventArgs e)
        {
            SourceElement source = new SourceElement
            {
                Source = Source
            };
            // SourceType.AddRecord();
            Index(No + 1);
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