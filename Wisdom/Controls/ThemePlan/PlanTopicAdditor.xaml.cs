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
    /// Логика взаимодействия для PlanTopicAdditor.xaml
    /// </summary>
    public partial class PlanTopicAdditor : UserControl, ITopicIndexing, INotifyPropertyChanged
    {
        public int TopicNo { get; set; }
        public string TopicHeader => $"Раздел {TopicNo}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void SetTopicNo(int no)
        {
            TopicNo = no;
            OnPropertyChanged(nameof(TopicHeader));
        }

        public PlanTopicAdditor()
        {
            InitializeComponent();
            TopicNo = 1;
            OnPropertyChanged(nameof(TopicHeader));
        }

        private static PlanTopicAdditor SetElement()
        {
            PlanTopicAdditor task = new PlanTopicAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanTopicAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddTopic(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid topicGrid = Parent(addButton);

            TextBox topicName = Box(topicGrid, 2);
            TextBox topicHours = Box(topicGrid, 3);

            PlanTopicAdditor topicAdd = topicGrid.Parent as PlanTopicAdditor;
            StackPanel topicPanel = Parent(topicAdd);

            topicPanel.Children.Remove(topicAdd);
            PlanTopic.AddElement(topicName.Text, topicHours.Text, topicPanel);
            PlanTopic.AutoIndexing2(topicPanel);
            topicPanel.Children.Add(topicAdd);
            AutoIndexing(topicPanel);
        } //PlanTheme

        public static void AutoIndexing(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no);
            }
        }

        public static void Index(StackPanel grandGrid, int no)
        {
            ITopicIndexing topic = grandGrid.Children[no] as ITopicIndexing;
            topic.SetTopicNo(no + 1);

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
