using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using Wisdom.Model;
using static Wisdom.Customing.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wisdom.Controls.UserTemplates
{
    /// <summary>
    /// Логика взаимодействия для TemplateControl.xaml
    /// </summary>
    public partial class TemplateControl : UserControl, INotifyPropertyChanged
    {
        private string _name = "";
        public string FileName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string FullName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public TemplateControl()
        {
            InitializeComponent();
        }

        public TemplateControl(string fullName) : this()
        {
            FullName = fullName;
            FileName = Path.GetFileNameWithoutExtension(fullName);
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
            MainWindow.CreateDisciplineProgram(program);
        }

        private static void LoadMessage(string exception)
        {
            string noLoad = "Не удалось загрузить файл.";
            string message = "\nУбедитесь, что файл не поврежден или отсутствует в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }
    }
}