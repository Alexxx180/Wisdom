using ControlMaterials.Total;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public abstract class PlanVM<T> : TNode<T>, IParent<T>, IPlan, ICount, IHighlighting where T : ICloneable<T>, IChangeable, IHours
    {
        public Countable Count { get; private set; }
        public Highlightable Coloring { get; private set; }

        private void SetDefault(byte numeration,
            byte count, byte highlight)
        {
            Numeration.Select(numeration);
            SumCount.Select(count);
            Higlighting.Select(highlight);
        }

        private protected virtual void Features()
        {
            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);
        }

        private protected virtual void ListSetup(T additor)
        {
            Items = new AutoList<T>(additor);
            Items.Options.Add(new StateBlock<T>(Count.Collection(Items), ref _sumCount));
            Items.Options.Add(new StateBlock<T>(Coloring.Collection(Items), ref _higlighting));
        }

        private protected void UpdateHiglighting()
        {
            Items.Options[1].Recalculate();
        }

        public abstract ushort Hours { get; set; }

        private protected PlanVM(byte numeration,
            byte count, byte highlight)
        {
            Numeration = new FeatureSetting();
            _sumCount = new FeatureSetting();
            _higlighting = new FeatureSetting();
            SetDefault(numeration, count, highlight);
            Features();
        }

        private protected PlanVM(IPlan plan)
        {
            Numeration = plan.Numeration;
            _sumCount = plan.SumCount;
            _higlighting = plan.Higlighting;
            Features();
        }

        private protected FeatureSetting _numeration;
        public FeatureSetting Numeration
        {
            get => _numeration;
            set
            {
                _numeration = value;
                OnPropertyChanged();
            }
        }

        private FeatureSetting _sumCount;
        public FeatureSetting SumCount => _sumCount;
        private FeatureSetting _higlighting;
        public FeatureSetting Higlighting => _higlighting;
    }
}
