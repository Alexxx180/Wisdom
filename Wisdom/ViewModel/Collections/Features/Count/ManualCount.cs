using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public class ManualCount<T> : State<T>, ISummator where T : IHours, IChangeable
    {
        private protected readonly Bridge<ISummator> Count;
        private readonly IHours _node;

        public ushort Sum => GetSum();
        public virtual ushort PrevSum => _node.Hours;

        public ManualCount(Bridge<ISummator> count) : base(nameof(IHours.Hours))
        {
            Count = count;
        }

        public ManualCount(Bridge<ISummator> count, IHours node) : this(count)
        {
            _node = node;
        }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }

        public override void Setup()
        {
            Count.SetReference(this);
        }

        private protected ushort GetSum()
        {
            ushort sum = 0;
            for (ushort i = 0; i < Items.Count; i++)
            {
                sum += Items[i].Hours;
            }
            return sum;
        }
    }
}
