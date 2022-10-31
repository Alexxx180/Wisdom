using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TopicVM : PlanVM<ThemeVM, TopicVM, FNode<TopicVM, ThemeVM, FNode<ThemeVM, WorkVM, StateGroup<TaskVM, WorkVM>>>>,
        INo, INumerable, ICount, IHighlighting, ICloneable<TopicVM>, ICollectionContainer<ThemeVM>, IParent<ThemeVM>, IHours
    {
        private protected override TopicVM _this => this;

        public Numerable Number { get; private set; }

        public TopicVM() { }

        public TopicVM(ThemePlanVM parent)
        {
            Set(parent, new Topic(1, "СУПЕР ВАЖНОЕ Изучение местных достопримечательностей в Константинополе на оценку", 1));
        }

        public TopicVM(ThemePlanVM parent, Topic topic)
        {
            Set(parent, topic);
            SetItems(new ThemeVM(this));

            RemoveCommand = new RelayCommand
                (argument => Parent.Remove(this));

            //AddChain(5);
        }

        private protected void Set(ThemePlanVM parent, Topic topic)
        {
            _topic = topic;
            Parent = parent;
            SetFeatures(this);
            SetNode(parent.Node.List);
        }

        private protected override void SetFeatures(TopicVM item)
        {
            base.SetFeatures(item);
            Number = new Numerable(item);
        }

        private Topic _topic;

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

        public ushort Hours
        {
            get => _topic.Hours;
            set
            {
                _topic.Hours = value;
                OnPropertyChanged();
            }
        }

        public ThemePlanVM Parent { get; private set; }
        public ICommand RemoveCommand { get; }

        public TopicVM Copy()
        {
            return new TopicVM(Parent, _topic.Copy());
        }
    }
}
