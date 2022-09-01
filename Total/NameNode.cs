using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class NameNode<T> : NameLabel
    {
        public NameNode()
        {
            Items = new ObservableCollection<T>();
        }
        
        public ObservableCollection<T> Items { get; }
    }
}
