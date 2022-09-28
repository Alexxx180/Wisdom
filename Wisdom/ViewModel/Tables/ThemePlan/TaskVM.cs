using ControlMaterials.Tables.Hours;
using ControlMaterials.Total;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TaskVM : Highlightable, ICloneable<TaskVM>
    {
        private IndexedHour _task;

        public TaskVM(IndexedHour task)
        {
            _task = task;
        }

        public override ushort No
        {
            get => _task.No;
            set
            {
                _task.No = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _task.Name;
            set
            {
                _task.Name = value;
                OnPropertyChanged();
            }
        }

        public override ushort Hours
        {
            get => _task.Count;
            set
            {
                _task.Count = value;
                OnPropertyChanged();
            }
        }

        public TaskVM Copy() => new TaskVM(_task.Copy());
    }
}
