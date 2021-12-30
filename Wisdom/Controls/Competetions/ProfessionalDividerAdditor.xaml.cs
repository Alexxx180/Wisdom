using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Convert;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для ProfessionalDividerAdditor.xaml
    /// </summary>
    public partial class ProfessionalDividerAdditor : UserControl, INotifyPropertyChanged, IDividerIndexing
    {
        public ProfessionalDividerAdditor()
        {
            InitializeComponent();
            SetNo1(1);
        }

        public int No1 { get; set; }

        private string _memoryNo = "";
        private string _dividerNo = "";
        public string DividerNo
        {
            get => _dividerNo;
            set
            {
                _dividerNo = value;
                OnPropertyChanged();
            }
        }

        public string DividerPrefix => "ПК";
        public string DividerHeader => DividerPrefix + " " + DividerNo;

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

        public void SetNo1(int no)
        {
            No1 = no;
            DividerNo = no.ToString();
            OnPropertyChanged(nameof(DividerHeader));
        }

        private void DividerNo_GotFocus(object sender, RoutedEventArgs e)
        {
            DividerNo = RememberNo(out _memoryNo, DividerNo);
        }

        private void DividerNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string dividerNo = box.Text;
            if (dividerNo.Length <= 0)
                DividerNo = _memoryNo;
            else
            {
                int no = ToInt32(dividerNo);
                SetNo1(no);
            }
        }

        public static void AddElement(StackPanel stack)
        {
            ProfessionalDividerAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddDivision(object sender, RoutedEventArgs e)
        {
            Button addButton = sender as Button;
            Grid compGrid = Parent(addButton);
            ProfessionalDividerAdditor competetion = compGrid.Parent as ProfessionalDividerAdditor;
            StackPanel compPanel = Parent(competetion);
            compPanel.Children.Remove(competetion);
            ProfessionalDivider.AddElement(compPanel, AutoOption, No1);
            compPanel.Children.Add(competetion);
            Indexing option = (Indexing)AutoOption;
            switch (option)
            {
                case Indexing.AUTO:
                    AutoIndexing3(compPanel);
                    AutoIndexing(compPanel);
                    break;
                case Indexing.NEW_ONLY:
                    SetNo1(No1 + 1);
                    break;
                default:
                    break;
            }
        }

        public StackPanel GetCompetetionsStack()
        {
            Grid topicGrid = Content as Grid;
            return Panel(topicGrid, 2);
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
            IDividerIndexing theme = grandGrid.Children[no] as IDividerIndexing;
            theme.SetNo1(no + 1);
        }

        public static void AutoIndexing3(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                Index3(grandGrid, no);
        }

        public static void Index3(StackPanel grandGrid, int no)
        {
            ProfessionalDivider topic = grandGrid.Children[no] as ProfessionalDivider;
            if (topic != null)
                topic.Index2(no + 1);
        }

        private static ProfessionalDividerAdditor SetElement() => new ProfessionalDividerAdditor();
    }
}
