using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ControlMaterials.Tables;
using Wisdom.Customing;
using System.Windows;
using Wisdom.Controls.Tables.Hours.Groups;
using System.Windows.Input;
using Wisdom.Model;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged, IRawData<Hour>
    {
        public static readonly DependencyProperty
            HourProperty = DependencyProperty.Register(nameof(Hour),
                typeof(Hour), typeof(HourElement));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(HourElement));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }

        #region IRawData Members
        public Hour Raw()
        {
            //ushort hours = HourValue.ParseHours(); //WorkType
            return new Hour("", 0);
        }

        public void SetElement(Hour value)
        {
            Hour = value;
            //WorkType = values.Name;
            //HourValue = values.Count.ToString();
        }
        #endregion

        #region Hour Members
        public Hour Hour
        {
            get => (Hour)GetValue(HourProperty);
            set => SetValue(HourProperty, value);
        }
        #endregion

        public HourElement()
        {
            InitializeComponent();
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
