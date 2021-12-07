using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wisdom.Model;
using static Wisdom.Customing.Converters;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для PlanWorkTask.xaml
    /// </summary>
    public partial class PlanWorkTask : UserControl
    {
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

        private static readonly Regex _hours = new Regex("^([1-9]|[1-9]\\d\\d?)$");//v\\d
        private void Hours(object sender, TextCompositionEventArgs e)
        {
            TextBox box = e.OriginalSource as TextBox;
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !_hours.IsMatch(full);
        }
        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;
            if (textBox.SelectionStart != -1)
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            text = text.Insert(textBox.CaretIndex, newText);
            return text;
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                string proposedText = GetProposedText(textBox, pastedText);

                if (!_hours.IsMatch(proposedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
