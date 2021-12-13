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
    /// Логика взаимодействия для ApplyElement.xaml
    /// </summary>
    public partial class ApplyElement : UserControl, INotifyPropertyChanged, IApplyIndexing
    {
        public int No { get; set; }
        public string ApplyHeader => $"{No}.";

        public string _value = "";
        public string Applyment
        {
            get { return _value; }
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

        public ApplyElement()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(ApplyHeader));
        }

        public static void AddElement(string source, StackPanel stack)
        {
            ApplyElement sourceElement = SetElement(source);
            _ = stack.Children.Add(sourceElement);
        }

        public static void AddElements(List<string> sources, StackPanel stack)
        {
            for (byte i = 0; i < sources.Count; i++)
                AddElement(sources[i], stack);
        }

        public static void DropElements(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private static ApplyElement SetElement(string name)
        {
            ApplyElement applyElement = new ApplyElement();
            applyElement.Applyment = name;
            return applyElement;
        }

        private void DropElement(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid sourceGrid = Parent(dropButton);
            ApplyElement source = sourceGrid.Parent as ApplyElement;
            StackPanel workPanel = Parent(source);
            workPanel.Children.Remove(source);
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

        public static List<string> GetValues(StackPanel stack)
        {
            List<string> values = new List<string>();
            for (byte i = 0; i < stack.Children.Count - 1; i++)
            {
                ApplyElement element = stack.Children[i] as ApplyElement;
                values.Add(element.Applyment);
            }
            return values;
        }
    }
}
