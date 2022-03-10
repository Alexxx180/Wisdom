using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel;

namespace Wisdom
{
    /// <summary>
    /// Customer main window
    /// </summary>
    public partial class MainWindow : Window
    {
        private GlobalViewModel _viewModel;
        public GlobalViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            ViewModel = new GlobalViewModel();
            ViewModel.Connector.Connect();

            ActivateUser();
        }

        private void ActivateUser()
        {
            InitializeComponent();
            OnPropertyChanged(nameof(ViewModel));
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