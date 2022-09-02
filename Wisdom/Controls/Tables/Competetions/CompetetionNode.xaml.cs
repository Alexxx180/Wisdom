using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlMaterials.Tables;
using Wisdom.ViewModel.Commands;
using System.Windows.Input;
using ControlMaterials.Total;

namespace Wisdom.Controls.Tables.Competetions
{
    /// <summary>
    /// Professional competetion related to speciality | discipline
    /// </summary>
    public partial class CompetetionNode : UserControl, INotifyPropertyChanged, IExtendableItems
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(IndexNode<Competetion>), typeof(CompetetionNode));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(CompetetionNode));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }
        
        public IndexNode<Competetion> Data
        {
            get => GetValue(DataProperty) as IndexNode<Competetion>;
            set => SetValue(DataProperty, value);
        }
        #endregion

        public ICommand RemoveCompetetion { get; }

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

        public CompetetionNode()
        {
            InitializeComponent();
            Extended = true;
            RemoveCompetetion = new RelayCommand(argument =>
            {
                Data.Items.Remove((Competetion)argument);
            });
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
