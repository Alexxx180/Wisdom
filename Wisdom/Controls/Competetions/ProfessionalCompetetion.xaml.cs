using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        public string ProfessionalHeader => $"ПК {_no1}.{No2}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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

        public static void AddElement(string name, StackPanel stack)
        {
            ProfessionalCompetetion element = SetElement(name);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(string name,
            List<String2> abilities, StackPanel stack)
        {
            AddElement(name, abilities[0].Value,
                abilities[1].Value, abilities[2].Value, stack);
        }

        public static void AddElement(string name, string knowledge,
            string skills, string experience, StackPanel stack)
        {
            ProfessionalCompetetion element = SetElement(name, knowledge, skills, experience);
            _ = stack.Children.Add(element);
        }

        private void DropCompetetion(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid compGrid = Parent(dropButton);
            ProfessionalCompetetion competetion = compGrid.Parent as ProfessionalCompetetion;
            StackPanel compPanel = Parent(competetion);
            compPanel.Children.Remove(competetion);
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
            Grid compGrid = competetion.Content as Grid;
            TextBox compName = Box(compGrid, 2);
            compName.Text = name;
            return competetion;
        }

        private static ProfessionalCompetetion SetElement(string name,
            string knowledge, string skills, string experience)
        {
            ProfessionalCompetetion competetion = new ProfessionalCompetetion();
            Grid compGrid = competetion.Content as Grid;
            TextBox compName = Box(compGrid, 2);
            TextBox compExperince = Box(compGrid, 4);
            TextBox compSkills = Box(compGrid, 6); 
            TextBox compKnowledge = Box(compGrid, 8);
            compName.Text = name;
            compExperince.Text = experience;
            compSkills.Text = skills;
            compKnowledge.Text = knowledge;
            return competetion;
        }
    }
}
