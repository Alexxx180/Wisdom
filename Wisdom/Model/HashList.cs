using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Model
{
    public class HashList<T>
    {
        public HashList(string name)
        {
            Name = name;
            Values = new List<T>();
        }
        public HashList(string name, List<T> values)
        {
            Name = name;
            Values = values;
        }
        public string Name { get; set; }
        public List<T> Values { get; set; }
    }
}
