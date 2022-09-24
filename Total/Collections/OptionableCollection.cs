using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlMaterials.Total.Collections
{
    public class OptionableCollection<T> : ObservableCollection<T>, IOptionableCollection<T> where T : IChangeable, ICloneable<T>
    {
        public State<T>[] Sets { get; }
        public State<T>[][] Options { get; }

        public T Additor { get; }

        public void Set(int no, int no2)
        {
            Sets[no] = Options[no][no2];
            Sets[no].Setup();
        }

        public void Add()
        {
            Add(Additor.Copy());
        }

        public OptionableCollection(T additor, params State<T>[][] options)
        {
            Additor = additor;

            // When the collection changes set the Sum to the new Sum of TotalValues
            CollectionChanged += OnCollectionChanged;

            Options = options;
            Sets = new State<T>[options.Length];

            for (byte i = 0; i < Options.Length; i++)
            {
                for (byte ii = 0; ii < Options[i].Length; ii++)
                {
                    Options[i][ii].SetItems(this);
                }
                Set(i, 0);
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems is not null)
                foreach (T item in args.OldItems)
                {
                    // Unsubscribe to changes in each item
                    item.PropertyChanged -= OnItemChanged;
                    for (byte i = 0; i < Sets.Length; i++)
                    {
                        Sets[i].Remove(item);
                    }
                }

            if (args.NewItems is not null)
                foreach (T item in args.NewItems)
                {
                    // Subscribe to future changes for each item
                    item.PropertyChanged += OnItemChanged;
                    for (byte i = 0; i < Sets.Length; i++)
                    {
                        Sets[i].Add(item);
                    }
                }
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs args)
        {
            for (byte i = 0; i < Sets.Length; i++)
            {
                if (args.PropertyName == Sets[i].PropertyName)
                {
                    Sets[i].Recalculate();
                }
            }
        }

        public virtual void SetTotal(uint total) { }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
