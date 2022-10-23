using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemePlanVM : TNode<TopicVM>, ICount, IHighlighting, ICloneable<ThemePlanVM>, IPlan<TopicVM>
    {
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public ThemePlanVM(Plan plan)
        {
            _plan = plan;

            _numeration = new FeatureSetting();
            _sumCount = new FeatureSetting();
            _higlighting = new FeatureSetting();

            Numeration.Select(2);
            SumCount.Select(0);
            Higlighting.Select(0);

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<TopicVM>(new TopicVM(this, new Topic()));
            SetNumeration();
            SetCount();
            SetHighlight();
        }

        public void SetNumeration()
        {
            Items.Options.Add(new StateBlock<TopicVM>(Numerable.Collection(Items), ref _numeration));
        }

        public void SetCount()
        {
            Items.Options.Add(new StateBlock<TopicVM>(Count.Collection(Items), ref _sumCount));
        }

        public void SetHighlight()
        {
            Items.Options.Add(new StateBlock<TopicVM>(Coloring.Collection(Items), ref _higlighting));
        }

        private readonly Plan _plan;

        public ushort Hours
        {
            get => _plan.Sum;
            set
            {
                _plan.Sum = value;
                OnPropertyChanged();
            }
        }

        public ThemePlanVM Copy()
        {
            return new ThemePlanVM(_plan.Copy());
        }

        private FeatureSetting _numeration;
        public FeatureSetting Numeration => _numeration;
        private FeatureSetting _sumCount;
        public FeatureSetting SumCount => _sumCount;
        private FeatureSetting _higlighting;
        public FeatureSetting Higlighting => _higlighting;
    }
}
