using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class IndexNode<T> : Indexer
    {
        public IndexNode()
        {
            Items = new ObservableCollection<T>();
        }
        
        public ObservableCollection<T> Items { get; }
    }
}
