using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Controls.Tables;
using Wisdom.Model;
using Wisdom.ViewModel;
using Wisdom.Customing;

namespace Wisdom.Controls
{
    /// <summary>
    /// Record component containing total hours count (user preset)
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged, IRawData<Pair<string, ushort>>
    {
        #region IRawData Members
        public Pair<string, ushort> Raw()
        {
            ushort hours = HourValue.ParseHours();
            return new Pair<string, ushort>(WorkType, hours);
        }

        public void SetElement(Pair<string, ushort> values)
        {
            WorkType = values.Name;
            HourValue = values.Value.ToString();
        }
        #endregion

        #region Hour Members
        private DisciplineProgramViewModel _viewModel;
        internal DisciplineProgramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private string _type;
        public string WorkType
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _value;
        public string HourValue
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                ViewModel.RefreshHours();
            }
        }
        #endregion

        public HourElement()
        {
            InitializeComponent();
        }

        public void SetType(string value)
        {
            WorkType = value;
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