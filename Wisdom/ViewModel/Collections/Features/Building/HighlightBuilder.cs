using ControlMaterials.Total;
using System.Collections.Generic;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;

namespace Wisdom.ViewModel.Collections.Features.Building
{
    public class HighlightBuilder<T, TParent> : StateBuilder<T, TParent>
        where T : IChangeable where TParent : IHighlighting
    {
        public HighlightBuilder<T, TParent> Off()
        {
            AddState(new HighlightOff<T, TParent>());
            return this;
        }

        public HighlightBuilder<T, TParent> On(Bridge<ISummator<TParent>> сount)
        {
            AddState(new HighlightOn<T, TParent>(сount));
            return this;
        }
    }
}
