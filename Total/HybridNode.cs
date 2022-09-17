namespace ControlMaterials.Total
{
    public class HybridNode<T> : IndexNode<T>, INumerable where T : INumerable
    {
        public HybridNode() : base() { }

        private protected HybridNode(OptionableCollection<T> items) : base(items) { }

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
