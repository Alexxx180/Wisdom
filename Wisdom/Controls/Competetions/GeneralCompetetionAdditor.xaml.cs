using static System.Convert;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
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

        public string GeneralPrefix => "ОК";
        //public string GeneralHeader => string.Format("ОК {0:00}", No);
        public string GeneralNo { get; set; }
        public string GeneralHeader => GeneralPrefix + " " + GeneralNo;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private static byte AutoOption = Bits(Indexing.AUTO);

        public static void SetAuto(byte selection)
        {
            AutoOption = selection;
        }

        public GeneralCompetetionAdditor()
        {
            InitializeComponent();
            SetNo(1);
        }

        public void SetNo(int no)
        {
            No = no;
            GeneralNo = string.Format("{0:00}", no);
            OnPropertyChanged(nameof(GeneralHeader));
        }

        private string MemoryNo = "";

        private void GeneralNo_GotFocus(object sender, RoutedEventArgs e)
        {
            MemoryNo = GeneralNo;
            GeneralNo = "";
        }

        private void GeneralNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GeneralNo.Length <= 0)
                GeneralNo = MemoryNo;
            else
            {
                int no = ToInt32(GeneralNo);
                SetNo(no);
            }
        }

        public static void AddElement(StackPanel stack)
        {
            GeneralCompetetionAdditor element = SetElement();
            _ = stack.Children.Add(element);
            if (AutoOption == Bits(Indexing.AUTO))
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
            GeneralCompetetion.AddElement(No, name.Text, competetionPanel);
            competetionPanel.Children.Add(competetionAdd);
            Indexing option = (Indexing)AutoOption;
            switch (option)
            {
                case Indexing.AUTO:
                    AutoIndexing(competetionPanel);
                    break;
                case Indexing.NEW_ONLY:
                    SetNo(No + 1);
                    break;
                default:
                    break;
            }   
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
