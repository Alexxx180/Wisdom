using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using static Wisdom.Writers.AutoGenerating.Processors;

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
            return ReadJson<T>(FullName);
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