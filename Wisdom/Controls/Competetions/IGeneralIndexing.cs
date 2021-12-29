namespace Wisdom.Controls.Competetions
{
    public interface IGeneralIndexing
    {
        public int No { get; set; }
        public byte AutoOption { get; set; }
        public string GeneralHeader { get; }

        public void SetNo(int no);
        public void SetAuto(byte selection);
    }
}
