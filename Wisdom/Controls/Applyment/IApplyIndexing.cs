using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Applyment
{
    interface IApplyIndexing
    {
        public int No { get; set; }
        public string ApplyHeader { get; }

        public void SetNo(int no);
    }
}
