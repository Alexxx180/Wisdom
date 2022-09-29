using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Count.Highlighting;
using ControlMaterials.Total.Numeration;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables
{
    public abstract class TNode<T> : Highlightable, IParent<T> where T : ISum, IHighlighting, INumerable, ICloneable<T>
    {
        private protected TNode()
        {
            AddCommand = new RelayCommand(argument => Items.Add());
            //RemoveCommand = new RelayCommand(argument =>
            //{
            //    _ = Items.Remove((T)argument);
            //});
        }

        private protected void BuildItems(T additor)
        {
            Bridge<ISummator> bridge = new Bridge<ISummator>();
            SetItems(additor, Numeration<T>(), SumCount<T>(bridge), Highlighting<T>(bridge));
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

        public void Remove(T item)
        {
            _ = Items.Remove(item);
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
        //public ICommand RemoveCommand { get; }
    }
}
