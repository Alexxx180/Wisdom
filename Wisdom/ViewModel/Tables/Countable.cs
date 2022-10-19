using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables
{
    public class Countable : PropertyChangedVM, ISum
    {
        private readonly Bridge<ISummator> _bridge;
        private readonly ICount _item;
        
        public Countable(IHours item, Bridge<ISummator> bridge)
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

        private protected State<T>[] SumCount<T>() where T : Collections.Features.Count.ICount, IChangeable
        {
            return new State<T>[]
            {
                new Collections.Features.Count.ManualCount<T>(_bridge, _item),
                new Collections.Features.Count.AutoCount<T>(_bridge, _item)
            };
        }
    }
}
