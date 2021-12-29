using static System.Convert;
using System.Windows.Controls;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для AutoIndexer.xaml
    /// </summary>
    public partial class GeneralAutoIndexer : UserControl
    {
        public StackPanel ToIndex;

        public GeneralAutoIndexer()
        {
            InitializeComponent();
            ToIndex = Tag as StackPanel;
        }

        private void AutoIndexing(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            byte selection = ToByte(box.SelectedIndex);
            SetAuto(selection);
        }

        private void SetAuto(byte selection)
        {
            GeneralCompetetion.SetAuto(selection);
            GeneralCompetetionAdditor.SetAuto(selection);
        }
    }
}
