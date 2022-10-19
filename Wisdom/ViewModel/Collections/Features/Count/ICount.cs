using Wisdom.ViewModel.Tables;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public interface ICount : IHours
    {
        public Countable Count { get; }
    }
}
