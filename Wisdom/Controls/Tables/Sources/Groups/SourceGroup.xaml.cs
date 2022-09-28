using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wisdom.Customing;
using ControlMaterials.Tables;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;
using ControlMaterials.Total;

namespace Wisdom.Controls.Tables.Sources.Groups
{
    /// <summary>
    /// Record component containing source group with type header
    /// </summary>
    public partial class SourceGroup : UserControl, INotifyPropertyChanged
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            VariantsProperty = DependencyProperty.Register(nameof(Variants),
                typeof(ObservableCollection<string>), typeof(SourceGroup));
        
        //public static readonly DependencyProperty
        //    DataProperty = DependencyProperty.Register(nameof(Data),
        //        typeof(NameNode<IndexedLabel>), typeof(SourceGroup));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(SourceGroup));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
        
        //public NameNode<IndexedLabel> Data
        //{
        //    get => GetValue(DataProperty) as Source;
        //    set => SetValue(DataProperty, value);
        //}
        
        public ObservableCollection<string> Variants
        {
            get => GetValue(VariantsProperty) as ObservableCollection<string>;
            set => SetValue(VariantsProperty, value);
        }
        #endregion
    
        public ICommand RemoveSource { get; }

        public SourceGroup()
        {
            InitializeComponent();
            //RemoveSource = new RelayCommand(argument =>
            //{
            //    Data.Remove((IndexedLabel)argument);
            //});
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
