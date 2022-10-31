using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public class AutoCount<T, TParent> : ManualCount<T, TParent>, ISummator<TParent>
        where T : IHours, IChangeable, ICloneable<T>
        where TParent : ICount, ICollectionContainer<T>, ICloneable<TParent>
    {
        public AutoCount(Bridge<ISummator<TParent>> count) : base(count) { }

        public override void Add(T item, TParent parent)
        {
            parent.Count.Append(item.Hours);
        }

        public override void Remove(T item, TParent parent)
        {
            parent.Count.Reduce(item.Hours);
        }

        public override void Recalculate(T item, TParent parent)
        {
            parent.Count.SetTotal(Sum(parent));
        }

        public override void Setup()
        {
            base.Setup();
        }

        public override ushort CurrentSum(TParent parent)
        {
            return PreviousSum(parent);
        }
    }
}
