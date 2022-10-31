using ControlMaterials.Total;
using System.Collections.Generic;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;

namespace Wisdom.ViewModel.Collections.Features.Building.Stacking
{
    public class Counter<T, TParent> : Stacker<T, TParent>
        where T : IHours, IChangeable, ICloneable<T>
        where TParent : ICount, ICollectionContainer<T>, ICloneable<TParent>, IHighlighting
    {
        private CountBuilder<T, TParent> _count;
        private HighlightBuilder<T, TParent> _highlighting;

        public Counter()
        {
            Reset();
        }

        private protected override void Reset()
        {
            _count = new CountBuilder<T, TParent>();
            _highlighting = new HighlightBuilder<T, TParent>();
        }

        public override StateGroup<T, TParent> Stack()
        {
            List<StateBlock<T, TParent>> features = new List<StateBlock<T, TParent>>();
            Bridge<ISummator<TParent>> count = new Bridge<ISummator<TParent>>();
            
            features.Add(_count.Sync(count).Manual().Auto().Select(0).Result());
            features.Add(_highlighting.Off().On(count).Select(0).Result());

            return new StateGroup<T, TParent>(features);
        }
    }
}
