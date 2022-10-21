using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using System.Collections.Generic;

namespace Wisdom.ViewModel.Tables
{
    public class Countable
    {
        private readonly Bridge<ISummator> _bridge;
        private readonly Collections.Features.Count.ICount _item;
        
        public Countable(Collections.Features.Count.ICount item, Bridge<ISummator> bridge)
        {
            _item = item;
            _bridge = bridge;
        }

        public void Append(ushort increment)
        {
            _item.Hours += increment;
        }

        public void Reduce(ushort decrement)
        {
            _item.Hours -= decrement;
        }

        public void SetTotal(ushort sum)
        {
            _item.Hours = sum;
        }

        public ushort Sum => _item.Hours;

        internal List<State<T>> Collection<T>(IOptionableCollection<T> items)
            where T : Collections.Features.Count.IHours, IChangeable
        {
            return new List<State<T>>
            {
                new Collections.Features.Count.ManualCount<T>(_bridge, _item, items),
                new Collections.Features.Count.AutoCount<T>(_bridge, _item, items)
            };
        }
    }
}
