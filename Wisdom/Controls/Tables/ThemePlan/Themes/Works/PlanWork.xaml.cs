using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using Wisdom.Controls.Tables.ThemePlan.Themes.Works.Tasks;
using Wisdom.Customing;
using ControlMaterials.Tables.ThemePlan;
using static Wisdom.Customing.Converters;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan.Themes.Works
{
    /// <summary>
    /// Work with tasks group of theme
    /// </summary>
    public partial class PlanWork : UserControl, INotifyPropertyChanged, IExtendableItems
    {
        #region Dependency Properties
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(Theme), typeof(PlanWork));

        public static readonly DependencyProperty
            RemoveProperty = DependencyProperty.Register(nameof(Remove),
                typeof(ICommand), typeof(PlanWork));
                
        public static readonly DependencyProperty
            RemoveTaskProperty = DependencyProperty.Register(nameof(RemoveTask),
                typeof(ICommand), typeof(PlanWork));

        public ICommand Remove
        {
            get => GetValue(RemoveProperty) as ICommand;
            set => SetValue(RemoveProperty, value);
        }

        public ICommand RemoveTask
        {
            get => GetValue(RemoveTaskProperty) as ICommand;
            set => SetValue(RemoveTaskProperty, value);
        }
        
        public Work Data
        {
            get => GetValue(DataProperty) as Work;
            set => SetValue(DataProperty, value);
        }
        #endregion

        #region PlanWork Members
        public void RefreshHours()
        {
            //OnPropertyChanged(nameof(Tasks));
            //Theme.RefreshHours();
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

        public PlanWork()
        {
            InitializeComponent();
            Extended = true;
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
