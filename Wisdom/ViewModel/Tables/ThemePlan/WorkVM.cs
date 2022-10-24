using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class WorkVM : PlanVM<TaskVM>, ICount, IHighlighting, ICloneable<WorkVM>
    {
        public WorkVM(PlanVM<WorkVM> parent, Work work) : base(parent)
        {
            _work = work;
            Parent = parent;
            ListSetup(new TaskVM(this, new Topic()));
            RemoveCommand = new RelayCommand
                (argument => Parent.Remove((WorkVM)argument));
        }

        private protected override void ListSetup(TaskVM additor)
        {
            base.ListSetup(additor);
            Items.Options.Add(new StateBlock<TaskVM>(Numerable.Collection(Items), ref _numeration));
        }

        private readonly Work _work;

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
                Items.UpdateHead(nameof(Hours));
            }
        }

        public PlanVM<WorkVM> Parent { get; }
        public ICommand RemoveCommand { get; }
        
        public WorkVM Copy()
        {
            return new WorkVM(Parent, _work.Copy());
        }
    }
}
