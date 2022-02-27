﻿using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables.EducationLevels
{
    /// <summary>
    /// Record component containing theme plan education (competetion) levels
    /// </summary>
    public partial class EducationLevel : UserControl, INotifyPropertyChanged, IOptionableIndexing, IRawData<Pair<string, string>>
    {
        public Pair<string, string> Raw()
        {
            return new Pair<string, string>(LevelName, LevelDescription);
        }

        #region IOptionableIndexing Members
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
        #endregion

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                if (Options != null &&
                    !Options.IsManual)
                    LevelNo = No.ToString();
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region EducationLevel Members
        private string _levelNo;
        public string LevelNo
        {
            get => _levelNo;
            set
            {
                if (value == "")
                    return;
                uint no = value.ParseHours();
                _levelNo = $"{no}.";
                if (Options != null &&
                    Options.IsManual)
                    No = no;
                OnPropertyChanged();
            }
        }

        public string _name;
        public string LevelName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _description;
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

        public EducationLevel()
        {
            InitializeComponent();
        }

        private void DropLevel(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        public void SetElement(Pair<string, string> level)
        {
            LevelName = level.Name;
            LevelDescription = level.Value;
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