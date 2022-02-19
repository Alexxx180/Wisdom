using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks
{
    /// <summary>
    /// Task of work
    /// </summary>
    public partial class PlanTask : UserControl, INotifyPropertyChanged, IAutoIndexing
    {
        public Pair<string, string> Raw()
        {
            return new Pair<string, string>(TaskName, TaskHours);
        }

        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TaskHeader));
            }
        }

        public string TaskHeader => $"{No}.";

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

        public PlanTask()
        {
            InitializeComponent();
        }

        public void Index(uint no)
        {
            No = no;
        }

        public static void AddElements(List<Pair<string, string>> tasks, StackPanel stack)
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
            IAutoIndexing task = grandGrid.Children[no] as IAutoIndexing;
            uint newIndex = (no + 1).ToUInt();
            task.Index(newIndex);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}