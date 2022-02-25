using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Tables.Competetions.Professional
{
    /// <summary>
    /// Special component to add professional competetion
    /// </summary>
    public partial class ProfessionalCompetetionAdditor : UserControl, INotifyPropertyChanged, IOptionableIndexing
    {
        public ProfessionalCompetetionAdditor()
        {
            InitializeComponent();
            Index(1);
        }

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
                ProfessionalNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        #region ProfessionalCompetetionAdditor Members
        public string ProfessionalPrefix => "ПК";
        public string ProfessionalHeader => $"{ProfessionalPrefix} 1.{ProfessionalNo}.";

        private string _professionalNo = "";
        public string ProfessionalNo
        {
            get => _professionalNo;
            set
            {
                _professionalNo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ProfessionalHeader));
            }
        }

        private string _professionalName;
        internal string ProfessionalName
        {
            get => _professionalName;
            set
            {
                _professionalName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public void Index(uint no)
        {
            No = no;
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            ProfessionalCompetetion competetion = new ProfessionalCompetetion
            {
                ProfessionalName = ProfessionalName
            };
            Options.AddRecord(competetion);
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