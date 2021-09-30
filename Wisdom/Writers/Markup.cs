using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using Wisdom.Model;

namespace Wisdom.Writers
{
    public static class Markup
    {
        public static Run RunAdd(string text, params OpenXmlElement[] elements)
        {
            Run run227 = new Run();

            RunProperties runProperties217 = new RunProperties();
            RunFonts runFonts202 = new RunFonts()
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman",
                EastAsia = "Times New Roman",
                ComplexScript = "Times New Roman"
            };
            //Bold bold35 = new Bold();
            Color color187 = new Color() { Val = "000000" };
            FontSize fontSize199 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript187 = new FontSizeComplexScript() { Val = "24" };
            Languages languages182 = new Languages() { Val = "ru" };

            for (byte i = 0; i < elements.Length; i++)
                runProperties217.Append(elements[i]);
            runProperties217.Append(runFonts202);
            //runProperties217.Append(bold35);
            runProperties217.Append(color187);
            runProperties217.Append(fontSize199);
            runProperties217.Append(fontSizeComplexScript187);
            runProperties217.Append(languages182);
            Text text125 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text125.Text = text; //"Раздел 1. "

            run227.Append(runProperties217);
            run227.Append(text125);
            return run227;
        }
        public static Paragraph ParagraphAdd(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph117 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties117 = new ParagraphProperties();
            WidowControl widowControl62 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE89 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN89 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent89 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines89 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification71 = new Justification() { Val = justify };

            ParagraphMarkRunProperties paragraphMarkRunProperties109 = new ParagraphMarkRunProperties();
            RunFonts runFonts201 = new RunFonts()
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman",
                EastAsia = "Times New Roman",
                ComplexScript = "Times New Roman"
            };
            Color color186 = new Color() { Val = "000000" };
            FontSize fontSize198 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript186 = new FontSizeComplexScript() { Val = "24" };
            Languages languages181 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties109.Append(runFonts201);
            paragraphMarkRunProperties109.Append(color186);
            paragraphMarkRunProperties109.Append(fontSize198);
            paragraphMarkRunProperties109.Append(fontSizeComplexScript186);
            paragraphMarkRunProperties109.Append(languages181);

            paragraphProperties117.Append(widowControl62);
            paragraphProperties117.Append(autoSpaceDE89);
            paragraphProperties117.Append(autoSpaceDN89);
            paragraphProperties117.Append(adjustRightIndent89);
            paragraphProperties117.Append(spacingBetweenLines89);
            paragraphProperties117.Append(justification71);
            paragraphProperties117.Append(paragraphMarkRunProperties109);

            //Run run = RunAdd("Раздел 1. ", new Bold());

