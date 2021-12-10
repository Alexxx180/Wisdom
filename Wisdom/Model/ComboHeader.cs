using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Wisdom.Model
{
    public class ComboHeader
    {
        public ComboHeader()
        {
            keys = new List<uint>();
            items = new List<ComboBoxItem>();
        }

        public List<uint> keys;
        public List<ComboBoxItem> items;
    }
}
