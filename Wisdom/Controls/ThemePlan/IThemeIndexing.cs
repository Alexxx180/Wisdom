using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.ThemePlan
{
    interface IThemeIndexing
    {
        public int SectionNo { get; set; }
        public string ThemeHeader { get; }

        public void SetTopicNo(int no);
        public void SetSectionNo(int no);
    }
}
