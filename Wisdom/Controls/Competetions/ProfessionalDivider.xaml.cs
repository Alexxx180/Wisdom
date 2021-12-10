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

        public string DividerHeader => $"ПК {No1}.";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void SetNo1(int no)
        {
            No1 = no;
            OnPropertyChanged(nameof(DividerHeader));
        }

        public static List<List<HoursList<String2>>> FullProfessional(StackPanel compStack)
        {
            List<List<HoursList<String2>>> competetions = new List<List<HoursList<String2>>>();
            for (byte i = 0; i < compStack.Children.Count - 1; i++)
            {
                ProfessionalDivider competetion = compStack.Children[i] as ProfessionalDivider;
                competetions.Add(competetion.ProfessionalCompetetions);
            }
            return competetions;
        }

        public static List<HoursList<String2>> Zip(List<List<HoursList<String2>>> competetions)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            for (byte i = 0; i < competetions.Count - 1; i++)
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

        public static void AddElements(List<List<HoursList<String2>>> competetions, StackPanel stack)
        {
            for (byte i = 0; i < competetions.Count; i++)
                AddElement(competetions[i], stack);
            ProfessionalDividerAdditor.AddElement(stack);
            AutoIndexing3(stack);
            AutoIndexing(stack);
        }

        public static void AddElement(List<HoursList<String2>> competetions, StackPanel stack)
        {
            ProfessionalDivider element = SetElement();
            StackPanel dividerStack = element.GetCompetetionsStack();
            ProfessionalCompetetion.AddElements(competetions, dividerStack);
            _ = stack.Children.Add(element);
        }

        public static void AddElement(StackPanel stack)
        {
            ProfessionalDivider element = SetElement();
            StackPanel dividerStack = element.GetCompetetionsStack();
            ProfessionalCompetetionAdditor.AddElement(dividerStack);
            _ = stack.Children.Add(element);
        }

        private void DropDivision(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid compGrid = Parent(dropButton);
            ProfessionalCompetetion competetion = compGrid.Parent as ProfessionalCompetetion;
            StackPanel compPanel = Parent(competetion);
            compPanel.Children.Remove(competetion);
            AutoIndexing3(compPanel);
            AutoIndexing(compPanel);
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
                ProfessionalCompetetion.PassNo1(topic.GetCompetetionsStack(), no + 1);
        }

        private static ProfessionalDivider SetElement() => new ProfessionalDivider();
    }
}
