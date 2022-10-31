using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables
{
    public class Countable
    {
        private readonly IHours _item;
        
        public Countable(IHours item)
        {
            _item = item;
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
    }
}
