using System.Windows;
using System.Windows.Controls;
using System.IO;
using Wisdom.Controls.Forms.MainForm.UserTemplates;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using static Wisdom.Writers.AutoGenerating.Processors;

namespace Wisdom.Controls.Forms.MainForm
{
    /// <summary>
    /// Part responsible for add/load program calls
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
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

        static MainPart()
        {
            Settings = new Preferences();
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
                dialog = new System.Windows.Forms.FolderBrowserDialog
                {
                    Description = "Выберите директорию пользовательских шаблонов",
                    UseDescriptionForTitle = true,
                    SelectedPath = Environment.GetFolderPath(
                        Environment.SpecialFolder.DesktopDirectory)
                        + Path.DirectorySeparatorChar,
                    ShowNewFolderButton = true
                };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.TemplateDirectory = dialog.SelectedPath;
                ProcessJson(ConfigDirectory + "Preferences.json", Settings);
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
                foreach (string file in
                    Directory.GetFiles(Settings.TemplateDirectory))
                {
                    if (Path.GetExtension(file).ToLower() != ".json")
                        continue;

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

        private static void LoadMessage(string exception)
        {
            string noLoad = "Не удалось загрузить шаблоны.";
            string message = "\nФайлы повреждены или " +
                "находятся вне досягаемости программы.\n";
            string advice = "Полное сообщение:\n";
            _ = MessageBox.Show
                (noLoad + message + advice + exception);
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