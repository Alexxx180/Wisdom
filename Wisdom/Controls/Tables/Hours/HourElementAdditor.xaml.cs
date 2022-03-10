using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Wisdom.Model.Tables;
using Wisdom.ViewModel;
using Wisdom.Customing;
using System.Windows;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Special component to add new hour
    /// </summary>
    public partial class HourElementAdditor : UserControl, INotifyPropertyChanged, IRawData<Hour>
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(
                nameof(ViewModel), typeof(DisciplineProgramViewModel),
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
        public DisciplineProgramViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as DisciplineProgramViewModel;
            set => SetValue(ViewModelProperty, value);
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

        public HourElementAdditor()
        {
            InitializeComponent();
        }

        private void AddHour(object sender, RoutedEventArgs e)
        {
            ViewModel.AddHour(Raw());
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
