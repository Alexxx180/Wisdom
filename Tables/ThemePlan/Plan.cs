using ControlMaterials.Total;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Plan : ICloneable<Plan>
    {
        public ushort Sum { get; set; }

        public void Append(ushort increment)
        {
            Sum += increment;
        }

        public void Reduce(ushort decrement)
        {
            Sum -= decrement;
        }

        public void SetTotal(ushort sum)
        {
            Sum = sum;
        }

        public Plan Copy() => new Plan() { Sum = Sum };
    }
}
