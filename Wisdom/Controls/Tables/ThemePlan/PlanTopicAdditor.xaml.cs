using ControlMaterials.Tables.ThemePlan;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wisdom.Controls.Tables.ThemePlan
{
    /// <summary>
    /// Special component to add new topic to theme plan
    /// </summary>
    public partial class PlanTopicAdditor : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            DataProperty = DependencyProperty.Register(nameof(Data),
                typeof(Topic), typeof(PlanTopicAdditor));

        public static readonly DependencyProperty
            AddProperty = DependencyProperty.Register(nameof(Add),
                typeof(ICommand), typeof(PlanTopicAdditor));

        public ICommand Add
        {
            get => GetValue(AddProperty) as ICommand;
            set => SetValue(AddProperty, value);
        }
        
        public Topic Data
        {
            get => GetValue(DataProperty) as Topic;
            set => SetValue(DataProperty, value);
        }

        public PlanTopicAdditor()
        {
            InitializeComponent();
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
