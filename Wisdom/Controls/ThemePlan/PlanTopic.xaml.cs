using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanTopic.xaml
    /// </summary>
    public partial class PlanTopic : UserControl, ITopicIndexing, INotifyPropertyChanged
    {
        public HoursList<LevelsList<HashList<String2>>> Topic => new
            HoursList<LevelsList<HashList<String2>>>( //TopicHeader + " " + 
                TopicName.Text, TopicHours.Text
            )
        {
            Values = Themes()
        };

        public int TopicNo { get; set; }
        public string TopicHeader => $"Раздел {TopicNo}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public PlanTopic()
        {
            InitializeComponent();
            TopicNo = 1;
            OnPropertyChanged(nameof(TopicHeader));
        }

        public static List<HoursList<LevelsList<HashList<String2>>>> FullThemePlan(StackPanel planStack)
        {
            List<HoursList<LevelsList<HashList<String2>>>> topics =
                new List<HoursList<LevelsList<HashList<String2>>>>();
            for (byte i = 0; i < planStack.Children.Count - 1; i++)
            {
                PlanTopic topic = planStack.Children[i] as PlanTopic;
                topics.Add(topic.Topic);
            }
            return topics;
        }

        public static void DropPlan(StackPanel plan)
        {
            plan.Children.Clear();
        }

        private List<LevelsList<HashList<String2>>> Themes()
        {
            List<LevelsList<HashList<String2>>> themes = new List<LevelsList<HashList<String2>>>();
            for (byte i = 0; i < ThemePanel.Children.Count - 1; i++)
            {
                PlanTheme theme = ThemePanel.Children[i] as PlanTheme;
                themes.Add(theme.Theme);
            }
            return themes;
        }

        public void SetTopicNo(int no)
        {
            TopicNo = no;
            OnPropertyChanged(nameof(TopicHeader));
        }

        public static void AddElements(List<HoursList<LevelsList<HashList<String2>>>> topics, StackPanel stack)
        {
            for (byte i = 0; i < topics.Count; i++)
                AddElement(topics[i].Name, topics[i].Hours,
                   topics[i].Values, stack);
            PlanTopicAdditor.AddElement(stack);
            AutoIndexing3(stack);
            AutoIndexing(stack);
        }

        public static void AddElement(string name,
            string hours, StackPanel stack)
        {
            PlanTopic element = SetElement(name, hours);
            StackPanel topicStack = element.GetThemeStack();
            PlanThemeAdditor.AddElement(topicStack);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            string hours, List<LevelsList<HashList<String2>>> themes,
            StackPanel stack)
        {
            PlanTopic element = SetElement(name, hours, themes);
            _ = stack.Children.Add(element);
        }

        public StackPanel GetThemeStack()
        {
            Grid topicGrid = Content as Grid;
            return Panel(topicGrid, 4);
        }

        private void DropTopic(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid topicGrid = Parent(dropButton);
            PlanTopic topic = topicGrid.Parent as PlanTopic;
            StackPanel topicPanel = Parent(topic);
            topicPanel.Children.Remove(topic);
            AutoIndexing3(topicPanel);
            AutoIndexing(topicPanel);
        }

        public static void AutoIndexing(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                Index(grandGrid, no);
        }

        public static void Index(StackPanel grandGrid, int no)
        {
            ITopicIndexing theme = grandGrid.Children[no] as ITopicIndexing;
            theme.SetTopicNo(no + 1);
        }

        public static void AutoIndexing2(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                Index2(grandGrid, no);
        }

        public static void Index2(StackPanel grandGrid, int no)
        {
            PlanTopic topic = grandGrid.Children[no] as PlanTopic;
            PlanTheme.PassTopicNo(topic.GetThemeStack(), no + 1);
        }

        public static void AutoIndexing3(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                Index3(grandGrid, no);
        }

        public static void Index3(StackPanel grandGrid, int no)
        {
            PlanTopic topic = grandGrid.Children[no] as PlanTopic;
            if (topic != null)
                PlanTheme.PassTopicNo(topic.GetThemeStack(), no + 1);
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            //binding.UpdateTarget();
        }

        private static PlanTopic SetElement(string name,
            string hours)
        {
            PlanTopic topic = new PlanTopic();
            Grid topicGrid = topic.Content as Grid;
            TextBox topicName = Box(topicGrid, 2);
            TextBox topicHours = Box(topicGrid, 3);
            topicName.Text = name;
            topicHours.Text = hours;
            return topic;
        }

        private static PlanTopic SetElement(string name,
            string hours, List<LevelsList<HashList<String2>>> themes)
        {
            PlanTopic topic = SetElement(name, hours);
            StackPanel topicStack = topic.GetThemeStack();
            PlanTheme.AddElements(themes, topicStack);
            return topic;
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
