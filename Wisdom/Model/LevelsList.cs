namespace Wisdom.Model
{
    public class LevelsList<T> : HoursList<T>
    {
        public LevelsList() : base()
        {
            Level = "";
            Competetions = "";
        }

        public LevelsList(string name, string hours, string competetions, string level) : base(name, hours)
        {
            Level = level;
            Competetions = competetions;
        }
        public string Level { get; set; }
        public string Competetions { get; set; }
    }
}