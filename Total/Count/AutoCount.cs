namespace ControlMaterials.Total.Count
{
    public class AutoCount<T> : State<T> where T : ISum
    {
        public ICount _node;

        public AutoCount(ICount node, string property) : base(property)
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
            uint sum = 0;
            for (ushort i = 0; i < Items.Count; i++)
            {
                sum += Items[i].Sum;
            }
            _node.SetTotal(sum);
        }
    }
}
