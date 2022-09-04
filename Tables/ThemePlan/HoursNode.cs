using ControlMaterials.Total;
using System.Collections.ObjectModel;

namespace ControlMaterials.Tables.ThemePlan
{
    public class HoursNode<T> : HybridNode<T>
    {
        public HoursNode() : base() { }

        public HoursNode(ObservableCollection<T> items) : base(items) { }

        public override HoursNode<T> Copy()
        {
            return new HoursNode<T>(Items)
            {
                No = No,
                Name = Name,
                Hours = Hours
            };
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
    }
}
