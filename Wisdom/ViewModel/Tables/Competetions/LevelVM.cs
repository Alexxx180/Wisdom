using ControlMaterials.Tables.Tasks;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.Competetions
{
    public class LevelVM : Numerable, ICloneable<LevelVM>
    {
        private Level _level;

        public LevelVM(Level level)
        {
            _level = level;
        }

        public override ushort No
        {
            get => _level.No;
            set
            {
                _level.No = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _level.Name;
            set
            {
                _level.Name = value;
                OnPropertyChanged();
            }
        }

        public string Data
        {
            get => _level.Data;
            set
            {
                _level.Data = value;
                OnPropertyChanged();
            }
        }

        public LevelVM Copy() => new LevelVM(_level.Copy());
    }
}
