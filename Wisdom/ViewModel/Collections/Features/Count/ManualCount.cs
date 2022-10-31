using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public class ManualCount<T, TParent> : State<T, TParent>, ISummator<TParent>
        where T : IHours, IChangeable, ICloneable<T>
        where TParent : ICount, ICollectionContainer<T>, ICloneable<TParent>
    {
        private protected readonly Bridge<ISummator<TParent>> Count;
        
        public ManualCount(Bridge<ISummator<TParent>> count) : base(nameof(IHours.Hours))
        {
            Count = count;
        }

        public override void Add(T item, TParent parent) { }

        public override void Remove(T item, TParent parent) { }

        public override void Recalculate(T item, TParent parent) { }

        public override void Setup()
        {
            Count.SetReference(this);
        }

        public ushort PreviousSum(TParent parent)
        {
            return parent.Count.Sum;
        }

        public virtual ushort CurrentSum(TParent parent)
        {
            return Sum(parent);
        }

        private protected static ushort Sum(TParent parent)
        {
            ushort sum = 0;
            for (byte i = 0; i < parent.Items.Count; i++)
            {
                sum += parent.Items[i].Hours;
            }
            return sum;
        }
    }
}
