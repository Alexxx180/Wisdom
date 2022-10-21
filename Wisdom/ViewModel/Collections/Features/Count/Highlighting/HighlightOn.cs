using ControlMaterials.Total;
using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using Color = ControlMaterials.Total.Count.Highlighting.HighlightColor;

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

        public Color DefineColor(ISummator summator)
        {
            if (summator.Sum == summator.PrevSum)
                return Color.CONFORMITY;

            return summator.Sum > summator.PrevSum ? Color.VIOLATION : Color.NEUTRAL;
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
            Color higlighting = DefineColor(Count.Reference);
            Item.Coloring.SetColor(higlighting);
        }
    }
}
