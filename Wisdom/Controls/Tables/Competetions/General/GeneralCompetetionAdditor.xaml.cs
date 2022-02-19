using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables.Competetions.General
{
    /// <summary>
    /// Special component to add new general competetion
    /// </summary>
    public partial class GeneralCompetetionAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        private AutoPanel _options;
        public AutoPanel Options
        {
            get => _options;
            set
            {
                _options = value;
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
                GeneralNo = string.Format("{0:00}", value);
                OnPropertyChanged();
            }
        }

        #region GeneralCompetetionAdditor Members
        public string Prefix => "ОК";
        public string GeneralHeader => Prefix + " " + GeneralNo;

        private string _generalNo;
        public string GeneralNo
        {
            get => _generalNo;
            set
            {
                _generalNo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GeneralHeader));
            }
        }

        private string _generalName;
        internal string GeneralName
        {
            get => _generalName;
            set
            {
                _generalName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public GeneralCompetetionAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            GeneralCompetetion competetion = new GeneralCompetetion
            {
                GeneralName = GeneralName
            };
            if (Options.AddRecord(competetion))
            {
                Index(No + 1);
            }
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