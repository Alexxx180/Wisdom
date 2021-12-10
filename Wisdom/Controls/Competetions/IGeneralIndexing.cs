using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Competetions
{
    interface IGeneralIndexing
    {
        public int No { get; set; }
        public string GeneralHeader { get; }

        public void SetNo(int no);
    }
}
