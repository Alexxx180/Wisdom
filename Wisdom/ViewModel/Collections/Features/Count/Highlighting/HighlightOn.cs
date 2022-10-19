namespace ControlMaterials.Total.Count.Highlighting
{
    public class HighlightOn<T> : HighlightOff<T> where T : ISum
    {
        private readonly Bridge<ISummator> Count;

        public HighlightOn(Bridge<ISummator> count,
            IHighlighting item, string property) : base(item, property)
        {
            Count = count;
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
            ISummator summator = Count.Reference;
            if (summator.Sum > summator.PrevSum)
            {
                Item.SetColor(HighlightColor.VIOLATION);
            }
            else if (summator.Sum == summator.PrevSum)
            {
                Item.SetColor(HighlightColor.CONFORMITY);
            }
            else
            {
                Item.SetColor(HighlightColor.NEUTRAL);
            }
        }

        public override void Setup()
        {
            Recalculate();
        }
    }
}
