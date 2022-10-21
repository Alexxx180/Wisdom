using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class TaskVM : PropertyChangedVM, INo, IHours, ICloneable<TaskVM>, INumerable
    {
        public Numerable Number { get; }

        public TaskVM(IParent<TaskVM> parent, Topic task)
        {
            Parent = parent;
            _task = task;

            Number = new Numerable(this);
            
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((TaskVM)argument));
        }

        private Topic _task;

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

        public IParent<TaskVM> Parent { get; }
        public ICommand RemoveCommand { get; }

        public TaskVM Copy()
        {
            return new TaskVM(Parent, _task.Copy());
        }
    }
}
