using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TopicVM : TNode<ThemeVM>, ICloneable<TopicVM>
    {
        private readonly HoursNode<Theme> _topic;

        public TopicVM(HoursNode<Theme> topic) : base(new ThemeVM(new Theme()))
        {
            _topic = topic;
        }

        public override ushort No
        {
            get => _topic.No;
            set
            {
                _topic.No = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _topic.Name;
            set
            {
                _topic.Name = value;
                OnPropertyChanged();
            }
        }

        public override ushort Hours
        {
            get => _topic.Hours;
            set
            {
                _topic.Hours = value;
                OnPropertyChanged();
            }
        }
        
        public TopicVM Copy() => new TopicVM(_topic.Copy());
    }
}
