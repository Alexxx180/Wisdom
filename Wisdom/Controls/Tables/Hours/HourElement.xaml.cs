using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ControlMaterials.Tables;
using System.Windows;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.Hours
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    public partial class HourElement : UserControl, INotifyPropertyChanged
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

        public Hour Hour
        {
            get => GetValue(HourProperty) as Hour;
            set => SetValue(HourProperty, value);
        }

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
