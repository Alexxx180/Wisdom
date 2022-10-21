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
    public class TopicVM : TNode<ThemeVM>, INo, INumerable, ICount, IHighlighting, ICloneable<TopicVM>
    {
        public Numerable Number { get; }
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public TopicVM(IParent<TopicVM> parent, Topic topic)
        {
            _topic = topic;
            Parent = parent;

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Number = new Numerable(this);
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<ThemeVM>(new ThemeVM(this, new Theme()));
            Items.Options.Add(new StateBlock<ThemeVM>(Numerable.Collection(Items)));
            Items.Options.Add(new StateBlock<ThemeVM>(Count.Collection(Items)));
            Items.Options.Add(new StateBlock<ThemeVM>(Coloring.Collection(Items)));

            RemoveCommand = new RelayCommand
                (argument => Parent.Remove(this));
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

        public ushort Hours
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

        public TopicVM Copy()
        {
            return new TopicVM(Parent, _topic.Copy());
        }
    }
}
