﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.AutoGenerating
{
    class Match
    {
        /// <summary>
        /// Last matching element index containing part of the search text
        /// </summary>
        public int EndElementIndex { get; set; }
        /// <summary>
        /// Last matching char index of the search text in last matching element
        /// </summary>
        public int EndCharIndex { get; set; }
    }
}
