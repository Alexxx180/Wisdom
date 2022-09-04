﻿using System.ComponentModel;
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
        public static readonly DependencyProperty
            GroupProperty = DependencyProperty.Register(nameof(Group),
                typeof(HybridNode<Hour>), typeof(HourGroup));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(HourGroup));

        public static readonly DependencyProperty
            RemoveHourProperty = DependencyProperty.Register(nameof(RemoveHour),
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

        public HybridNode<Hour> Group
        {
            get => GetValue(GroupProperty) as HybridNode<Hour>;
            set => SetValue(GroupProperty, value);
        }

        #region Hour Members
        public uint Total
        {
            get
            {
                uint total = 0;

                if (Group != null)
                {
                    for (ushort i = 0; i < Group.Items.Count; i++)
                    {
                        total += Group.Items[i].Count;
                    }
                }

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
            RemoveHour = new RelayCommand(argument =>
            {
                _ = Group.Remove((Hour)argument);
                System.Diagnostics.Trace.WriteLine("LOL");
            });

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