            paragraph117.Append(paragraphProperties117);
            for (byte i = 0; i < runs.Length; i++)
                paragraph117.Append(runs[i]);
            return paragraph117;
        }
        public static TableCell TableCellAdd(Paragraph par, ushort width, params OpenXmlElement[] cellProps)
        {
            TableCell tableCell36 = new TableCell();

            TableCellProperties tableCellProperties36 = new TableCellProperties();
            TableCellWidth tableCellWidth36 = new TableCellWidth() { Width = width.ToString(), Type = TableWidthUnitValues.Dxa };

            tableCellProperties36.Append(tableCellWidth36);

            tableCell36.Append(tableCellProperties36);
            for (byte i = 0; i < cellProps.Length; i++)
                tableCell36.Append(cellProps[i]);
            tableCell36.Append(par);
            return tableCell36;
        }
        public static TableRow TableRowAdd(params TableCell[] cells)
        {
            TableRow tableRow = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };
            for (byte i = 0; i < cells.Length; i++)
                tableRow.Append(cells[i]);
            return tableRow;
        }
        //GridColumn gridColumn7 = new GridColumn() { Width = "1971" };

        //GridColumn gridColumn8 = new GridColumn() { Width = "283" };
        //5528
        //GridColumn gridColumn8_1 = new GridColumn() { Width = "5245" };

        //GridColumn gridColumn9 = new GridColumn() { Width = "992" };
        //GridColumn gridColumn10 = new GridColumn() { Width = "1276" };
        public static TableRow SectionAdd(string title, string hours)
        {
            Run sectionRun = RunAdd(title, new Bold());
            Run hoursRun = RunAdd(hours, new Bold());

            Paragraph sectionP = ParagraphAdd(JustificationValues.Center, sectionRun);
            Paragraph desriptionP = ParagraphAdd(JustificationValues.Both);
            Paragraph hoursP = ParagraphAdd(JustificationValues.Center, hoursRun);
            Paragraph levelsP = ParagraphAdd(JustificationValues.Center);

            TableCell[] cells = new TableCell[] {
                TableCellAdd(sectionP, 1971),
                TableCellAdd(desriptionP, 5528, new GridSpan { Val = 2 }),
                TableCellAdd(hoursP, 992),
                TableCellAdd(levelsP, 1276)
            };

            TableRow tableRow = TableRowAdd(cells);
            return tableRow;
        }
        //HoursList<HashList<String2>> data
        public static List<TableRow> ThemeAdd(string title, string level,
            List<HashList<String2>> data)
        {
            List<TableRow> themeContents = new List<TableRow>();

            Run themeRun1 = RunAdd(title, new Bold());
            Run descriptionRun1 = RunAdd(data[0].Name);
            Run levelRun1 = RunAdd(level);

            Paragraph sectionP1 = ParagraphAdd(JustificationValues.Center, themeRun1);
            Paragraph desriptionP1 = ParagraphAdd(JustificationValues.Both, descriptionRun1);
            Paragraph hoursP1 = ParagraphAdd(JustificationValues.Center);
            Paragraph levelsP1 = ParagraphAdd(JustificationValues.Center, levelRun1);

            //Row span
            //new VerticalMerge { Val = MergedCellValues.Restart }
            //new VerticalMerge()
            //Unless new sections encountered

            //TableRow1
            TableCell[] cells1 = new TableCell[] {
                TableCellAdd(sectionP1, 1971, new VerticalMerge
                { Val = MergedCellValues.Restart }),
                TableCellAdd(desriptionP1, 5528, new GridSpan { Val = 2 }),
                TableCellAdd(hoursP1, 992),
                TableCellAdd(levelsP1, 1276, new VerticalMerge
                { Val = MergedCellValues.Restart })
            };

            TableRow headerRow = TableRowAdd(cells1);

            themeContents.Add(headerRow);
            themeContents.AddRange(ThemeContentAdd(data[0].Values));

            for (byte i = 1; i < data.Count; i++)
            {
                Run descriptionRun = RunAdd(data[i].Name);

                Paragraph sectionP = ParagraphAdd(JustificationValues.Center);
                Paragraph desriptionP = ParagraphAdd(JustificationValues.Both, descriptionRun);
                Paragraph hoursP = ParagraphAdd(JustificationValues.Center);
                Paragraph levelsP = ParagraphAdd(JustificationValues.Center);

                TableCell[] subCells = new TableCell[] {
                    TableCellAdd(sectionP, 1971, new VerticalMerge
                    { Val = MergedCellValues.Restart }),
                    TableCellAdd(desriptionP, 5528, new GridSpan { Val = 2 }),
                    TableCellAdd(hoursP, 992),
                    TableCellAdd(levelsP, 1276, new VerticalMerge
                    { Val = MergedCellValues.Restart })
                };

                TableRow subHeaderRow = TableRowAdd(subCells);

                themeContents.Add(subHeaderRow);
                themeContents.AddRange(ThemeContentAdd(data[i].Values));
            }

            return themeContents;
        }
        private static List<TableRow> ThemeContentAdd(List<String2> rows)
        {
            List<TableRow> themeContent = new List<TableRow>();
            for (byte ii = 0; ii < rows.Count; ii++)
            {
                Run no = RunAdd((ii + 1).ToString());
                Run descriptionRun2 = RunAdd(rows[ii].Name);
                Run hoursRun = RunAdd(rows[ii].Value);

                Paragraph sectionP2 = ParagraphAdd(JustificationValues.Center);
                Paragraph headerNo = ParagraphAdd(JustificationValues.Center, no);
                Paragraph desriptionP2 = ParagraphAdd(JustificationValues.Both, descriptionRun2);
                Paragraph hoursP2 = ParagraphAdd(JustificationValues.Center, hoursRun);
                Paragraph levelsP2 = ParagraphAdd(JustificationValues.Center);

                TableCell[] subCells2 = new TableCell[] {
                        TableCellAdd(sectionP2, 1971, new VerticalMerge()),
                        TableCellAdd(headerNo, 425),
                        TableCellAdd(desriptionP2, 5103),
                        TableCellAdd(hoursP2, 992),
                        TableCellAdd(levelsP2, 1276, new VerticalMerge())
                    };

                TableRow valueRow = TableRowAdd(subCells2);

                themeContent.Add(valueRow);
            }
            return themeContent;
        }

        public static Paragraph WordParagraph(string value, string sequence, object[] optionalPar = null, object[] optionalRuns = null)
        {
            Paragraph paragraph127 = new Paragraph() { RsidParagraphAddition = "00E769EC", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties127 = new ParagraphProperties();
            WidowControl widowControl72 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE99 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN99 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent99 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines99 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification81 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties119 = new ParagraphMarkRunProperties();
            RunFonts runFonts214 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color199 = new Color() { Val = "000000" };
            FontSize fontSize211 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript199 = new FontSizeComplexScript() { Val = "24" };
            Languages languages194 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties119.Append(runFonts214);
            paragraphMarkRunProperties119.Append(color199);
            paragraphMarkRunProperties119.Append(fontSize211);
            paragraphMarkRunProperties119.Append(fontSizeComplexScript199);
            if (optionalPar != null)
                foreach (OpenXmlElement markProp in optionalPar)
                    paragraphMarkRunProperties119.Append(markProp);
            paragraphMarkRunProperties119.Append(languages194);

            paragraphProperties127.Append(widowControl72);
            paragraphProperties127.Append(autoSpaceDE99);
            paragraphProperties127.Append(autoSpaceDN99);
            paragraphProperties127.Append(adjustRightIndent99);
            paragraphProperties127.Append(spacingBetweenLines99);
            paragraphProperties127.Append(justification81);
            paragraphProperties127.Append(paragraphMarkRunProperties119);

            Run run231 = new Run();

            RunProperties runProperties221 = new RunProperties();
            RunFonts runFonts216 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color201 = new Color() { Val = "000000" };
            FontSize fontSize213 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript201 = new FontSizeComplexScript() { Val = "24" };
            Languages languages196 = new Languages() { Val = "ru" };
            runProperties221.Append(runFonts216);
            if (optionalRuns != null)
                foreach (OpenXmlElement markProp in optionalRuns)
                    runProperties221.Append(markProp);
            runProperties221.Append(color201);
            runProperties221.Append(fontSize213);
            runProperties221.Append(fontSizeComplexScript201);
            runProperties221.Append(languages196);
            //Break break8 = new Break();
            Text text129 = new Text();
            text129.Text = sequence + value;
            //"1. - ознакомительный (узнавание ран ее изученных объектов, свойств)"
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            run231.Append(runProperties221);
            run231.Append(text129);

            paragraph127.Append(paragraphProperties127);
            paragraph127.Append(run231);

            return paragraph127;
        }
        /*private List<Paragraph> NumberList(List<string> values)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
                paragraphs.Add(WordParagraph(values[i], i + " "));
            return paragraphs;
        }*/
        public static List<Paragraph> NumberList(List<string> values, char symbol)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                int no = i + 1;
                paragraphs.Add(WordParagraph(values[i], no + "" + symbol + " "));
            }

            return paragraphs;
        }
        public static List<Paragraph> NumberList(List<string> values, char symbol, string marker)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                int no = i + 1;
                paragraphs.Add(WordParagraph(values[i], marker + no + "" + symbol + " "));
            }

            return paragraphs;
        }
        public static List<Paragraph> MarkerList(List<string> values, char symbol)
        {
            return MarkerList(values, symbol + " ");
        }
        public static List<Paragraph> MarkerList(List<string> values, string sequence)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
                paragraphs.Add(WordParagraph(values[i], sequence));
            return paragraphs;
        }
    }
}
