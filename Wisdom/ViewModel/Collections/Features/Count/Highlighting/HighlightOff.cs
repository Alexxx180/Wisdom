using ControlMaterials.Total;

namespace Wisdom.ViewModel.Collections.Features.Count.Highlighting
{
    public class HighlightOff<T, TParent> : State<T, TParent>
        where T : IChangeable
        where TParent : IHighlighting
    {
        public HighlightOff() : base(nameof(IHours.Hours)) { }

        public override void Add(T item, TParent parent) { }

        public override void Remove(T item, TParent parent) { }

        public override void Recalculate(T item, TParent parent) { }

        public override void Setup() { }
    }
}
