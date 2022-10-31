namespace Wisdom.ViewModel.Collections.Features
{
    public interface IStateBlock<T, TParent>
    {
        public abstract void Add(T item, TParent parent);
        public abstract void Remove(T item, TParent parent);
        public abstract void Recalculate(T item, TParent parent);
    }
}
