using ControlMaterials.Total;
using System.Collections.Generic;

namespace Wisdom.ViewModel.Collections.Features
{
    public class StateGroup<T, TParent> : IStateBlock<T, TParent> where T : IChangeable
    {
        public List<StateBlock<T, TParent>> Features { get; }

        public StateGroup(List<StateBlock<T, TParent>> features)
        {
            Features = features;
        }

        public void Add(T item, TParent parent)
        {
            for (byte i = 0; i < Features.Count; i++)
                Features[i]?.Add(item, parent);
        }

        public void Remove(T item, TParent parent)
        {
            for (byte i = 0; i < Features.Count; i++)
                Features[i]?.Remove(item, parent);
        }

        public void Recalculate(T item, TParent parent)
        {
            for (byte i = 0; i < Features.Count; i++)
                Features[i]?.Recalculate(item, parent);
        }
    }
}
