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

        public string ProfessionalHeader => $"ПК {_no1}.{No2}.";

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

        public static void AddElement(StackPanel stack)
        {
            ProfessionalCompetetionAdditor element = SetElement();
            _ = stack.Children.Add(element);
        }

        private void AddCompetetion(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid compGrid = Parent(dropButton);
            TextBox name = Box(compGrid, 2);
            ProfessionalCompetetionAdditor competetion = compGrid.Parent as ProfessionalCompetetionAdditor;
            StackPanel compPanel = Parent(competetion);
            compPanel.Children.Remove(competetion);
            ProfessionalCompetetion.AddElement(name.Text, compPanel);
            compPanel.Children.Add(competetion);
            AutoIndexing(compPanel);
            AutoIndexing2(compPanel, _no1);
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
    }
}
