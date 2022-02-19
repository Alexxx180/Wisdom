using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel;

namespace Wisdom.Controls.DocumentForms.AddDisciplineProgram
{
    /// <summary>
    /// Part responsible for result document previewing
    /// </summary>
    public partial class PreviewPart : UserControl, INotifyPropertyChanged
    {
        private DisciplineProgramViewModel _viewModel;
        internal DisciplineProgramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public PreviewPart()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}