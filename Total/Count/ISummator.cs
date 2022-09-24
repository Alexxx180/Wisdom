namespace ControlMaterials.Total.Count
{
    public interface ISummator
    {
        public ushort Sum { get; }
        public ushort PrevSum { get; }
    }
}