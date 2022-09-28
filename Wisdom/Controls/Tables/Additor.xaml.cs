using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Логика взаимодействия для Additor.xaml
    /// </summary>
    public partial class Additor : UserControl
    {
        public static readonly DependencyProperty
            ItemProperty = DependencyProperty.Register(nameof(Item),
                typeof(ControlTemplate), typeof(Additor));

        public ControlTemplate Item
        {
            get => GetValue(ItemProperty) as ControlTemplate;
            set => SetValue(ItemProperty, value);
        }

        public Additor()
        {
            InitializeComponent();
        }
    }
}
