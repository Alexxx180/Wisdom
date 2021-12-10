using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для GeneralCompetetionAdditor.xaml
    /// </summary>
    public partial class GeneralCompetetionAdditor : UserControl, INotifyPropertyChanged, IGeneralIndexing
    {
        public int No { get; set; }
        public string GeneralHeader => string.Format("ОК {0:00}", No);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public GeneralCompetetionAdditor()
        {
            InitializeComponent();
            SetNo(1);
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(GeneralHeader));
        }

        public static void AddElement(StackPanel stack)
        {
            GeneralCompetetionAdditor element = SetElement();
            _ = stack.Children.Add(element);
            AutoIndexing(stack);
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid compGrid = Parent(addButton);
            TextBox name = Box(compGrid, 2);
            GeneralCompetetionAdditor competetionAdd = compGrid.Parent as GeneralCompetetionAdditor;
            StackPanel competetionPanel = Parent(competetionAdd);
            competetionPanel.Children.Remove(competetionAdd);
            GeneralCompetetion.AddElement(name.Text, competetionPanel);
            AutoIndexing(competetionPanel);
        }

        private static GeneralCompetetionAdditor SetElement() => new GeneralCompetetionAdditor();

        public static void AutoIndexing(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index(grandGrid, no);
            }
        }

        public static void Index(StackPanel grandGrid, int no)
        {
            IGeneralIndexing task = grandGrid.Children[no] as IGeneralIndexing;
            task.SetNo(no + 1);
        }
    }
}
