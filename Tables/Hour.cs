namespace ControlMaterials.Tables
{
    public struct Hour
    {
        public Hour(string name, ushort count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }
        public ushort Count { get; set; }
    }
}