using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class NameNode<T> : NameLabel
    {
        public T this[int no]
        {
            get => Items[no];
            set => Items[no] = value;
        }

        public NameNode()
        {
            Items = new ObservableCollection<T>();
        }

        private protected NameNode(ObservableCollection<T> items)
        {
            Items = new ObservableCollection<T>(items);
        }

        public override NameNode<T> Copy()
        {
            return new NameNode<T>(Items)
            {
                Name = Name
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
        
        public ObservableCollection<T> Items { get; }
    }
}
