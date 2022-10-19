using ControlMaterials.Total;
using ControlMaterials.Total.Count;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public class AutoCount<T> : ManualCount<T>, ISummator where T : IHours, IChangeable
    {
        public readonly ICount _node;
        public override ushort PrevSum => _node.Hours;

        public AutoCount(Bridge<ISummator> count, ICount node) : base(count)
        {
            _node = node;
        }

        public override void Add(T item)
        {
            _node.Count.Append(item.Hours);
        }

        public override void Remove(T item)
        {
            _node.Count.Reduce(item.Hours);
        }

        public override void Recalculate()
        {
            _node.Count.SetTotal(GetSum());
        }

        public override void Setup()
        {
            base.Setup();
            Recalculate();
        }
    }
}
