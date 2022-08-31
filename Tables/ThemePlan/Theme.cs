using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Theme : NameLabel
    {
        public Theme()
        {
            Works = new ObservableCollection<Work>();
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
    }
}
