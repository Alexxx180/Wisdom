using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Special component to add new theme to topic
    /// </summary>
    public partial class PlanThemeAdditor : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        private PlanTopic _topic;
        public PlanTopic Topic
        {
            get => _topic;
            set
            {
                _topic = value;
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
                OnPropertyChanged(nameof(ThemeHeader));
            }
        }

        #region PlanThemeAdditor Members
        public string Prefix => "Тема";
        public string ThemeHeader => $"{Prefix} {Topic.No}.{No}.";

        private string _themeName;
        internal string ThemeName
        {
            get => _themeName;
            set
            {
                _themeName = value;
                OnPropertyChanged();
            }
        }

        private string _themeHours;
        internal string ThemeHours
        {
            get => _themeHours;
            set
            {
                _themeHours = value;
                OnPropertyChanged();
            }
        }

        private string _themeCompetetions;
        internal string ThemeCompetetions
        {
            get => _themeCompetetions;
            set
            {
                _themeCompetetions = value;
                OnPropertyChanged();
            }
        }

        private string _themeLevel;
        internal string ThemeLevel
        {
            get => _themeLevel;
            set
            {
                _themeLevel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public PlanThemeAdditor()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void AddTheme(object sender, RoutedEventArgs e)
        {
            PlanTheme theme = new PlanTheme
            {
                No = No,
                ThemeName = ThemeName,
                ThemeHours = ThemeHours,
                ThemeCompetetions = ThemeCompetetions,
                ThemeLevel = ThemeLevel
            };
            //Topic.AddRecord(theme);
            Index(No + 1);
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