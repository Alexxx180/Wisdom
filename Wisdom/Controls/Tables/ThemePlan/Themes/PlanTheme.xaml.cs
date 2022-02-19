using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works;
using Wisdom.Model;
using static Wisdom.Customing.Converters;

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
                Values = GetWorks()
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

        private uint _topicNo;
        public uint TopicNo
        {
            get => _topicNo;
            set
            {
                _topicNo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ThemeHeader));
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

        #region Theme Members
        public string ThemeHeader => $"Тема {TopicNo}.{No}.";

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

        private ObservableCollection<UserControl> _works;
        public ObservableCollection<UserControl> Works
        {
            get => _works;
            set
            {
                _works = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private List<HashList<Pair<string, string>>> GetWorks()
        {
            List<HashList<Pair<string, string>>> works = new List<HashList<Pair<string, string>>>();
            for (byte i = 0; i < WorksPanel.Children.Count - 1; i++)
            {
                IWork work = WorksPanel.Children[i] as IWork;
                works.Add(work.Work);
            }
            return works;
        }

        public PlanTheme()
        {
            InitializeComponent();
            Index(1);
            TopicNo = 1;
        }

        public void Index(uint no)
        {
            No = no;
        }

        private void DropTheme(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid themeGrid = Parent(dropButton);
            PlanTheme theme = themeGrid.Parent as PlanTheme;
            StackPanel themePanel = Parent(theme);
            themePanel.Children.Remove(theme);
            AutoIndexing(themePanel);
        }

        //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
        //binding.UpdateTarget();

        private static PlanTheme SetElement(string name,
            string hours, string masteredCompetetions,
            string level)
        {
            PlanTheme theme = new PlanTheme();
            Grid themeGrid = theme.Content as Grid;
            TextBox themeName = Box(themeGrid, 2);
            TextBox themeHours = Box(themeGrid, 3);
            TextBox themeCompetetions = Box(themeGrid, 4);
            ComboBox themeLevel = Cbx(themeGrid, 5);
            themeName.Text = name;
            themeHours.Text = hours;
            themeCompetetions.Text = masteredCompetetions;
            themeLevel.Text = level;
            return theme;
        }

        private static PlanTheme SetElement(string name,
            string hours, string masteredCompetetions,
            string level, List<HashList<Pair<string, string>>> works)
        {
            PlanTheme theme = SetElement(name, hours, masteredCompetetions, level);
            StackPanel themeStack = theme.GetWorkStack();
            List<HashList<Pair<string, string>>>[] content = ReviewContent(works);
            PlanThemeContent.AddElements(content[0], themeStack);
            PlanWork.AddElements(content[1], themeStack);
            PlanWorkAdditor.AddElement(themeStack);
            return theme;
        }

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