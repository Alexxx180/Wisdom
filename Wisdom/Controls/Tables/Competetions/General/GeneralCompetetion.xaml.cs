using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables.Competetions.General
{
    /// <summary>
    /// General competetion related to speciality | discipline
    /// </summary>
    public partial class GeneralCompetetion : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<HoursList<Pair<string, string>>>
    {
        public HoursList<Pair<string, string>> Raw()
        {
            return new HoursList<Pair<string, string>>(GeneralHeader, GeneralName)
            {
                Values = {
                    new Pair<string, string>("Умения", GeneralSkills),
                    new Pair<string, string>("Знания", GeneralKnowledge),
                }
            };
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
                GeneralNo = string.Format("{0:00}", value);
                OnPropertyChanged();
            }
        }

        #region GeneralCompetetion Members
        public string Prefix => "ОК";
        public string GeneralHeader => Prefix + " " + GeneralNo;

        private string _generalNo = "";
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

        private string _generalSkills;
        internal string GeneralSkills
        {
            get => _generalSkills;
            set
            {
                _generalSkills = value;
                OnPropertyChanged();
            }
        }

        private string _generalKnowledge;
        internal string GeneralKnowledge
        {
            get => _generalKnowledge;
            set
            {
                _generalKnowledge = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public GeneralCompetetion()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        public void SetElement(HoursList<Pair<string, string>> competetion)
        {
            int no = Regex.Match(competetion.Name, @"\d+").Value.ToInt();
            List<Pair<string, string>> data = competetion.Values;

            Index(no.ToUInt());
            GeneralName = competetion.Hours;
            GeneralSkills = data[0].Value;
            GeneralKnowledge = data[1].Value;
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