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
        public SourceTypeElementAdditor()
        {
            InitializeComponent();
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
        #endregion

        private void AddSourceGroup(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetElement(List<string> types)
        {
            for (ushort i = 0; i < types.Count; i++)
                Types.Add(types[i]);
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