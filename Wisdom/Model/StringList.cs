using System.Collections.Generic;

namespace Wisdom.Model
{
    public class StringList
    {
        private readonly string startSequence;
        private readonly string endSequence;
        public StringList(string start, string end)
        {
            startSequence = start;
            endSequence = end;
            Values = new List<string>();
        }

        private void Add(params string[] values)
        {
            if (values == null || values.Length <= 0)
                return;
            string sub = values[0];
            for (byte i = 1; i < values.Length; i++)
                sub += startSequence + values[i] + endSequence;
            Values.Add(sub);
        }
        public List<string> Values { get; set; }
    }
}
