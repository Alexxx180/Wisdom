namespace ControlMaterials.Total.Collections
{
    public abstract class State<T> where T : IChangeable
    {
        public State(string name)
        {
            PropertyName = name;
        }

        public void SetItems(IOptionableCollection<T> items)
        {
            _items = items;
        }

        private IOptionableCollection<T> _items;
        public IOptionableCollection<T> Items => _items;

        public string PropertyName { get; }

        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract void Recalculate();
        public abstract void Setup();
    }
}
