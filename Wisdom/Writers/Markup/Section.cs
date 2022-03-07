using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Wisdom.Writers.Markup
{
    public class Section
    {
        public ushort Width { get; set; }
        public Justification Justification { get; set; }

        public Run Header { get; set; }
        public OpenXmlElement[] Properties { get; set; }
    }
}