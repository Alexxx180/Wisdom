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
using System.Text.RegularExpressions;

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
            if (stack.Children.Count < 1)
                return;
            IGeneralIndexing indexing = GetElement(stack, 0);
            if (indexing.AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        public GeneralCompetetion()
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
            GeneralNo = RememberNo(out _memoryNo, GeneralNo);
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

        public static void AddElements(List<HoursList<String2>> competetions, StackPanel stack, byte auto)
        {
            for (byte i = 0; i < competetions.Count; i++)
            {
                HoursList<String2> current = competetions[i];
                int no = ToInt32(Regex.Match(current.Name, @"\d+").Value);
                string name = current.Hours;
                List<String2> skills = current.Values;
                
                AddElement(no, name, skills, stack, auto);
            }    
                
            GeneralCompetetionAdditor.AddElement(stack);
            if (auto == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        public static void AddElements(List<HoursList<String2>> competetions, StackPanel stack)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i].Hours, competetions[i].Values, stack);
            GeneralCompetetionAdditor.AddElement(stack);
            if (stack.Children.Count < 1)
                return;
            IGeneralIndexing element = GetElement(stack, 0);
            if (element.AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        public static void AddElement(int no, string name, StackPanel stack, byte auto)
        {
            GeneralCompetetion element = SetElement(name);
            element.SetNo(no);
            element.SetAuto(auto);
            _ = stack.Children.Add(element);
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

        public static void AddElement(int no, string name,
            List<String2> abilities, StackPanel stack, byte auto)
        {
            AddElement(no, name, abilities[0].Value, abilities[1].Value, stack, auto);
        }

        public static void AddElement(string name,
            List<String2> abilities, StackPanel stack)
        {
            AddElement(name, abilities[0].Value, abilities[1].Value, stack);
        }

        public static void AddElement(int no, string name,
            string knowledge, string skills, StackPanel stack, byte auto)
        {
            GeneralCompetetion element = SetElement(name, knowledge, skills);
            element.SetNo(no);
            element.SetAuto(auto);
            _ = stack.Children.Add(element);
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