using System.IO;
using System.Windows;
using System.Windows.Documents;
//using Xceed.Words.NET;
//using Xceed.Document.NET;
//using Microsoft.Office.Interop.Word;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        public static void WriteDoc(FlowDocument doc, string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                TextRange textRange = new TextRange(doc.ContentStart, doc.ContentEnd);
                textRange.Save(fs, DataFormats.Rtf);
            }

            //Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            //doc.WordOpenXML.
            //Microsoft.Office.Interop.Word.Section section = (Microsoft.Office.Interop.Word.Section)textRange;
            //doc.Sections.Add(section);
            //doc.Sections.Add(Sheet2);
            //doc.Sections.Add(Sheet3);
            //doc.Sections.Add(Sheet4);
            //doc.Sections.Add(Sheet5);
            //doc.Sections.Add(Sheet6);
            //doc.Sections.Add(Sheet7);
            //doc.SaveAs2(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Words.NET.DocX doc = Xceed.Words.NET.DocX.Create(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Document.NET.Document doc = null;
            //doc.InsertDocument(doc);
            //Xceed.Document.NET.Section section = null;
            //section.InsertSection();
            //section.Xml
            //doc.Xml.Add(Struct);
            //doc.SaveAs(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.docx");
            //Xceed.Document.NET.Section

            //MemoryStream stream = new MemoryStream();
            //DocX document = DocX.Create(stream);
            //Xceed.Document.NET.Paragraph p = document.InsertParagraph();
            //p.Append("Hello World");

            //document.Save();

            //System.IO.
            //return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "DOCHK.docx");
            //using FileStream fs = File.Open(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\test.doc", FileMode.Create);


            //Method 1
            //IDocumentPaginatorSource source = Struct;
            //TextRange content = new TextRange(Struct.ContentStart, Struct.ContentEnd);

            //if (content.CanSave(DataFormats.Rtf))
            //{
            //    using FileStream fs = File.Open(fileName, FileMode.Create);
            //    content.Save(fs, DataFormats.Rtf, true);
            //}

            //Method 2
            //using FileStream fs = File.Open(@"D:,ent, fs);
            //    MessageBox.Show("Файл сохранен");

            //Method 3
            //using (FileStream fs = File.Create(fileName))
            //{
            //    using (BinaryWriter binWriter = new BinaryWriter(fs))
            //    {
            //        //binWriter.Write(true);
            //        binWriter.Write(XamlWriter.Save(Struct));
            //    }
            //}
            //Method 4
            //try
            //{
            //    IDocumentPaginatorSource source = Struct;
            //    Stream file = File.Create(fileName);
            //    TextWriter writer = new StreamWriter(file);
            //    XmlTextWriter xmlWriter = new XmlTextWriter(writer);

            //    XamlDesignerSerializationManager xamlManager = new XamlDesignerSerializationManager(xmlWriter);
            //    XamlWriter.Save(source, xamlManager);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //                      BreakPageBefore="True"
            /*string searchPattern = @"}{\qj"; //
            //bool firstPage = true; // No pagebreak on the first page
            List<long> linesReadList = new List<long>(10);
            // open the file for writing
            using (MemoryStream stream = new MemoryStream())
            {
                // create a textrange and save it to the memory stream;
                TextRange content = new TextRange(Struct.ContentStart, Struct.ContentEnd);
                //if (content.CanSave(DataFormats.Rtf))
                content.Save(stream, DataFormats.Rtf, true);
                StreamReader memoryReader = new StreamReader(stream);
                stream.Seek(0, SeekOrigin.Begin);
                StreamWriter writer = new StreamWriter(fileName);
                string line;
               // string lines = "";
                // Read and display lines from the file until the end of
                // the file is reached.
                //throw new Exception(memoryReader.ReadLine());
                while ((line = memoryReader.ReadLine()) != null)
                {
                    if (line.Contains(searchPattern))
                    {
                        // if not on the first page write a pagebreak
                        //if (!firstPage)
                        writer.WriteLine("\\page");
                        //throw new Exception("-YEAH-");
                        //lines += "\n\\page\n";
                        //firstPage = false;
                    }
                    //throw new Exception("-SUCCESS-");
                    writer.WriteLine(line);
                   // lines += line;
                }
                writer.Close();
                memoryReader.Close();
            }*/
        }
    }
}
