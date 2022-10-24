using Wisdom.ViewModel.Collections.Features;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public interface IPlan
    {
        public FeatureSetting Numeration { get; }
        public FeatureSetting SumCount { get; }
        public FeatureSetting Higlighting { get; }
    }
}
