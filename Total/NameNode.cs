using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Total
{
    public class NameNode<T> : NameLabel
    {
        public NameNode()
        {
            Themes = new ObservableCollection<T>();
        }
        
        public ObservableCollection<T> Items { get; }
    }
}
