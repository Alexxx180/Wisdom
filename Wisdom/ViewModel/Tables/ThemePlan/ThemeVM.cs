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
    public class ThemeVM : TNode<WorkVM>, INo, INumerable, ICount, IHighlighting, ICloneable<ThemeVM>, IPlan<WorkVM>
    {
        public Numerable Number { get; }
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public ThemeVM(IPlan<ThemeVM> parent, Theme theme)
        {
            _theme = theme;
            Parent = parent;

            _numeration = parent.Numeration;
            _sumCount = parent.SumCount;
            _higlighting = parent.Higlighting;

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Number = new Numerable(this);
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<WorkVM>(new WorkVM(this, new Topic()));
            SetCount();
            SetHighlight();

            RemoveCommand = new RelayCommand(argument => Parent.Remove((ThemeVM)argument));
        }

        public void SetCount()
        {
            Items.Options.Add(new StateBlock<WorkVM>(Count.Collection(Items), ref _sumCount));
        }

        public void SetHighlight()
        {
            Items.Options.Add(new StateBlock<WorkVM>(Coloring.Collection(Items), ref _higlighting));
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

        public IPlan<ThemeVM> Parent { get; set; }
        public ICommand RemoveCommand { get; }

        public ThemeVM Copy()
        {
            return new ThemeVM(Parent, _theme.Copy());
        }

        private FeatureSetting _numeration;
        public FeatureSetting Numeration => _numeration;
        private FeatureSetting _sumCount;
        public FeatureSetting SumCount => _sumCount;
        private FeatureSetting _higlighting;
        public FeatureSetting Higlighting => _higlighting;
    }
}
