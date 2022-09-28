using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemeVM : TNode<WorkVM>, ICloneable<ThemeVM>
    {
        private readonly Theme _theme;

        public ThemeVM(Theme theme) : base(new WorkVM(new Work()))
        {
            _theme = theme;
        }

        public override ushort No
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

        private OptionableCollection<Competetion> _gcompetetions;
        public OptionableCollection<Competetion> GCompetetions
        {
            get => _gcompetetions;
            set
            {
                _gcompetetions = value;
                OnPropertyChanged();
            }
        }

        public ThemeVM Copy() => new ThemeVM(_theme.Copy());
    }
}
