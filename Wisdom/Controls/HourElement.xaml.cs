using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для HourElement.xaml
    /// </summary>
    
    public sealed partial class HourElement : UserControl
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

        private void Hours(object sender, TextCompositionEventArgs e)
        {
            CheckForHours(sender, e);
        }
        private void PastingHours(object sender, DataObjectPastingEventArgs e)
        {
            CheckForPastingHours(sender, e);
        }
    }
}
