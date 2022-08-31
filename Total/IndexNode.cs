using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Total
{
    public class IndexNode<T> : Indexer
    {
        public IndexNode()
        {
            Themes = new ObservableCollection<T>();
        }
        
        public ObservableCollection<T> Items { get; }
    }
}
