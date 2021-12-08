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
    /// Логика взаимодействия для PlanThemeContent.xaml
    /// </summary>
    public partial class PlanThemeContent : UserControl, IWork
    {
        public HashList<String2> Work => new HashList<String2>(WorkType.Text, Tasks());

        public PlanThemeContent()
        {
            InitializeComponent();
        }

        private List<String2> Tasks()
        {
            List<String2> tasks = new List<String2>();
            for (byte i = 0; i < TasksPanel.Children.Count - 1; i++)
            {
                PlanTask task = TasksPanel.Children[i] as PlanTask;
                tasks.Add(task.Task);
            }
            return tasks;
        }

        public static void AddElement(string type, StackPanel stack)
        {
            PlanThemeContent element = SetElement(type);
            PlanTaskAdditor.AddElement(element.GetTaskStack());
            _ = stack.Children.Add(element);
        }

        public static void AddElements(List<HashList<String2>> works, StackPanel stack)
        {
            for (byte i = 0; i < works.Count; i++)
                AddElement(works[i].Name, works[i].Values, stack);
            //AutoIndexing(stack, 1, '.');
        }

        public static void AddElement(string type, List<String2> tasks, StackPanel stack)
        {
            PlanThemeContent element = SetElement(type, tasks);
            _ = stack.Children.Add(element);
        }

        private StackPanel GetTaskStack()
        {
            Grid contentGrid = Content as Grid;
            return Panel(contentGrid, 4);
        }

        private void DropWork(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid taskGrid = Parent(dropButton);
            PlanThemeContent task = taskGrid.Parent as PlanThemeContent;
            StackPanel themePanel = Parent(task);
            themePanel.Children.Remove(task);
        }

        private static PlanThemeContent SetElement(string type)
        {
            PlanThemeContent task = new PlanThemeContent();
            Grid taskGrid = task.Content as Grid;
            TextBlock contentType = Txt(taskGrid, 0);
            contentType.Text = type;
            return task;
        }

        private static PlanThemeContent SetElement(string type, List<String2> tasks)
        {
            PlanThemeContent content = SetElement(type);
            StackPanel contentStack = content.GetTaskStack();
            PlanTask.AddElements(tasks, contentStack);
            PlanTaskAdditor.AddElement(contentStack);
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
