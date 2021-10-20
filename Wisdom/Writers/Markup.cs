using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Diagnostics;
using Wisdom.Model;
using static Wisdom.Model.ProgramContent;

namespace Wisdom.Writers
{
    public static class Markup
    {
        public static Paragraph PageBreak()
        {
            Break pageBreak = new Break() { Type = BreakValues.Page };
            Run runPageBreak = new Run(pageBreak);
            return new Paragraph(runPageBreak);
        }
        public static Run RunPreAdd(string text)
        {
            Run run = new Run() { RsidRunProperties = "00D933D9" };
            Text text1 = new Text();
            text1.Text = text;
            run.Append(text1);
            return run;
        }
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
            Color color187 = new Color() { Val = "000000" };
            FontSize fontSize199 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript187 = new FontSizeComplexScript() { Val = "24" };
            Languages languages182 = new Languages() { Val = "ru" };

            for (byte i = 0; i < elements.Length; i++)
                runProperties217.Append(elements[i]);
            runProperties217.Append(runFonts202);
            runProperties217.Append(color187);
            runProperties217.Append(fontSize199);
            runProperties217.Append(fontSizeComplexScript187);
            runProperties217.Append(languages182);
            Text text125 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text125.Text = text;

            run227.Append(runProperties217);
            run227.Append(text125);
            return run227;
        }
        public static Paragraph ParagraphPreAdd1(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph = new Paragraph() {
                RsidParagraphAddition = "00D933D9",
                RsidParagraphProperties = "00D933D9",
                RsidRunAdditionDefault = "00D933D9"
            };
            return BaseParagraph(paragraph, justify, runs);
        }
        public static Paragraph ParagraphPreAdd2(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph = new Paragraph() {
                RsidParagraphMarkRevision = "00D933D9", RsidParagraphAddition = "00D933D9",
                RsidParagraphProperties = "00D933D9", RsidRunAdditionDefault = "00D933D9"
            };
            return BaseParagraph(paragraph, justify, runs);
        }
        public static Paragraph BaseParagraph(Paragraph paragraph, JustificationValues justify, params Run[] runs) {
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            Justification justification = new Justification() { Val = justify };
            paragraphProperties.Append(justification);
            for (byte i = 0; i < runs.Length; i++)
                paragraph.Append(runs[i]);
            return paragraph;
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
            FontSize fontSize198 = new FontSize() { Val = "24" };
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

            paragraph117.Append(paragraphProperties117);
            for (byte i = 0; i < runs.Length; i++)
                paragraph117.Append(runs[i]);
            return paragraph117;
        }
        private static TableCell CellBase(ushort width)
        {
            TableCell tableCell = new TableCell();
            TableCellProperties tableCellProperties = new TableCellProperties();
            TableCellWidth tableCellWidth = new TableCellWidth()
            { Width = width.ToString(), Type = TableWidthUnitValues.Dxa };
            tableCellProperties.Append(tableCellWidth);
            tableCell.Append(tableCellProperties);
            return tableCell;
        }
        public static TableCell TableCellAdd(Paragraph par, ushort width, OpenXmlElement cellProp)
        {
            TableCell tableCell36 = CellBase(width);
            tableCell36.Append(cellProp);
            tableCell36.Append(par);
            return tableCell36;
        }
        public static TableCell TableCellAdd(Paragraph par, ushort width, params OpenXmlElement[] cellProps)
        {
            TableCell tableCell36 = CellBase(width);
            for (byte i = 0; i < cellProps.Length; i++)
                tableCell36.Append(cellProps[i]);
            tableCell36.Append(par);
            return tableCell36;
        }
        public static TableCell TableCellAdd(Paragraph[] pars, ushort width, params OpenXmlElement[] cellProps)
        {
            TableCell tableCell36 = CellBase(width);
            for (byte i = 0; i < cellProps.Length; i++)
                tableCell36.Append(cellProps[i]);
            for (byte i = 0; i < pars.Length; i++)
                tableCell36.Append(pars[i]);
            return tableCell36;
        }
        public static TableRow TableRowAdd(params TableCell[] cells)
        {
            TableRow tableRow = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };
            for (byte i = 0; i < cells.Length; i++)
                tableRow.Append(cells[i]);
            return tableRow;
        }

        public static List<TableRow> CompetetionsTableRows()
        {
            List<TableRow> rows = new List<TableRow>();
            for (byte i = 0; i < GeneralCompetetions.Count; i++)
                rows.AddRange(CompetetionAdd(GeneralCompetetions[i].Name, GeneralCompetetions[i].Hours, GeneralCompetetions[i].Values));
            for (byte i = 0; i < ProfessionalCompetetions.Count; i++)
                rows.AddRange(CompetetionAdd(ProfessionalCompetetions[i].Name, ProfessionalCompetetions[i].Hours, ProfessionalCompetetions[i].Values));
            return rows;
        }
        public static List<TableRow> CompetetionAdd(string id, string name, List<String2> skills)
        {
            Run idRun = RunAdd(id);
            Run nameRun = RunAdd(name);

            List<TableRow> rows = new List<TableRow>();
            Paragraph idParagraph = ParagraphAdd(JustificationValues.Left, idRun);
            Paragraph nameParagraph = ParagraphAdd(JustificationValues.Left, nameRun);
            List<Paragraph> skillsParagraph = new List<Paragraph>();
            for (byte i = 0; i < skills.Count; i++)
            {
                Run skillsName = RunAdd(skills[i].Name + " ", new Bold());
                Run skillsDescription = RunAdd(skills[i].Value);
                Paragraph skillsParagraphPart = ParagraphAdd(JustificationValues.Left, skillsName, skillsDescription);
                skillsParagraph.Add(skillsParagraphPart);
            }
            TableCell[] cells = TableCellsTemplate3(idParagraph, nameParagraph, skillsParagraph[0], new VerticalMerge { Val = MergedCellValues.Restart }, new VerticalMerge { Val = MergedCellValues.Restart });
            TableRow tableRow = TableRowAdd(cells);
            rows.Add(tableRow);
            for (byte i = 1; i < skillsParagraph.Count; i++)
            {
                TableCell[] cells3 = TableCellsTemplate3(ParagraphAdd(JustificationValues.Left), ParagraphAdd(JustificationValues.Left), skillsParagraph[i], new VerticalMerge(), new VerticalMerge());
                TableRow tableRow2 = TableRowAdd(cells3);
                rows.Add(tableRow2);
            }
            return rows;
        }

        public static List<TableRow> PlanTableRows()
        {
            List<TableRow> rows = new List<TableRow>();
            for (byte i = 0; i < Plan.Count; i++)
            {
                rows.Add(SectionAdd($"Раздел {(i + 1)}. {Plan[i].Name}", Plan[i].Hours));
                for (byte ii = 0; ii < Plan[i].Values.Count; ii++)
                    rows.AddRange(ThemeAdd($"Тема {(i + 1)}.{(ii + 1)}. {Plan[i].Values[ii].Name}",
                        Plan[i].Values[ii].Hours, Plan[i].Values[ii].Competetions, Plan[i].Values[ii].Level, Plan[i].Values[ii].Values));
            }
            return rows;
        }
        public static TableRow SectionAdd(string title, string hours)
        {
            Run sectionRun = RunAdd(title, new Bold());
            Run hoursRun = RunAdd(hours, new Bold());

            Paragraph sectionP = ParagraphAdd(JustificationValues.Left, sectionRun);
            Paragraph desriptionP = ParagraphAdd(JustificationValues.Both);
            Paragraph hoursP = ParagraphAdd(JustificationValues.Center, hoursRun);
            Paragraph competetionsP = ParagraphAdd(JustificationValues.Center);
            Paragraph levelsP = ParagraphAdd(JustificationValues.Center);
            
            sectionP.ParagraphProperties.Append(TableTabs());
            desriptionP.ParagraphProperties.Append(TableTabs());
            hoursP.ParagraphProperties.Append(TableTabs());
            competetionsP.ParagraphProperties.Append(TableTabs());
            levelsP.ParagraphProperties.Append(TableTabs());

            TableCell[] cells = TableCellsTemplate4(sectionP, desriptionP, hoursP, competetionsP, levelsP);
            //TableCell[] cells = TableCellsTemplate1(sectionP, desriptionP, hoursP, levelsP);

            TableRow tableRow = TableRowAdd(cells);
            return tableRow;
        }
        public static List<TableRow> ThemeAdd(string title, string hours,
            string competetions, string level, List<HashList<String2>> data)
        {
            List<TableRow> themeContents = new List<TableRow>();

            Run themeRun1 = RunAdd(title, new Bold());
            Run descriptionRun1 = RunAdd(data[0].Name);
            Run hoursRun1 = RunAdd(hours);
            Run competetionRun1 = RunAdd(competetions);
            Run levelRun1 = RunAdd(level);

            Paragraph sectionP1 = ParagraphAdd(JustificationValues.Center, themeRun1);
            Paragraph desriptionP1 = ParagraphAdd(JustificationValues.Both, descriptionRun1);
            Paragraph hoursP1 = ParagraphAdd(JustificationValues.Center, hoursRun1);
            Paragraph competetionsP1 = ParagraphAdd(JustificationValues.Center, competetionRun1);
            Paragraph levelsP1 = ParagraphAdd(JustificationValues.Center, levelRun1);
            
            sectionP1.ParagraphProperties.Append(TableTabs());
            desriptionP1.ParagraphProperties.Append(TableTabs());
            hoursP1.ParagraphProperties.Append(TableTabs());
            competetionsP1.ParagraphProperties.Append(TableTabs());
            levelsP1.ParagraphProperties.Append(TableTabs());

            TableCell[] cells1 = TableCellsTemplate4(sectionP1, desriptionP1, hoursP1, competetionsP1, levelsP1);
            //TableCell[] cells1 = TableCellsTemplate1(sectionP1, desriptionP1, hoursP1, levelsP1);

            TableRow headerRow = TableRowAdd(cells1);

            themeContents.Add(headerRow);
            themeContents.AddRange(ThemeContentAdd(data[0].Values));

            for (byte i = 1; i < data.Count; i++)
            {
                if (data[i].Values.Count <= 1)
                {
                    themeContents.Add(ThemeContent1(data[i].Name + " "
                        + data[i].Values[0].Name, data[i].Values[0].Value));
                    continue;
                }
                Run descriptionRun = RunAdd(data[i].Name);

                Paragraph sectionP = ParagraphAdd(JustificationValues.Center);
                Paragraph desriptionP = ParagraphAdd(JustificationValues.Both, descriptionRun);
                Paragraph hoursP = ParagraphAdd(JustificationValues.Center);
                Paragraph competetionsP = ParagraphAdd(JustificationValues.Center);
                Paragraph levelsP = ParagraphAdd(JustificationValues.Center);

                sectionP.ParagraphProperties.Append(TableTabs());
                desriptionP.ParagraphProperties.Append(TableTabs());
                hoursP.ParagraphProperties.Append(TableTabs());
                competetionsP.ParagraphProperties.Append(TableTabs());
                levelsP.ParagraphProperties.Append(TableTabs());

                TableCell[] subCells = TableCellsTemplate4(sectionP, desriptionP, hoursP, competetionsP, levelsP);
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
                themeContent.Add(ThemeContent2(ii + 1, rows[ii].Name, rows[ii].Value));
            return themeContent;
        }

        private static TableRow ThemeContent1(string name, string hours)
        {
            Run descriptionRun2 = RunAdd(name);
            Run hoursRun = RunAdd(hours);

            Paragraph sectionP2 = ParagraphAdd(JustificationValues.Center);
            Paragraph desriptionP2 = ParagraphAdd(JustificationValues.Both, descriptionRun2);
            Paragraph hoursP2 = ParagraphAdd(JustificationValues.Center, hoursRun);
            Paragraph competetionsP2 = ParagraphAdd(JustificationValues.Center);
            Paragraph levelsP2 = ParagraphAdd(JustificationValues.Center);

            sectionP2.ParagraphProperties.Append(TableTabs());
            desriptionP2.ParagraphProperties.Append(TableTabs());
            hoursP2.ParagraphProperties.Append(TableTabs());
            competetionsP2.ParagraphProperties.Append(TableTabs());
            levelsP2.ParagraphProperties.Append(TableTabs());

            TableCell[] subCells2 = TableCellsTemplate4(sectionP2, desriptionP2, hoursP2, competetionsP2, levelsP2);

            //TableCell[] subCells2 = TableCellsTemplate1(sectionP2, desriptionP2, hoursP2, levelsP2);

            TableRow valueRow = TableRowAdd(subCells2);
            return valueRow;
        }

        private static TableRow ThemeContent2(int no1, string name, string hours)
        {
            Run no = RunAdd(no1.ToString());
            Run descriptionRun2 = RunAdd(name);
            Run hoursRun = RunAdd(hours);

            Paragraph sectionP2 = ParagraphAdd(JustificationValues.Center);
            Paragraph headerNo = ParagraphAdd(JustificationValues.Center, no);
            Paragraph desriptionP2 = ParagraphAdd(JustificationValues.Both, descriptionRun2);
            Paragraph hoursP2 = ParagraphAdd(JustificationValues.Center, hoursRun);
            Paragraph competetionsP2 = ParagraphAdd(JustificationValues.Center);
            Paragraph levelsP2 = ParagraphAdd(JustificationValues.Center);

            sectionP2.ParagraphProperties.Append(TableTabs());
            headerNo.ParagraphProperties.Append(TableTabs());
            desriptionP2.ParagraphProperties.Append(TableTabs());
            hoursP2.ParagraphProperties.Append(TableTabs());
            competetionsP2.ParagraphProperties.Append(TableTabs());
            levelsP2.ParagraphProperties.Append(TableTabs());

            TableCell[] subCells2 = TableCellsTemplate5(sectionP2,
                headerNo, desriptionP2, hoursP2, competetionsP2, levelsP2);

            TableRow valueRow = TableRowAdd(subCells2);
            return valueRow;
        }

        public static List<Paragraph> Literature()
        {
            List<Paragraph> proccessedSources = new List<Paragraph>();
            Dictionary<string, List<Paragraph>> sources = new
                Dictionary<string, List<Paragraph>>
            {
                { "Основная литература", new List<Paragraph>() },
                { "Дополнительная литература", new List<Paragraph>() },
                { "Программное обеспечение", new List<Paragraph>() },
                { "Базы данных, информационно-справочные и поисковые системы", new List<Paragraph>() },
            };
            for(byte i = 0; i < SourcesControl.Count; i++)
            {
                sources[SourcesControl[i].Name] = NumberList(
                    sources[SourcesControl[i].Name].Count + 1, SourcesControl[i].Values, ". ");
            }
            foreach (KeyValuePair<string, List<Paragraph>> sourceType in sources)
            {
                if (sourceType.Value.Count <= 0)
                    continue;
                Run run = RunAdd(sourceType.Key, new Bold());
                proccessedSources.Add(ParagraphAdd(JustificationValues.Both, run));
                proccessedSources.AddRange(sourceType.Value);
            }
            return proccessedSources;
        }

        private static TableCell[] TableCellsTemplate1(Paragraph p1,
            Paragraph p2, Paragraph p3, Paragraph p4)
        {
            return new TableCell[] {
                TableCellAdd(p1, 2235),
                TableCellAdd(p2, 3969, new GridSpan { Val = 2 }),
                TableCellAdd(p3, 992),
                TableCellAdd(p4, 2551)
            };
        }
        private static TableCell[] TableCellsTemplate2(Paragraph p1,
            Paragraph p2, Paragraph p3, Paragraph p4, Paragraph p5)
        {
            return new TableCell[] {
                TableCellAdd(p1, 2235),
                TableCellAdd(p2, 425),
                TableCellAdd(p3, 3544),
                TableCellAdd(p4, 992),
                TableCellAdd(p5, 2551)
            };
        }
        private static TableCell[] TableCellsTemplate3(Paragraph p1, Paragraph p2,
            Paragraph p3, OpenXmlElement property1, OpenXmlElement property2)
        {
            return new TableCell[] {
                TableCellAdd(p1, 1565, property1),
                TableCellAdd(p2, 3298, property2),
                TableCellAdd(p3, 4482),
            };
        }
        private static TableCell[] TableCellsTemplate4(Paragraph p1,
            Paragraph p2, Paragraph p3, Paragraph p4, Paragraph p5)
        {
            return new TableCell[] {
                TableCellAdd(p1, 2235),
                TableCellAdd(p2, 3969, new GridSpan { Val = 2 }),
                TableCellAdd(p3, 992),
                TableCellAdd(p4, 1559),
                TableCellAdd(p5, 992)
            };
        }
        private static TableCell[] TableCellsTemplate5(Paragraph p1,
            Paragraph p2, Paragraph p3, Paragraph p4, Paragraph p5, Paragraph p6)
        {
            return new TableCell[] {
                TableCellAdd(p1, 2235),
                TableCellAdd(p2, 425),
                TableCellAdd(p3, 3544),
                TableCellAdd(p4, 992),
                TableCellAdd(p5, 1559),
                TableCellAdd(p6, 992)
            };
        }
        public static Tabs TableTabs()
        {
            Tabs tabs114 = new Tabs();
            TabStop tabStop1070 = new TabStop() { Val = TabStopValues.Left, Position = 916 };
            TabStop tabStop1071 = new TabStop() { Val = TabStopValues.Left, Position = 1832 };
            TabStop tabStop1072 = new TabStop() { Val = TabStopValues.Left, Position = 2748 };
            TabStop tabStop1073 = new TabStop() { Val = TabStopValues.Left, Position = 3664 };
            TabStop tabStop1074 = new TabStop() { Val = TabStopValues.Left, Position = 4580 };
            TabStop tabStop1075 = new TabStop() { Val = TabStopValues.Left, Position = 5496 };
            TabStop tabStop1076 = new TabStop() { Val = TabStopValues.Left, Position = 6412 };
            TabStop tabStop1077 = new TabStop() { Val = TabStopValues.Left, Position = 7328 };
            TabStop tabStop1078 = new TabStop() { Val = TabStopValues.Left, Position = 8244 };
            TabStop tabStop1079 = new TabStop() { Val = TabStopValues.Left, Position = 9160 };
            TabStop tabStop1080 = new TabStop() { Val = TabStopValues.Left, Position = 10076 };
            TabStop tabStop1081 = new TabStop() { Val = TabStopValues.Left, Position = 10992 };
            TabStop tabStop1082 = new TabStop() { Val = TabStopValues.Left, Position = 11908 };
            TabStop tabStop1083 = new TabStop() { Val = TabStopValues.Left, Position = 12824 };
            TabStop tabStop1084 = new TabStop() { Val = TabStopValues.Left, Position = 13740 };
            TabStop tabStop1085 = new TabStop() { Val = TabStopValues.Left, Position = 14656 };

            tabs114.Append(tabStop1070);
            tabs114.Append(tabStop1071);
            tabs114.Append(tabStop1072);
            tabs114.Append(tabStop1073);
            tabs114.Append(tabStop1074);
            tabs114.Append(tabStop1075);
            tabs114.Append(tabStop1076);
            tabs114.Append(tabStop1077);
            tabs114.Append(tabStop1078);
            tabs114.Append(tabStop1079);
            tabs114.Append(tabStop1080);
            tabs114.Append(tabStop1081);
            tabs114.Append(tabStop1082);
            tabs114.Append(tabStop1083);
            tabs114.Append(tabStop1084);
            tabs114.Append(tabStop1085);
            return tabs114;
        }

        public static Paragraph WordParagraph(string value, string sequence,
            JustificationValues justification = JustificationValues.Both, params OpenXmlElement[] optionalRuns)
        {
            Run newRun = RunAdd(sequence + value, optionalRuns);
            Paragraph newParagraph = ParagraphAdd(justification, newRun);
            return newParagraph;
        }
        public static List<Paragraph> NumberList(in int start, List<string> values, string sequence)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                int no = i + start;
                paragraphs.Add(WordParagraph(values[i], no + sequence));
            }

            return paragraphs;
        }
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
        public static List<Paragraph> NumberList(List<string> values, string sequence)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                int no = i + 1;
                paragraphs.Add(WordParagraph(values[i], no + sequence));
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
