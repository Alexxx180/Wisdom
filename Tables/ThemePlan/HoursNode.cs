using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class HoursNode<T> : HybridNode<T>
    {
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
