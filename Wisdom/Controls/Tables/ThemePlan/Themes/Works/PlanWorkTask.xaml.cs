using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with single task of theme plan
    /// </summary>
    public partial class PlanWorkTask : UserControl, INotifyPropertyChanged, IRawData<HashList<Pair<string, string>>>
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}