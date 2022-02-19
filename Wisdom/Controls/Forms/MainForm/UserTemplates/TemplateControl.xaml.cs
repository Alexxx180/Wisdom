using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.Forms.MainForm.UserTemplates
{
    /// <summary>
    /// User input template file unit
    /// </summary>
    public partial class TemplateControl : UserControl, INotifyPropertyChanged
    {
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                FileName = Path.GetFileNameWithoutExtension(value);
                OnPropertyChanged();
            }
        }

        private string _name;
        public string FileName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public TemplateControl()
        {
            InitializeComponent();
        }

        public TemplateControl(string fullName) : this()
        {
            FullName = fullName;
        }

        private void RemoveSelf()
        {
            StackPanel templates = Parent(this);
            templates.Children.Remove(this);
        }

        private void CreateFromTemplate(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FullName))
            {
                RemoveSelf();
                return;
            }
            try
            {
                LoadFromTemplate();
            }
            catch (IOException exception)
            {
                LoadMessage(exception.Message);
            }
        }

        private void LoadFromTemplate()
        {
            byte[] fileBytes = File.ReadAllBytes(FullName);
            Utf8JsonReader utf8Reader = new Utf8JsonReader(fileBytes);
            DisciplineProgram program = JsonSerializer.Deserialize<DisciplineProgram>(ref utf8Reader);
            MainPart.CreateDisciplineProgram(program);
        }

        private static void LoadMessage(string exception)
        {
            string noLoad = "Не удалось загрузить файл.";
            string message = "\nУбедитесь, что файл не поврежден или отсутствует в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
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