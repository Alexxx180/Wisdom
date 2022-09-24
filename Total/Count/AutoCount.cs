namespace ControlMaterials.Total.Count
{
    public class AutoCount<T> : ManualCount<T>, ISummator where T : ISum
    {
        public readonly ICount _node;
        public override ushort PrevSum => _node.Sum;

        public AutoCount(Bridge<ISummator> count, ICount node,
            string property) : base(count, property)
        {
            _node = node;
        }

        public override void Add(T item)
        {
            _node.Append(item.Sum);
        }

        public override void Remove(T item)
        {
            _node.Reduce(item.Sum);
        }

        public override void Recalculate()
        {
            _node.SetTotal(GetSum());
        }

        public override void Setup()
        {
            base.Setup();
            Recalculate();
        }
    }
}
