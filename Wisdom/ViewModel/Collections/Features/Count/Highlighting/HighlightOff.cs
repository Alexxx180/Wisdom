using ControlMaterials.Total.Collections;
using ControlMaterials.Total.Count;
using ControlMaterials.Total.Count.Highlighting;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class HighlightOff<T> : State<T> where T : ISum
    {
        public IHighlighting Item { get; set; }

        public HighlightOff(IHighlighting item,
            string property) : base(property)
        {
            Item = item;
        }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }

        public override void Setup()
        {
            Item.SetColor(HighlightColor.NEUTRAL);
        }
    }
}
