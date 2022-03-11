using System.Windows;
using System.Windows.Controls;
using System.IO;
using Wisdom.Controls.Forms.MainForm.UserTemplates;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using static Wisdom.Writers.AutoGenerating.Processors;
using Wisdom.ViewModel;
using Serilog;

namespace Wisdom.Controls.Forms.MainForm
{
    /// <summary>
    /// Part responsible for add/load program calls
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
                typeof(GlobalViewModel), typeof(MainPart));

        #region MainPart Members
        public GlobalViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as GlobalViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        public static readonly string ProgramPreferences;
        public Preferences Settings { get; set; }

        private ObservableCollection<DisciplineProgramTemplate> _templates;
        public ObservableCollection<DisciplineProgramTemplate> Templates
        {
            get => _templates;
            set
            {
                _templates = value;
                OnPropertyChanged();
            }
        }
        #endregion

        static MainPart()
        {
            ProgramPreferences = "Preferences.json";
        }

        public MainPart()
        {
            InitializeComponent();
            Templates = new ObservableCollection<DisciplineProgramTemplate>();

            Settings = LoadConfig<Preferences>
                (ProgramPreferences) ?? new Preferences();
            LoadTemplates();
        }

        #region CreateProgram Logic
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateDisciplineProgram();
        }

        public void CreateDisciplineProgram()
        {
            AddProg Discipline;

            if (ViewModel.Connector.IndependentMode)
            {
                Discipline = new AddProg();
            }
            else
            {
                Discipline = new AddProg(ViewModel);
            }

            Discipline.Show();
        }
        #endregion

        #region Templates Logic
        private void SelectTemplatesDirectory(object sender, RoutedEventArgs e)
        {
            using System.Windows.Forms.FolderBrowserDialog
                dialog = CallLocator("Выберите место шаблонов учебных программ");

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.TemplatePath = dialog.SelectedPath;
                SaveConfig(ProgramPreferences, Settings);
                ReloadTemplates();
            }
        }

        public void ReloadTemplates()
        {
            Templates.Clear();
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            Log.Information("Loading templates from folder: " +
                Settings.TemplatePath);
            try
            {
                foreach (string file in
                    Directory.GetFiles(Settings.TemplatePath))
                {
                    if (Path.GetExtension(file).ToLower() != ".json")
                    {
                        continue;
                    }

                    DisciplineProgramTemplate
                        template = new
                        DisciplineProgramTemplate
                        {
                            FullName = file,
                            MainForm = this
                        };
                    Templates.Add(template);
                }
            }
            catch (IOException exception)
            {
                Log.Error("Exception on templates loading: " +
                    exception.Message);
                LoadMessage(exception.Message);
            }
        }
        #endregion

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