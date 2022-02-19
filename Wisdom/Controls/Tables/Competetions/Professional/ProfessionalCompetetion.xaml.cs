using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;

namespace Wisdom.Controls.Tables.Competetions.Professional
{
    /// <summary>
    /// Professional competetion related to speciality | discipline
    /// </summary>
    public partial class ProfessionalCompetetion : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<HoursList<Pair<string, string>>>
    {
        public HoursList<Pair<string, string>> Raw()
        {
            return new HoursList<Pair<string, string>>(ProfessionalHeader, ProfessionalName)
            {
                Values = {
                    new Pair<string, string>("Практический опыт", ProfessionalExperience),
                    new Pair<string, string>("Умения", ProfessionalSkills),
                    new Pair<string, string>("Знания", ProfessionalKnowledge)
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
                ProfessionalNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        #region ProfessionalCompetetion Members
        private ProfessionalDivider _group;
        public ProfessionalDivider Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        public string Prefix => "ПК"; //{_no1}
        public string ProfessionalHeader => $"{Prefix} 1.{ProfessionalNo}.";

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

        private string _professionalExperience;
        internal string ProfessionalExperience
        {
            get => _professionalExperience;
            set
            {
                _professionalExperience = value;
                OnPropertyChanged();
            }
        }

        private string _professionalSkills;
        internal string ProfessionalSkills
        {
            get => _professionalSkills;
            set
            {
                _professionalSkills = value;
                OnPropertyChanged();
            }
        }

        private string _professionalKnowledge;
        internal string ProfessionalKnowledge
        {
            get => _professionalKnowledge;
            set
            {
                _professionalKnowledge = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ProfessionalCompetetion()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        public static void DropProfessional(StackPanel stack)
        {
            stack.Children.Clear();
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        public void SetElement(HoursList<Pair<string, string>> competetion)
        {
            ProfessionalName = competetion.Hours;
            List<Pair<string, string>> value = competetion.Values;
            ProfessionalExperience = value[0].Value;
            ProfessionalSkills = value[1].Value;
            ProfessionalKnowledge = value[2].Value;
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