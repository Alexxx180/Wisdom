namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Components autoindexing feature with indexing options
    /// </summary>
    public interface IOptionableIndexing : IAutoIndexing
    {
        public AutoPanel Options { get; set; }
    }
}