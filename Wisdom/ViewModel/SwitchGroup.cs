using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Wisdom.Controls.Forms;
using static Wisdom.Customing.Decorators;

namespace Wisdom.ViewModel
{
    internal class SwitchGroup : INotifyPropertyChanged
    {
        private Switcher _activeSwitcher;
        internal Switcher ActiveSwitcher
        {
            get => _activeSwitcher;
            set
            {
                if (_activeSwitcher != null)
                    _activeSwitcher.IsNotPressed = true;
                _activeSwitcher = value;
                OnPropertyChanged();
            }
        }

        private FrameworkElement _activeElement;
        internal FrameworkElement ActiveElement
        {
            get => _activeElement;
            set
            {
                if (_activeElement != null)
                    _activeElement.SetActive(false);
                _activeElement = value;
                _activeElement.SetActive(true);
                OnPropertyChanged();
            }
        }

        internal void SwitchElement(
            Switcher switcher, FrameworkElement element)
        {
            ActiveSwitcher = switcher;
            ActiveElement = element;
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