using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class Competetion : HybridNode<Task>
    {
        public Competetion() : base() { }

        public Competetion(string prefix) : this()
        {
            Prefix = prefix;
        }

        public Competetion(string prefix, ushort no) : this(prefix)
        {
            No = no;
        }

        private string _prefix;
        public string Prefix
        {
            get => _prefix;
            set
            {
                _prefix = value;
                OnPropertyChanged();
            }
        }
    }
}
