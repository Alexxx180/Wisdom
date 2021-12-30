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
    /// Логика взаимодействия для ProfessionalDivider.xaml
    /// </summary>
    public partial class ProfessionalDivider : UserControl, INotifyPropertyChanged, IDividerIndexing
    {
        public List<HoursList<String2>> ProfessionalCompetetions => ProfessionalDivision();

        public ProfessionalDivider()
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
            ProfessionalCompetetion.SetAutoOptions(Competetions, selection);
        }

        public void SetNo1(int no)
        {
            No1 = no;
            DividerNo = no.ToString();
            Index2(no);
            OnPropertyChanged(nameof(DividerHeader));
        }

        public static void SetAutoOptions(StackPanel stack, byte selection)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                IDividerIndexing element = stack.Children[i] as IDividerIndexing;
                element.SetAuto(selection);
            }
            if (stack.Children.Count < 1)
                return;
            IDividerIndexing indexing = GetElement(stack, 0);
            if (indexing.AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
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

        public static List<List<HoursList<String2>>> FullProfessional(StackPanel compStack)
        {
            List<List<HoursList<String2>>> competetions = new List<List<HoursList<String2>>>();
            for (byte i = 0; i < compStack.Children.Count; i++)
            {
                ProfessionalDivider competetion = compStack.Children[i] as ProfessionalDivider;
                if (competetion != null)
                    competetions.Add(competetion.ProfessionalCompetetions);
            }
            return competetions;
        }

        public static List<HoursList<String2>> Zip(List<List<HoursList<String2>>> competetions)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            for (byte i = 0; i < competetions.Count; i++)
            {
                list.AddRange(competetions[i]);
            }
            return list;
        }

        public List<HoursList<String2>> ProfessionalDivision()
        {
            List<HoursList<String2>> competetions = new List<HoursList<String2>>();
            for (byte i = 0; i < Competetions.Children.Count - 1; i++)
            {
                ProfessionalCompetetion competetion = Competetions.Children[i] as ProfessionalCompetetion;
                competetions.Add(competetion.Competetion);
            }
            return competetions;
        }

        public static void DropProfessional(StackPanel stack)
        {
            stack.Children.Clear();
        }

        public static void AddElements(List<List<HoursList<String2>>> competetions, StackPanel stack, byte auto)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i], stack, auto);
            ProfessionalDividerAdditor.AddElement(stack);
            AutoIndexing3(stack);
            AutoIndexing(stack);
        }

        public static void AddElements(List<List<HoursList<String2>>> competetions, StackPanel stack)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i], stack);
            ProfessionalDividerAdditor.AddElement(stack);
            AutoIndexing3(stack);
            AutoIndexing(stack);
        }

        public static void AddElement(List<HoursList<String2>> competetions, StackPanel stack, byte auto)
        {
            ProfessionalDivider element = SetElement();
            ProfessionalCompetetion.AddElements(competetions, element.Competetions);
            element.SetAuto(auto);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(List<HoursList<String2>> competetions, StackPanel stack)
        {
            ProfessionalDivider element = SetElement();
            ProfessionalCompetetion.AddElements(competetions, element.Competetions);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(StackPanel stack)
        {
            ProfessionalDivider element = SetElement();
            ProfessionalCompetetionAdditor.AddElement(element.Competetions);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(StackPanel stack, byte auto, int no)
        {
            ProfessionalDivider element = SetElement();
            element.SetAuto(auto);
            element.SetNo1(no);
            ProfessionalCompetetionAdditor.AddElement(element.Competetions);
            _ = stack.Children.Add(element);
        }

        private void DropDivision(object sender, RoutedEventArgs e)
        {
            StackPanel compPanel = Parent(this);
            compPanel.Children.Remove(this);
            if (AutoOption == Bits(Indexing.AUTO))
            {
                AutoIndexing3(compPanel);
                AutoIndexing(compPanel);
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
            IDividerIndexing theme = grandGrid.Children[no] as IDividerIndexing;
            theme.SetNo1(no + 1);
        }

        public static void AutoIndexing3(StackPanel grandGrid)
        {
            for (int no = 0; no < grandGrid.Children.Count; no++)
                Index3(grandGrid, no);
        }

        public void Index2(int no1)
        {
            ProfessionalCompetetion.PassNo1(Competetions, no1);
        }

        public static void Index3(StackPanel grandGrid, int no)
        {
            ProfessionalDivider topic = grandGrid.Children[no] as ProfessionalDivider;
            if (topic != null)
                topic.Index2(no + 1);
        }

        private static ProfessionalDivider SetElement() => new ProfessionalDivider();

        public static IDividerIndexing GetElement(StackPanel stack, in int no)
        {
            return stack.Children[no] as IDividerIndexing;
        }
    }
}
