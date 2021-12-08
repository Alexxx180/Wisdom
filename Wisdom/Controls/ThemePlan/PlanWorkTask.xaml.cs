using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls.ThemePlan
{
    /// <summary>
    /// Логика взаимодействия для PlanWorkTask.xaml
    /// </summary>
    public partial class PlanWorkTask : UserControl, IWork
    {
        public HashList<String2> Work => new HashList<String2>(
            WorkType.Text,
            new List<String2> {
                new String2(TaskName.Text, TaskHours.Text)
            });

        public PlanWorkTask()
        {
            InitializeComponent();
        }

        public static void AddElement(string type, StackPanel stack)
        {
            PlanWorkTask element = SetElement(type);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string type, string name, string value, StackPanel stack)
        {
            PlanWorkTask element = SetElement(type, name, value);
            _ = stack.Children.Add(element);
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid taskGrid = Parent(dropButton);
            PlanWorkTask task = taskGrid.Parent as PlanWorkTask;
            StackPanel themePanel = Parent(task);
            themePanel.Children.Remove(task);
        }

        private static PlanWorkTask SetElement(string type)
        {
            PlanWorkTask task = new PlanWorkTask();
            Grid taskGrid = task.Content as Grid;
            TextBlock workType = Txt(taskGrid, 1);
            workType.Text = type;
            return task;
        }

        private static PlanWorkTask SetElement(string type, string name, string value)
        {
            PlanWorkTask task = new PlanWorkTask();
            Grid taskGrid = task.Content as Grid;
            TextBlock workType = Txt(taskGrid, 1);
            TextBox taskName = Box(taskGrid, 2);
            TextBox taskHours = Box(taskGrid, 3);
            workType.Text = type;
            taskName.Text = name;
            taskHours.Text = value;
            return task;
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
