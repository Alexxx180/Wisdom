namespace ControlMaterials.Total.Count
{
    public interface ICount : ISum
    {
        public void Append(ushort increment);
        public void Reduce(ushort decrement);
        public void SetTotal(ushort sum);
    }
}
