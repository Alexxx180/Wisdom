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
    /// Логика взаимодействия для PlanTaskAditor.xaml
    /// </summary>
    public partial class PlanTaskAdditor : UserControl, INotifyPropertyChanged, ITaskIndexing
    {
        public int No { get; set; }
        public string TaskHeader => $"{No}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public PlanTaskAdditor()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(TaskHeader));
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
            AutoIndexing(stack);
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
            AutoIndexing(workPanel);
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
