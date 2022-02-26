using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Wisdom.Model;
using Wisdom.Customing;
using System.Text.RegularExpressions;

namespace Wisdom.Controls.Tables.Competetions.Professional.ProfessionalGroups
{
    /// <summary>
    /// A group of professional competetions
    /// </summary>
    public partial class ProfessionalDivider : UserControl, INotifyPropertyChanged, IOptionableIndexing, IRawData<List<HoursList<Pair<string, string>>>>
    {
        public List<HoursList<Pair<string, string>>> Raw()
        {
            return GetDivision();
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

        public ProfessionalDivider()
        {
            InitializeComponent();
            Competetions = new ObservableCollection<ProfessionalCompetetion>();
            Index(1);
        }

        public void DropCompetetion(ProfessionalCompetetion competetion)
        {
            _ = Competetions.Remove(competetion);
            OnPropertyChanged(nameof(Competetions));
            CheckAuto();
        }

        public bool AddRecord(ProfessionalCompetetion record)
        {
            Competetions.Add(record);
            System.Diagnostics.Trace.WriteLine(Competetions.Count);
            OnPropertyChanged(nameof(Competetions));
            CheckAuto();
            return Options.Mode == Indexing.NEW_ONLY;
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
            if (competetions.Count < 0)
                return;
            DividerNo = Regex.Match(competetions[0].Name, ".\\d+").Value;
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