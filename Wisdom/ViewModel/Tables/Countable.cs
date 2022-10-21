using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using System.Collections.Generic;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables
{
    public class Countable
    {
        private readonly Bridge<ISummator> _bridge;
        private readonly ICount _item;
        
        public Countable(ICount item, Bridge<ISummator> bridge)
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

        internal List<State<T>> Collection<T>(IOptionableCollection<T> items) where T : IHours, IChangeable
        {
            return new List<State<T>>
            {
                new ManualCount<T>(_bridge, _item, items),
                new AutoCount<T>(_bridge, _item, items)
            };
        }
    }
}
