namespace ControlMaterials.Total.Count
{
    public interface ICount
    {
        public uint Sum { get; }

        public void Append(ushort increment);
        public void Reduce(ushort decrement);

        public void SetTotal(uint sum);
    }
}
