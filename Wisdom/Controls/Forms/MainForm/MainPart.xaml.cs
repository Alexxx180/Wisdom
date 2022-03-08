using System.Windows;
using System.Windows.Controls;
using System.IO;
using Wisdom.Controls.Forms.MainForm.UserTemplates;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using static Wisdom.Writers.AutoGenerating.Processors;

namespace Wisdom.Controls.Forms.MainForm
{
    /// <summary>
    /// Part responsible for add/load program calls
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
        public static readonly string ProgramPreferences = "Preferences.json";
        public static Preferences Settings { get; set; }

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

        public MainPart()
        {
            InitializeComponent();
            Templates = new ObservableCollection<DisciplineProgramTemplate>();
            LoadTemplates();
        }

        public static void CreateDisciplineProgram()
        {
            AddProg Discipline = new AddProg();
            Discipline.Show();
        }

        private void SelectTemplatesDirectory(object sender, RoutedEventArgs e)
        {
            using System.Windows.Forms.FolderBrowserDialog
                dialog = CallLocator("Выберите место шаблонов учебных программ");

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.TemplatePath = dialog.SelectedPath;
                ProcessJson(ConfigDirectory + ProgramPreferences, Settings);
                ReloadTemplates();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateDisciplineProgram();
        }

        public void ReloadTemplates()
        {
            Templates.Clear();
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            try
            {
                if (Settings == null)
                {
                    Settings = new Preferences();
                    return;
                }
                
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
                LoadMessage(exception.Message);
            }
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