using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram;
using Wisdom.ViewModel;
using Wisdom.Writers.AutoGenerating.Documents;
using static Wisdom.Writers.AutoGenerating.Processors;
using static Wisdom.Writers.ResultRenderer;
using Wisdom.Model;

namespace Wisdom
{
    /// <summary>
    /// Add new discipline program window
    /// </summary>
    public partial class AddProg : Window, INotifyPropertyChanged
    {
        #region DisciplineProgramWindow Members
        private DisciplineProgram _program;
        public DisciplineProgram Program
        {
            get => _program;
            set
            {
                _program = value;
                OnPropertyChanged();
            }
        }

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
            Program = new DisciplineProgram(ReadJson<Settings>
                (SettingsDirectory + DisciplineProgram.ProgramPreferences));
            Page5.LoadPreferences(Program.Processing);
        }

        public AddProg(Model.Documents.DisciplineProgram program) : this()
        {
            ViewModel.SetFromTemplate(program);
        }

        private void MakeUserTemplate(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateTemplate(FileName);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (Page5.WasChanged())
                SavePreferences();

            Pair<string, bool> head = UserAgreement();
            if (head.Value)
            {
                Program.WriteDocument
                    (Program.Processing.TemplatePath,
                    head.Name, ViewModel.MakeDocument());
            }
        }

        private void DisciplineProgramWindow_Closing(object sender, CancelEventArgs e)
        {
            if (Page5.WasChanged())
                SavePreferences();
        }

        private void SavePreferences()
        {
            Program.Processing.TemplatePath = Page5.FullPath;
            Program.Processing.Options = Page5.SerializeOptions();

            ProcessJson(SettingsDirectory +
                DisciplineProgram.ProgramPreferences,
                Program.Processing);
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