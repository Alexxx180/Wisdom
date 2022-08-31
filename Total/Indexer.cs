using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Total
{
    public class Indexer
    {
        private ushort _no;
        public ushort No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }
        
        public void Add(short no)
        {
            No += no;
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
