using System.Collections.Generic;

namespace Wisdom.Model
{
    public class ComboHeader<TName, TValue>
    {
        public ComboHeader()
        {
            keys = new List<TName>();
            items = new List<TValue>();
        }

        public List<TName> keys;
        public List<TValue> items;
    }
}