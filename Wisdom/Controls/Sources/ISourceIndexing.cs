using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.Sources
{
    interface ISourceIndexing
    {
        public int No { get; set; }
        public string SourceHeader { get; }

        public void SetNo(int no);
    }
}
