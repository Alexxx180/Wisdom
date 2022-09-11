namespace ControlMaterials.Total.Count
{
    public class ManualCount<T> : State<T> where T : ISum
    {
        public ManualCount(string property) : base(property) { }

        public override void Add(T item) { }

        public override void Remove(T item) { }

        public override void Recalculate() { }
    }
}
