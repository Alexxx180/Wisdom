using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Sources
{
    /// <summary>
    /// Логика взаимодействия для SourceElementAdditorAdditor.xaml
    /// </summary>
    public partial class SourceElementAdditor : UserControl, INotifyPropertyChanged, ISourceIndexing
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

        public SourceElementAdditor()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(SourceHeader));
        }

        public static void AddElement(StackPanel stack)
        {
            SourceElementAdditor sourceElement = SetElement();
            _ = stack.Children.Add(sourceElement);
            AutoIndexing(stack);
        }

        private static SourceElementAdditor SetElement() => new SourceElementAdditor();

        private void AddSource(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
            SourceElement.AddElement(Source, workPanel);
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
            ISourceIndexing source = grandGrid.Children[no] as ISourceIndexing;
            source.SetNo(no + 1);
        }
    }
}
