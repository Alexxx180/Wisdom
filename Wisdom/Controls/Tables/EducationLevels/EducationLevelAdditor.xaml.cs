using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Customing;

namespace Wisdom.Controls.Tables.EducationLevels
{
    /// <summary>
    /// Special component to add new education (competetion) level
    /// </summary>
    public partial class EducationLevelAdditor : UserControl, INotifyPropertyChanged, IOptionableIndexing
    {
        public static readonly DependencyProperty
            OptionsProperty = DependencyProperty.Register(nameof(Options),
                typeof(AutoPanel), typeof(EducationLevelAdditor));

        #region IOptionableIndexing
        public AutoPanel Options
        {
            get => GetValue(OptionsProperty) as AutoPanel;
            set => SetValue(OptionsProperty, value);
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
                OnPropertyChanged();

                if (Options is null ||
                    !Options.IsManual)
                    LevelNo = value.ToString();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region LevelAdditor Members
        private string _levelNo;
        public string LevelNo
        {
            get => _levelNo;
            set
            {
                if (value == "")
                    return;

                uint no = value.ParseHours();
                _levelNo = no.ToString();
                OnPropertyChanged();

                if (Options != null &&
                    Options.IsManual)
                    Index(no);
            }
        }

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
            Index(1);
        }

        private void AddLevel(object sender, RoutedEventArgs e)
        {
            EducationLevel level = new EducationLevel
            {
                LevelNo = LevelNo,
                Options = Options,
                LevelName = LevelName,
                LevelDescription = LevelDescription
            };

            if (Options.AddRecord(level))
            {
                Index(No + 1);
            }
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