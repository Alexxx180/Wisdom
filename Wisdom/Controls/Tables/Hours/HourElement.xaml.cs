using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Controls.Tables;
using Wisdom.Model;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls
{
    /// <summary>
    /// Record component containing theme plan hours total count (user preset)
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged, IRawData<Pair<string, ushort>>
    {
        public Pair<string, ushort> Raw()
        {
            ushort hours = HourValue.ParseHours();
            return new Pair<string, ushort>(WorkType, hours);
        }

        #region Hour Members
        public string _type = "";
        public string WorkType
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string _value = "";
        public string HourValue
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
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

        public void SetElement(Pair<string, ushort> values)
        {
            WorkType = values.Name;
            HourValue = values.Value.ToString();
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