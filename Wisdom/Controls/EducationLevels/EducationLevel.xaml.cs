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
    /// Логика взаимодействия для EducationLevel.xaml
    /// </summary>
    public partial class EducationLevel : UserControl, INotifyPropertyChanged, ILevelIndexing
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

        public EducationLevel()
        {
            InitializeComponent();
        }

        public void SetNo(int no)
        {
            No = no;
            OnPropertyChanged(nameof(LevelHeader));
        }

        public static void AddElement(string name, string description, StackPanel stack)
        {
            EducationLevel sourceElement = SetElement(name, description);
            _ = stack.Children.Add(sourceElement);
        }

        public static void AddElements(List<String2> levels, StackPanel stack)
        {
            for (byte i = 0; i < levels.Count; i++)
                AddElement(levels[i].Name, levels[i].Value, stack);
            EducationLevelAdditor.AddElement(stack);
        }

        public static void DropLevels(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private static EducationLevel SetElement(string name, string description)
        {
            EducationLevel level = new EducationLevel();
            level.LevelName = name;
            level.LevelDescription = description;
            return level;
        }

        private void DropLevel(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
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

        public static StringList GetValues(StackPanel stack)
        {
            StringList values = new StringList("(", ")");
            for (byte i = 0; i < stack.Children.Count - 1; i++)
            {
                EducationLevel element = stack.Children[i] as EducationLevel;
                values.Add(element.LevelName, element.LevelDescription);
            }
            return values;
        }
    }
}
