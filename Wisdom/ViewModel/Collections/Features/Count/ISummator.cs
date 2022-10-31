namespace Wisdom.ViewModel.Collections.Features.Count
{
    public interface ISummator<T>
    {
        public ushort CurrentSum(T parent);
        public ushort PreviousSum(T parent);
    }
}
