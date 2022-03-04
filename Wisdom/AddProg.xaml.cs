using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using Wisdom.ViewModel;

namespace Wisdom
{
    /// <summary>
    /// Add new discipline program window
    /// </summary>
    public partial class AddProg : Window, INotifyPropertyChanged
    {
        #region DisciplineProgramWindow Members
        private DisciplineProgramViewModel _viewModel;
        public DisciplineProgramViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public AddProg()
        {
            InitializeComponent();
            ViewModel = new DisciplineProgramViewModel();
        }

        public AddProg(DisciplineProgram program) : this()
        {
            ViewModel.SetFromTemplate(program);
        }

        private void MakeUserTemplate(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateTemplate(FileName);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MakeDocument(FileName);
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