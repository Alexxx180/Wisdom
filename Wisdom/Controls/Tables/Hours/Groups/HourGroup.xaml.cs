using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ControlMaterials.Tables;
using System.Windows;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.Controls.Tables.Hours.Groups
{
    /// <summary>
    /// Record component containing total hours count (user preset)
    /// </summary>
    public partial class HourGroup : UserControl, INotifyPropertyChanged, IExtendableItems
    {
        //public static readonly DependencyProperty
        //    DataProperty = DependencyProperty.Register(nameof(Data),
        //        typeof(HybridNode<Hour>), typeof(HourGroup));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(HourGroup));

        public static readonly DependencyProperty
            RemoveHourProperty = DependencyProperty.Register(nameof(RemoveHour),
                typeof(ICommand), typeof(HourGroup));

        public static readonly DependencyProperty
            AddHourProperty = DependencyProperty.Register(nameof(AddHour),
                typeof(ICommand), typeof(HourGroup));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }

        public ICommand RemoveHour
        {
            get => GetValue(RemoveHourProperty) as ICommand;
            set => SetValue(RemoveHourProperty, value);
        }

        public ICommand AddHour
        {
            get => GetValue(AddHourProperty) as ICommand;
            set => SetValue(AddHourProperty, value);
        }

        //public HybridNode<Hour> Data
        //{
        //    get => GetValue(DataProperty) as HybridNode<Hour>;
        //    set => SetValue(DataProperty, value);
        //}

        #region Hour Members
        public uint Total
        {
            get
            {
                uint total = 0;

                //if (Data != null)
                //{
                //    for (ushort i = 0; i < Data.Items.Count; i++)
                //    {
                //        total += Data.Items[i].Count;
                //    }
                //}

                return total;
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Total));
        }
        #endregion

        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

        public HourGroup()
        {
            InitializeComponent();
            
            //RemoveHour = new RelayCommand(argument =>
            //{
            //    _ = Data.Remove((Hour)argument);
            //});

            //AddHour = new RelayCommand(argument =>
            //{
            //    Hour hour = argument as Hour;
            //    Data.Add(hour.Copy());
            //});

            Extended = true;
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