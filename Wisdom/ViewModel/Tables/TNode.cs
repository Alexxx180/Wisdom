using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables
{
    public abstract class TNode<T, TParent, TFeatures> : PropertyChangedVM, IState<T>
        where T : ICloneable<T>, IChangeable
        where TParent : IState<T>
        where TFeatures : IStateBlock<T, TParent>
    {
        private protected abstract TParent _this { get; }
        public TFeatures Node { get; private set; }

        public void Add(T item)
        {
            Node.Add(item, _this);
        }

        public void Remove(T item)
        {
            Node.Remove(item, _this);
        }

        public void Recalculate(T item, string property)
        {
            Node.Recalculate(item, _this);
        }

        private protected TNode()
        {
            AddCommand = new RelayCommand(argument => Items.Add());
        }

        private protected void SetNode(TFeatures node)
        {
            Node = node;
        }

        private protected void SetItems(T additor)
        {
            Items = new AutoList<T>(additor, _this);
        }

        public T this[int no]
        {
            get => Items[no];
            set => Items[no] = value;
        }

        private AutoList<T> _items;
        public AutoList<T> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
    }
}
