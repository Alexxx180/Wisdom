namespace ControlMaterials.Total
{
    public class IndexedLabel : Indexer
    {
        public IndexedLabel() { }

        public IndexedLabel(string name)
        {
            Name = name;
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
