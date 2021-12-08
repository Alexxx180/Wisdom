using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanTask.xaml
    /// </summary>
    public partial class PlanTask : UserControl
    {
        public String2 Task => new String2(TaskName.Text, TaskHours.Text);

        public PlanTask()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> tasks, StackPanel stack)
        {
            for (byte i = 0; i < tasks.Count; i++)
                AddElement(tasks[i].Name, tasks[i].Value, stack);
            //AutoIndexing(stack, 1, '.');
        }

        public static void AddElement(string name, string value, StackPanel stack)
        {
            PlanTask element = SetElement(name, value);
            _ = stack.Children.Add(element);
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid taskGrid = Parent(dropButton);
            PlanTask task = taskGrid.Parent as PlanTask;
            StackPanel workPanel = Parent(task);
            workPanel.Children.Remove(task);
            AutoIndexing(workPanel, 1, '.');
        }

        private static PlanTask SetElement(string name, string value)
        {
            PlanTask task = new PlanTask();
            Grid taskGrid = task.Content as Grid;
            TextBox taskName = Box(taskGrid, 2);
            TextBox taskHours = Box(taskGrid, 3);
            taskName.Text = name;
            taskHours.Text = value;
            return task;
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