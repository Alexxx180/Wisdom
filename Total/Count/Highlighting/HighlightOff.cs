using ControlMaterials.Total.Collections;

namespace ControlMaterials.Total.Count.Highlighting
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
