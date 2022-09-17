using ControlMaterials.Total;

namespace ControlMaterials.Tables
{
    public class Competetion : NameNode<Task>, INumerable
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

        private ushort _no;
        public ushort No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public void SetNumber(ushort no)
        {
            No = no;
        }

        public void Increment(ushort no)
        {
            No += no;
        }

        public void Decrement(ushort no)
        {
            No -= no;
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
