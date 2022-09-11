using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ControlMaterials.Total
{
    public class OptionableCollection<T> : ObservableCollection<T>, IOptionableCollection<T> where T : IChangeable
    {
        public State<T>[] Sets { get; }
        public State<T>[][] Options { get; }

        public T Additor { get; }

        public void Set(int no, int no2)
        {
            Sets[no] = Options[no][no2];
        }

        public OptionableCollection(params State<T>[][] options)
        {
            // When the collection changes set the Sum to the new Sum of TotalValues
            this.CollectionChanged += OnCollectionChanged;

            Options = options;
            for (byte i = 0; i < Options.Length; i++)
            {
                Options[i][0].SetItems(this);
            }
            
            Sets = new State<T>[options.Length];
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //throw new System.Exception($"IS NULL: {args.OldItems is null}");

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
