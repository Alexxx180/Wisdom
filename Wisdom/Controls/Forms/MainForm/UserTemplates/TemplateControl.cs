using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Wisdom.Controls.Forms.MainForm.UserTemplates
{
    /// <summary>
    /// User input template file unit
    /// </summary>
    public class TemplateControl : UserControl, INotifyPropertyChanged
    {
        #region TemplateControl Members
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FileName));
            }
        }

        public string FileName => Path.GetFileNameWithoutExtension(FullName);
        #endregion

        public MainPart MainForm { get; set; }

        public T LoadFromTemplate<T>()
        {
            T progam = default;
            try
            {
                byte[] fileBytes = File.ReadAllBytes(FullName);
                Utf8JsonReader utf8Reader = new Utf8JsonReader(fileBytes);
                progam = JsonSerializer.Deserialize<T>(ref utf8Reader);
            }
            catch (IOException exception)
            {
                LoadMessage(exception.Message);
            }
            return progam;
        }

        protected static void LoadMessage(string exception)
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