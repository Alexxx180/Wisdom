using static System.Convert;
using System.Windows.Controls;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для AutoIndexer.xaml
    /// </summary>
    public partial class GeneralAutoIndexer : UserControl
    {
        public StackPanel ToIndex => Tag as StackPanel;

        public GeneralAutoIndexer()
        {
            InitializeComponent();
        }

        private void AutoIndexing(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            byte selection = ToByte(box.SelectedIndex);
            SetAuto(selection);
        }

        private void SetAuto(byte selection)
        {
            GeneralCompetetion.SetAutoOptions(ToIndex, selection);
        }
    }
}