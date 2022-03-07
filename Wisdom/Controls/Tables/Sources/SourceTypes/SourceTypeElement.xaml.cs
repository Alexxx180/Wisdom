using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Customing;
using Wisdom.Model.Tables;

namespace Wisdom.Controls.Tables.Sources.SourceTypes
{
    /// <summary>
    /// Record component containing source group with type header
    /// </summary>
    public partial class SourceTypeElement : UserControl, INotifyPropertyChanged, IRawData<Source>
    {
        #region IRawData Members
        public Source Raw()
        {
            return new Source(Text, Sources.GetRaw());
        }

        public void SetElement(Source sources)
        {
            ushort i;
            for (i = 0; i < sources.Descriptions.Count; i++)
            {
                string description = sources.Descriptions[i];
                SourceElement source = new SourceElement
                {
                    Source = description,
                    SourceType = this
                };
                source.Index((i + 1).ToUInt());
                Sources.Add(source);
            }
            Additor.Index((i + 1).ToUInt());
        }
        #endregion

        #region SourceType Members
        private ObservableCollection<SourceTypeElement> _groups;
        public ObservableCollection<SourceTypeElement> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

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

        #region AutoIndexing Logic
        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < Sources.Count; i++)
            {
                Sources[i].Index((i + 1).ToUInt());
            }
            Additor.Index((i + 1).ToUInt());
        }
        #endregion

        public SourceTypeElement()
        {
            InitializeComponent();
            Types = new ObservableCollection<string>();
            Sources = new ObservableCollection<SourceElement>();
        }

        private void DropSourceGroup(object sender, RoutedEventArgs e)
        {
            _ = Groups.Remove(this);
            OnPropertyChanged(nameof(Groups));
        }

        #region SourceGroup Members
        public void DropSource(SourceElement source)
        {
            _ = Sources.Remove(source);
            AutoIndexing();
            OnPropertyChanged(nameof(Sources));
        }

        public void AddRecord(SourceElement record)
        {
            Sources.Add(record);
            OnPropertyChanged(nameof(Sources));
        }
        #endregion

        public void SetTypes(IList<string> types)
        {
            for (ushort i = 0; i < types.Count; i++)
                Types.Add(types[i]);
        }

        public void SetElement(IList<string> types, Source sources)
        {
            SetTypes(types);
            Text = sources.Name;

            SetElement(sources);
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