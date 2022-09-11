namespace ControlMaterials.Total
{
    public class CountHours<T> : State<T> where T : ISum
    {
        private uint _sum;

        public CountHours() : base("Hours")
        {
            _sum = 0;
        }

        public override void Add(T item)
        {
            _sum += item.Sum;
        }

        public override void Remove(T item)
        {
            _sum -= item.Sum;
        }

        public override void Recalculate()
        {
            _sum = 0;
            for (ushort i = 0; i < Items.Count; i++)
            {
                _sum += Items[i].Sum;
            }
        }
    }
}
