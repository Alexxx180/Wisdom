using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Wisdom.Customing.Converters;
using static Wisdom.Writers.Content;
using static Wisdom.Model.ProgramContent;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Wisdom.Controls.Sources
{
    /// <summary>
    /// Логика взаимодействия для SourceTypeElementAdditorAdditor.xaml
    /// </summary>
    public partial class SourceTypeElementAdditor : UserControl, INotifyPropertyChanged
    {
        public SourceTypeElementAdditor()
        {
            InitializeComponent();
        }

        private ObservableCollection<string> _sources;
        public ObservableCollection<string> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }

        private int _selectedSource;
        public int SelectedSource
        {
            get { return _selectedSource; }
            set
            {
                _selectedSource = value;
                OnPropertyChanged();
            }
        }
        public string Text => Sources[SelectedSource];

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static void AddElement(List<string> types, StackPanel stack)
        {
            SourceTypeElementAdditor sourceElement = SetElement(types);
            _ = stack.Children.Add(sourceElement);
        }

        private void AddSourceGroup(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
            SourceTypeElement.AddElement(SelectedSource, Sources, workPanel);
            workPanel.Children.Add(this);
        }

        private static SourceTypeElementAdditor SetElement(List<string> types)
        {
            SourceTypeElementAdditor sourceTypeElement = new SourceTypeElementAdditor();
            ObservableCollection<string> items = new ObservableCollection<string>();
            for (byte i = 0; i < types.Count; i++)
                items.Add(types[i]);
            sourceTypeElement.Sources = items;
            return sourceTypeElement;
        }
    }
}
