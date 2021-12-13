using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Sources
{
    /// <summary>
    /// Логика взаимодействия для SourceElement.xaml
    /// </summary>
    public partial class SourceElement : UserControl, INotifyPropertyChanged, ISourceIndexing
    {
        public int No { get; set; }
        public string SourceHeader => $"{No}.";

        public string _value = "";
        public string Source
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

        public SourceElement()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(SourceHeader));
        }

        public static void AddElement(string source, StackPanel stack)
        {
            SourceElement sourceElement = SetElement(source);
            _ = stack.Children.Add(sourceElement);
        }

        public static void AddElements(List<string> sources, StackPanel stack)
        {
            for (byte i = 0; i < sources.Count; i++)
                AddElement(sources[i], stack);
        }

        public static void DropSources(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private static SourceElement SetElement(string name)
        {
            SourceElement hourElement = new SourceElement();
            hourElement.Source = name;
            return hourElement;
        }

        private void DropSource(object sender, RoutedEventArgs e)
        {
            Button dropButton = sender as Button;
            Grid sourceGrid = Parent(dropButton);
            SourceElement source = sourceGrid.Parent as SourceElement;
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
            ISourceIndexing source = grandGrid.Children[no] as ISourceIndexing;
            source.SetNo(no + 1);
        }

        public static List<string> GetValues(StackPanel stack)
        {
            List<string> values = new List<string>();
            for (byte i = 0; i < stack.Children.Count - 1; i++)
            {
                SourceElement element = stack.Children[i] as SourceElement;
                values.Add(element.Source);
            }
            return values;
        }
    }
}