namespace ControlMaterials.Total.Count
{
    public interface ICount
    {
        public ushort Sum { get; }

        public void Append(ushort increment);
        public void Reduce(ushort decrement);

        public void SetTotal(ushort sum);
    }
}
