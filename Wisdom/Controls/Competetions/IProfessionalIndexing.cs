using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Competetions
{
    public interface IProfessionalIndexing
    {
        public int No2 { get; set; }
        public byte AutoOption { get; set; }
        public string ProfessionalHeader { get; }

        public void SetNo1(int no);
        public void SetNo2(int no);
        public void SetAuto(byte selection);
    }
}
