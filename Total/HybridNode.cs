using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ControlMaterials.Total
{
    public class HybridNode<T> : IndexNode<T>
    {
        public HybridNode() : base() { }
        
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
