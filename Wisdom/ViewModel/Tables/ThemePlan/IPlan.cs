using Wisdom.ViewModel.Collections.Features;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public interface IPlan<T> : IParent<T>
    {
        public FeatureSetting Numeration { get; }
        public FeatureSetting SumCount { get; }
        public FeatureSetting Higlighting { get; }
    }
}
