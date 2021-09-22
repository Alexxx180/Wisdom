using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        //private static Paragraph FastText(string text)
        //{
        //    return new Paragraph(new ParagraphProperties(
        //        new RunFonts
        //        {
        //            Ascii = "Times New Roman",
        //            HighAnsi = "Times New Roman",
        //            EastAsia = "Times New Roman",
        //            ComplexScript = "Times New Roman"
        //        },
        //        new FontSize { Val = new StringValue("28") }
        //        ),
        //        new Run(new RunProperties(
        //        new RunFonts
        //        {
        //            Ascii = "Times New Roman",
        //            HighAnsi = "Times New Roman",
        //            EastAsia = "Times New Roman",
        //            ComplexScript = "Times New Roman"
        //        },
        //        new FontSize { Val = new StringValue("28") }),
        //        new Text(text)));
        //}
        //private static TableCellWidth CellWidth(string value)
        //{
        //    TableCellWidth width = new TableCellWidth
        //    {
        //        Width = new StringValue(value),
        //        Type = TableWidthUnitValues.Pct,
        //    };
        //    return width;
        //}
        //private static Table DefaultTable()
        //{
        //    TableWidth tabWidth = new TableWidth
        //    {
        //        Width = new StringValue("100%"),
        //        Type = TableWidthUnitValues.Pct,
        //    };
        //    return new Table(new TableProperties(tabWidth));
        //}

        //private static Table FillTable(Table table, string width1, string width2, params string[] texts)
        //{
        //    for (byte i = 0; i < texts.Length; i++)
        //    {
        //TableBorders tableBorders1 = new TableBorders();
        //TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
        //        TableCell cell0 = new TableCell(FastText("\n"), new TableCellProperties(CellWidth(width1),
        //            tableBorders1));
        //        TableCell cell = new TableCell(FastText(texts[i]), new TableCellProperties(CellWidth(width2)));
        //        TableRow row = new TableRow(cell0, cell);
        //        table.AddChild(row);
        //    }
        //    return table;
        //}
        //Method 5, Using OOXML can save as docx
        public static void WriteDoc(System.Windows.Documents.FlowDocument doc, string filename)
        {
            GeneratedClass class1 = new GeneratedClass();
            class1.CreatePackage(@"C:\Users\Администратор\Desktop\Работы\Курсовая\Tests\Shit.docx");
            /*using (WordprocessingDocument package = WordprocessingDocument.Create(
                @"C:\Users\Администратор\Desktop\Работы\Курсовая\Tests\Shit.docx", WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = package.AddMainDocumentPart();
                new Document(new Body()).Save(mainPart);
                //row.ChildElements.GetItem(1)
                Body body = mainPart.Document.Body;
                mainPart.Document.Save();
                Table tab = FillTable(DefaultTable(), "15%", "85%",
                    "123123");
                body.Append(tab);
                package.Save();
                package.Close();
            }*/
        }
    }
}

//using (FileStream fs = new FileStream(@"C:\Users\Администратор\Desktop\Работы\Курсовая\Tests\Shit.rtf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
//{
//    TextRange textRange = new TextRange(doc.ContentStart, doc.ContentEnd);
//    textRange.Save(fs, DataFormats.Rtf);
//}