using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.ThemePlan
{
    interface ITaskIndexing
    {
        public int No { get; set; }
        public string TaskHeader { get; }

        public void SetNo(int no);
    }
}
