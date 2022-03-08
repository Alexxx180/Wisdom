using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram;
using Wisdom.Model.Documents;
using Wisdom.ViewModel;
using static Wisdom.Writers.AutoGenerating.Processors;

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
            SetUp();
        }

        private void SetUp()
        {
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

        private void DisciplineProgramWindow_Closing(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("SAVED");
            SavePreferences();
        }

        private void SavePreferences()
        {
            Page5.SerializeOptions();
            ProcessJson(
                SettingsDirectory + SettingsPart.ProgramPreferences,
                SettingsPart.DisciplineProgramProcessing
                );
        }
    }
}