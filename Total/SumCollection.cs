using System.Collections.ObjectModel;

namespace ControlMaterials.Total
{
    public class SumCollection<T> : ObservaleCollection<T> where T : ISummable
    {
        private uint sum;
        public uint Sum
        { 
            get => sum;
            set
            {
                sum = value;
                OnPropertyChanged();
            }
        }
        
        public ParagonCollection()
        {
            // When the collection changes set the Sum to the new Sum of TotalValues
            this.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            foreach(ISummable item in args.OldItems)
            {
                // Unsubscribe to changes in each item
                item.PropertyChanged -= OnItemChanged;
            }
            
            foreach(ISummable item in args.NewItems)
            {
                // Subscribe to future changes for each item
                item.PropertyChanged += OnItemChanged;
            }

            Recalculate();
        }

        private void OnItemChanged(object sender, PropertyChangedEventArgs args)
        {
            Recalulate();
            // If it is need to decide that we only want to recalculate for some property 
            // changes, and do something like the following instead
            // if (args.PropertyName=="TotalValue")
            //   Recalulate();
        }

        private void Recalculate()
        {
            Sum = Sum(x=>x.Sum());
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
