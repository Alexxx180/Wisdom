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

        public Task Description
        {
            get => _level.Description;
            set
            {
                _level.Description = value;
                OnPropertyChanged();
            }
        }

        //public string Name
        //{
        //    get => _level.Description.Name;
        //    set
        //    {
        //        _level.Description.Name = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public string Data
        //{
        //    get => _level.Description.Data;
        //    set
        //    {
        //        _level.Description.Data = value;
        //        OnPropertyChanged();
        //    }
        //}

        public LevelVM Copy() => new LevelVM(_level.Copy());
    }
}
