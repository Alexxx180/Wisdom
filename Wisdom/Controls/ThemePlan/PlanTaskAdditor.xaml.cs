using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanTaskAditor.xaml
    /// </summary>
    public partial class PlanTaskAdditor : UserControl, IAuto
    {
        public PlanTaskAdditor()
        {
            InitializeComponent();
        }

        private static PlanTaskAdditor SetElement()
        {
            PlanTaskAdditor task = new PlanTaskAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanTaskAdditor element = SetElement();
            _ = stack.Children.Add(element);
            AutoIndexing(stack, 1, '.');
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid taskGrid = Parent(addButton);
            TextBox taskName = Box(taskGrid, 2);
            TextBox taskHours = Box(taskGrid, 3);
            PlanTaskAdditor task = taskGrid.Parent as PlanTaskAdditor;
            StackPanel workPanel = Parent(task);
            workPanel.Children.Remove(task);
            PlanTask.AddElement(taskName.Text, taskHours.Text, workPanel);
            workPanel.Children.Add(task);
            AutoIndexing(workPanel, 1, '.');
        }

        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no, pos, mark);
            }
        }

        public static void Index(StackPanel grandGrid, int no, int pos, char mark)
        {
            UserControl task = grandGrid.Children[no] as UserControl;
            Grid content = task.Content as Grid;
            TextBlock taskNo = Txt(content, pos);
            taskNo.Text = $"{no + 1}{mark}";
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
