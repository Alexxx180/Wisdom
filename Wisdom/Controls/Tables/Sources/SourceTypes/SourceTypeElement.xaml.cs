﻿using System.Collections.Generic;
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

namespace Wisdom.Controls.Tables.Sources.SourceTypes
{
    /// <summary>
    /// Record component containing source group with type header
    /// </summary>
    public partial class SourceTypeElement : UserControl, INotifyPropertyChanged, IRawData<Pair<string, List<string>>>
    {
        public Pair<string, List<string>> Raw()
        {
            return new Pair<string, List<string>>(Text, GetSources());
        }

        public SourceTypeElement()
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
            get => _selectedSource;
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

        public List<string> GetSources()
        {
            StackPanel stack = GetSourceStack();
            List<string> values = new List<string>();
            for (byte i = 0; i < stack.Children.Count - 1; i++)
            {
                SourceElement element = stack.Children[i] as SourceElement;
                values.Add(element.Source);
            }
            return values;
        }

        public static List<Pair<string, List<string>>> GetValues(StackPanel stack)
        {
            List<Pair<string, List<string>>> values = new List<Pair<string, List<string>>>();
            for (byte i = 0; i < stack.Children.Count - 1; i++)
            {
                SourceTypeElement element = stack.Children[i] as SourceTypeElement;
                values.Add(element.Raw());
            }
            return values;
        }

        public static void AddElement(int index, ObservableCollection<string> types, StackPanel stack)
        {
            SourceTypeElement sourceElement = SetElement(index, types);
            _ = stack.Children.Add(sourceElement);
            SourceElementAdditor.AddElement(sourceElement.GetSourceStack());
        }

        public static void AddElement(string name, List<string> types, StackPanel stack)
        {
            SourceTypeElement sourceElement = SetElement(name, types);
            _ = stack.Children.Add(sourceElement);
        }

        public static void AddElement(string name, List<string> sources, List<string> types, StackPanel stack)
        {
            SourceTypeElement sourceElement = SetElement(name, sources, types);
            _ = stack.Children.Add(sourceElement);
        }

        public static void AddElements(List<HashList<string>> sources, List<string> types, StackPanel stack)
        {
            for (byte i = 0; i < sources.Count; i++)
                AddElement(sources[i].Name, sources[i].Values, types, stack);
            SourceTypeElementAdditor.AddElement(types, stack);
        }

        public static void DropSourceGroups(StackPanel panel)
        {
            panel.Children.Clear();
        }

        private void DropSourceGroup(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent(this);
            workPanel.Children.Remove(this);
        }

        private StackPanel GetSourceStack()
        {
            Grid workGrid = Content as Grid;
            return Panel(workGrid, 2);
        }

        public void SetElement(Pair<string, List<string>> types)
        {
            ObservableCollection<string> items = new ObservableCollection<string>();
            for (byte i = 0; i < types.Value.Count; i++)
                items.Add(types.Value[i]);
            Sources = items;
            if (SourceTypeKeys.TryGetValue(types.Name, out int index))
                SelectedSource = index;
            else
                SourcesGroup.Text = types.Name;
        }

        private static SourceTypeElement SetElement(int index, ObservableCollection<string> types)
        {
            SourceTypeElement sourceTypeElement = new SourceTypeElement();
            ObservableCollection<string> items = new ObservableCollection<string>();
            for (byte i = 0; i < types.Count; i++)
                items.Add(types[i]);
            sourceTypeElement.Sources = items;
            sourceTypeElement.SelectedSource = index;
            return sourceTypeElement;
        }

        private static SourceTypeElement SetElement(string name, List<string> types)
        {
            SourceTypeElement sourceTypeElement = new SourceTypeElement();
            ObservableCollection<string> items = new ObservableCollection<string>();
            for (byte i = 0; i < types.Count; i++)
                items.Add(types[i]);
            sourceTypeElement.Sources = items;
            if (SourceTypeKeys.TryGetValue(name, out int index))
                sourceTypeElement.SelectedSource = index;
            else
                sourceTypeElement.SourcesGroup.Text = name;
            return sourceTypeElement;
        }

        private static SourceTypeElement SetElement(string name, List<string> sources, List<string> types)
        {
            SourceTypeElement sourceTypeElement = SetElement(name, types);
            StackPanel stack = sourceTypeElement.GetSourceStack();
            SourceElement.AddElements(sources, stack);
            SourceElementAdditor.AddElement(stack);
            return sourceTypeElement;
        }
    }
}