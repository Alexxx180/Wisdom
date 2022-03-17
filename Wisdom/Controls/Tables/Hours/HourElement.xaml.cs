using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Model.Tables;
using Wisdom.Customing;
using System.Windows;
using Wisdom.Controls.Tables.Hours.Groups;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged, IRawData<Hour>
    {
        #region IRawData Members
        public Hour Raw()
        {
            ushort hours = HourValue.ParseHours();
            return new Hour(WorkType, hours);
        }

        public void SetElement(Hour values)
        {
            WorkType = values.Name;
            HourValue = values.Count.ToString();
        }
        #endregion

        #region Hour Members
        private HourGroup _group;
        internal HourGroup Group
        {
            get => _group;
            set
            {
                _group = value;
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
                Group?.RefreshHours();
            }
        }
        #endregion

        public HourElement()
        {
            InitializeComponent();
        }

        private void DropHour(object sender, RoutedEventArgs e)
        {
            Group.DropHour(this);
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
