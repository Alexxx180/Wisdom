using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemePlanVM : PlanVM<TopicVM>, ICount, IHighlighting, ICloneable<ThemePlanVM>, IPlan
    {
        public ThemePlanVM(Plan plan) : base(0, 0, 0)
        {
            _plan = plan;
            ListSetup(new TopicVM(this, new Topic()));
        }

        private protected override void ListSetup(TopicVM additor)
        {
            base.ListSetup(additor);
            Items.Options.Add(new StateBlock<TopicVM>(Numerable.Collection(Items), ref _numeration));
        }

        private readonly Plan _plan;

        public override ushort Hours
        {
            get => _plan.Sum;
            set
            {
                _plan.Sum = value;
                OnPropertyChanged();
                Items.UpdateHead(nameof(Hours));
            }
        }

        public ThemePlanVM Copy()
        {
            return new ThemePlanVM(_plan.Copy());
        }
    }
}
