using System.Windows.Controls;
using System.Collections.Generic;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    public partial class HourElement : UserControl
    {
        public HourElement()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> metaTypes, StackPanel stack)
        {
            for (byte i = 0; i < metaTypes.Count; i++)
            {
                HourElement metaElement = SetElement(metaTypes[i].Value);
                _ = stack.Children.Add(metaElement);
            }
        }

        private static HourElement SetElement(string name)
        {
            HourElement metaElement = new HourElement();
            Grid metaGrid = metaElement.Content as Grid;
            TextBlock metaName = Txt(metaGrid, 0);
            metaName.Text = name;
            return metaElement;
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
            {
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            }

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
