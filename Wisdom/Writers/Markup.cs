using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;

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
                RsidParagraphMarkRevision = "00D933D9",
                RsidParagraphAddition = "00D933D9",
                RsidParagraphProperties = "00D933D9",
                RsidRunAdditionDefault = "00D933D9"
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



        public static Table CompetetionsTable(DisciplineProgram program)
        {
            string[] columns = { "Код компетенции", "Формулировка компетенции", "Знания, умения, практический опыт" };

            Table table3 = new Table();

            TableProperties tableProperties3 = new TableProperties();
            TableWidth tableWidth3 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableLook tableLook3 = new TableLook() { Val = "04A0" };

            tableProperties3.Append(tableWidth3);
            tableProperties3.Append(tableBorders1);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            GridColumn gridColumn10 = new GridColumn() { Width = "1565" };
            GridColumn gridColumn11 = new GridColumn() { Width = "3298" };
            GridColumn gridColumn12 = new GridColumn() { Width = "4482" };

            tableGrid3.Append(gridColumn10);
            tableGrid3.Append(gridColumn11);
            tableGrid3.Append(gridColumn12);

            TableRow tableRow23 = new TableRow() { RsidTableRowMarkRevision = "00D551C2", RsidTableRowAddition = "00D551C2", RsidTableRowProperties = "00D82FF5" };

            TableCell tableCell67 = new TableCell();

            TableCellProperties tableCellProperties67 = new TableCellProperties();
            TableCellWidth tableCellWidth67 = new TableCellWidth() { Width = "1565", Type = TableWidthUnitValues.Dxa };
            Shading shading67 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties67.Append(tableCellWidth67);
            tableCellProperties67.Append(shading67);

            Paragraph paragraph170 = new Paragraph() { RsidParagraphMarkRevision = "00D551C2", RsidParagraphAddition = "00D551C2", RsidParagraphProperties = "00D551C2", RsidRunAdditionDefault = "00D551C2" };

            ParagraphProperties paragraphProperties161 = new ParagraphProperties();
            KeepNext keepNext2 = new KeepNext();
            Justification justification107 = new Justification() { Val = JustificationValues.Center };
            OutlineLevel outlineLevel2 = new OutlineLevel() { Val = 1 };

            ParagraphMarkRunProperties paragraphMarkRunProperties78 = new ParagraphMarkRunProperties();
            ItalicComplexScript italicComplexScript6 = new ItalicComplexScript();
            Languages languages9 = new Languages() { EastAsia = "x-none" };

            paragraphMarkRunProperties78.Append(italicComplexScript6);
            paragraphMarkRunProperties78.Append(languages9);

            paragraphProperties161.Append(keepNext2);
            paragraphProperties161.Append(justification107);
            paragraphProperties161.Append(outlineLevel2);
            paragraphProperties161.Append(paragraphMarkRunProperties78);

            Run run176 = new Run() { RsidRunProperties = "00D551C2" };

            RunProperties runProperties74 = new RunProperties();
            ItalicComplexScript italicComplexScript7 = new ItalicComplexScript();
            Languages languages10 = new Languages() { EastAsia = "x-none" };

            runProperties74.Append(italicComplexScript7);
            runProperties74.Append(languages10);
            Text text174 = new Text();
            text174.Text = columns[0];

            run176.Append(runProperties74);
            run176.Append(text174);

            paragraph170.Append(paragraphProperties161);
            paragraph170.Append(run176);

            tableCell67.Append(tableCellProperties67);
            tableCell67.Append(paragraph170);

            TableCell tableCell68 = new TableCell();

            TableCellProperties tableCellProperties68 = new TableCellProperties();
            TableCellWidth tableCellWidth68 = new TableCellWidth() { Width = "3363", Type = TableWidthUnitValues.Dxa };
            Shading shading68 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties68.Append(tableCellWidth68);
            tableCellProperties68.Append(shading68);

            Paragraph paragraph171 = new Paragraph() { RsidParagraphMarkRevision = "00D551C2", RsidParagraphAddition = "00D551C2", RsidParagraphProperties = "00D551C2", RsidRunAdditionDefault = "00D551C2" };

            ParagraphProperties paragraphProperties162 = new ParagraphProperties();
            KeepNext keepNext3 = new KeepNext();
            Justification justification108 = new Justification() { Val = JustificationValues.Center };
            OutlineLevel outlineLevel3 = new OutlineLevel() { Val = 1 };

            ParagraphMarkRunProperties paragraphMarkRunProperties79 = new ParagraphMarkRunProperties();
            ItalicComplexScript italicComplexScript8 = new ItalicComplexScript();
            Languages languages11 = new Languages() { EastAsia = "x-none" };

            paragraphMarkRunProperties79.Append(italicComplexScript8);
            paragraphMarkRunProperties79.Append(languages11);

            paragraphProperties162.Append(keepNext3);
            paragraphProperties162.Append(justification108);
            paragraphProperties162.Append(outlineLevel3);
            paragraphProperties162.Append(paragraphMarkRunProperties79);

            Run run177 = new Run() { RsidRunProperties = "00D551C2" };

            RunProperties runProperties75 = new RunProperties();
            ItalicComplexScript italicComplexScript9 = new ItalicComplexScript();
            Languages languages12 = new Languages() { EastAsia = "x-none" };

            runProperties75.Append(italicComplexScript9);
            runProperties75.Append(languages12);
            Text text175 = new Text();
            text175.Text = columns[1];

            run177.Append(runProperties75);
            run177.Append(text175);

            paragraph171.Append(paragraphProperties162);
            paragraph171.Append(run177);

            tableCell68.Append(tableCellProperties68);
            tableCell68.Append(paragraph171);

            TableCell tableCell69 = new TableCell();

            TableCellProperties tableCellProperties69 = new TableCellProperties();
            TableCellWidth tableCellWidth69 = new TableCellWidth() { Width = "4643", Type = TableWidthUnitValues.Dxa };
            Shading shading69 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties69.Append(tableCellWidth69);
            tableCellProperties69.Append(shading69);

            Paragraph paragraph172 = new Paragraph() { RsidParagraphMarkRevision = "00D551C2", RsidParagraphAddition = "00D551C2", RsidParagraphProperties = "00D551C2", RsidRunAdditionDefault = "00D551C2" };

            ParagraphProperties paragraphProperties163 = new ParagraphProperties();
            KeepNext keepNext4 = new KeepNext();
            Justification justification109 = new Justification() { Val = JustificationValues.Center };
            OutlineLevel outlineLevel4 = new OutlineLevel() { Val = 1 };

            ParagraphMarkRunProperties paragraphMarkRunProperties80 = new ParagraphMarkRunProperties();
            ItalicComplexScript italicComplexScript10 = new ItalicComplexScript();
            Languages languages13 = new Languages() { EastAsia = "x-none" };

            paragraphMarkRunProperties80.Append(italicComplexScript10);
            paragraphMarkRunProperties80.Append(languages13);

            paragraphProperties163.Append(keepNext4);
            paragraphProperties163.Append(justification109);
            paragraphProperties163.Append(outlineLevel4);
            paragraphProperties163.Append(paragraphMarkRunProperties80);

            Run run178 = new Run() { RsidRunProperties = "00D551C2" };

            RunProperties runProperties76 = new RunProperties();
            ItalicComplexScript italicComplexScript11 = new ItalicComplexScript();
            Languages languages14 = new Languages() { EastAsia = "x-none" };

            runProperties76.Append(italicComplexScript11);
            runProperties76.Append(languages14);
            Text text176 = new Text();
            text176.Text = columns[2];

            run178.Append(runProperties76);
            run178.Append(text176);

            paragraph172.Append(paragraphProperties163);
            paragraph172.Append(run178);

            tableCell69.Append(tableCellProperties69);
            tableCell69.Append(paragraph172);

            tableRow23.Append(tableCell67);
            tableRow23.Append(tableCell68);
            tableRow23.Append(tableCell69);

            table3.Append(tableProperties3);
            table3.Append(tableGrid3);
            table3.Append(tableRow23);
            table3.Append(CompetetionsTableRows(program));

            return table3;
        }

        public static List<TableRow> CompetetionsTableRows(DisciplineProgram program)
        {
            List<TableRow> rows = new List<TableRow>();
            for (byte i = 0; i < program.GeneralCompetetions.Count; i++)
                rows.AddRange(CompetetionAdd(program.GeneralCompetetions[i].PrefixNo, program.GeneralCompetetions[i].Name, program.GeneralCompetetions[i].Abilities));
            for (byte i = 0; i < program.ProfessionalCompetetions.Count; i++)
            {
                List<Competetion> professionalGroup = program.ProfessionalCompetetions[i];
                for (byte ii = 0; ii < professionalGroup.Count; ii++)
                    rows.AddRange(CompetetionAdd(professionalGroup[i].PrefixNo, professionalGroup[i].Name, professionalGroup[i].Abilities));
            }
                
            return rows;
        }

        public static List<TableRow> CompetetionAdd(string id, string name, List<Task> skills)
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
                Run skillsDescription = RunAdd(skills[i].Hours);
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





        public static Table ThemePlanTable(DisciplineProgram program)
        {
            string[] columns = {
                "Наименование разделов и тем",
                "Содержание учебного материала, лабораторные работы и практические занятия, самостоятельная работа обучающихся, курсовая работа (проект)",
                "Количество часов",
                "Коды компетенций, формированию которых способствует элемент программы",
                "Уровни освоения"
            };

            Table table5 = new Table();

            TableProperties tableProperties5 = new TableProperties();
            TableWidth tableWidth5 = new TableWidth() { Width = "9747", Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders3 = new TableBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder3 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder3 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders3.Append(topBorder3);
            tableBorders3.Append(leftBorder5);
            tableBorders3.Append(bottomBorder3);
            tableBorders3.Append(rightBorder5);
            tableBorders3.Append(insideHorizontalBorder3);
            tableBorders3.Append(insideVerticalBorder3);
            TableLayout tableLayout3 = new TableLayout() { Type = TableLayoutValues.Fixed };
            TableLook tableLook5 = new TableLook() { Val = "04A0" };

            tableProperties5.Append(tableWidth5);
            tableProperties5.Append(tableBorders3);
            tableProperties5.Append(tableLayout3);
            tableProperties5.Append(tableLook5);

            TableGrid tableGrid5 = new TableGrid();
            GridColumn gridColumn15 = new GridColumn() { Width = "2235" };
            GridColumn gridColumn15_1 = new GridColumn() { Width = "425" };
            GridColumn gridColumn16 = new GridColumn() { Width = "3544" };
            GridColumn gridColumn17 = new GridColumn() { Width = "992" };
            GridColumn gridColumn18 = new GridColumn() { Width = "1559" };
            GridColumn gridColumn18_1 = new GridColumn() { Width = "992" };

            tableGrid5.Append(gridColumn15);
            tableGrid5.Append(gridColumn15_1);
            tableGrid5.Append(gridColumn16);
            tableGrid5.Append(gridColumn17);
            tableGrid5.Append(gridColumn18);

            TableRow tableRow43 = new TableRow() { RsidTableRowMarkRevision = "000C238F", RsidTableRowAddition = "00015275", RsidTableRowProperties = "00015275" };

            TableCell tableCell111 = new TableCell();

            TableCellProperties tableCellProperties111 = new TableCellProperties();
            TableCellWidth tableCellWidth111 = new TableCellWidth() { Width = "2235", Type = TableWidthUnitValues.Dxa };
            Shading shading111 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties111.Append(tableCellWidth111);
            tableCellProperties111.Append(shading111);

            Paragraph paragraph233 = new Paragraph() { RsidParagraphMarkRevision = "000C238F", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties224 = new ParagraphProperties();

            Tabs tabs114 = TableTabs();
            Justification justification163 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties126 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript7 = new BoldComplexScript();

            paragraphMarkRunProperties126.Append(boldComplexScript7);

            paragraphProperties224.Append(tabs114);
            paragraphProperties224.Append(justification163);
            paragraphProperties224.Append(paragraphMarkRunProperties126);

            Run run309 = new Run() { RsidRunProperties = "000C238F" };

            RunProperties runProperties161 = new RunProperties();
            BoldComplexScript boldComplexScript8 = new BoldComplexScript();

            runProperties161.Append(boldComplexScript8);
            Text text307 = new Text();
            text307.Text = columns[0];

            run309.Append(runProperties161);
            run309.Append(text307);

            paragraph233.Append(paragraphProperties224);
            paragraph233.Append(run309);

            tableCell111.Append(tableCellProperties111);
            tableCell111.Append(paragraph233);

            TableCell tableCell112 = new TableCell();

            TableCellProperties tableCellProperties112 = new TableCellProperties();
            TableCellWidth tableCellWidth112 = new TableCellWidth() { Width = "3969", Type = TableWidthUnitValues.Dxa };
            Shading shading112 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties112.Append(tableCellWidth112);
            tableCellProperties112.Append(shading112);

            Paragraph paragraph234 = new Paragraph() { RsidParagraphMarkRevision = "000C238F", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties225 = new ParagraphProperties();

            Tabs tabs115 = TableTabs();
            Justification justification164 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties127 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript9 = new BoldComplexScript();

            paragraphMarkRunProperties127.Append(boldComplexScript9);

            paragraphProperties225.Append(tabs115);
            paragraphProperties225.Append(justification164);
            paragraphProperties225.Append(paragraphMarkRunProperties127);

            Run run310 = new Run() { RsidRunProperties = "000C238F" };

            RunProperties runProperties162 = new RunProperties();
            BoldComplexScript boldComplexScript10 = new BoldComplexScript();

            runProperties162.Append(boldComplexScript10);
            Text text308 = new Text();
            text308.Text = columns[1];

            run310.Append(runProperties162);
            run310.Append(text308);

            Run run311 = new Run() { RsidRunProperties = "000C238F" };

            RunProperties runProperties163 = new RunProperties();
            BoldComplexScript boldComplexScript11 = new BoldComplexScript();
            Italic italic73 = new Italic();

            runProperties163.Append(boldComplexScript11);
            runProperties163.Append(italic73);
            Text text309 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text309.Text = " (если предусмотрены)";

            run311.Append(runProperties163);
            run311.Append(text309);

            paragraph234.Append(paragraphProperties225);
            paragraph234.Append(run310);
            paragraph234.Append(run311);

            tableCell112.Append(tableCellProperties112);
            GridSpan span2 = new GridSpan { Val = 2 };
            tableCell112.Append(span2);
            tableCell112.Append(paragraph234);

            TableCell tableCell113 = new TableCell();

            TableCellProperties tableCellProperties113 = new TableCellProperties();
            TableCellWidth tableCellWidth113 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };
            Shading shading113 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties113.Append(tableCellWidth113);
            tableCellProperties113.Append(shading113);

            Paragraph paragraph235 = new Paragraph() { RsidParagraphMarkRevision = "000C238F", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00015275", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties226 = new ParagraphProperties();

            Tabs tabs116 = TableTabs();
            Justification justification165 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties128 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript12 = new BoldComplexScript();

            paragraphMarkRunProperties128.Append(boldComplexScript12);

            paragraphProperties226.Append(tabs116);
            paragraphProperties226.Append(justification165);
            paragraphProperties226.Append(paragraphMarkRunProperties128);

            Run run312 = new Run();

            RunProperties runProperties164 = new RunProperties();
            BoldComplexScript boldComplexScript13 = new BoldComplexScript();

            runProperties164.Append(boldComplexScript13);
            Text text310 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text310.Text = columns[2];

            run312.Append(runProperties164);
            run312.Append(text310);

            paragraph235.Append(paragraphProperties226);
            paragraph235.Append(run312);

            tableCell113.Append(tableCellProperties113);
            tableCell113.Append(paragraph235);

            TableCell tableCell114 = new TableCell();

            TableCellProperties tableCellProperties114 = new TableCellProperties();
            TableCellWidth tableCellWidth114 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            tableCellProperties114.Append(tableCellWidth114);

            Paragraph paragraph236 = new Paragraph() { RsidParagraphMarkRevision = "00015275", RsidParagraphAddition = "0026510F", RsidParagraphProperties = "0026510F", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties227 = new ParagraphProperties();

            Tabs tabs117 = TableTabs();
            Justification justification166 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties129 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript15 = new BoldComplexScript();

            paragraphMarkRunProperties129.Append(boldComplexScript15);

            paragraphProperties227.Append(tabs117);
            paragraphProperties227.Append(justification166);
            paragraphProperties227.Append(paragraphMarkRunProperties129);

            Run run314 = new Run() { RsidRunProperties = "00015275" };

            RunProperties runProperties166 = new RunProperties();
            BoldComplexScript boldComplexScript16 = new BoldComplexScript();

            runProperties166.Append(boldComplexScript16);
            Text text312 = new Text();
            text312.Text = columns[3];

            run314.Append(runProperties166);
            run314.Append(text312);

            paragraph236.Append(paragraphProperties227);
            paragraph236.Append(run314);

            Paragraph paragraph237 = new Paragraph() { RsidParagraphMarkRevision = "00015275", RsidParagraphAddition = "00F352B2", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00F352B2" };

            ParagraphProperties paragraphProperties228 = new ParagraphProperties();

            Tabs tabs118 = TableTabs();
            Justification justification167 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties130 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript17 = new BoldComplexScript();

            paragraphMarkRunProperties130.Append(boldComplexScript17);

            paragraphProperties228.Append(tabs118);
            paragraphProperties228.Append(justification167);
            paragraphProperties228.Append(paragraphMarkRunProperties130);

            paragraph237.Append(paragraphProperties228);

            tableCell114.Append(tableCellProperties114);
            tableCell114.Append(paragraph236);
            tableCell114.Append(paragraph237);

            TableCell tableCell114_1 = new TableCell();

            TableCellProperties tableCellProperties114_1 = new TableCellProperties();
            TableCellWidth tableCellWidth114_1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties114_1.Append(tableCellWidth114_1);

            Paragraph paragraph236_1 = new Paragraph() { RsidParagraphMarkRevision = "00015275", RsidParagraphAddition = "0026510F", RsidParagraphProperties = "0026510F", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties227_1 = new ParagraphProperties();

            Justification justification166_1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties129_1 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript15_1 = new BoldComplexScript();

            paragraphMarkRunProperties129_1.Append(boldComplexScript15_1);

            paragraphProperties227_1.Append(TableTabs());
            paragraphProperties227_1.Append(justification166_1);
            paragraphProperties227_1.Append(paragraphMarkRunProperties129_1);

            Run run314_1 = new Run() { RsidRunProperties = "00015275" };

            RunProperties runProperties166_1 = new RunProperties();
            BoldComplexScript boldComplexScript16_1 = new BoldComplexScript();

            runProperties166_1.Append(boldComplexScript16_1);
            Text text312_1 = new Text();
            text312_1.Text = "Уровни освоения";

            run314_1.Append(runProperties166_1);
            run314_1.Append(text312_1);

            paragraph236_1.Append(paragraphProperties227_1);
            paragraph236_1.Append(run314_1);

            tableCell114_1.Append(tableCellProperties114_1);
            tableCell114_1.Append(paragraph236_1);

            tableRow43.Append(tableCell111);
            tableRow43.Append(tableCell112);
            tableRow43.Append(tableCell113);
            tableRow43.Append(tableCell114);
            tableRow43.Append(tableCell114_1);

            TableRow tableRow44 = new TableRow() { RsidTableRowAddition = "00015275", RsidTableRowProperties = "00015275" };

            TableCell tableCell115 = new TableCell();

            TableCellProperties tableCellProperties115 = new TableCellProperties();
            TableCellWidth tableCellWidth115 = new TableCellWidth() { Width = "2235", Type = TableWidthUnitValues.Dxa };
            Shading shading114 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties115.Append(tableCellWidth115);
            tableCellProperties115.Append(shading114);

            Paragraph paragraph238 = new Paragraph() { RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties229 = new ParagraphProperties();

            Tabs tabs119 = TableTabs();
            Justification justification168 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties229.Append(tabs119);
            paragraphProperties229.Append(justification168);

            Run run315 = new Run();
            Text text313 = new Text();
            text313.Text = "1";

            run315.Append(text313);

            paragraph238.Append(paragraphProperties229);
            paragraph238.Append(run315);

            tableCell115.Append(tableCellProperties115);
            tableCell115.Append(paragraph238);

            TableCell tableCell116 = new TableCell();

            TableCellProperties tableCellProperties116 = new TableCellProperties();
            TableCellWidth tableCellWidth116 = new TableCellWidth() { Width = "3969", Type = TableWidthUnitValues.Dxa };
            Shading shading115 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties116.Append(tableCellWidth116);
            tableCellProperties116.Append(shading115);

            Paragraph paragraph239 = new Paragraph() { RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties230 = new ParagraphProperties();

            Tabs tabs120 = TableTabs();
            Justification justification169 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties230.Append(tabs120);
            paragraphProperties230.Append(justification169);

            Run run316 = new Run();
            Text text314 = new Text();
            text314.Text = "2";

            run316.Append(text314);

            paragraph239.Append(paragraphProperties230);
            paragraph239.Append(run316);

            tableCell116.Append(tableCellProperties116);
            GridSpan span6 = new GridSpan { Val = 2 };
            tableCell116.Append(span6);
            tableCell116.Append(paragraph239);

            TableCell tableCell117 = new TableCell();

            TableCellProperties tableCellProperties117 = new TableCellProperties();
            TableCellWidth tableCellWidth117 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };
            Shading shading116 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties117.Append(tableCellWidth117);
            tableCellProperties117.Append(shading116);

            Paragraph paragraph240 = new Paragraph() { RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties231 = new ParagraphProperties();

            Tabs tabs121 = TableTabs();
            Justification justification170 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties231.Append(tabs121);
            paragraphProperties231.Append(justification170);

            Run run317 = new Run();
            Text text315 = new Text();
            text315.Text = "3";

            run317.Append(text315);

            paragraph240.Append(paragraphProperties231);
            paragraph240.Append(run317);

            tableCell117.Append(tableCellProperties117);
            tableCell117.Append(paragraph240);

            TableCell tableCell118 = new TableCell();

            TableCellProperties tableCellProperties118 = new TableCellProperties();
            TableCellWidth tableCellWidth118 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            tableCellProperties118.Append(tableCellWidth118);

            Paragraph paragraph241 = new Paragraph() { RsidParagraphMarkRevision = "0076108B", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "0076108B" };

            ParagraphProperties paragraphProperties232 = new ParagraphProperties();

            Tabs tabs122 = TableTabs();
            Justification justification171 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties131 = new ParagraphMarkRunProperties();
            Languages languages56 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties131.Append(languages56);

            paragraphProperties232.Append(tabs122);
            paragraphProperties232.Append(justification171);
            paragraphProperties232.Append(paragraphMarkRunProperties131);

            Run run318 = new Run();

            RunProperties runProperties167 = new RunProperties();
            Languages languages57 = new Languages() { Val = "en-US" };

            runProperties167.Append(languages57);
            Text text316 = new Text();
            text316.Text = "4";

            run318.Append(runProperties167);
            run318.Append(text316);

            paragraph241.Append(paragraphProperties232);
            paragraph241.Append(run318);

            tableCell118.Append(tableCellProperties118);
            tableCell118.Append(paragraph241);

            TableCell tableCell118_1 = new TableCell();

            TableCellProperties tableCellProperties118_1 = new TableCellProperties();
            TableCellWidth tableCellWidth118_1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties118_1.Append(tableCellWidth118_1);

            Paragraph paragraph241_1 = new Paragraph() { RsidParagraphMarkRevision = "0076108B", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "0076108B" };

            ParagraphProperties paragraphProperties232_1 = new ParagraphProperties();

            Justification justification171_1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties131_1 = new ParagraphMarkRunProperties();
            Languages languages56_1 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties131_1.Append(languages56_1);

            paragraphProperties232_1.Append(TableTabs());
            paragraphProperties232_1.Append(justification171_1);
            paragraphProperties232_1.Append(paragraphMarkRunProperties131_1);

            Run run318_1 = new Run();

            RunProperties runProperties167_1 = new RunProperties();
            Languages languages57_1 = new Languages() { Val = "en-US" };

            runProperties167_1.Append(languages57_1);
            Text text316_1 = new Text();
            text316_1.Text = "5";

            run318_1.Append(runProperties167_1);
            run318_1.Append(text316_1);

            paragraph241_1.Append(paragraphProperties232_1);
            paragraph241_1.Append(run318_1);

            tableCell118_1.Append(tableCellProperties118_1);
            tableCell118_1.Append(paragraph241_1);

            tableRow44.Append(tableCell115);
            tableRow44.Append(tableCell116);
            tableRow44.Append(tableCell117);
            tableRow44.Append(tableCell118);
            tableRow44.Append(tableCell118_1);

            TableRow tableRow68 = new TableRow() { RsidTableRowAddition = "00015275", RsidTableRowProperties = "00015275" };

            TableCell tableCell211 = new TableCell();

            TableCellProperties tableCellProperties211 = new TableCellProperties();
            TableCellWidth tableCellWidth211 = new TableCellWidth() { Width = "6204", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan14 = new GridSpan() { Val = 2 };
            Shading shading186 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties211.Append(tableCellWidth211);
            tableCellProperties211.Append(gridSpan14);
            tableCellProperties211.Append(shading186);

            Paragraph paragraph334 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties325 = new ParagraphProperties();

            Tabs tabs215 = TableTabs();

            ParagraphMarkRunProperties paragraphMarkRunProperties202 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript144 = new BoldComplexScript();

            paragraphMarkRunProperties202.Append(boldComplexScript144);

            paragraphProperties325.Append(tabs215);
            paragraphProperties325.Append(paragraphMarkRunProperties202);

            Run run381 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties227 = new RunProperties();
            BoldComplexScript boldComplexScript145 = new BoldComplexScript();

            runProperties227.Append(boldComplexScript145);
            LastRenderedPageBreak lastRenderedPageBreak6 = new LastRenderedPageBreak();
            Text text379 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text379.Text = "Примерная тематика курсовой работы (проекта) ";

            run381.Append(runProperties227);
            run381.Append(lastRenderedPageBreak6);
            run381.Append(text379);

            Run run382 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties228 = new RunProperties();
            BoldComplexScript boldComplexScript146 = new BoldComplexScript();
            Italic italic148 = new Italic();

            runProperties228.Append(boldComplexScript146);
            runProperties228.Append(italic148);
            Text text380 = new Text();
            text380.Text = "(если предусмотрены)";

            run382.Append(runProperties228);
            run382.Append(text380);

            paragraph334.Append(paragraphProperties325);
            paragraph334.Append(run381);
            paragraph334.Append(run382);

            tableCell211.Append(tableCellProperties211);
            GridSpan span1 = new GridSpan { Val = 3 };
            tableCell211.Append(span1);
            tableCell211.Append(paragraph334);

            TableCell tableCell212 = new TableCell();

            TableCellProperties tableCellProperties212 = new TableCellProperties();
            TableCellWidth tableCellWidth212 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };
            Shading shading187 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties212.Append(tableCellWidth212);
            tableCellProperties212.Append(shading187);

            Paragraph paragraph335 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties326 = new ParagraphProperties();

            Tabs tabs216 = TableTabs();
            Justification justification223 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties203 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript147 = new BoldComplexScript();
            Italic italic149 = new Italic();

            paragraphMarkRunProperties203.Append(boldComplexScript147);
            paragraphMarkRunProperties203.Append(italic149);

            paragraphProperties326.Append(tabs216);
            paragraphProperties326.Append(justification223);
            paragraphProperties326.Append(paragraphMarkRunProperties203);

            Run run383 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties229 = new RunProperties();
            BoldComplexScript boldComplexScript148 = new BoldComplexScript();
            Italic italic150 = new Italic();

            runProperties229.Append(boldComplexScript148);
            runProperties229.Append(italic150);
            Text text381 = new Text();
            text381.Text = "*";

            run383.Append(runProperties229);
            run383.Append(text381);

            paragraph335.Append(paragraphProperties326);
            paragraph335.Append(run383);

            tableCell212.Append(tableCellProperties212);
            tableCell212.Append(paragraph335);

            TableCell tableCell213 = new TableCell();

            TableCellProperties tableCellProperties213 = new TableCellProperties();
            TableCellWidth tableCellWidth213 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            tableCellProperties213.Append(tableCellWidth213);

            Paragraph paragraph336 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties327 = new ParagraphProperties();

            Tabs tabs217 = TableTabs();
            Justification justification224 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties204 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript149 = new BoldComplexScript();
            Italic italic151 = new Italic();

            paragraphMarkRunProperties204.Append(boldComplexScript149);
            paragraphMarkRunProperties204.Append(italic151);

            paragraphProperties327.Append(tabs217);
            paragraphProperties327.Append(justification224);
            paragraphProperties327.Append(paragraphMarkRunProperties204);

            paragraph336.Append(paragraphProperties327);

            tableCell213.Append(tableCellProperties213);
            tableCell213.Append(paragraph336);

            TableCell tableCell213_1 = new TableCell();

            TableCellProperties tableCellProperties213_1 = new TableCellProperties();
            TableCellWidth tableCellWidth213_1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties213_1.Append(tableCellWidth213_1);

            Paragraph paragraph336_1 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties327_1 = new ParagraphProperties();

            Tabs tabs217_1 = new Tabs();
            Justification justification224_1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties204_1 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript149_1 = new BoldComplexScript();
            Italic italic151_1 = new Italic();

            paragraphMarkRunProperties204_1.Append(boldComplexScript149_1);
            paragraphMarkRunProperties204_1.Append(italic151_1);

            paragraphProperties327_1.Append(TableTabs());
            paragraphProperties327_1.Append(justification224_1);
            paragraphProperties327_1.Append(paragraphMarkRunProperties204_1);

            paragraph336_1.Append(paragraphProperties327_1);

            tableCell213_1.Append(tableCellProperties213_1);
            tableCell213_1.Append(paragraph336_1);

            tableRow68.Append(tableCell211);
            tableRow68.Append(tableCell212);
            tableRow68.Append(tableCell213);
            tableRow68.Append(tableCell213_1);

            TableRow tableRow69 = new TableRow() { RsidTableRowAddition = "00015275", RsidTableRowProperties = "00015275" };

            TableCell tableCell214 = new TableCell();

            TableCellProperties tableCellProperties214 = new TableCellProperties();
            TableCellWidth tableCellWidth214 = new TableCellWidth() { Width = "6204", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan15 = new GridSpan() { Val = 2 };
            Shading shading188 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties214.Append(tableCellWidth214);
            tableCellProperties214.Append(gridSpan15);
            tableCellProperties214.Append(shading188);

            Paragraph paragraph337 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties328 = new ParagraphProperties();

            Tabs tabs218 = TableTabs();

            ParagraphMarkRunProperties paragraphMarkRunProperties205 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript150 = new BoldComplexScript();

            paragraphMarkRunProperties205.Append(boldComplexScript150);

            paragraphProperties328.Append(tabs218);
            paragraphProperties328.Append(paragraphMarkRunProperties205);

            Run run384 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties230 = new RunProperties();
            BoldComplexScript boldComplexScript151 = new BoldComplexScript();

            runProperties230.Append(boldComplexScript151);
            Text text382 = new Text();
            text382.Text = "Самостоятельная работа обучающихся над курсовой работой (проектом)";

            run384.Append(runProperties230);
            run384.Append(text382);

            Run run385 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties231 = new RunProperties();
            BoldComplexScript boldComplexScript152 = new BoldComplexScript();
            Italic italic152 = new Italic();

            runProperties231.Append(boldComplexScript152);
            runProperties231.Append(italic152);
            Text text383 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text383.Text = " (если предусмотрены)";

            run385.Append(runProperties231);
            run385.Append(text383);

            paragraph337.Append(paragraphProperties328);
            paragraph337.Append(run384);
            paragraph337.Append(run385);

            tableCell214.Append(tableCellProperties214);
            GridSpan span5 = new GridSpan { Val = 3 };
            tableCell214.Append(span5);
            tableCell214.Append(paragraph337);

            TableCell tableCell215 = new TableCell();

            TableCellProperties tableCellProperties215 = new TableCellProperties();
            TableCellWidth tableCellWidth215 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };
            Shading shading189 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties215.Append(tableCellWidth215);
            tableCellProperties215.Append(shading189);

            Paragraph paragraph338 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties329 = new ParagraphProperties();

            Tabs tabs219 = TableTabs();
            Justification justification225 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties206 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript153 = new BoldComplexScript();
            Italic italic153 = new Italic();

            paragraphMarkRunProperties206.Append(boldComplexScript153);
            paragraphMarkRunProperties206.Append(italic153);

            paragraphProperties329.Append(tabs219);
            paragraphProperties329.Append(justification225);
            paragraphProperties329.Append(paragraphMarkRunProperties206);

            Run run386 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties232 = new RunProperties();
            BoldComplexScript boldComplexScript154 = new BoldComplexScript();
            Italic italic154 = new Italic();

            runProperties232.Append(boldComplexScript154);
            runProperties232.Append(italic154);
            Text text384 = new Text();
            text384.Text = "*";

            run386.Append(runProperties232);
            run386.Append(text384);

            paragraph338.Append(paragraphProperties329);
            paragraph338.Append(run386);

            tableCell215.Append(tableCellProperties215);
            tableCell215.Append(paragraph338);

            TableCell tableCell216 = new TableCell();

            TableCellProperties tableCellProperties216 = new TableCellProperties();
            TableCellWidth tableCellWidth216 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            tableCellProperties216.Append(tableCellWidth216);

            Paragraph paragraph339 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties330 = new ParagraphProperties();

            Tabs tabs220 = TableTabs();
            Justification justification226 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties207 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript155 = new BoldComplexScript();
            Italic italic155 = new Italic();

            paragraphMarkRunProperties207.Append(boldComplexScript155);
            paragraphMarkRunProperties207.Append(italic155);

            paragraphProperties330.Append(tabs220);
            paragraphProperties330.Append(justification226);
            paragraphProperties330.Append(paragraphMarkRunProperties207);

            paragraph339.Append(paragraphProperties330);

            tableCell216.Append(tableCellProperties216);
            tableCell216.Append(paragraph339);

            TableCell tableCell216_1 = new TableCell();

            TableCellProperties tableCellProperties216_1 = new TableCellProperties();
            TableCellWidth tableCellWidth216_1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties216_1.Append(tableCellWidth216_1);

            Paragraph paragraph339_1 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties330_1 = new ParagraphProperties();

            Justification justification226_1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties207_1 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript155_1 = new BoldComplexScript();
            Italic italic155_1 = new Italic();

            paragraphMarkRunProperties207_1.Append(boldComplexScript155_1);
            paragraphMarkRunProperties207_1.Append(italic155_1);

            paragraphProperties330_1.Append(TableTabs());
            paragraphProperties330_1.Append(justification226_1);
            paragraphProperties330_1.Append(paragraphMarkRunProperties207_1);

            paragraph339_1.Append(paragraphProperties330_1);

            tableCell216_1.Append(tableCellProperties216_1);
            tableCell216_1.Append(paragraph339_1);

            tableRow69.Append(tableCell214);
            tableRow69.Append(tableCell215);
            tableRow69.Append(tableCell216);
            tableRow69.Append(tableCell216_1);

            TableRow tableRow70 = new TableRow() { RsidTableRowAddition = "00015275", RsidTableRowProperties = "00015275" };

            TableCell tableCell217 = new TableCell();

            TableCellProperties tableCellProperties217 = new TableCellProperties();
            TableCellWidth tableCellWidth217 = new TableCellWidth() { Width = "6204", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan16 = new GridSpan() { Val = 2 };
            Shading shading190 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties217.Append(tableCellWidth217);
            tableCellProperties217.Append(gridSpan16);
            tableCellProperties217.Append(shading190);

            Paragraph paragraph340 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties331 = new ParagraphProperties();

            Tabs tabs221 = TableTabs();
            Justification justification227 = new Justification() { Val = JustificationValues.Right };

            ParagraphMarkRunProperties paragraphMarkRunProperties208 = new ParagraphMarkRunProperties();
            Bold bold144 = new Bold();
            BoldComplexScript boldComplexScript156 = new BoldComplexScript();

            paragraphMarkRunProperties208.Append(bold144);
            paragraphMarkRunProperties208.Append(boldComplexScript156);

            paragraphProperties331.Append(tabs221);
            paragraphProperties331.Append(justification227);
            paragraphProperties331.Append(paragraphMarkRunProperties208);

            Run run387 = new Run() { RsidRunProperties = "00C32A4C" };

            RunProperties runProperties233 = new RunProperties();
            Bold bold145 = new Bold();
            BoldComplexScript boldComplexScript157 = new BoldComplexScript();

            runProperties233.Append(bold145);
            runProperties233.Append(boldComplexScript157);
            Text text385 = new Text();
            text385.Text = "Всего:";

            run387.Append(runProperties233);
            run387.Append(text385);

            paragraph340.Append(paragraphProperties331);
            paragraph340.Append(run387);

            tableCell217.Append(tableCellProperties217);
            GridSpan span4 = new GridSpan { Val = 3 };
            tableCell217.Append(span4);
            tableCell217.Append(paragraph340);

            TableCell tableCell218 = new TableCell();

            TableCellProperties tableCellProperties218 = new TableCellProperties();
            TableCellWidth tableCellWidth218 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };
            Shading shading191 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties218.Append(tableCellWidth218);
            tableCellProperties218.Append(shading191);

            Paragraph paragraph341 = new Paragraph() { RsidParagraphMarkRevision = "00933EE4", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00933EE4", RsidRunAdditionDefault = "00933EE4" };

            ParagraphProperties paragraphProperties332 = new ParagraphProperties();

            Tabs tabs222 = TableTabs();
            Justification justification228 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties209 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript158 = new BoldComplexScript();
            Italic italic156 = new Italic();
            FontSize fontSize41 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "20" };
            Languages languages64 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties209.Append(boldComplexScript158);
            paragraphMarkRunProperties209.Append(italic156);
            paragraphMarkRunProperties209.Append(fontSize41);
            paragraphMarkRunProperties209.Append(fontSizeComplexScript39);
            paragraphMarkRunProperties209.Append(languages64);

            paragraphProperties332.Append(tabs222);
            paragraphProperties332.Append(justification228);
            paragraphProperties332.Append(paragraphMarkRunProperties209);

            Run run388 = new Run();

            RunProperties runProperties234 = new RunProperties();
            BoldComplexScript boldComplexScript159 = new BoldComplexScript();
            Italic italic157 = new Italic();
            FontSize fontSize42 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "20" };
            Languages languages65 = new Languages() { Val = "en-US" };

            runProperties234.Append(boldComplexScript159);
            runProperties234.Append(italic157);
            runProperties234.Append(fontSize42);
            runProperties234.Append(fontSizeComplexScript40);
            runProperties234.Append(languages65);
            Text text386 = new Text();
            text386.Text = program.MaxHours;

            run388.Append(runProperties234);
            run388.Append(text386);

            paragraph341.Append(paragraphProperties332);
            paragraph341.Append(run388);

            tableCell218.Append(tableCellProperties218);
            tableCell218.Append(paragraph341);

            TableCell tableCell219 = new TableCell();

            TableCellProperties tableCellProperties219 = new TableCellProperties();
            TableCellWidth tableCellWidth219 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            tableCellProperties219.Append(tableCellWidth219);

            Paragraph paragraph342 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties333 = new ParagraphProperties();

            Tabs tabs223 = TableTabs();
            Justification justification229 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties210 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript160 = new BoldComplexScript();
            Italic italic158 = new Italic();
            FontSize fontSize43 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties210.Append(boldComplexScript160);
            paragraphMarkRunProperties210.Append(italic158);
            paragraphMarkRunProperties210.Append(fontSize43);
            paragraphMarkRunProperties210.Append(fontSizeComplexScript41);

            paragraphProperties333.Append(tabs223);
            paragraphProperties333.Append(justification229);
            paragraphProperties333.Append(paragraphMarkRunProperties210);

            paragraph342.Append(paragraphProperties333);

            tableCell219.Append(tableCellProperties219);
            tableCell219.Append(paragraph342);

            TableCell tableCell219_1 = new TableCell();

            TableCellProperties tableCellProperties219_1 = new TableCellProperties();
            TableCellWidth tableCellWidth219_1 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties219_1.Append(tableCellWidth219_1);

            Paragraph paragraph342_1 = new Paragraph() { RsidParagraphMarkRevision = "00C32A4C", RsidParagraphAddition = "00015275", RsidParagraphProperties = "00C32A4C", RsidRunAdditionDefault = "00015275" };

            ParagraphProperties paragraphProperties333_1 = new ParagraphProperties();
            Justification justification229_1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties210_1 = new ParagraphMarkRunProperties();
            BoldComplexScript boldComplexScript160_1 = new BoldComplexScript();
            Italic italic158_1 = new Italic();
            FontSize fontSize43_1 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript41_1 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties210_1.Append(boldComplexScript160_1);
            paragraphMarkRunProperties210_1.Append(italic158_1);
            paragraphMarkRunProperties210_1.Append(fontSize43_1);
            paragraphMarkRunProperties210_1.Append(fontSizeComplexScript41_1);

            paragraphProperties333_1.Append(TableTabs());
            paragraphProperties333_1.Append(justification229_1);
            paragraphProperties333_1.Append(paragraphMarkRunProperties210_1);

            paragraph342_1.Append(paragraphProperties333_1);

            tableCell219_1.Append(tableCellProperties219_1);
            tableCell219_1.Append(paragraph342_1);

            tableRow70.Append(tableCell217);
            tableRow70.Append(tableCell218);
            tableRow70.Append(tableCell219);
            tableRow70.Append(tableCell219_1);

            table5.Append(tableProperties5);
            table5.Append(tableGrid5);
            table5.Append(tableRow43);
            table5.Append(tableRow44);
            table5.Append(PlanTableRows(program));
            table5.Append(tableRow68);
            table5.Append(tableRow69);
            table5.Append(tableRow70);

            return table5;
        }

        public static List<TableRow> PlanTableRows(DisciplineProgram program)
        {
            List<TableRow> rows = new List<TableRow>();
            for (byte i = 0; i < program.Plan.Count; i++)
            {
                Topic topic = program.Plan[i];
                rows.Add(SectionAdd($"Раздел {i + 1}. {topic.Name}", topic.Hours));
                for (byte ii = 0; ii < topic.Themes.Count; ii++)
                {
                    Theme theme = program.Plan[i].Themes[ii];
                    rows.AddRange(ThemeAdd($"Тема {i + 1}.{ii + 1}. {theme.Name}",
                        theme.Hours, theme.Competetions, theme.Level, theme.Works));
                }
                    
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
            string competetions, string level, List<Work> data)
        {
            List<TableRow> themeContents = new List<TableRow>();

            Run themeRun1 = RunAdd(title, new Bold());
            Run descriptionRun1 = RunAdd(data[0].Type);
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
            themeContents.AddRange(ThemeContentAdd(data[0].Tasks));

            for (byte i = 1; i < data.Count; i++)
            {
                Work work = data[i];
                if (work.Tasks.Count <= 1)
                {
                    themeContents.Add(ThemeContent1(work.Type + " "
                        + work.Tasks[0].Name, work.Tasks[0].Hours));
                    continue;
                }
                Run descriptionRun = RunAdd(work.Type);

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
                themeContents.AddRange(ThemeContentAdd(work.Tasks));
            }

            return themeContents;
        }
        
        private static List<TableRow> ThemeContentAdd(List<Task> rows)
        {
            List<TableRow> themeContent = new List<TableRow>();
            for (byte ii = 0; ii < rows.Count; ii++)
                themeContent.Add(ThemeContent2(ii + 1, rows[ii].Name, rows[ii].Hours));
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

        public static List<Paragraph> Literature(List<Task> sources)
        {
            //DisciplineProgram program

            List<Paragraph> proccessedSources = new List<Paragraph>();
            //Dictionary<string, List<Paragraph>> sources = new
            //    Dictionary<string, List<Paragraph>>
            //{
            //    { "Основная литература", new List<Paragraph>() },
            //    { "Дополнительная литература", new List<Paragraph>() },
            //    { "Программное обеспечение", new List<Paragraph>() },
            //    { "Базы данных, информационно-справочные и поисковые системы", new List<Paragraph>() },
            //};
            for(byte i = 0; i < sources.Count; i++)
            {
                #warning ATTENTION!!! THIS MUST BE REPAIRED
                Task source = sources[i];
                //List<Paragraph> paragraphs = NumberList(
                //    sources.Count + 1, source.Value, ". ");

                Run run = RunAdd(source.Name, new Bold());
                proccessedSources.Add(ParagraphAdd(JustificationValues.Both, run));
                //proccessedSources.AddRange(paragraphs);
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
