using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ControlMaterials.Tables;
using System.Windows.Input;
using ControlMaterials.Total;

namespace Wisdom.Controls.Tables.Sources.Groups
{
    /// <summary>
    /// Special component to add new source type group
    /// </summary>
    public partial class SourceGroupAdditor : UserControl, INotifyPropertyChanged
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            VariantsProperty = DependencyProperty.Register(nameof(Variants),
                typeof(ObservableCollection<string>), typeof(SourceGroupAdditor));
        
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(NameNode<IndexedLabel>), typeof(SourceGroupAdditor));

        public static readonly DependencyProperty
            AddProperty = DependencyProperty.Register(nameof(Add),
                typeof(ICommand), typeof(SourceGroupAdditor));

        public ICommand Add
        {
            get => GetValue(AddProperty) as ICommand;
            set => SetValue(AddProperty, value);
        }
        
        public NameNode<IndexedLabel> Data
        {
            get => GetValue(DataProperty) as Source;
            set => SetValue(DataProperty, value);
        }
        
        public ObservableCollection<string> Variants
        {
            get => GetValue(VariantsProperty) as ObservableCollection<string>;
            set => SetValue(VariantsProperty, value);
        }
        #endregion

        public SourceGroupAdditor()
        {
            InitializeComponent();
            Data = new NameNode<IndexedLabel>();
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
