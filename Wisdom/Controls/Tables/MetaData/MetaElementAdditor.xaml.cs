using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Tables.ThemePlan;
using Wisdom.ViewModel;
using System.Windows;

namespace Wisdom.Controls.Tables.MetaData
{
    /// <summary>
    /// Special component to add new metadata
    /// </summary>
    public partial class MetaElementAdditor : UserControl, INotifyPropertyChanged, IRawData<Task>
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(
                nameof(ViewModel), typeof(DisciplineProgramViewModel),
                typeof(MetaElementAdditor));

        #region IRawData Members
        public Task Raw()
        {
            return new Task(MetaName, MetaValue);
        }

        public void SetElement(Task values)
        {
            MetaName = values.Name;
            //MetaValue = values.Hours;
        }
        #endregion

        #region MetaData Members
        public DisciplineProgramViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as DisciplineProgramViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        public string _name;
        public string MetaName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _value;
        public string MetaValue
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MetaElementAdditor()
        {
            InitializeComponent();
        }

        private void AddMetaData(object sender, RoutedEventArgs e)
        {
            ViewModel.AddMetaData(Raw());
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