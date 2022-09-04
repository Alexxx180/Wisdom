using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class HybridNode<T> : IndexNode<T>
    {
        public HybridNode() : base() { }

        public HybridNode(ObservableCollection<T> items) : base(items) { }

        public override HybridNode<T> Copy()
        {
            return new HybridNode<T>(Items)
            {
                No = No,
                Name = Name
            };
        }

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
