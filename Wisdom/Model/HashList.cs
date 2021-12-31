using System.Collections.Generic;

namespace Wisdom.Model
{
    public class HashList<T>
    {
        public HashList()
        {
            Values = new List<T>();
            Name = "";
        }
        public HashList(string name) : this()
        {
            Name = name;
        }
        public HashList(string name, List<T> values) : this(name)
        {
            Values = values;
        }
        public string Name { get; set; }
        public List<T> Values { get; set; }
    }

    public class HashList2<T>
    {
        public HashList2(string name)
        {
            Name = name;
            Values = default(T);
        }
        public HashList2(string name, T values)
        {
            Name = name;
            Values = values;
        }
        public string Name { get; set; }
        public T Values { get; set; }
    }
}