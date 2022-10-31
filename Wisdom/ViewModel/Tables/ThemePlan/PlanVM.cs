using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public abstract class PlanVM<T, TParent, TFeatures> : TNode<T, TParent, TFeatures>, ICount, IHighlighting
        where T : ICloneable<T>, IChangeable, IHours
        where TParent : IHours, IState<T>
        where TFeatures : IStateBlock<T, TParent>
    {
        public Countable Count { get; private set; }
        public Highlightable Coloring { get; private set; }

        private protected virtual void SetFeatures(TParent item)
        {
            Count = new Countable(item);
            Coloring = new Highlightable();
        }

        private protected void AddChain(int max)
        {
            for (byte i = 0; i < max; i++)
            {
                Items.Add();
            }
        }
    }
}
