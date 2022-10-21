using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class HighlightOn<T> : HighlightOff<T> where T : IChangeable
    {
        private readonly Bridge<ISummator> Count;

        public HighlightOn(Bridge<ISummator> count, IHighlighting item,
            IOptionableCollection<T> items) : base(item, items)
        {
            Count = count;
        }

        public HighlightColor DefineColor(ISummator summator)
        {
            if (summator.Sum == summator.PrevSum)
                return HighlightColor.CONFORMITY;

            return summator.Sum > summator.PrevSum ?
                HighlightColor.VIOLATION : HighlightColor.NEUTRAL;
        }

        public override void Setup()
        {
            Recalculate();
        }

        public override void Add(T item)
        {
            Recalculate();
        }

        public override void Remove(T item)
        {
            Recalculate();
        }

        public override void Recalculate()
        {
            HighlightColor higlighting = DefineColor(Count.Reference);
            Item.Coloring.SetColor(higlighting);
        }
    }
}
