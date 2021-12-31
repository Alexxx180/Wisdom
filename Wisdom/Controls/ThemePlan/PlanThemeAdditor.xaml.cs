using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanThemeAdditor.xaml
    /// </summary>
    public partial class PlanThemeAdditor : UserControl, INotifyPropertyChanged, IThemeIndexing
    {
        private int _topicNo { get; set; } //{ get; set; }
        public int SectionNo { get; set; }

        public string ThemeHeader => $"Тема {_topicNo}.{SectionNo}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public PlanThemeAdditor()
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

        private static PlanThemeAdditor SetElement()
        {
            PlanThemeAdditor task = new PlanThemeAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanThemeAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddTheme(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid themeGrid = Parent(addButton);
            
            TextBox themeName = Box(themeGrid, 2);
            TextBox themeHours = Box(themeGrid, 3);
            TextBox themeCompetetions = Box(themeGrid, 4);
            ComboBox themeLevel = Cbx(themeGrid, 5);

            PlanThemeAdditor themeAdd = themeGrid.Parent as PlanThemeAdditor;
            StackPanel themePanel = Parent(themeAdd);

            themePanel.Children.Remove(themeAdd);
            PlanTheme.AddElement(_topicNo, themeName.Text, themeHours.Text, 
                themeCompetetions.Text, themeLevel.Text, themePanel);
            themePanel.Children.Add(themeAdd);
            AutoIndexing(themePanel);
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
