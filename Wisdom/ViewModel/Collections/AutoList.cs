using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel.Collections.Features;

namespace Wisdom.ViewModel.Collections
{
    public class AutoList<T> : ObservableCollection<T>, IOptionableCollection<T> where T : IChangeable, ICloneable<T>
    {
        public List<StateBlock<T>> Options { get; }
        public T Additor { get; }

        public void Add()
        {
            Add(Additor.Copy());
        }

        public AutoList(T additor)
        {
            Additor = additor;
            Options = new List<StateBlock<T>>();
            CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            OnAppend(args.NewItems);
            OnDelete(args.OldItems);
        }

        // Subscribe to future changes for each item
        private void OnAppend(IList items)
        {
            if (items is null)
                return;

            foreach (T item in items)
            {
                item.PropertyChanged += OnItemChanged;
                for (byte i = 0; i < Options.Count; i++)
                {
                    Options[i].Add(item);
                }
            }
        }

        // Unsubscribe to changes in each item
        private void OnDelete(IList items)
        {
            if (items is null)
                return;

            foreach (T item in items)
            {
                item.PropertyChanged -= OnItemChanged;
                for (byte i = 0; i < Options.Count; i++)
                {
                    Options[i].Remove(item);
                }
            }
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs args)
        {
            for (byte i = 0; i < Options.Count; i++)
            {
                if (args.PropertyName == Options[i].PropertyName)
                {
                    Options[i].Recalculate();
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
