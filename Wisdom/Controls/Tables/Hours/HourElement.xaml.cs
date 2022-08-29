using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ControlMaterials.Tables;
using Wisdom.Customing;
using System.Windows;
using Wisdom.Controls.Tables.Hours.Groups;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged, IRawData<Hour>
    {
        public static readonly DependencyProperty
            WorkTypeProperty = DependencyProperty.Register(nameof(WorkType),
                typeof(string), typeof(HourElement));

        public static readonly DependencyProperty
            HourValueProperty = DependencyProperty.Register(nameof(HourValue),
                typeof(ushort), typeof(HourElement));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(HourValue),
                typeof(ushort), typeof(HourElement));


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

        public void SetElement(Hour values)
        {
            WorkType = values.Name;
            //HourValue = values.Count.ToString();
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

        //private string _type;
        public string WorkType
        {
            get => GetValue(WorkTypeProperty) as string;
            set => SetValue(WorkTypeProperty, value);
        }

        //private ushort _value;
        public ushort HourValue
        {
            get => GetValue(HourValueProperty).ToUShort();
            set => SetValue(HourValueProperty, value);
        }
        #endregion

        public HourElement()
        {
            InitializeComponent();
        }

        private void DropHour(object sender, RoutedEventArgs e)
        {
            //Group.DropHour(this);
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
