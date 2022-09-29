using ControlMaterials.Total.Numeration;

namespace ControlMaterials.Total.Collections.Nodes
{
    public class IndexNode<T> : Indexer where T : INumerable, ICloneable<T>
    {
        public int Count => _items.Count;

        public T this[int no]
        {
            get => _items[no];
            set => _items[no] = value;
        }

        private protected IndexNode() { }

        public IndexNode(T additor)
        {
            SetItems(additor, Numeration());
        }

        private protected IndexNode(OptionableCollection<T> items)
        {
            SetItems(items);
        }

        public static State<T>[] Numeration()
        {
            return new State<T>[]
            {
                new ManualNumeration<T>(),
                new OnlyNewNumeration<T>(),
                new AutoNumeration<T>()
            };
        }

        public override IndexNode<T> Copy()
        {
            return new IndexNode<T>(_items)
            {
                No = No
            };
        }

        public void Add()
        {
            _items.Add();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public void Option(int no, int no2)
        {
            _items.Set(no, no2);
        }

        public void Clear()
        {
            _items.Clear();
        }

        private protected void SetItems(T additor, params State<T>[][] states)
        {
            SetItems(new OptionableCollection<T>(additor, states));
        }

        private protected void SetItems(OptionableCollection<T> items)
        {
            _items = items;
        }

        private protected OptionableCollection<T> _items;
    }
}
