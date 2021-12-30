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
    /// Логика взаимодействия для ProfessionalCompetetion.xaml
    /// </summary>
    public partial class ProfessionalCompetetion : UserControl, INotifyPropertyChanged, IProfessionalIndexing
    {
        public HoursList<String2> Competetion => new HoursList<String2>(ProfessionalHeader, ProfessionalName.Text)
        {
            Values =
            {
                new String2("Практический опыт", ProfessionalExperience.Text),
                new String2("Умения", ProfessionalSkills.Text),
                new String2("Знания", ProfessionalKnowledge.Text)
            }
        };

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

        public static void SetAutoOptions(StackPanel stack, byte selection)
        {
            for (byte i = 0; i < stack.Children.Count; i++)
            {
                IProfessionalIndexing element = stack.Children[i] as IProfessionalIndexing;
                element.SetAuto(selection);
            }
            if (stack.Children.Count < 1)
                return;
            IProfessionalIndexing indexing = GetElement(stack, 0);
            if (indexing.AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(stack);
        }

        public ProfessionalCompetetion()
        {
            InitializeComponent();
            SetNo1(1);
            SetNo2(1);
        }

        public void SetNo1(int no)
        {
            _no1 = no;
            OnPropertyChanged(nameof(ProfessionalHeader));
        }

        public void SetNo2(int no)
        {
            No2 = no;
            ProfessionalNo = no.ToString();
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
            string professionalNo = box.Text;
            if (professionalNo.Length <= 0)
                ProfessionalNo = _memoryNo;
            else
            {
                int no = ToInt32(professionalNo);
                SetNo2(no);
            }
        }

        public static List<HoursList<String2>> FullProfessional(StackPanel compStack)
        {
            List<HoursList<String2>> competetions = new List<HoursList<String2>>();
            for (byte i = 0; i < compStack.Children.Count - 1; i++)
            {
                ProfessionalCompetetion competetion = compStack.Children[i] as ProfessionalCompetetion;
                competetions.Add(competetion.Competetion);
            }
            return competetions;
        }

        public static void DropProfessional(StackPanel stack)
        {
            stack.Children.Clear();
        }

        public static void AddElements(List<HoursList<String2>> competetions, StackPanel stack)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i].Hours, competetions[i].Values, stack);
            ProfessionalCompetetionAdditor.AddElement(stack);
            AutoIndexing(stack);
        }

        public static void AddElement(int no, string name, StackPanel stack, byte auto)
        {
            ProfessionalCompetetion element = SetElement(name);
            element.SetAuto(auto);
            element.SetNo2(no);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name, StackPanel stack)
        {
            ProfessionalCompetetion element = SetElement(name);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            List<String2> abilities, StackPanel stack)
        {
            string knowledge = abilities[0].Value;
            string skills = abilities[1].Value;
            string experience = abilities[2].Value;
            AddElement(name, knowledge, skills, experience, stack);
        }

        public static void AddElement(string name, string knowledge,
            string skills, string experience, StackPanel stack)
        {
            ProfessionalCompetetion element = SetElement(name, knowledge, skills, experience);
            _ = stack.Children.Add(element);
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            StackPanel compPanel = Parent(this);
            compPanel.Children.Remove(this);
            if (AutoOption == Bits(Indexing.AUTO))
                AutoIndexing(compPanel);
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

        private static ProfessionalCompetetion SetElement(string name)
        {
            ProfessionalCompetetion competetion = new ProfessionalCompetetion();
            competetion.SetName(name);
            return competetion;
        }

        private static ProfessionalCompetetion SetElement(string name,
            string knowledge, string skills, string experience)
        {
            ProfessionalCompetetion competetion = SetElement(name);
            competetion.SetInfo(knowledge, skills, experience);
            return competetion;
        }

        public void SetName(string name)
        {
            ProfessionalName.Text = name;
        }

        public void SetInfo(string knowledge, string skills, string experience)
        {
            ProfessionalExperience.Text = experience;
            ProfessionalSkills.Text = skills;
            ProfessionalKnowledge.Text = knowledge;
        }

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