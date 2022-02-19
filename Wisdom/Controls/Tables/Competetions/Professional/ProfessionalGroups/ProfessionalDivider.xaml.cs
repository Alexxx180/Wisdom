using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups
{
    /// <summary>
    /// A group of professional competetions
    /// </summary>
    public partial class ProfessionalDivider : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<List<HoursList<Pair<string, string>>>>
    {
        public List<HoursList<Pair<string, string>>> Raw()
        {
            return GetDivision();
        }

        private AutoIndexer _options;
        public AutoIndexer Options
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
                DividerNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        #region ProfessionalDivider Members
        public string Prefix => "ПК";
        public string DividerHeader => Prefix + " " + DividerNo;

        private string _dividerNo = "";
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

        private ObservableCollection<ProfessionalCompetetion> _competetions;
        internal ObservableCollection<ProfessionalCompetetion> Competetions
        {
            get => _competetions;
            set
            {
                _competetions = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ProfessionalDivider()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        public static List<HoursList<Pair<string, string>>>
            Zip(List<List<HoursList<Pair<string, string>>>> competetions)
        {
            List<HoursList<Pair<string, string>>> list = new
                List<HoursList<Pair<string, string>>>();
            for (byte i = 0; i < competetions.Count; i++)
            {
                list.AddRange(competetions[i]);
            }
            return list;
        }

        public List<HoursList<Pair<string, string>>> GetDivision()
        {
            List<HoursList<Pair<string, string>>> competetions = new
                List<HoursList<Pair<string, string>>>();
            for (byte i = 0; i < Competetions.Count - 1; i++)
            {
                competetions.Add(Competetions[i].Raw());
            }
            return competetions;
        }

        private void DropDivision(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        public void SetElement(List<HoursList<Pair<string, string>>> competetions)
        {
            for (ushort i = 0; i < competetions.Count; i++)
            {
                ProfessionalCompetetion competetion = new ProfessionalCompetetion();
                competetion.SetElement(competetions[i]);
                Competetions.Add(competetion);
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