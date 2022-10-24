using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemeVM : PlanVM<WorkVM>, INo, INumerable, ICount, IHighlighting, ICloneable<ThemeVM>, IPlan
    {
        public Numerable Number { get; private set; }

        public ThemeVM(PlanVM<ThemeVM> parent, Theme theme) : base(parent)
        {
            _theme = theme;
            Parent = parent;
            ListSetup(new WorkVM(this, new Work()));
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((ThemeVM)argument));
        }

        private protected override void Features()
        {
            base.Features();
            Number = new Numerable(this);
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

        public override ushort Hours
        {
            get => _theme.Hours;
            set
            {
                _theme.Hours = value;
                OnPropertyChanged();
                Items.UpdateHead(nameof(Hours));
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

        public PlanVM<ThemeVM> Parent { get; }
        public ICommand RemoveCommand { get; }

        public ThemeVM Copy()
        {
            return new ThemeVM(Parent, _theme.Copy());
        }
    }
}
