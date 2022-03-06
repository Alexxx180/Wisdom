using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.Model.Tables.ThemePlan;

namespace Wisdom.Controls.Tables.MetaData
{
    /// <summary>
    /// Record component containing discipline meta data
    /// </summary>
    public partial class MetaElement : UserControl, INotifyPropertyChanged, IRawData<Task>
    {
        #region IRawData Members
        public Task Raw()
        {
            return new Task(MetaName, MetaValue);
        }

        public void SetElement(Task values)
        {
            MetaName = values.Name;
            MetaValue = values.Hours;
        }
        #endregion

        #region MetaData Members
        public string _name;
        public string MetaName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string _value;
        public string MetaValue
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MetaElement()
        {
            InitializeComponent();
        }

        public void SetType(string type)
        {
            MetaName = type;
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