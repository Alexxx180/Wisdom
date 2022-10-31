using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Tables;

namespace Wisdom.ViewModel.Collections.Features.Count
{
    public interface ICount : IHighlighting
    {
        public Countable Count { get; }
    }
}
