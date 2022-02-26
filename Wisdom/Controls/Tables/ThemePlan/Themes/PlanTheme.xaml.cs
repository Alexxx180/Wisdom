using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;
using Wisdom.Customing;
using Wisdom.Model;

namespace Wisdom.Controls.Tables.ThemePlan.Themes
{
    /// <summary>
    /// Theme of topic
    /// </summary>
    public partial class PlanTheme : UserControl, INotifyPropertyChanged, IAutoIndexing, IRawData<LevelsList<HashList<Pair<string, string>>>>
    {
        public LevelsList<HashList<Pair<string, string>>> Raw()
        {
            return new LevelsList<HashList<Pair<string, string>>>
                (ThemeName, ThemeHours, ThemeCompetetions, ThemeLevel)
            {
                Values = Works.GetRaw()
            };
        }

        private PlanTopic _options;
        public PlanTopic Options
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
            }
        }

        #region Theme Members
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

        private ObservableCollection<IRawData<HashList<Pair<string, string>>>> _works;
        public ObservableCollection<IRawData<HashList<Pair<string, string>>>> Works
        {
            get => _works;
            set
            {
                _works = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public PlanTheme()
        {
            InitializeComponent();
            Index(1);
        }

        public void Index(uint no)
        {
            No = no;
        }

        public void SetElement(LevelsList<HashList<Pair<string, string>>> theme)
        {
            ThemeName = theme.Name;
            ThemeHours = theme.Hours;
            ThemeCompetetions = theme.Competetions;
            ThemeLevel = theme.Level;
            for (ushort i = 0; i < theme.Values.Count; i++)
            {
                HashList<Pair<string, string>> workData = theme.Values[i];
                IRawData<HashList<Pair<string, string>>> work;
                if (workData.Values.Count > 1)
                {
                    work = new PlanWork();
                }   
                else
                {
                    work = new PlanWorkTask();
                }
                Works.Add(work);
            }
        }

        private void DropTheme(object sender, RoutedEventArgs e)
        {
            Options.Themes.Remove(this);
        }

        //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
        //binding.UpdateTarget();

        //private static List<HashList<Pair<string, string>>>[]
        //    ReviewContent(List<HashList<Pair<string, string>>> works)
        //{
        //    List<HashList<Pair<string, string>>>[] content = new List<HashList<Pair<string, string>>>[2] { 
        //        new List<HashList<Pair<string, string>>>(), new List<HashList<Pair<string, string>>>()
        //    };
        //    for (int no = 0; no < works.Count; no++)
        //    {
        //        int index = works[no].Name == "Содержание" ? 0 : 1;
        //        content[index].Add(works[no]);
        //    }
        //    return content;
        //}

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