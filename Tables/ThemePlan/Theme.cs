using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Theme
    {
        public Theme()
        {
            Works = new ObservableCollection<Work>();
        }
        
        public string Name { get; set; }
        
        private ushort _hours;
        public ushort Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Competetion> _gCompetetions;
        public ObservableCollection<Competetion> GCompetetions
        {
            get => _gCompetetions;
            set
            {
                _gCompetetions = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<Competetion> _pCompetetions;
        public ObservableCollection<Competetion> PCompetetions
        {
            get => _pCompetetions;
            set
            {
                _pCompetetions = value;
                OnPropertyChanged();
            }
        }
        
        private ushort _level;
        public ushort Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Work> Works { get; }
        
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
