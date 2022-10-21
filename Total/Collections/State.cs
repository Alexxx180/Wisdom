namespace ControlMaterials.Total.Collections
{
    public abstract class State<T> where T : IChangeable
    {
        public State(string name, IOptionableCollection<T> items)
        {
            PropertyName = name;
            Items = items;
        }

        public string PropertyName { get; }
        public IOptionableCollection<T> Items { get; }

        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract void Recalculate();
        public abstract void Setup();
    }
}
