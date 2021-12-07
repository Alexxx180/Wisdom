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

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для PlanWorkAdditor.xaml
    /// </summary>
    public partial class PlanWorkAdditor : UserControl
    {
        public PlanWorkAdditor()
        {
            InitializeComponent();
        }

        private static PlanWorkAdditor SetElement()
        {
            PlanWorkAdditor task = new PlanWorkAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanWorkAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddWork(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid workGrid = Parent(addButton);
            ComboBox workName = Cbx(workGrid, 1);
            CheckBox workFew = Chx(workGrid, 2);
            PlanWorkAdditor workAdd = workGrid.Parent as PlanWorkAdditor;
            StackPanel workPanel = Parent(workAdd);
            workPanel.Children.Remove(workAdd);
            if (workFew.IsChecked.Value)
                PlanWork.AddElement(workName.Text, workPanel);
            else
                PlanWorkTask.AddElement(workName.Text, workPanel);
            workPanel.Children.Add(workAdd);
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
