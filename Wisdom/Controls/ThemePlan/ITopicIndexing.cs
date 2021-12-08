using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Controls.ThemePlan
{
    interface ITopicIndexing
    {
        public int TopicNo { get; set; }
        public string TopicHeader { get; }

        public void SetTopicNo(int no);
    }
}
