namespace Wisdom.Model
{
    public struct TaskHours
    {
        public TaskHours(string name, ushort value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public ushort Value { get; set; }
    }
}
