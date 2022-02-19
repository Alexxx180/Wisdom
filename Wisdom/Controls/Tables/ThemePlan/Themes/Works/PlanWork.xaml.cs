using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using Wisdom.Controls.Tables.ThemePlan;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : UserControl, INotifyPropertyChanged, IRawData<HashList<Pair<string, string>>>
    {
        public HashList<Pair<string, string>> Raw()
        {
            return new HashList<Pair<string, string>>(
               WorkType, new List<Pair<string, string>> {
                   new Pair<string, string>(TaskName, TaskHours)
               });
        }

        private string _workType;
        public string WorkType
        {
            get => _workType;
            set
            {
                _workType = value;
                OnPropertyChanged();
            }
        }

        private string _taskName;
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }

        private string _taskHours;
        public string TaskHours
        {
            get => _taskHours;
            set
            {
                _taskHours = value;
                OnPropertyChanged();
            }
        }

        public PlanWork()
        {
            InitializeComponent();
        }

        private List<Pair<string, string>> Tasks()
        {
            List<Pair<string, string>> tasks = new List<Pair<string, string>>();
            for (byte i = 0; i < TasksPanel.Children.Count - 1; i++)
            {
                PlanTask task = TasksPanel.Children[i] as PlanTask;
                tasks.Add(task.Raw());
            }
            return tasks;
        }

        public static void AddElements(List<HashList<Pair<string, string>>> works, StackPanel stack)
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

        public static void AddElement(string type, List<Pair<string, string>> tasks, StackPanel stack)
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

        private static PlanWork SetElement(string type, List<Pair<string, string>> tasks)
        {
            PlanWork work = SetElement(type);
            StackPanel workStack = work.GetTaskStack();
            PlanTask.AddElements(tasks, workStack);
            PlanTaskAdditor.AddElement(workStack);
            return work;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}