using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;

namespace Wisdom.Controls.Tables.Competetions.Professional
{
    /// <summary>
    /// Special component to add professional competetion
    /// </summary>
    public partial class ProfessionalCompetetionAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        public static readonly DependencyProperty
            GroupProperty = DependencyProperty.Register(nameof(Group),
                typeof(ProfessionalDivider), typeof(ProfessionalCompetetionAdditor));

        #region IAutoIndexing Members
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

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region ProfessionalCompetetionAdditor Members
        public ProfessionalDivider Group
        {
            get => GetValue(GroupProperty) as ProfessionalDivider;
            set => SetValue(GroupProperty, value);
        }

        private string _professionalNo;
        public string ProfessionalNo
        {
            get => _professionalNo;
            set
            {
                _professionalNo = value;
                OnPropertyChanged();
            }
        }

        private string _professionalName;
        public string ProfessionalName
        {
            get => _professionalName;
            set
            {
                _professionalName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ProfessionalCompetetionAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            ProfessionalCompetetion competetion = new ProfessionalCompetetion
            {
                ProfessionalNo = ProfessionalNo,
                ProfessionalName = ProfessionalName,
                Group = Group
            };

            if (Group.AddRecord(competetion))
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