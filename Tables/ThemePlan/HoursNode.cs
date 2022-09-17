using ControlMaterials.Total;
using ControlMaterials.Total.Count;

namespace ControlMaterials.Tables.ThemePlan
{
    public class HoursNode<T> : HybridNode<T>, ISum, ICount where T : INumerable, ISum
    {
        public HoursNode()
        {
            SetItems(Numeration(), Count());
            Items.Set(0, 0);
            Items.Set(1, 0);
        }

        private protected State<T>[] Count()
        {
            return new State<T>[]
            {
                new ManualCount<T>(nameof(Hours)),
                new AutoCount<T>(this, nameof(Hours))
            };
        }

        private HoursNode(OptionableCollection<T> items) : base(items) { }

        public override HoursNode<T> Copy()
        {
            return new HoursNode<T>(Items)
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
