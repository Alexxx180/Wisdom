﻿using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Tables.EducationLevels
{
    /// <summary>
    /// Special component to add new education (competetion) level
    /// </summary>
    public partial class EducationLevelAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        private AutoPanel _options;
        public AutoPanel Options
        {
            get => _options;
            set
            {
                _options = value;
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
                OnPropertyChanged(nameof(LevelHeader));
            }
        }

        #region LevelAdditor Members
        public string LevelHeader => $"{No}.";

        public string _name = "";
        public string LevelName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _description = "";
        public string LevelDescription
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public EducationLevelAdditor()
        {
            InitializeComponent();
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void AddLevel(object sender, RoutedEventArgs e)
        {
            EducationLevel level = new EducationLevel
            {
                LevelName = LevelName,
                LevelDescription = LevelDescription
            };
            Options.AddRecord(level);
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