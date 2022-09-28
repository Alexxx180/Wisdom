using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Count.Highlighting;
using ControlMaterials.Total.Numeration;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables
{
    public abstract class TNode<T> : Highlightable where T : ISum, IHighlighting, INumerable, ICloneable<T>
    {
        private TNode()
        {
            AddCommand = new RelayCommand(argument =>
            {
                Items.Add();
                //Items.Add((T)argument);
            });
            RemoveCommand = new RelayCommand(argument =>
            {
                _ = Items.Remove((T)argument);
            });
        }

        //private protected TNode(OptionableCollection<T> items)
        //{
        //    Items = ;

        //    AddCommand = new RelayCommand(argument =>
        //    {
        //        Items.Add();
        //    });
        //    RemoveCommand = new RelayCommand(argument =>
        //    {
        //        _ = Items.Remove((T)argument);
        //    });
        //}

        public TNode(T additor) : this()
        {
            Bridge<ISummator> bridge = new Bridge<ISummator>();
            SetItems(additor, Numeration<T>(), SumCount<T>(bridge),
                Highlighting<T>(bridge));
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
