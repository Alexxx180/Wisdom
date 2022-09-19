using ControlMaterials.Total;
using System.Collections.ObjectModel;

namespace ControlMaterials.Tables
{
    public class Competetion : NameNode<Task>, INumerable, ICloneable<Competetion>
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

        private protected Competetion(ObservableCollection<Task> items) : base(items) { }

        public override Competetion Copy()
        {
            return new Competetion(Items)
            {
                No = No,
                Name = Name,
            };
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
