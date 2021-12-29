using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static System.Convert;
using static Wisdom.Customing.Converters;
using Wisdom.Model;
using static Wisdom.Writers.Content;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;

namespace Wisdom.Controls.Competetions
{
    /// <summary>
    /// Логика взаимодействия для GeneralCompetetion.xaml
    /// </summary>
    public partial class GeneralCompetetion : UserControl, INotifyPropertyChanged, IGeneralIndexing
    {
        public HoursList<String2> Competetion => new HoursList<String2>(GeneralHeader, GeneralName.Text)
        {
            Values =
                {
                    new String2("Умения", GeneralSkills.Text),
                    new String2("Знания", GeneralKnowledge.Text),
                }
        };

        public int No { get; set; }

        public string GeneralPrefix => "ОК";
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

        public GeneralCompetetion()
        {
            InitializeComponent();
            SetNo(1);
        }

        public void SetNo(int no)
        {
            No = no;
            GeneralNo = string.Format("{0:00}", no);
            OnPropertyChanged(nameof(GeneralNo));
            OnPropertyChanged(nameof(GeneralHeader));
        }

        private string MemoryNo = "";

        private void GeneralNo_GotFocus(object sender, RoutedEventArgs e)
        {
            MemoryNo = GeneralNo;
            GeneralNo = "";
            OnPropertyChanged(nameof(GeneralNo));
        }

        private void GeneralNo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string generalNo = box.Text;
            if (generalNo.Length <= 0)
            {
                GeneralNo = MemoryNo;
                OnPropertyChanged(nameof(GeneralNo));
            }
            else
            {
                int no = ToInt32(generalNo);
                SetNo(no);
            }
        }

        public static List<HoursList<String2>> FullGeneral(StackPanel compStack)
        {
            List<HoursList<String2>> competetions = new List<HoursList<String2>>();
            for (byte i = 0; i < compStack.Children.Count - 1; i++)
            {
                GeneralCompetetion competetion = compStack.Children[i] as GeneralCompetetion;
                competetions.Add(competetion.Competetion);
            }
            return competetions;
        }

        public static void DropGeneral(StackPanel stack)
        {
            stack.Children.Clear();
        }

        public static void AddElements(List<HoursList<String2>> competetions, StackPanel stack)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i].Hours, competetions[i].Values, stack);
            GeneralCompetetionAdditor.AddElement(stack);
            if (AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        public static void AddElement(int no, string name, StackPanel stack)
        {
            GeneralCompetetion element = SetElement(name);
            element.SetNo(no);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name, StackPanel stack)
        {
            GeneralCompetetion element = SetElement(name);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            List<String2> abilities, StackPanel stack)
        {
            AddElement(name, abilities[0].Value, abilities[1].Value, stack);
        }

        public static void AddElement(string name,
            string knowledge, string skills, StackPanel stack)
        {
            GeneralCompetetion element = SetElement(name, knowledge, skills);
            _ = stack.Children.Add(element);
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid compGrid = Parent(dropButton);
            GeneralCompetetion competetion = compGrid.Parent as GeneralCompetetion;
            StackPanel workPanel = Parent(competetion);
            workPanel.Children.Remove(competetion);
            if (AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(workPanel);
        }

        private static GeneralCompetetion SetElement(string name)
        {
            GeneralCompetetion competetion = new GeneralCompetetion();
            Grid compGrid = competetion.Content as Grid;
            TextBox compName = Box(compGrid, 2);
            compName.Text = name;
            return competetion;
        }

        private static GeneralCompetetion SetElement(string name,
            string knowledge, string skills)
        {
            GeneralCompetetion competetion = new GeneralCompetetion();
            Grid compGrid = competetion.Content as Grid;
            TextBox compName = Box(compGrid, 2);
            TextBox compSkills = Box(compGrid, 4);
            TextBox compKnowledge = Box(compGrid, 6);
            compName.Text = name;
            compSkills.Text = skills;
            compKnowledge.Text = knowledge;
            return competetion;
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