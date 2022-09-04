using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ControlMaterials.Tables;
using Wisdom.Customing;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Wisdom.Controls.Tables.Hours.Groups
{
    /// <summary>
    /// Record component containing total hours count (user preset)
    /// </summary>
    public partial class HourGroupAdditor : UserControl, INotifyPropertyChanged, IExtendableItems
    {
        public static readonly DependencyProperty
            TypeProperty = DependencyProperty.Register(nameof(Type),
                typeof(string), typeof(HourGroup));

        public static readonly DependencyProperty
            HoursProperty = DependencyProperty.Register(nameof(Hours),
                typeof(ObservableCollection<HourElement>), typeof(HourGroup));

        #region Hour Members
        public string Type
        {
            get => GetValue(TypeProperty) as string;
            set => SetValue(TypeProperty, value);
        }

        public string Total
        {
            get
            {
                uint total = 0;

                //if (Hours != null)
                //{
                //    for (ushort i = 0; i < Hours.Count; i++)
                //    {
                //        total += Hours[i].HourValue.ParseHours();
                //    }
                //}

                return total.ToString();
            }
        }

        public ObservableCollection<HourElement> Hours
        {
            get => GetValue(HoursProperty) as ObservableCollection<HourElement>;
            set => SetValue(HoursProperty, value);
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

        public HourGroupAdditor()
        {
            InitializeComponent();
            Hours = new ObservableCollection<HourElement>();
            Extended = true;
        }

        public void DropHour(HourElement hour)
        {
            _ = Hours.Remove(hour);
            OnPropertyChanged(nameof(Hours));
            RefreshHours();
        }

        public void AddHour(HourElement hour)
        {
            Hours.Add(hour);
            OnPropertyChanged(nameof(Hours));
            RefreshHours();
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