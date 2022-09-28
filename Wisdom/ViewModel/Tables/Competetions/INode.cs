using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Numeration;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.Competetions
{
    public abstract class INode<T> : Numerable where T : INumerable, ICloneable<T>
    {
        private INode()
        {
            AddCommand = new RelayCommand(argument => Items.Add());
            RemoveCommand = new RelayCommand(argument =>
            {
                _ = Items.Remove((T)argument);
            });
        }

        public INode(T additor) : this()
        {
            SetItems(additor, Numeration<T>());
        }

        public T this[int no]
        {
            get => Items[no];
            set => Items[no] = value;
        }

        private OptionableCollection<T> _items;
        public OptionableCollection<T> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private protected void SetItems(T additor, params State<T>[][] states)
        {
            SetItems(new OptionableCollection<T>(additor, states));
        }

        private protected void SetItems(OptionableCollection<T> items)
        {
            Items = items;
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
    }
}
