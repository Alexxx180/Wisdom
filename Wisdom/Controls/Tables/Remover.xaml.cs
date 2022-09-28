using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Логика взаимодействия для Remover.xaml
    /// </summary>
    public partial class Remover : UserControl
    {
        public static readonly DependencyProperty
            ItemProperty = DependencyProperty.Register(nameof(Item),
                typeof(ControlTemplate), typeof(Remover));

        public ControlTemplate Item
        {
            get => GetValue(ItemProperty) as ControlTemplate;
            set => SetValue(ItemProperty, value);
        }

        public Remover()
        {
            InitializeComponent();
        }
    }
}
