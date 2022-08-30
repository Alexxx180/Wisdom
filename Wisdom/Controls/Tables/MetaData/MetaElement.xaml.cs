using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Tables.ThemePlan;
using Wisdom.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.MetaData
{
    /// <summary>
    /// Record component containing discipline meta data
    /// </summary>
    public partial class MetaElement : UserControl, INotifyPropertyChanged, IRawData<Task>, IWrapFields
    {
        public static readonly DependencyProperty
            MetaNameProperty = DependencyProperty.Register(nameof(MetaName),
                typeof(string), typeof(MetaElement));

        public static readonly DependencyProperty
            MetaValueProperty = DependencyProperty.Register(nameof(MetaValue),
                typeof(string), typeof(MetaElement));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(MetaElement));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }


        #region IRawData Members
        public Task Raw()
        {
            return new Task(MetaName, MetaValue);
        }

        public void SetElement(Task values)
        {
            MetaName = values.Name;
            MetaValue = values.Hours;
        }
        #endregion

        #region MetaData Members
        private DisciplineProgramViewModel _viewModel;
        public DisciplineProgramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public string MetaName
        {
            get => GetValue(MetaNameProperty) as string;
            set => SetValue(MetaNameProperty, value);
        }

        public string MetaValue
        {
            get => GetValue(MetaValueProperty) as string;
            set => SetValue(MetaValueProperty, value);
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

        public MetaElement()
        {
            InitializeComponent();
        }

        private void DropMetaData(object sender, RoutedEventArgs e)
        {
            ViewModel.DropMetaData(this);
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