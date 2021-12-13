using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Applyment
{
    /// <summary>
    /// Логика взаимодействия для ApplyElementAdditor.xaml
    /// </summary>
    public partial class ApplyElementAdditor : UserControl, INotifyPropertyChanged, IApplyIndexing
    {
        public int No { get; set; }
        public string ApplyHeader => $"{No}.";

        public string _value = "";
        public string Applyment
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ApplyElementAdditor()
        {
            InitializeComponent();
            No = 1;
            OnPropertyChanged(nameof(ApplyHeader));
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(ApplyHeader));
        }

        public static void AddElement(StackPanel stack)
        {
            ApplyElementAdditor sourceElement = SetElement();
            _ = stack.Children.Add(sourceElement);
            AutoIndexing(stack);
        }

        private static ApplyElementAdditor SetElement() => new ApplyElementAdditor();

        private void AddElement(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
            ApplyElement.AddElement(Applyment, workPanel);
            workPanel.Children.Add(this);
            AutoIndexing(workPanel);
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
            IApplyIndexing source = grandGrid.Children[no] as IApplyIndexing;
            source.SetNo(no + 1);
        }
    }
}
