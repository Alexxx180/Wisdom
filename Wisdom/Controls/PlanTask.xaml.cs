﻿using System;
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
    public partial class PlanTask : UserControl, IAuto
    {
        public PlanTask()
        {
            InitializeComponent();
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
            AutoIndexing(workPanel, 1, '.');
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

        public static void AutoIndexing(StackPanel grandGrid, int pos, char mark)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no, pos, mark);
            }
        }

        public static void Index(StackPanel grandGrid, int no, int pos, char mark)
        {
            UserControl task = grandGrid.Children[no] as UserControl;
            Grid content = task.Content as Grid;
            TextBlock taskNo = Txt(content, pos);
            taskNo.Text = $"{no + 1}{mark}";
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