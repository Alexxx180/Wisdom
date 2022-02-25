using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Model;
using static Wisdom.Customing.Converters;

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

        #region SourceType Members
        private ObservableCollection<string> _types;
        public ObservableCollection<string> Types
        {
            get => _types;
            set
            {
                _types = value;
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

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SourceElement> _sources;
        public ObservableCollection<SourceElement> Sources
        {
            get => _sources;
            set
            {
                _sources = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public SourceTypeElement()
        {
            InitializeComponent();
        }

        public List<string> GetSources()
        {
            List<string> values = new List<string>();
            for (byte i = 0; i < Sources.Count - 1; i++)
            {
                values.Add(Sources[i].Raw());
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

        private void DropSourceGroup(object sender, RoutedEventArgs e)
        {
            StackPanel workPanel = Parent as StackPanel;
            workPanel.Children.Remove(this);
        }

        public void SetElement(List<string> types, Pair<string, List<string>> sources)
        {
            for (ushort i = 0; i < types.Count; i++)
                Types.Add(types[i]);

            Text = sources.Name;
            for (ushort i = 0; i < sources.Value.Count; i++)
            {
                SourceElement source = new SourceElement
                {
                    Source = sources.Value[i]
                };
                Sources.Add(source);
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}