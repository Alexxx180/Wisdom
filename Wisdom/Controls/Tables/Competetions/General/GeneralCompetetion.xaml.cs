using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls.Tables.Competetions.General
{
    /// <summary>
    /// General competetion related to speciality | discipline
    /// </summary>
    public partial class GeneralCompetetion : UserControl, INotifyPropertyChanged, IOptionableIndexing, IRawData<Competetion>
    {
        #region IRawData Members
        public Competetion Raw()
        {
            return new Competetion
            {
                PrefixNo = GeneralHeader,
                Name = GeneralName,
                Abilities = new List<Task> {
                    new Task("Умения", GeneralSkills),
                    new Task("Знания", GeneralKnowledge)
                }
            };
        }

        public void SetElement(Competetion competetion)
        {
            string prefixNo = Regex.Match(competetion.PrefixNo, @"\d+").Value;
            uint no = prefixNo.ToUInt();
            Index(no);

            GeneralName = competetion.Name;

            List<Task> data = competetion.Abilities;
            GeneralSkills = data[0].Hours;
            GeneralKnowledge = data[1].Hours;
        }
        #endregion

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
        #endregion

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                GeneralNo = value.ToGeneralNo();
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
        public string GeneralHeader => $"{Prefix} {GeneralNo}";

        private string _generalNo;
        public string GeneralNo
        {
            get => _generalNo;
            set
            {
                if (value == "")
                    return;
                uint no = value.ParseHours();
                _generalNo = no.ToGeneralNo();
                if (Options != null &&
                    Options.IsManual)
                    Index(no);
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

        private string _generalSkills;
        public string GeneralSkills
        {
            get => _generalSkills;
            set
            {
                _generalSkills = value;
                OnPropertyChanged();
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