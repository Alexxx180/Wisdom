using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;
using Wisdom.Customing;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Theme of theme plan's topic
    /// </summary>
    public partial class PlanTheme : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<Theme>, IExtendableItems
    {
        #region IRawData Members
        public Theme Raw()
        {
            return new Theme
            {
                Name = ThemeName,
                Hours = ThemeHours,
                Competetions = ThemeCompetetions,
                Level = ThemeLevel,
                Works = Works.GetRaw()
            };
        }

        public void SetElement(Theme theme)
        {
            ThemeName = theme.Name;
            ThemeHours = theme.Hours;
            ThemeCompetetions = theme.Competetions;
            ThemeLevel = theme.Level;

            for (ushort i = 0; i < theme.Works.Count; i++)
            {
                Work workData = theme.Works[i];
                IRawData<Work> work;
                if (workData.Tasks.Count > 1)
                {
                    PlanWork group = new PlanWork
                    {
                        Theme = this
                    };
                    group.SetElement(workData);
                    work = group;
                }
                else
                {
                    PlanWorkTask single = new PlanWorkTask
                    {
                        Theme = this
                    };
                    single.SetElement(workData);
                    work = single;
                }
                Works.Add(work);
            }
            RefreshHours();
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
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region Theme Members
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
                Topic?.RefreshHours();
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

        private ObservableCollection<IRawData<Work>> _works;
        public ObservableCollection<IRawData<Work>> Works
        {
            get => _works;
            set
            {
                _works = value;
                OnPropertyChanged();
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Works));
            Topic.RefreshHours();
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

        public PlanTheme()
        {
            InitializeComponent();
            Index(1);
            Works = new ObservableCollection<IRawData<Work>>();
            Extended = true;
        }

        private void DropTheme(object sender, RoutedEventArgs e)
        {
            Topic.DropTheme(this);
        }

        #region WorksGroup Members
        public void DropWork(IRawData<Work> work)
        {
            _ = Works.Remove(work);
            OnPropertyChanged(nameof(Works));
        }

        public void AddRecord(IRawData<Work> work)
        {
            Works.Add(work);
            OnPropertyChanged(nameof(Works));
        }
        #endregion

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