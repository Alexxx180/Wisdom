using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups
{
    /// <summary>
    /// Special component to add a group of professional competetions
    /// </summary>
    public partial class ProfessionalDividerAdditor : UserControl, INotifyPropertyChanged, IOptionableIndexing
    {
        public static readonly DependencyProperty
            OptionsProperty = DependencyProperty.Register(nameof(Options),
                typeof(AutoPanel), typeof(ProfessionalDividerAdditor));

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
                DividerNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region ProfessionalDividerAdditor Members
        public string DividerPrefix => "ПК";
        public string DividerHeader => DividerPrefix + " " + DividerNo;

        private string _dividerNo;
        public string DividerNo
        {
            get => _dividerNo;
            set
            {
                _dividerNo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DividerHeader));
            }
        }
        #endregion

        public ProfessionalDividerAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        private void AddDivision(object sender, RoutedEventArgs e)
        {
            ProfessionalDivider divider = new ProfessionalDivider
            {
                DividerNo = DividerNo,
                Options = Options
            };

            if (Options.AddRecord(divider))
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