using ControlMaterials.Total;
using ControlMaterials.Total.Count;

namespace ControlMaterials.Tables.ThemePlan
{
    public class HoursNode<T> : HybridNode<T>, ISum, ICount where T : INumerable, ISum, ICloneable<T>
    {
        public HoursNode(T additor)
        {
            SetItems(additor, Numeration(), SumCount());
            Option(0, 0);
            Option(1, 0);
        }

        private protected HoursNode(OptionableCollection<T> items) : base(items) { }


        private protected State<T>[] SumCount()
        {
            return new State<T>[]
            {
                new ManualCount<T>(nameof(Hours)),
                new AutoCount<T>(this, nameof(Hours))
            };
        }


        public override HoursNode<T> Copy()
        {
            return new HoursNode<T>(_items)
            {
                No = No,
                Name = Name,
                Hours = Hours
            };
        }

        public void Append(ushort increment)
        {
            Hours += increment;
        }

        public void Reduce(ushort decrement)
        {
            Hours -= decrement;
        }

        public void SetTotal(ushort sum)
        {
            Hours = sum;
        }

        public ushort Sum => Hours;

        private ushort _hours;
        public ushort Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Sum));
            }
        }
    }
}
