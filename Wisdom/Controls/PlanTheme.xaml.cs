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
    /// Логика взаимодействия для PlanTheme.xaml
    /// </summary>
    public partial class PlanTheme : UserControl
    {
        public PlanTheme()
        {
            InitializeComponent();
        }

        public static void AddElements(List<LevelsList<HashList<String2>>> works, StackPanel stack)
        {
            for (byte i = 0; i < works.Count; i++)
                AddElement(works[i].Name, works[i].Hours, works[i].Competetions,
                    works[i].Level, works[i].Values, stack);
            //AutoIndexing(stack, 1, '.');
        }

        public static void AddElement(string name,
            string hours, string masteredCompetetions,
            string level, StackPanel stack)
        {
            PlanTheme element = SetElement(name, hours, masteredCompetetions, level);
            StackPanel themeStack = element.GetWorkStack();
            PlanThemeContent.AddElement("Содержание", themeStack);
            PlanWorkAdditor.AddElement(themeStack);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            string hours, string masteredCompetetions,
            string level, List<HashList<String2>> works, 
            StackPanel stack)
        {
            PlanTheme element = SetElement(name, hours, masteredCompetetions, level, works);
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
            Grid theme = task.Content as Grid;
            TextBlock taskNo = Txt(theme, pos);
            taskNo.Text = $"{no + 1}{mark}";
        }

        private StackPanel GetWorkStack()
        {
            Grid themeGrid = Content as Grid;
            return Panel(themeGrid, 6);
        }

        private void DropTheme(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid themeGrid = Parent(dropButton);
            PlanTheme theme = themeGrid.Parent as PlanTheme;
            StackPanel themePanel = Parent(theme);
            themePanel.Children.Remove(theme);
        }

        private void Levels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox combobox = sender as ComboBox;
            //BindingExpression binding = GetBindExpress(combobox, ComboBox.ItemsSourceProperty);
            //binding.UpdateTarget();
        }

        private static PlanTheme SetElement(string name,
            string hours, string masteredCompetetions,
            string level)
        {
            PlanTheme theme = new PlanTheme();
            Grid themeGrid = theme.Content as Grid;
            TextBox themeName = Box(themeGrid, 2);
            TextBox themeHours = Box(themeGrid, 3);
            TextBox themeCompetetions = Box(themeGrid, 4);
            ComboBox themeLevel = Cbx(themeGrid, 5);
            themeName.Text = name;
            themeHours.Text = hours;
            themeCompetetions.Text = masteredCompetetions;
            themeLevel.Text = level;
            return theme;
        }

        private static PlanTheme SetElement(string name,
            string hours, string masteredCompetetions,
            string level, List<HashList<String2>> works)
        {
            PlanTheme theme = SetElement(name, hours, masteredCompetetions, level);
            StackPanel themeStack = theme.GetWorkStack();
            PlanThemeContent.AddElement("", themeStack);
            PlanWork.AddElements(works, themeStack);
            PlanWorkAdditor.AddElement(themeStack);
            return theme;
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
