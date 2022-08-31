using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Topic : NameLabel
    {
        public Topic()
        {
            Themes = new ObservableCollection<Theme>();
        }
      
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
        
        public ObservableCollection<Theme> Themes { get; }
    }
}