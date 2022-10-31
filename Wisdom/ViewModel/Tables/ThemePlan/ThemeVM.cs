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
    public class ThemeVM : PlanVM<WorkVM, ThemeVM, FNode<ThemeVM, WorkVM, StateGroup<TaskVM, WorkVM>>>,
        INo, INumerable, IHighlighting, ICloneable<ThemeVM>, ICollectionContainer<WorkVM>, ICount, IParent<WorkVM>, IHours
    {
        private protected override ThemeVM _this => this;

        public Numerable Number { get; private set; }

        public ThemeVM() { }

        public ThemeVM(TopicVM parent)
        {
            Set(parent, new Theme(1, "ВАЖНОЕ Изучение местных достопримечательностей в Константинополе на оценку", 1, 2));
        }

        public ThemeVM(TopicVM parent, Theme theme)
        {
            Set(parent, theme);
            SetItems(new WorkVM(this));

            RemoveCommand = new RelayCommand
                (argument => Parent.Items.Remove((ThemeVM)argument));

            //AddChain(5);
        }

        private protected void Set(TopicVM parent, Theme theme)
        {
            _theme = theme;
            Parent = parent;
            SetFeatures(this);
            SetNode(parent.Node.List);
            OnPropertyChanged(nameof(_this));
        }

        private protected override void SetFeatures(ThemeVM item)
        {
            base.SetFeatures(item);
            Number = new Numerable(item);
        }

        private Theme _theme;

        public ushort No
        {
            get => _theme.No;
            set
            {
                _theme.No = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _theme.Name;
            set
            {
                _theme.Name = value;
                OnPropertyChanged();
            }
        }

        public ushort Hours
        {
            get => _theme.Hours;
            set
            {
                _theme.Hours = value;
                OnPropertyChanged();
            }
        }

        public ushort Level
        {
            get => _theme.Level;
            set
            {
                _theme.Level = value;
                OnPropertyChanged();
            }
        }

        //private OptionableCollection<Competetion> _gcompetetions;
        //public OptionableCollection<Competetion> GCompetetions
        //{
        //    get => _gcompetetions;
        //    set
        //    {
        //        _gcompetetions = value;
        //        OnPropertyChanged();
        //    }
        //}

        public TopicVM Parent { get; private set; }

        public ICommand RemoveCommand { get; }

        public ThemeVM Copy()
        {
            return new ThemeVM(Parent, _theme.Copy());
        }
    }
}
