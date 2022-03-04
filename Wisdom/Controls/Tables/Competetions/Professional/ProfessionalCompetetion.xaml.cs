using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups;
using Wisdom.Model.ThemePlan;
using Wisdom.Model;

namespace Wisdom.Controls.Tables.Competetions.Professional
{
    /// <summary>
    /// Professional competetion related to speciality | discipline
    /// </summary>
    public partial class ProfessionalCompetetion : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<Competetion>
    {
        #region IRawData Members
        public Competetion Raw()
        {
            return new Competetion
            {
                PrefixNo = ProfessionalHeader,
                Name = ProfessionalName,
                Abilities = new List<Task> {
                    new Task("Практический опыт", ProfessionalExperience),
                    new Task("Умения", ProfessionalSkills),
                    new Task("Знания", ProfessionalKnowledge)
                }
            };
        }

        public void SetElement(Competetion competetion)
        {
            string no = competetion.PrefixNo;

            ProfessionalNo = no[(no.LastIndexOf('.') + 1)..];
            ProfessionalName = competetion.Name;

            List<Task> value = competetion.Abilities;
            ProfessionalExperience = value[0].Hours;
            ProfessionalSkills = value[1].Hours;
            ProfessionalKnowledge = value[2].Hours;
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
                ProfessionalNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

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
        
        public string ProfessionalHeader => $"{Group.Prefix} {Group.DividerNo}.{ProfessionalNo}.";

        private string _professionalNo;
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
        public string ProfessionalName
        {
            get => _professionalName;
            set
            {
                _professionalName = value;
                OnPropertyChanged();
            }
        }

        private string _professionalExperience;
        public string ProfessionalExperience
        {
            get => _professionalExperience;
            set
            {
                _professionalExperience = value;
                OnPropertyChanged();
            }
        }

        private string _professionalSkills;
        public string ProfessionalSkills
        {
            get => _professionalSkills;
            set
            {
                _professionalSkills = value;
                OnPropertyChanged();
            }
        }

        private string _professionalKnowledge;
        public string ProfessionalKnowledge
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

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Group.DropCompetetion(this);
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