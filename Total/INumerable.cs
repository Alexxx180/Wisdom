namespace ControlMaterials.Total
{
    public interface INumerable : IChangeable
    {
        public ushort No { get; }

        public void SetNumber(ushort no);
        public void Increment(ushort no);
        public void Decrement(ushort no);
    }
}
