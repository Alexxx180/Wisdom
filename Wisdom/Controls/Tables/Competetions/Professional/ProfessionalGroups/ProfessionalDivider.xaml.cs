using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using ControlMaterials.Tables;
using Wisdom.Customing;
using System.Text.RegularExpressions;

namespace Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups
{
    /// <summary>
    /// A group of professional competetions
    /// </summary>
    public partial class ProfessionalDivider : UserControl, INotifyPropertyChanged, IOptionableIndexing, IRawData<List<Competetion>>, IExtendableItems
    {
        #region IRawData Members
        public List<Competetion> Raw()
        {
            return Competetions.GetRaw();
        }

        public void SetElement(List<Competetion> competetions)
        {
            if (competetions.Count < 0)
                return;

            //DividerNo = Regex.Match(competetions[0].PrefixNo, ".\\d+").Value;
            for (ushort i = 0; i < competetions.Count; i++)
            {
                ProfessionalCompetetion competetion = new ProfessionalCompetetion
                {
                    Group = this
                };
                competetion.SetElement(competetions[i]);
                Competetions.Add(competetion);
            }
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
                DividerNo = _no.ToString();
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
            if (Options != null)
                CheckAuto();
        }
        #endregion

        #region ProfessionalDivider Members
        public string Prefix => "ПК";

        private string _dividerNo;
        public string DividerNo
        {
            get => _dividerNo;
            set
            {
                _dividerNo = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ProfessionalCompetetion> _competetions;
        public ObservableCollection<ProfessionalCompetetion> Competetions
        {
            get => _competetions;
            set
            {
                _competetions = value;
                OnPropertyChanged();
            }
        }

        private void CheckAuto()
        {
            if (Options.Mode == Indexing.AUTO)
                IndexGroup();
        }

        private void IndexGroup()
        {
            ushort i;
            for (i = 0; i < Competetions.Count; i++)
            {
                Competetions[i].Index((i + 1).ToUInt());
            }
            Additor.Index((i + 1).ToUInt());
        }
        #endregion

        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
            for (ushort i = 0; i < Competetions.Count; i++)
            {
                Competetions[i].Extended = Extended;
            }
        }
        #endregion

        public ProfessionalDivider()
        {
            InitializeComponent();
            Competetions = new ObservableCollection<ProfessionalCompetetion>();
            Index(1);
            Extended = true;
        }

        private void DropDivision(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        #region CompetetionsGroup Members
        public void DropCompetetion(ProfessionalCompetetion competetion)
        {
            _ = Competetions.Remove(competetion);
            OnPropertyChanged(nameof(Competetions));
            CheckAuto();
        }

        public bool AddRecord(ProfessionalCompetetion record)
        {
            Competetions.Add(record);
            OnPropertyChanged(nameof(Competetions));
            CheckAuto();
            return Options.Mode == Indexing.NEW_ONLY;
        }
        #endregion

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