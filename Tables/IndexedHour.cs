using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class IndexedHour : IndexedLabel, ISum, ICloneable<IndexedHour>
    {
        public IndexedHour() : base() { }

        public IndexedHour(string name, ushort count) : base(name)
        {
            Count = count;
        }

        public ushort Sum => Count;

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

        public override IndexedHour Copy()
        {
            return new IndexedHour(Name, Count)
            {
                No = No
            };
        }
    }
}
