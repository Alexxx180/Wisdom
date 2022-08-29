using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel;
using System.Windows;

namespace Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram
{
    /// <summary>
    /// Part responsible for total hours editing
    /// </summary>
    public partial class HoursPart : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(DisciplineProgramViewModel), typeof(HoursPart));

        public DisciplineProgramViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as DisciplineProgramViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        public HoursPart()
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