using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
//using System.Diagnostics;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        public static void WriteDoc(System.Windows.Documents.FlowDocument doc, string filename)
        {
            //using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    System.Windows.Documents.TextRange textRange = new System.Windows.Documents.TextRange(doc.ContentStart, doc.ContentEnd);
            //    textRange.Save(fs, DataFormats.Rtf);
            //}

            //Method 5, Using OOXML can save as docx
            using (WordprocessingDocument package = WordprocessingDocument.Open(@"C:\Users\Администратор\Desktop\Работы\Курсовая\Shit.docx", true)) //, WordprocessingDocumentType.Document
            {
                IEnumerable<Table> list = package.MainDocumentPart.Document.Descendants<Table>();
                foreach (Table tab in list)
                {
                    //Trace.WriteLine(tab.ChildElements.Count);
                    TableRow row = tab.ChildElements.GetItem(2) as TableRow;
                    //Trace.WriteLine(row.ChildElements.Count);
                    TableCell cell = row.ChildElements.GetItem(1) as TableCell;
                    //Trace.WriteLine(cell.InnerText);
                    cell.AppendChild(new Paragraph(new Run(new Text("LOOOL"))));
                }
                package.Save();
                package.Close();
            }
        }
    }
}
