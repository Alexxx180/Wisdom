using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Commands;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class WorkVM : PlanVM<TaskVM, WorkVM, StateGroup<TaskVM, WorkVM>>,
        ICount, IHours, IHighlighting, ICloneable<WorkVM>, ICollectionContainer<TaskVM>, IParent<TaskVM>
    {
        private protected override WorkVM _this => this;

        public WorkVM(ThemeVM parent)
        {
            Set(parent, new Work("Самостоятельная работа", 1));
        }

        public WorkVM(ThemeVM parent, Work work)
        {
            Set(parent, work);
            SetItems(new TaskVM(this));
            RemoveCommand = new RelayCommand
                (argument => Parent.Items.Remove((WorkVM)argument));

            //AddChain(2);
        }
        
        private protected void Set(ThemeVM parent, Work work)
        {
            _work = work;
            Parent = parent;
            SetFeatures(this);
            SetNode(parent.Node.List);
            OnPropertyChanged(nameof(_this));
        }

        private Work _work;

        public string Name
        {
            get => _work.Name;
            set
            {
                _work.Name = value;
                OnPropertyChanged();
            }
        }

        public ushort Hours
        {
            get => _work.Hours;
            set
            {
                _work.Hours = value;
                OnPropertyChanged();
            }
        }
        
        public ThemeVM Parent { get; private set; }
        public ICommand RemoveCommand { get; }
        
        public WorkVM Copy()
        {
            return new WorkVM(Parent, _work.Copy());
        }
    }
}
