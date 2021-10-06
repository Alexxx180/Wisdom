namespace Wisdom.Model
{
    public class LevelsList<T> : HoursList<T>
    {
        public LevelsList(string name, string hours, string level) : base(name, hours)
        {
            Level = level;
        }
        public string Level { get; set; }
    }
}