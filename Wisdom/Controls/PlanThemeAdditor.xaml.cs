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
    /// Логика взаимодействия для PlanThemeAdditor.xaml
    /// </summary>
    public partial class PlanThemeAdditor : UserControl
    {
        public PlanThemeAdditor()
        {
            InitializeComponent();
        }

        private static PlanThemeAdditor SetElement()
        {
            PlanThemeAdditor task = new PlanThemeAdditor();
            return task;
        }

        public static void AddElement(StackPanel stack)
        {
            PlanThemeAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddTheme(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid themeGrid = Parent(addButton);
            
            TextBox themeName = Box(themeGrid, 2);
            TextBox themeHours = Box(themeGrid, 3);
            TextBox themeCompetetions = Box(themeGrid, 4);
            ComboBox themeLevel = Cbx(themeGrid, 5);

            PlanThemeAdditor themeAdd = themeGrid.Parent as PlanThemeAdditor;
            StackPanel themePanel = Parent(themeAdd);

            themePanel.Children.Remove(themeAdd);
            PlanTheme.AddElement(themeName.Text, themeHours.Text, 
                themeCompetetions.Text, themeLevel.Text, themePanel);
            themePanel.Children.Add(themeAdd);
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
