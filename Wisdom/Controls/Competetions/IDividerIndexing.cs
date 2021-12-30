using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Competetions
{
    public interface IDividerIndexing
    {
        public int No1 { get; set; }
        public byte AutoOption { get; set; }
        public string DividerHeader { get; }

        public void SetNo1(int no);
        public void SetAuto(byte selection);
    }
}
