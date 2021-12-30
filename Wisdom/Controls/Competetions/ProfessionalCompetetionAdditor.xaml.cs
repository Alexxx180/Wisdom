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
    /// Логика взаимодействия для ProfessionalCompetetionAdditor.xaml
    /// </summary>
    public partial class ProfessionalCompetetionAdditor : UserControl, INotifyPropertyChanged, IProfessionalIndexing
    {
        public ProfessionalCompetetionAdditor()
        {
            InitializeComponent();
            SetNo1(1);
            SetNo2(1);
        }

        private int _no1 { get; set; }
        public int No2 { get; set; }

        public string ProfessionalPrefix => "ПК";
        public string ProfessionalHeader => $"{ProfessionalPrefix} {_no1}.{ProfessionalNo}.";

        private string _memoryNo = "";
        private string _professionalNo = "";
        public string ProfessionalNo
        {
            get => _professionalNo;
            set
            {
                _professionalNo = value;
                OnPropertyChanged();
            }
        }

        public byte AutoOption { get; set; }
        public bool CanBeEdited => AutoOption == Bits(Indexing.MANUAL);

        public void SetAuto(byte selection)
        {
            AutoOption = selection;
            OnPropertyChanged(nameof(CanBeEdited));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void SetNo1(int no)
        {
            _no1 = no;
            OnPropertyChanged(nameof(ProfessionalHeader));
        }

        public void SetNo2(int no)
        {
            No2 = no;
            OnPropertyChanged(nameof(ProfessionalHeader));
        }

        public static void PassNo1(StackPanel themePanel, int no)
        {
            for (int i = 0; i < themePanel.Children.Count; i++)
            {
                IProfessionalIndexing theme = themePanel.Children[i] as IProfessionalIndexing;
                theme.SetNo1(no);
            }
        }

        private void ProfessionalNo_GotFocus(object sender, RoutedEventArgs e)
        {
            ProfessionalNo = RememberNo(out _memoryNo, ProfessionalNo);
        }

        private void ProfessionalNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string generalNo = box.Text;
            if (generalNo.Length <= 0)
                ProfessionalNo = _memoryNo;
            else
            {
                int no = ToInt32(generalNo);
                SetNo2(no);
            }
        }

        public static void AddElement(StackPanel stack)
        {
            ProfessionalCompetetionAdditor element = SetElement();
            _ = stack.Children.Add(element);
            IProfessionalIndexing indexing = GetElement(stack, 0);
            if (indexing == null)
                return;
            if (indexing.AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid compGrid = Parent(dropButton);
            TextBox name = Box(compGrid, 2);
            ProfessionalCompetetionAdditor competetion = compGrid.Parent as ProfessionalCompetetionAdditor;
            StackPanel competetionPanel = Parent(competetion);
            competetionPanel.Children.Remove(competetion);
            ProfessionalCompetetion.AddElement(No2, name.Text, competetionPanel, AutoOption);
            competetionPanel.Children.Add(competetion);
            Indexing option = (Indexing)AutoOption;
            switch (option)
            {
                case Indexing.AUTO:
                    AutoIndexing(competetionPanel);
                    AutoIndexing2(competetionPanel, _no1);
                    break;
                case Indexing.NEW_ONLY:
                    SetNo2(No2 + 1);
                    break;
                default:
                    break;
            }
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
            IProfessionalIndexing theme = grandGrid.Children[no] as IProfessionalIndexing;
            theme.SetNo2(no + 1);
        }

        public static void AutoIndexing2(StackPanel grandGrid, int no1)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
            {
                Index2(grandGrid, no, no1);
            }
        }

        public static void Index2(StackPanel grandGrid, int no, int no1)
        {
            IProfessionalIndexing theme = grandGrid.Children[no] as IProfessionalIndexing;
            theme.SetNo1(no1);
        }

        private static ProfessionalCompetetionAdditor SetElement() => new ProfessionalCompetetionAdditor();

        public static IProfessionalIndexing GetElement(StackPanel stack, in int no)
        {
            return stack.Children[no] as IProfessionalIndexing;
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
