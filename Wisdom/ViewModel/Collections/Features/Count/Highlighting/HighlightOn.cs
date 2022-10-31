using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class HighlightOn<T, TParent> : HighlightOff<T, TParent>
        where T : IChangeable
        where TParent : IHighlighting
    {
        private readonly Bridge<ISummator<TParent>> _count;

        public HighlightOn(Bridge<ISummator<TParent>> count)
        {
            _count = count;
        }

        public HighlightColor DefineColor(ISummator<TParent> summator, TParent parent)
        {
            ushort current = summator.CurrentSum(parent);
            ushort previous = summator.PreviousSum(parent);

            if (current == previous)
                return HighlightColor.CONFORMITY;

            return current > previous ? HighlightColor.VIOLATION : HighlightColor.NEUTRAL;
        }

        public override void Setup() { }

        public override void Add(T item, TParent parent)
        {
            Recalculate(item, parent);
        }

        public override void Remove(T item, TParent parent)
        {
            Recalculate(item, parent);
        }

        public override void Recalculate(T item, TParent parent)
        {
            HighlightColor higlighting = DefineColor(_count.Reference, parent);
            parent.Coloring.SetColor(higlighting);
        }
    }
}
