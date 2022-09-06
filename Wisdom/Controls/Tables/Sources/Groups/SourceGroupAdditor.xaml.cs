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
    /// Special component to add new source type group
    /// </summary>
    public partial class SourceGroupAdditor : UserControl, INotifyPropertyChanged
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            VariantsProperty = DependencyProperty.Register(nameof(Variants),
                typeof(ObservableCollection<string>), typeof(SourceType));
        
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(NameNode<IndexedLabel>), typeof(SourceType));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(SourceType));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
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

        public SourceTypeElementAdditor()
        {
            InitializeComponent();
            Data = new NameNode<IndexedLabel>();
        }
    }
}
