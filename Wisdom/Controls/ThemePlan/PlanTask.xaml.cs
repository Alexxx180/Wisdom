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
    /// Логика взаимодействия для PlanTask.xaml
    /// </summary>
    public partial class PlanTask : UserControl, INotifyPropertyChanged, ITaskIndexing
    {
        public String2 Task => new String2(TaskName.Text, TaskHours.Text);

        public int No { get; set; }
        public string TaskHeader => $"{No}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public PlanTask()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(TaskHeader));
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
            AutoIndexing(workPanel);
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

        public static void AutoIndexing(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no);
            }
        }

        public static void Index(StackPanel grandGrid, int no)
        {
            ITaskIndexing task = grandGrid.Children[no] as ITaskIndexing;
            task.SetNo(no + 1);
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