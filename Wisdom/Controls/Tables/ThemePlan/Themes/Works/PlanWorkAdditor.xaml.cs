using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Special component to add new work to theme
    /// </summary>
    public partial class PlanWorkAdditor : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ThemeProperty = DependencyProperty.Register(nameof(Theme),
                typeof(PlanTheme), typeof(PlanWorkAdditor));

        public static readonly DependencyProperty
            TypesProperty = DependencyProperty.Register(nameof(Types),
                typeof(ObservableCollection<string>),
                typeof(PlanWorkAdditor));

        #region WorkAdditor Members
        public static ObservableCollection<string> AvailableTypes { get; set; }

        public ObservableCollection<string> Types
        {
            get => GetValue(TypesProperty) as ObservableCollection<string>;
            set => SetValue(TypesProperty, value);
        }

        public PlanTheme Theme
        {
            get => GetValue(ThemeProperty) as PlanTheme;
            set => SetValue(ThemeProperty, value);
        }

        public string _workType;
        public string WorkType
        {
            get => _workType;
            set
            {
                _workType = value;
                OnPropertyChanged();
            }
        }

        public bool _isGroup;
        public bool IsGroup
        {
            get => _isGroup;
            set
            {
                _isGroup = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public PlanWorkAdditor()
        {
            InitializeComponent();
        }

        private void AddWork(object sender, RoutedEventArgs e)
        {
            IRawData<Work> work;

            if (IsGroup)
            {
                PlanWork group = new PlanWork
                {
                    WorkType = WorkType,
                    Theme = Theme
                };
                work = group;
            }
            else
            {
                PlanWorkTask single = new PlanWorkTask
                {
                    WorkType = WorkType,
                    Theme = Theme
                };
                work = single;
            }

            Theme.AddRecord(work);
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