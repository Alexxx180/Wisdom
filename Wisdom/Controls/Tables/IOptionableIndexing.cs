namespace Wisdom.Controls.Tables
{
    public interface IOptionableIndexing : IAutoIndexing
    {
        public AutoPanel Options { get; set; }
    }
}