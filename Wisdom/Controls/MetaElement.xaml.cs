using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using Wisdom.Model;
using System.Collections.Generic;

namespace Wisdom.Controls
{
    /// <summary>
    /// Логика взаимодействия для MetaElement.xaml
    /// </summary>
    public partial class MetaElement : UserControl
    {
        public MetaElement()
        {
            InitializeComponent();
        }

        public static void AddElements(List<String2> metaTypes, StackPanel stack)
        {
            for (byte i = 0; i < metaTypes.Count; i++)
            {
                MetaElement metaElement = SetElement(metaTypes[i].Value);
                _ = stack.Children.Add(metaElement);
            }
        }

        private static MetaElement SetElement(string name)
        {
            MetaElement metaElement = new MetaElement();
            Grid metaGrid = metaElement.Content as Grid;
            TextBlock metaName = Txt(metaGrid, 0);
            metaName.Text = name;
            return metaElement;
        }
    }
}