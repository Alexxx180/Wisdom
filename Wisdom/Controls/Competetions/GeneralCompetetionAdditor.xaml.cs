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

        private string _memoryNo = "";
        private string _generalNo = "";
        public string GeneralNo
        {
            get => _generalNo;
            set
            {
                _generalNo = value;
                OnPropertyChanged();
            }
        }

        public string GeneralPrefix => "ОК";
        public string GeneralHeader => GeneralPrefix + " " + GeneralNo;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public byte AutoOption { get; set; }
        public bool CanBeEdited => AutoOption == Bits(Indexing.MANUAL);

        public void SetAuto(byte selection)
        {
            AutoOption = selection;
            OnPropertyChanged(nameof(CanBeEdited));
        }

        public static void SetAutoOptions(StackPanel stack, byte selection)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                IGeneralIndexing element = stack.Children[i] as IGeneralIndexing;
                element.SetAuto(selection);
            }
        }

        public GeneralCompetetionAdditor()
        {
            InitializeComponent();
            SetAuto(Bits(Indexing.AUTO));
            SetNo(1);
        }

        public void SetNo(int no)
        {
            No = no;
            GeneralNo = string.Format("{0:00}", no);
            OnPropertyChanged(nameof(GeneralHeader));
        }

        private void GeneralNo_GotFocus(object sender, RoutedEventArgs e)
        {
            _memoryNo = GeneralNo;
            GeneralNo = "";
        }

        private void GeneralNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string generalNo = box.Text;
            if (generalNo.Length <= 0)
                GeneralNo = _memoryNo;
            else
            {
                int no = ToInt32(generalNo);
                SetNo(no);
            }
        }

        public static void AddElement(StackPanel stack)
        {
            GeneralCompetetionAdditor element = SetElement();
            _ = stack.Children.Add(element);
            IGeneralIndexing indexing = GetElement(stack, 0);
            if (indexing == null)
                return;
            if (indexing.AutoOption == Bits(Indexing.AUTO))
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
            GeneralCompetetion.AddElement(No, name.Text, competetionPanel, Bits(Indexing.NEW_ONLY));
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

        public static IGeneralIndexing GetElement(StackPanel stack, in int no)
        {
            return stack.Children[no] as IGeneralIndexing;
        }

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
