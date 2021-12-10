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
            ProfessionalDivider.AddElement(compPanel);
            compPanel.Children.Add(competetion);
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

        private static ProfessionalDividerAdditor SetElement() => new ProfessionalDividerAdditor();
    }
}
