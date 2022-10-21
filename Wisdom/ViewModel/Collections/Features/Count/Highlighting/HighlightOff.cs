using ControlMaterials.Total;
using ControlMaterials.Total.Collections;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class HighlightOff<T> : State<T> where T : IChangeable
    {
        public IHighlighting Item { get; set; }

        public HighlightOff(IHighlighting item, IOptionableCollection<T> items) :
            base(nameof(IHours.Hours), items)
        {
            Item = item;
        }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }

        public override void Setup()
        {
            Item.Coloring.SetColor(HighlightColor.NEUTRAL);
        }
    }
}
