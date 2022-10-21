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
    public class ThemeVM : TNode<WorkVM>, INo, INumerable, ICount, IHighlighting, ICloneable<ThemeVM>
    {
        public Numerable Number { get; }
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public ThemeVM(IParent<ThemeVM> parent, Theme theme)
        {
            _theme = theme;
            Parent = parent;

            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((ThemeVM)argument));

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<WorkVM>(new WorkVM(this, new Topic()));

            Items.Options.Add(new StateBlock<WorkVM>(Count.Collection(Items)));
            Items.Options.Add(new StateBlock<WorkVM>(Coloring.Collection(Items)));
        }

        private readonly Theme _theme;

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

        public IParent<ThemeVM> Parent { get; set; }
        public ICommand RemoveCommand { get; }

        public ThemeVM Copy()
        {
            return new ThemeVM(Parent, _theme.Copy());
        }
    }
}
