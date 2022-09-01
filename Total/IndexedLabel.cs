using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlMaterials.Total
{
    public class IndexedLabel : Indexer
    {
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
