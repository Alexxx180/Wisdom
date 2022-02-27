using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Wisdom.Controls.Tables.Sources.SourceTypes
{
    /// <summary>
    /// Special component to add new source type group
    /// </summary>
    public partial class SourceTypeElementAdditor : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            TypesProperty = DependencyProperty.Register(nameof(Types),
                typeof(ObservableCollection<string>),
                typeof(SourceTypeElementAdditor));

        public static readonly DependencyProperty
            GroupProperty = DependencyProperty.Register(nameof(Group),
                typeof(ObservableCollection<SourceTypeElement>),
                typeof(SourceTypeElementAdditor));

        #region SourceType Members
        public ObservableCollection<SourceTypeElement> Group
        {
            get => GetValue(GroupProperty) as ObservableCollection<SourceTypeElement>;
            set => SetValue(GroupProperty, value);
        }

        public ObservableCollection<string> Types
        {
            get => GetValue(TypesProperty) as ObservableCollection<string>;
            set => SetValue(TypesProperty, value);
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
        #endregion

        public SourceTypeElementAdditor()
        {
            InitializeComponent();
        }

        private void AddSourceGroup(object sender, RoutedEventArgs e)
        {
            SourceTypeElement group = new SourceTypeElement
            {
                Groups = Group
            };
            group.SetTypes(Types);
            group.Text = Text;
            Group.Add(group);
            OnPropertyChanged(nameof(Group));
        }

        public void SetElement(List<string> types)
        {
            for (ushort i = 0; i < types.Count; i++)
            {
                Types.Add(types[i]);
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