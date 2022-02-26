using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables.Competetions.General
{
    /// <summary>
    /// Special component to add new general competetion
    /// </summary>
    public partial class GeneralCompetetionAdditor : UserControl, INotifyPropertyChanged, IOptionableIndexing
    {
        public static readonly DependencyProperty
            OptionsProperty = DependencyProperty.Register(nameof(Options),
                typeof(AutoPanel), typeof(GeneralCompetetionAdditor));

        #region IOptionableIndexing Members
        public AutoPanel Options
        {
            get => GetValue(OptionsProperty) as AutoPanel;
            set => SetValue(OptionsProperty, value);
        }
        #endregion

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                if (Options == null || !Options.IsManual)
                    GeneralNo = value.ToString();
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region GeneralCompetetionAdditor Members
        public string Prefix => "ОК";
        public string GeneralHeader => Prefix + " " + GeneralNo;

        private string _generalNo;
        public string GeneralNo
        {
            get => _generalNo;
            set
            {
                if (value == "")
                    return;
                uint no = value.ParseHours();
                _generalNo = string.Format("{0:00}", no);
                if (Options != null && Options.IsManual)
                    No = no;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GeneralHeader));
            }
        }

        private string _generalName;
        public string GeneralName
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

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            GeneralCompetetion competetion = new GeneralCompetetion
            {
                GeneralNo = GeneralNo,
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