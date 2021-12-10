using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using Wisdom.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;

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
        public string GeneralHeader => string.Format("ОК {0:00}", No);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public GeneralCompetetion()
        {
            InitializeComponent();
            SetNo(1);
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(GeneralHeader));
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
            AutoIndexing(stack);
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
    }
}
