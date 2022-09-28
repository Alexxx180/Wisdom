using ControlMaterials.Tables.Tasks;

namespace Wisdom.ViewModel.Tables.Competetions
{
    public class LevelsVM : INode<LevelVM>
    {
        public LevelsVM() : base(new LevelVM(new Level())) { }

        private ushort _no;
        public override ushort No
        {
            get => _no;
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }
    }
}
