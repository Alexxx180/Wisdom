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
    /// Логика взаимодействия для PlanWork.xaml
    /// </summary>
    public partial class PlanWork : UserControl, IWork
    {
        public HashList<String2> Work => new HashList<String2>(WorkType.Text, Tasks());

        public PlanWork()
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

        public static void AddElements(List<HashList<String2>> works, StackPanel stack)
        {
            for (byte i = 0; i < works.Count; i++)
            {
                if (works[i].Values.Count <= 1)
                    PlanWorkTask.AddElement(works[i].Name, works[i].Values[0].Name,
                        works[i].Values[0].Value, stack);
                else
                    AddElement(works[i].Name, works[i].Values, stack);
            }
            //AutoIndexing(stack, 1, '.');
        }

        public static void AddElement(string type, StackPanel stack)
        {
            PlanWork element = SetElement(type);
            PlanTaskAdditor.AddElement(element.GetTaskStack());
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string type, List<String2> tasks, StackPanel stack)
        {
            PlanWork element = SetElement(type, tasks);
            _ = stack.Children.Add(element);
        }

        private StackPanel GetTaskStack()
        {
            Grid workGrid = Content as Grid;
            return Panel(workGrid, 5);
        }

        private void DropWork(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid taskGrid = Parent(dropButton);
            PlanWork task = taskGrid.Parent as PlanWork;
            StackPanel themePanel = Parent(task);
            themePanel.Children.Remove(task);
        }

        private static PlanWork SetElement(string type)
        {
            PlanWork task = new PlanWork();
            Grid taskGrid = task.Content as Grid;
            TextBlock workType = Txt(taskGrid, 1);
            workType.Text = type;
            return task;
        }

        private static PlanWork SetElement(string type, List<String2> tasks)
        {
            PlanWork work = SetElement(type);
            StackPanel workStack = work.GetTaskStack();
            PlanTask.AddElements(tasks, workStack);
            PlanTaskAdditor.AddElement(workStack);
            return work;
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
