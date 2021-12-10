using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Competetions
{
    interface IDividerIndexing
    {
        public int No1 { get; set; }
        public string DividerHeader { get; }

        public void SetNo1(int no);
    }
}
