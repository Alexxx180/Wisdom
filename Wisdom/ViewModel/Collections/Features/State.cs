using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features
{
    public abstract class State<T, TParent> : IStateBlock<T, TParent> where T : IChangeable
    {
        public State(string name)
        {
            PropertyName = name;
        }

        public string PropertyName { get; }

        public abstract void Add(T item, TParent parent);
        public abstract void Remove(T item, TParent parent);
        public abstract void Recalculate(T item, TParent parent);
        public abstract void Setup();
    }
}
