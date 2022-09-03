using ControlMaterials.Total;
using System.Collections.ObjectModel;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Theme : HoursNode<Work>
    {
        public Theme() : base()
        {
            GCompetetions = new ObservableCollection<Competetion>();
            PCompetetions = new ObservableCollection<IndexNode<Competetion>>();
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

        public ObservableCollection<Competetion> GCompetetions { get; }
        public ObservableCollection<IndexNode<Competetion>> PCompetetions { get; }
    }
}
