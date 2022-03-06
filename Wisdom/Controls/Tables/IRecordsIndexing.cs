namespace Wisdom.Controls.Tables
{
    /// <summary>
    /// Components autoindexing feature
    /// </summary>
    public interface IRecordsIndexing : IAutoIndexing
    {
        public RecordsPanel Options { get; set; }
    }
}
