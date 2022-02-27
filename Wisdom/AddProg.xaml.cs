using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model;
using Wisdom.ViewModel;

namespace Wisdom
{
    /// <summary>
    /// Add new programm instance window
    /// </summary>
    public partial class AddProg : Window, INotifyPropertyChanged
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

        private string FileName => Program.Text;

        public AddProg()
        {
            InitializeComponent();
            ViewModel = DataContext as DisciplineProgramViewModel;
        }

        public AddProg(DisciplineProgram program) : this()
        {
            
        }

        private void MakeUserTemplate(object sender, RoutedEventArgs e)
        {
            //ViewModel.TestCompetetions();
            ViewModel.TestDiscipline();
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