using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using ControlMaterials.Tables;
using ControlMaterials.Total;

namespace Wisdom.Controls.Tables.Hours.Groups
{
    /// <summary>
    /// Record component containing total hours count (user preset)
    /// </summary>
    public partial class HourGroupAdditor : UserControl, INotifyPropertyChanged
    {
        //public static readonly DependencyProperty
        //    DataProperty = DependencyProperty.Register(nameof(Data),
        //        typeof(HybridNode<Hour>), typeof(HourGroupAdditor));

        public static readonly DependencyProperty
            AddProperty = DependencyProperty.Register(nameof(Add),
                typeof(ICommand), typeof(HourGroupAdditor));

        public ICommand Add
        {
            get => GetValue(AddProperty) as ICommand;
            set => SetValue(AddProperty, value);
        }

        //public HybridNode<Hour> Data
        //{
        //    get => GetValue(DataProperty) as HybridNode<Hour>;
        //    set => SetValue(DataProperty, value);
        //}

        #region Hour Members
        public void RefreshHours()
        {
            //OnPropertyChanged(nameof(Total));
        }
        #endregion

        public HourGroupAdditor()
        {
            InitializeComponent();
            //Data = new HybridNode<Hour>();
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