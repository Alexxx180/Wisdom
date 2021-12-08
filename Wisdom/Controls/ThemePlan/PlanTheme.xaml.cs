using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanTheme.xaml
    /// </summary>
    public partial class PlanTheme : UserControl, INotifyPropertyChanged, IThemeIndexing
    {
        public LevelsList<HashList<String2>> Theme => new
            LevelsList<HashList<String2>>( //ThemeHeader + " " + 
                ThemeName.Text, ThemeHours.Text,
                 ThemeCompetetions.Text, ThemeLevel.Text
            )
        {
            Values = Works()
        };

        private int _topicNo { get; set; } //{ get; set; }
        public int SectionNo { get; set; }

        public string ThemeHeader => $"Тема {_topicNo}.{SectionNo}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private List<HashList<String2>> Works()
        {
            List<HashList<String2>> works = new List<HashList<String2>>();
            for (byte i = 0; i < WorksPanel.Children.Count - 1; i++)
            {
                IWork work = WorksPanel.Children[i] as IWork;
                System.Diagnostics.Trace.WriteLine(WorksPanel.Children[i]);
                works.Add(work.Work);
            }
            return works;
        }

        public PlanTheme()
        {
            InitializeComponent();
            SectionNo = 1;
            _topicNo = 1;
            OnPropertyChanged(nameof(ThemeHeader));
        }

        public void SetTopicNo(int no)
        {
            _topicNo = no;
            OnPropertyChanged(nameof(ThemeHeader));
        }

        public void SetSectionNo(int no)
        {
            SectionNo = no;
            OnPropertyChanged(nameof(ThemeHeader));
        }

        public static void PassTopicNo(StackPanel themePanel, int no)
        {
            for (int i = 0; i < themePanel.Children.Count; i++)
            {
                IThemeIndexing theme = themePanel.Children[i] as IThemeIndexing;
                theme.SetTopicNo(no);
            }
        }

        public static void AddElements(List<LevelsList<HashList<String2>>> themes, StackPanel stack)
        {
            for (byte i = 0; i < themes.Count; i++)
                AddElement(themes[i].Name, themes[i].Hours, themes[i].Competetions,
                    themes[i].Level, themes[i].Values, stack);
            PlanThemeAdditor.AddElement(stack);
            AutoIndexing(stack);
        }

        public static void AddElement(int no, string name,
            string hours, string masteredCompetetions,
            string level, StackPanel stack)
        {
            PlanTheme element = SetElement(name, hours, masteredCompetetions, level);
            element.SetTopicNo(no);
            StackPanel themeStack = element.GetWorkStack();
            PlanThemeContent.AddElement("Содержание", themeStack);
            PlanWorkAdditor.AddElement(themeStack);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            string hours, string masteredCompetetions,
            string level, List<HashList<String2>> works, 
            StackPanel stack)
        {
            PlanTheme element = SetElement(name, hours, masteredCompetetions, level, works);
            _ = stack.Children.Add(element);
        }

        public static void AutoIndexing(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no);
            }
        }

        public static void Index(StackPanel grandGrid, int no)
        {
            IThemeIndexing theme = grandGrid.Children[no] as IThemeIndexing;
            theme.SetSectionNo(no + 1);
        }

        private StackPanel GetWorkStack()
        {
            Grid themeGrid = Content as Grid;
            return Panel(themeGrid, 6);
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

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            //binding.UpdateTarget();
        }

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
            string level, List<HashList<String2>> works)
        {
            PlanTheme theme = SetElement(name, hours, masteredCompetetions, level);
            StackPanel themeStack = theme.GetWorkStack();
            List<HashList<String2>>[] content = ReviewContent(works);
            PlanThemeContent.AddElements(content[0], themeStack);
            PlanWork.AddElements(content[1], themeStack);
            PlanWorkAdditor.AddElement(themeStack);
            return theme;
        }

        private static List<HashList<String2>>[] ReviewContent(List<HashList<String2>> works)
        {
            List<HashList<String2>>[] content = new List<HashList<String2>>[2] { 
                new List<HashList<String2>>(), new List<HashList<String2>>()
            };
            for (int no = 0; no < works.Count; no++)
            {
                int index = works[no].Name == "Содержание" ? 0 : 1;
                content[index].Add(works[no]);
            }
            return content;
        }

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }
    }
}
