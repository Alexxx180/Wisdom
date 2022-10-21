using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables
{
    public abstract class TNode<T> : PropertyChangedVM, IParent<T> where T : ICloneable<T>, IChangeable
    {
        private protected TNode()
        {
            AddCommand = new RelayCommand(argument => Items.Add());
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

        public void Remove(T item)
        {
            _ = Items.Remove(item);
        }

        public ICommand AddCommand { get; }
    }
}
