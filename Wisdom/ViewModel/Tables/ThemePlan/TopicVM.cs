using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TopicVM : TNode<ThemeVM>, ICloneable<TopicVM>
    {
        private readonly HoursNode<Theme> _topic;

        public TopicVM(HoursNode<Theme> topic, IParent<TopicVM> parent)
        {
            _topic = topic;
            Parent = parent;
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove(this));

            BuildItems(new ThemeVM(new Theme(), this));
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

        public IParent<TopicVM> Parent { get; set; }
        public ICommand RemoveCommand { get; }

        public TopicVM Copy() => new TopicVM(_topic.Copy(), Parent);
    }
}
