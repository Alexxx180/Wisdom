using ControlMaterials.Tables.Hours;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TaskVM : Highlightable, ICloneable<TaskVM>
    {
        private IndexedHour _task;

        public TaskVM(IndexedHour task)
        {
            _task = task;
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((TaskVM)argument));
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

        public IParent<TaskVM> Parent { get; set; }
        public ICommand RemoveCommand { get; }

        public TaskVM Copy()
        {
            return new TaskVM(_task.Copy())
            {
                Parent = Parent
            };
        }
    }
}
