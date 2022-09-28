using ControlMaterials.Tables.Hours;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class WorkVM : TNode<TaskVM>, ICloneable<WorkVM>
    {
        private readonly Work _work;

        public WorkVM(Work work) : base(new TaskVM(new IndexedHour()))
        {
            _work = work;
        }

        public override ushort No
        {
            get => _work.No;
            set
            {
                _work.No = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _work.Name;
            set
            {
                _work.Name = value;
                OnPropertyChanged();
            }
        }

        public override ushort Hours
        {
            get => _work.Hours;
            set
            {
                _work.Hours = value;
                OnPropertyChanged();
            }
        }

        public WorkVM Copy() => new WorkVM(_work.Copy());
    }
}
