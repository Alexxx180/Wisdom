namespace Wisdom.ViewModel.Collections.Features.Count
{
    public interface ISummator
    {
        public ushort Sum { get; }
        public ushort PrevSum { get; }
    }
}
