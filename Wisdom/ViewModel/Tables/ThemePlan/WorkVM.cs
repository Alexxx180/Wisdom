using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using System.Windows.Input;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Commands;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Numeration;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Count;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class WorkVM : TNode<TaskVM>, ICount, IHighlighting, ICloneable<WorkVM>
    {
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public WorkVM(IPlan<WorkVM> parent, Work work)
        {
            _work = work;
            Parent = parent;

            _numeration = parent.Numeration;
            _sumCount = parent.SumCount;
            _higlighting = parent.Higlighting;

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<TaskVM>(new TaskVM(this, new Topic()));
            SetNumeration();
            SetCount();
            SetHighlight();

            RemoveCommand = new RelayCommand(argument => Parent.Remove((WorkVM)argument));
        }

        public void SetNumeration()
        {
            Items.Options.Add(new StateBlock<TaskVM>(Numerable.Collection(Items), ref _numeration));
        }

        public void SetCount()
        {
            Items.Options.Add(new StateBlock<TaskVM>(Count.Collection(Items), ref _sumCount));
        }

        public void SetHighlight()
        {
            Items.Options.Add(new StateBlock<TaskVM>(Coloring.Collection(Items), ref _higlighting));
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

        public ushort Hours
        {
            get => _work.Hours;
            set
            {
                _work.Hours = value;
                OnPropertyChanged();
            }
        }

        public IPlan<WorkVM> Parent { get; }
        public ICommand RemoveCommand { get; }
        
        public WorkVM Copy()
        {
            return new WorkVM(Parent, _work.Copy());
        }

        private FeatureSetting _numeration;
        public FeatureSetting Numeration => _numeration;
        private FeatureSetting _sumCount;
        public FeatureSetting SumCount => _sumCount;
        private FeatureSetting _higlighting;
        public FeatureSetting Higlighting => _higlighting;
    }
}
