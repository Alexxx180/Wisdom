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
    /// Логика взаимодействия для PlanTopic.xaml
    /// </summary>
    public partial class PlanTopic : UserControl
    {
        public PlanTopic()
        {
            InitializeComponent();
        }

        public static void AddElements(List<HoursList<LevelsList<HashList<String2>>>> themes, StackPanel stack)
        {
            for (byte i = 0; i < themes.Count; i++)
                AddElement(themes[i].Name, themes[i].Hours,
                   themes[i].Values, stack);
            //AutoIndexing(stack, 1, '.');
        }

        public static void AddElement(string name,
            string hours, StackPanel stack)
        {
            PlanTopic element = SetElement(name, hours);
            StackPanel topicStack = element.GetThemeStack();
            PlanThemeAdditor.AddElement(topicStack);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            string hours, List<LevelsList<HashList<String2>>> themes,
            StackPanel stack)
        {
            PlanTopic element = SetElement(name, hours, themes);
            _ = stack.Children.Add(element);
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
            Grid topic = task.Content as Grid;
            TextBlock taskNo = Txt(topic, pos);
            taskNo.Text = $"{no + 1}{mark}";
        }

        private StackPanel GetThemeStack()
        {
            Grid topicGrid = Content as Grid;
            return Panel(topicGrid, 6);
        }

        private void DropTopic(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid topicGrid = Parent(dropButton);
            PlanTopic topic = topicGrid.Parent as PlanTopic;
            StackPanel topicPanel = Parent(topic);
            topicPanel.Children.Remove(topic);
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            //binding.UpdateTarget();
        }

        private static PlanTopic SetElement(string name,
            string hours)
        {
            PlanTopic topic = new PlanTopic();
            Grid topicGrid = topic.Content as Grid;
            TextBox topicName = Box(topicGrid, 2);
            TextBox topicHours = Box(topicGrid, 3);
            topicName.Text = name;
            topicHours.Text = hours;
            return topic;
        }

        private static PlanTopic SetElement(string name,
            string hours, List<LevelsList<HashList<String2>>> themes)
        {
            PlanTopic topic = SetElement(name, hours);
            StackPanel topicStack = topic.GetThemeStack();
            PlanTheme.AddElements(themes, topicStack);
            PlanThemeAdditor.AddElement(topicStack);
            return topic;
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
