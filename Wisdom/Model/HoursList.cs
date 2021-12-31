namespace Wisdom.Model
{
    public class HoursList<T> : HashList<T>
    {
        public HoursList() : base()
        {
            Hours = "";
        }

        public HoursList(string name, string hours) : base(name)
        {
            Hours = hours;
        }
        public string Hours { get; set; }
    }
}
