using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features;

namespace Wisdom.ViewModel.Collections
{
    public class FNode<TParent, TItems, TList> : IStateBlock<TItems, TParent>
        where TItems : IChangeable
    {
        public FNode(StateGroup<TItems, TParent> states, TList list)
        {
            States = states;
            List = list;
        }

        public void Add(TItems item, TParent parent) => States.Add(item, parent);

        public void Remove(TItems item, TParent parent) => States.Remove(item, parent);

        public void Recalculate(TItems item, TParent parent) => States.Recalculate(item, parent);

        public StateGroup<TItems, TParent> States { get; }
        public TList List { get; }
    }
}
