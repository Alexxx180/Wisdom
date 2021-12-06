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
    /// Логика взаимодействия для PlanTask.xaml
    /// </summary>
    public partial class PlanTask : UserControl
    {
        public PlanTask()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> tasks, StackPanel stack)
        {
            for (byte i = 0; i < tasks.Count; i++)
            {
                PlanTask metaElement = SetElement(tasks[i].Name, tasks[i].Value);
                _ = stack.Children.Add(metaElement);
            }
        }

        private void DropTask(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid taskGrid = Parent(dropButton);
            PlanTask task = taskGrid.Parent as PlanTask;
            StackPanel workPanel = Parent(task);
            workPanel.Children.Remove(dropButton);
        }

        private static PlanTask SetElement(string name, string value)
        {
            PlanTask task = new PlanTask();
            Grid taskGrid = task.Content as Grid;
            TextBlock taskName = Txt(taskGrid, 1);
            TextBlock taskHours = Txt(taskGrid, 2);
            taskName.Text = name;
            taskHours.Text = value;
            return task;
        }

        private void DeleteAuto(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            Grid subContent = deleteButton.Tag as Grid;
            //TextBox hours = Box(subContent, 3);
            //Binding bind = hours.Tag as Binding;

            //StackPanel contentStack = Parent(subContent);
            //Grid content = Parent(contentStack);
            //StackPanel themeStack = Parent(content);
            //Grid theme = Parent(themeStack);

            //TextBox refer = Box(theme, 3);
            //MultiBinding reCalculation = DeleteBindFromMulti(refer,
            //    BackgroundProperty, new UsedValuesConverter(), bind);

            //_ = SetBind(refer, BackgroundProperty, reCalculation);

            //RemoveTableRow(subContent.Tag);
            AutoIndexing(RemoveGrid(subContent), 1, '.');
        }

        public static StackPanel RemoveGrid(FrameworkElement element)
        {
            StackPanel grandGrid = element.Parent as StackPanel;
            grandGrid.Children.Remove(element);
            return grandGrid;
        }

        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                PlanTask task = grandGrid.Children[no] as PlanTask;
                Grid content = task.Content as Grid;
                Label taskNo = Lab(content, pos);
                taskNo.Content = $"{no + 1}{mark}";
            }
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
