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
    /// Логика взаимодействия для HourElementAdditor.xaml
    /// </summary>
    public partial class HourElementAdditor : UserControl, INotifyPropertyChanged, IRawData<Hour>
    {
        public static readonly DependencyProperty
            HourGroupProperty = DependencyProperty.Register(
                nameof(Group), typeof(HourGroup),
                typeof(HourElementAdditor));

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
        public HourGroup Group
        {
            get => GetValue(HourGroupProperty) as HourGroup;
            set => SetValue(HourGroupProperty, value);
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
                Group.RefreshHours();
            }
        }
        #endregion

        public HourElementAdditor()
        {
            InitializeComponent();
        }

        private void AddHour(object sender, RoutedEventArgs e)
        {
            HourElement element = new HourElement
            {
                Group = Group,
                WorkType = WorkType,
                HourValue = HourValue
            };
            Group.AddHour(element);
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