using ControlMaterials.Tables.Tasks;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Collections.Nodes;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Numeration;
using System.Collections.ObjectModel;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Theme : HoursNode<Work>, ISum, INumerable, ICloneable<Theme>
    {
        public Theme() : base(new Work())
        {
            GCompetetions = new ObservableCollection<Competetion>();
            PCompetetions = new ObservableCollection<IndexNode<Competetion>>();
        }

        private protected Theme
            (OptionableCollection<Work> items, ObservableCollection<Competetion> gcompetetions,
            ObservableCollection<IndexNode<Competetion>> pcompetetions) : base(items)
        {
            GCompetetions = new ObservableCollection<Competetion>(gcompetetions);
            PCompetetions = new ObservableCollection<IndexNode<Competetion>>(pcompetetions);
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

        public override Theme Copy()
        {
            return new Theme(_items, GCompetetions, PCompetetions)
            {
                No = No,
                Name = Name,
                Hours = Hours
            };
        }

        public ObservableCollection<Competetion> GCompetetions { get; }
        public ObservableCollection<IndexNode<Competetion>> PCompetetions { get; }
    }
}
