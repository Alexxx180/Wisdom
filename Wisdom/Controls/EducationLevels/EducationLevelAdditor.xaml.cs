using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.EducationLevels
{
    /// <summary>
    /// Логика взаимодействия для EducationLevelAdditor.xaml
    /// </summary>
    public partial class EducationLevelAdditor : UserControl, INotifyPropertyChanged, ILevelIndexing
    {
        public int No { get; set; }
        public string LevelHeader => $"{No}.";

        public string _name = "";
        public string LevelName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _description = "";
        public string LevelDescription
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public EducationLevelAdditor()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(LevelHeader));
        }

        public static void AddElement(StackPanel stack)
        {
            EducationLevelAdditor sourceElement = SetElement();
            _ = stack.Children.Add(sourceElement);
            AutoIndexing(stack);
        }

        private static EducationLevelAdditor SetElement() => new EducationLevelAdditor();

        private void AddLevel(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
            EducationLevel.AddElement(LevelName, LevelDescription, workPanel);
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
            ILevelIndexing source = grandGrid.Children[no] as ILevelIndexing;
            source.SetNo(no + 1);
        }
    }
}
