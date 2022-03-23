using System.Collections.Generic;

namespace ControlMaterials.Tables
{
    public class Source
    {
        public Source()
        {

        }

        public Source(
            string name,
            List<string>
            descriptions
            )
        {
            Name = name;
            Descriptions = descriptions;
        }

        public string Name { get; set; }

        public List<string> Descriptions { get; set; }
    }
}