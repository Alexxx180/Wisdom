using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemePlanVM : PlanVM<TopicVM, ThemePlanVM,
        FNode<ThemePlanVM, TopicVM, FNode<TopicVM, ThemeVM, FNode<ThemeVM, WorkVM, StateGroup<TaskVM, WorkVM>>>>>,
        ICount, IHighlighting, ICloneable<ThemePlanVM>, ICollectionContainer<TopicVM>, IHours
    {
        private protected override ThemePlanVM _this => this;

        public ThemePlanVM(Plan plan,
            FNode<ThemePlanVM, TopicVM, FNode<TopicVM, ThemeVM,
                FNode<ThemeVM, WorkVM, StateGroup<TaskVM, WorkVM>>>> features)
        {
            _plan = plan;
            SetFeatures(this);
            SetNode(features);
            OnPropertyChanged(nameof(_this));
            SetItems(new TopicVM(this));

            //AddChain(5);
        }

        private readonly Plan _plan;

        public ushort Hours
        {
            get => _plan.Sum;
            set
            {
                _plan.Sum = value;
                OnPropertyChanged();
            }
        }

        public ThemePlanVM Copy()
        {
            return new ThemePlanVM(_plan.Copy(), Node);
        }
    }
}
 