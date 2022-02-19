﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.Sources.SourceTypes;

namespace Wisdom.Controls.Tables.Sources
{
    /// <summary>
    /// Record component containing educational source
    /// </summary>
    public partial class SourceElement : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<string>
    {
        public string Raw()
        {
            return Source;
        }

        private SourceTypeElement _sourceType;
        public SourceTypeElement SourceType
        {
            get => _sourceType;
            set
            {
                _sourceType = value;
                OnPropertyChanged();
            }
        }

        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Header));
            }
        }

        #region Source Members
        public string Header => $"{No}.";

        public string _value = "";
        public string Source
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public SourceElement()
        {
            InitializeComponent();
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void DropSource(object sender, RoutedEventArgs e)
        {
            // SourceType.DropRecord();
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