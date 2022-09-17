namespace ControlMaterials.Total
{
    public abstract class State<T> where T : IChangeable
    {
        public State(string name)
        {
            PropertyName = name;
        }

        public void SetItems(IOptionableCollection<T> items)
        {
            Items = items;
        }

        public IOptionableCollection<T> Items { get; set; }
        public string PropertyName { get; }

        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract void Recalculate();
    }
}
