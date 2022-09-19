namespace ControlMaterials.Total
{
    public class HybridNode<T> : IndexNode<T>, INumerable where T : INumerable, ICloneable<T>
    {
        private protected HybridNode() { }

        public HybridNode(T additor) : base(additor) { }

        private protected HybridNode(OptionableCollection<T> items) : base(items) { }

        public override HybridNode<T> Copy()
        {
            return new HybridNode<T>(_items)
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
