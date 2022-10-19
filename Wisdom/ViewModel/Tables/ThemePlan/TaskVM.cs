using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TaskVM : PropertyChangedVM, INo, ICloneable<TaskVM>
    {
        private Topic _task;

        public Numerable Number { get; }
        private Highlightable Count { get; }

        public TaskVM(Topic task)
        {
            _task = task;
            Number = new Numerable(this);
            Count = new Highlightable();

            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((TaskVM)argument));
        }

        public ushort No
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

        public ushort Hours
        {
            get => _task.Hours;
            set
            {
                _task.Hours = value;
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
