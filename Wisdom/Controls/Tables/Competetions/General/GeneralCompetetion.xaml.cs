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
    public partial class GeneralCompetetion : UserControl, INotifyPropertyChanged, IOptionableIndexing, IRawData<HoursList<Pair<string, string>>>
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

        #region IOptionableIndexing Members
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

        public void UpdateOptions()
        {
            OnPropertyChanged(nameof(Options));
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
                GeneralNo = string.Format("{0:00}", value);
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region GeneralCompetetion Members
        public string Prefix => "ОК";
        public string GeneralHeader => Prefix + " " + GeneralNo;

        private string _generalNo = "";
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
                Options?.RegisterEdit();
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
                Options?.RegisterEdit();
            }
        }

        private string _generalSkills;
        public string GeneralSkills
        {
            get => _generalSkills;
            set
            {
                _generalSkills = value;
                OnPropertyChanged();
                Options?.RegisterEdit();
            }
        }

        private string _generalKnowledge;
        public string GeneralKnowledge
        {
            get => _generalKnowledge;
            set
            {
                _generalKnowledge = value;
                OnPropertyChanged();
                Options?.RegisterEdit();
            }
        }
        #endregion

        public GeneralCompetetion()
        {
            InitializeComponent();
            Index(1);
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        public void SetElement(HoursList<Pair<string, string>> competetion)
        {
            uint no = Regex.Match(competetion.Name, @"\d+").Value.ToUInt();
            Index(no);

            List<Pair<string, string>> data = competetion.Values;
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