using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Wisdom.ViewModel.Collections.Features;

namespace Wisdom.ViewModel.Collections
{
    public class AutoList<T> : ObservableCollection<T>, IOptionableCollection<T> where T : IChangeable, ICloneable<T>
    {
        public IState<T> Group { get; }
        public T Additor { get; }

        public void Add()
        {
            Add(Additor.Copy());
        }

        public AutoList(T additor, IState<T> group)
        {
            Additor = additor;
            Group = group;
            CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            OnAppend(args.NewItems);
            OnDelete(args.OldItems);
        }

        private void OnAppend(IList items)
        {
            if (items is null)
                return;

            foreach (T item in items)
            {
                item.PropertyChanged += OnItemChanged;
                Group.Add(item);
            }
        }

        private void OnDelete(IList items)
        {
            if (items is null)
                return;

            foreach (T item in items)
            {
                item.PropertyChanged -= OnItemChanged;
                Group.Remove(item);
            }
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs args)
        {
            Group.Recalculate((T)sender, args.PropertyName);
        }

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
