using ControlMaterials.Tables.Tasks;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.Competetions
{
    public class LevelVM : PropertyChangedVM, INumerable, ICloneable<LevelVM>
    {
        public Numerable Number { get; }

        public LevelVM(IParent<LevelVM> parent, Level level)
        {
            Parent = parent;
            _level = level;

            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((LevelVM)argument));
        }

        private Level _level;

        public ushort No
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

        public IParent<LevelVM> Parent { get; }
        public ICommand RemoveCommand { get; }

        public LevelVM Copy()
        {
            return new LevelVM(Parent, _level.Copy());
        }
    }
}
