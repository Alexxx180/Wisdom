using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Wisdom.Model;

namespace Wisdom.Controls
{
    interface IAtomicElement
    {
        public abstract void AddElements(List<String2> metaTypes, StackPanel stack);
    }
}
