using System.Windows;
using System.Windows.Controls;
using System.IO;
using Wisdom.Model.Documents;
using Wisdom.Controls.Forms.MainForm.UserTemplates;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Wisdom.Controls.Forms.MainForm
{
    /// <summary>
    /// Part responsible for add/load program calls
    /// </summary>
    public partial class MainPart : UserControl, INotifyPropertyChanged
    {
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

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateDisciplineProgram();
        }

        private void RefreshTemplates(object sender, RoutedEventArgs e)
        {
            ReloadTemplates();
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
                string templatesDirectory = @"D:\Aleksandr\Windows-7\Учёба, ПТК НовГУ\4 курс\ДИПЛОМ\Шаблоны JSON";
                foreach (string file in
                    Directory.GetFiles(templatesDirectory))
                {
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
            _ = MessageBox.Show(noLoad + message + advice + exception);
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