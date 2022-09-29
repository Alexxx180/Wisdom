using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemePlanVM : TNode<TopicVM>, ICloneable<ThemePlanVM>
    {
        private readonly Plan _plan;

        public ThemePlanVM(Plan plan)
        {
            _plan = plan;

            BuildItems(new TopicVM(new HoursNode<Theme>(new Theme()), this));
        }

        private ushort _no;
        public override ushort No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public override ushort Hours
        {
            get => _plan.Sum;
            set
            {
                _plan.Sum = value;
                OnPropertyChanged();
            }
        }

        public ThemePlanVM Copy() => new ThemePlanVM(_plan.Copy());
    }
}
