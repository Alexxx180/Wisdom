using ControlMaterials.Total.Numeration;

namespace ControlMaterials.Total
{
    public class IndexNode<T> : Indexer where T : INumerable
    {
        public IndexNode()
        {
            SetItems(Numeration());
            Items.Set(0, 0);
        }

        private protected State<T>[] Numeration()
        {
            return new State<T>[]
            {
                new ManualNumeration<T>(),
                new OnlyNewNumeration<T>(),
                new AutoNumeration<T>()
            };
        }

        private protected IndexNode(OptionableCollection<T> items)
        {
            SetItems(items);
        }

        public override IndexNode<T> Copy()
        {
            return new IndexNode<T>(Items)
            {
                No = No
            };
        }

        public void Add(T item)
        {
            Items.Add(item);
        }

        public bool Remove(T item)
        {
            return Items.Remove(item);
        }

        private protected void SetItems(params State<T>[][] states)
        {
            SetItems(new OptionableCollection<T>(states));
        }

        private protected void SetItems(OptionableCollection<T> items)
        {
            _items = items;
            OnPropertyChanged(nameof(Items));
        }

        private OptionableCollection<T> _items;
        public OptionableCollection<T> Items => _items;
    }
}
