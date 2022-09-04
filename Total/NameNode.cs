using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class NameNode<T> : NameLabel
    {
        public NameNode()
        {
            Items = new ObservableCollection<T>();
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
