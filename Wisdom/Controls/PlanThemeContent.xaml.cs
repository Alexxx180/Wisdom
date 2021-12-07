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
using static Wisdom.Customing.Decorators;
using static Wisdom.Customing.Converters;
using Wisdom.Model;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для PlanThemeContent.xaml
    /// </summary>
    public partial class PlanThemeContent : UserControl
    {
        public PlanThemeContent()
        {
            InitializeComponent();
        }

        public static void AddElement(string type, StackPanel stack)
        {
            PlanThemeContent element = SetElement(type);
            PlanTaskAdditor.AddElement(element.GetTaskStack());
            _ = stack.Children.Add(element);
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
