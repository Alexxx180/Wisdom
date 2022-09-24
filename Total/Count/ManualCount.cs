using ControlMaterials.Total.Collections;

namespace ControlMaterials.Total.Count
{
    public class ManualCount<T> : State<T>, ISummator where T : ISum
    {
        private protected readonly Bridge<ISummator> Count;
        private readonly ISum _node;

        public ushort Sum => GetSum();
        public virtual ushort PrevSum => _node.Sum;

        public ManualCount(Bridge<ISummator> count,
            string property) : base(property)
        {
            Count = count;
        }

        public ManualCount(Bridge<ISummator> count, ISum node,
            string property) : this(count, property)
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
                sum += Items[i].Sum;
            }
            return sum;
        }
    }
}
