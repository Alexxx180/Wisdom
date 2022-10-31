using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Collections.Features.Building
{
    public class CountBuilder<T, TParent> : StateBuilder<T, TParent>
        where T : IHours, IChangeable, ICloneable<T>
        where TParent : ICount, ICollectionContainer<T>, ICloneable<TParent>
    {
        private Bridge<ISummator<TParent>> _count;

        public CountBuilder<T, TParent> Sync(Bridge<ISummator<TParent>> сount)
        {
            _count = сount;
            return this;
        }

        public CountBuilder<T, TParent> Manual()
        {
            AddState(new ManualCount<T, TParent>(_count));
            return this;
        }

        public CountBuilder<T, TParent> Auto()
        {
            AddState(new AutoCount<T, TParent>(_count));
            return this;
        }
    }
}
