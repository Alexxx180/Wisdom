namespace Wisdom.ViewModel.Collections.Features
{
    public interface IState<T>
    {
        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract void Recalculate(T item, string property);
    }
}
