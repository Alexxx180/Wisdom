using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel;
using System.Windows;
using Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram;

namespace Wisdom.Controls.DocumentForms.AddDisciplineProgram
{
    /// <summary>
    /// Part responsible for result document previewing
    /// </summary>
    public partial class PreviewPart : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register("ViewModel",
                typeof(DisciplineProgramViewModel), typeof(PreviewPart));

        internal DisciplineProgramViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as DisciplineProgramViewModel;
            set
            {
                SetValue(ViewModelProperty, value);
                OnPropertyChanged();
            }
        }

        public PreviewPart()
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