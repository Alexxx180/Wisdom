using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class Hour : NameLabel
    {
        public Hour() { }

        public Hour(string name, ushort count)
        {
            Name = name;
            Count = count;
        }

        public override Hour Copy()
        {
            return new Hour
            {
                Name = Name,
                Count = Count
            };
        }

        private ushort _count;
        public ushort Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
    }
}
