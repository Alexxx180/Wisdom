using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class WorkVM : TNode<TaskVM>, ICloneable<WorkVM>
    {
        private readonly Work _work;

        public WorkVM(Work work)
        {
            _work = work;
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((WorkVM)argument));

            BuildItems(new TaskVM(new Topic()) { Parent = this });
        }

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

        public IParent<WorkVM> Parent { get; set; }
        public ICommand RemoveCommand { get; }
        
        public WorkVM Copy()
        {
            return new WorkVM(_work.Copy())
            {
                Parent = Parent
            };
        }
    }
}
