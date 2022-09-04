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
        public static readonly DependencyProperty
            TopicProperty = DependencyProperty.Register(nameof(Topic),
                typeof(PlanTopic), typeof(PlanThemeAdditor));

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region PlanThemeAdditor Members
        public PlanTopic Topic
        {
            get => GetValue(TopicProperty) as PlanTopic;
            set => SetValue(TopicProperty, value);
        }

        private string _themeName;
        public string ThemeName
        {
            get => _themeName;
            set
            {
                _themeName = value;
                OnPropertyChanged();
            }
        }

        private string _themeHours;
        public string ThemeHours
        {
            get => _themeHours;
            set
            {
                _themeHours = value;
                OnPropertyChanged();
            }
        }

        private string _themeCompetetions;
        public string ThemeCompetetions
        {
            get => _themeCompetetions;
            set
            {
                _themeCompetetions = value;
                OnPropertyChanged();
            }
        }

        private string _themeLevel;
        public string ThemeLevel
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