using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Topic of theme plan
    /// </summary>
    public partial class PlanTopic : UserControl, INotifyPropertyChanged, IRecordsIndexing, IExtendableItems, IWrapFields
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(Topic), typeof(PlanTopic));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(PlanTopic));
                
        public static readonly DependencyProperty
            RemoveThemeProperty = DependencyProperty.Register(nameof(RemoveTheme),
                typeof(ICommand), typeof(PlanTopic));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
        
        public ICommand RemoveTheme
        {
            get => GetValue(RemoveThemeProperty) as ICommand;
            set => SetValue(RemoveThemeProperty, value);
        }
        
        public Topic Data
        {
            get => GetValue(DataProperty) as Topic;
            set => SetValue(DataProperty, value);
        }
        #endregion

        #region IAutoIndexing Members
        private uint _no;
        public uint No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public void Index(uint no)
        {
            No = no;
        }
        #endregion

        #region AutoIndexing Logic
        public void AutoIndexing()
        {
            ushort i;
            for (i = 0; i < Themes.Count; i++)
            {
                Themes[i].Index((i + 1).ToUInt());
            }
            ThemeAdditor.Index((i + 1).ToUInt());
        }
        #endregion

        #region PlanTopic Members
        public RecordsPanel _options;
        public RecordsPanel Options
        {
            get => _options;
            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        private string _topicName;
        public string TopicName
        {
            get => _topicName;
            set
            {
                _topicName = value;
                OnPropertyChanged();
            }
        }

        private string _topicHours;
        public string TopicHours
        {
            get => _topicHours;
            set
            {
                _topicHours = value;
                OnPropertyChanged();
                Options?.RegisterEdit();
            }
        }

        private ObservableCollection<PlanTheme> _themes;
        public ObservableCollection<PlanTheme> Themes
        {
            get => _themes;
            set
            {
                _themes = value;
                OnPropertyChanged();
            }
        }

        public void RefreshHours()
        {
            OnPropertyChanged(nameof(Themes));
        }
        #endregion

        #region IExtendableItems Members
        private bool _extended;
        public bool Extended
        {
            get => _extended;
            set
            {
                _extended = value;
                OnPropertyChanged();
            }
        }

        public void ExtendItems()
        {
            Extended = !Extended;
        }
        #endregion

        #region IWrapFields Members
        private bool _isWrap;
        public bool IsWrap
        {
            get => _isWrap;
            set
            {
                _isWrap = value;
                OnPropertyChanged();
            }
        }

        public void WrapFields()
        {
            IsWrap = !IsWrap;
        }
        #endregion

        public PlanTopic()
        {
            InitializeComponent();
            Index(1);
            Themes = new ObservableCollection<PlanTheme>();
            Extended = true;
            IsWrap = false;
        }

        private void DropTopic(object sender, RoutedEventArgs e)
        {
            Options.DropRecord(this);
        }

        #region ThemesGroup Members
        public void DropTheme(PlanTheme source)
        {
            _ = Themes.Remove(source);
            AutoIndexing();
            OnPropertyChanged(nameof(Themes));
        }

        public void AddRecord(PlanTheme record)
        {
            Themes.Add(record);
            OnPropertyChanged(nameof(Themes));
        }
        #endregion

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
