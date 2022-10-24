using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TopicVM : PlanVM<ThemeVM>, INo, INumerable, ICount, IHighlighting, ICloneable<TopicVM>, IPlan
    {
        public Numerable Number { get; private set; }

        public TopicVM(PlanVM<TopicVM> parent, Topic topic) : base(parent)
        {
            _topic = topic;
            Parent = parent;
            ListSetup(new ThemeVM(this, new Theme()));
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove(this));
        }

        private protected override void Features()
        {
            base.Features();
            Number = new Numerable(this);
        }

        private protected override void ListSetup(ThemeVM additor)
        {
            base.ListSetup(additor);
            Items.Options.Add(new StateBlock<ThemeVM>(Numerable.Collection(Items), ref _numeration));
        }

        private readonly Topic _topic;

        public ushort No
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
                Items.UpdateHead(nameof(Hours));
            }
        }

        public PlanVM<TopicVM> Parent { get; }
        public ICommand RemoveCommand { get; }

        public TopicVM Copy()
        {
            return new TopicVM(Parent, _topic.Copy());
        }
    }
}
