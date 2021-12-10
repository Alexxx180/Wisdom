using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Competetions
{
    interface IProfessionalIndexing
    {
        public int No2 { get; set; }
        public string ProfessionalHeader { get; }

        public void SetNo1(int no);
        public void SetNo2(int no);
    }
}
