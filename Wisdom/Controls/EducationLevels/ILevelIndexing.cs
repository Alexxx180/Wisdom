using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.EducationLevels
{
    interface ILevelIndexing
    {
        public int No { get; set; }
        public string LevelHeader { get; }

        public void SetNo(int no);
    }
}
