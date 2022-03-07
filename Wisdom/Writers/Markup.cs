using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using Wisdom.Model.Documents;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;
using Wisdom.Model;
using Wisdom.Customing;
using System;

namespace Wisdom.Writers
{
    public static class Markup
    {
        public static Paragraph PageBreak()
        {
            Break pageBreak = new Break()
            {
                Type = BreakValues.Page
            };
            Run runPageBreak = new Run(pageBreak);
            return new Paragraph(runPageBreak);
        }

        public static Run RunPreAdd(string text)
        {
            Run run = new Run()
            {
                RsidRunProperties = "00D933D9"
            };

            Text chunk = new Text
            {
                Text = text
            };
            run.Append(chunk);
            return run;
        }

        public static void SetTextProperties(this OpenXmlCompositeElement properties)
        {
            //RunProperties runProperties = new RunProperties();

            RunFonts runFonts = new RunFonts()
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman",
                EastAsia = "Times New Roman",
                ComplexScript = "Times New Roman"
            };

            Color color = new
                Color()
            {
                Val = "000000"
            };

            FontSize
                fontSize = new
                FontSize()
                {
                    Val = "24"
                };

            FontSizeComplexScript
                fontSizeComplexScript = new
                FontSizeComplexScript()
                {
                    Val = "24"
                };

            Languages
                languages = new
                Languages()
                {
                    Val = "ru"
                };

            properties.Append(runFonts);
            properties.Append(color);
            properties.Append(fontSize);
            properties.Append(fontSizeComplexScript);
            properties.Append(languages);
        }

        public static void SetBorders(this TableBorders borders)
        {
            //(UInt32Value)

            TopBorder
                topBorder = new
                TopBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = 4U,
                    Space = 0U
                };

            LeftBorder
                leftBorder = new
                LeftBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = (UInt32Value)4U,
                    Space = (UInt32Value)0U
                };

            BottomBorder
                bottomBorder = new
                BottomBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = (UInt32Value)4U,
                    Space = (UInt32Value)0U
                };

            RightBorder
                rightBorder = new
                RightBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = (UInt32Value)4U,
                    Space = (UInt32Value)0U
                };

            InsideHorizontalBorder
                insideHorizontalBorder = new
                InsideHorizontalBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = (UInt32Value)4U,
                    Space = (UInt32Value)0U
                };

            InsideVerticalBorder
                insideVerticalBorder = new
                InsideVerticalBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = (UInt32Value)4U,
                    Space = (UInt32Value)0U
                };

            borders.Append(topBorder);
            borders.Append(leftBorder);
            borders.Append(bottomBorder);
            borders.Append(rightBorder);
            borders.Append(insideHorizontalBorder);
            borders.Append(insideVerticalBorder);
        }

        public static Run RunAdd(string text, params OpenXmlElement[] elements)
        {
            Run run227 = new Run();

            RunProperties runProperties217 = new RunProperties();
            runProperties217.SetTextProperties();

            // SetRunProperties();

            for (byte i = 0; i < elements.Length; i++)
            {
                runProperties217.Append(elements[i]);
            }

            Text text125 = new Text()
            {
                Space = SpaceProcessingModeValues.Preserve
            };
            text125.Text = text;

            run227.Append(runProperties217);
            run227.Append(text125);
            return run227;
        }

        public static Run RunPreset(string rsid)
        {
            return new Run()
            {
                RsidRunProperties = rsid
            };
        }

        public static Paragraph ParagraphPreset(string rsid)
        {
            return new Paragraph()
            {
                RsidParagraphMarkRevision = rsid,
                RsidParagraphAddition = rsid,
                RsidParagraphProperties = rsid,
                RsidRunAdditionDefault = rsid
            };
        }

        public static Paragraph ParagraphPreset
            (string revision, string addition,
            string properties, string runAdd)
        {
            return new Paragraph()
            {
                RsidParagraphMarkRevision = revision,
                RsidParagraphAddition = addition,
                RsidParagraphProperties = properties,
                RsidRunAdditionDefault = runAdd
            };
        }

        public static OutlineLevel Outline(int level)
        {
            return new OutlineLevel
            {
                Val = level
            };
        }

        public static ItalicComplexScript ComplexItalic()
        {
            return new ItalicComplexScript();
        }

        public static Languages EastAsia()
        {
            return new Languages
            {
                EastAsia = "x-none"
            };
        }

        public static Paragraph ParagraphPreAdd1(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph = new Paragraph()
            {
                RsidParagraphAddition = "00D933D9",
                RsidParagraphProperties = "00D933D9",
                RsidRunAdditionDefault = "00D933D9"
            };
            return BaseParagraph(paragraph, justify, runs);
        }

        public static Paragraph ParagraphPreAdd2(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph = new Paragraph()
            {
                RsidParagraphMarkRevision = "00D933D9",
                RsidParagraphAddition = "00D933D9",
                RsidParagraphProperties = "00D933D9",
                RsidRunAdditionDefault = "00D933D9"
            };
            return BaseParagraph(paragraph, justify, runs);
        }

        public static Paragraph BaseParagraph(Paragraph paragraph, JustificationValues justify, params Run[] runs)
        {
            ParagraphProperties
                paragraphProperties = new
                ParagraphProperties();

            Justification
                justification = new
                Justification()
                {
                    Val = justify
                };

            paragraphProperties.Append(justification);
            for (byte i = 0; i < runs.Length; i++)
            {
                paragraph.Append(runs[i]);
            }

            return paragraph;
        }

        public static Paragraph ParagraphAdd(JustificationValues justify, params Run[] runs)
        {
            Paragraph paragraph117 = new Paragraph()
            {
                RsidParagraphAddition = "009B27E8",
                RsidRunAdditionDefault = "009B27E8"
            };

            ParagraphProperties paragraphProperties117 = new ParagraphProperties();

            WidowControl
                widowControl62 = new
                WidowControl()
                {
                    Val = false
                };

            AutoSpaceDE
                autoSpaceDE89 = new
                AutoSpaceDE()
                {
                    Val = false
                };

            AutoSpaceDN
                autoSpaceDN89 = new
                AutoSpaceDN()
                {
                    Val = false
                };

            AdjustRightIndent
                adjustRightIndent89 = new
                AdjustRightIndent()
                {
                    Val = false
                };

            SpacingBetweenLines
                spacingBetweenLines89 = new
                SpacingBetweenLines()
                {
                    After = "0",
                    Line = "240",
                    LineRule = LineSpacingRuleValues.Auto
                };

            Justification
                justification71 = new
                Justification()
                {
                    Val = justify
                };

            ParagraphMarkRunProperties
                paragraphMarkRunProperties = new
                ParagraphMarkRunProperties();

            paragraphMarkRunProperties.SetTextProperties();

            paragraphProperties117.Append(widowControl62);
            paragraphProperties117.Append(autoSpaceDE89);
            paragraphProperties117.Append(autoSpaceDN89);
            paragraphProperties117.Append(adjustRightIndent89);
            paragraphProperties117.Append(spacingBetweenLines89);
            paragraphProperties117.Append(justification71);
            paragraphProperties117.Append(paragraphMarkRunProperties);

            paragraph117.Append(paragraphProperties117);
            for (byte i = 0; i < runs.Length; i++)
                paragraph117.Append(runs[i]);
            return paragraph117;
        }

        private static TableCell CellBase(ushort width)
        {
            TableCell
                tableCell = new
                TableCell();

            TableCellProperties
                tableCellProperties = new
                TableCellProperties();

            TableCellWidth tableCellWidth = new TableCellWidth()
            {
                Width = width.ToString(),
                Type = TableWidthUnitValues.Dxa
            };

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
            {
                tableCell36.Append(cellProps[i]);
            }
            tableCell36.Append(par);
            return tableCell36;
        }

        public static TableCell TableCellAdd(Paragraph[] pars, ushort width, params OpenXmlElement[] cellProps)
        {
            TableCell tableCell36 = CellBase(width);
            for (byte i = 0; i < cellProps.Length; i++)
            {
                tableCell36.Append(cellProps[i]);
            }

            for (byte i = 0; i < pars.Length; i++)
            {
                tableCell36.Append(pars[i]);
            }
            return tableCell36;
        }

        public static TableRow TableRowAdd(params TableCell[] cells)
        {
            TableRow tableRow = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };
            for (byte i = 0; i < cells.Length; i++)
                tableRow.Append(cells[i]);
            return tableRow;
        }

        public static GridColumn Column(string width)
        {
            return new GridColumn() { Width = width };
        }

        public static GridColumn Column(ushort width)
        {
            return Column(width.ToString());
        }

        public static TableWidth AutoTableWidth()
        {
            return new TableWidth()
            {
                Width = "0",
                Type = TableWidthUnitValues.Auto
            };
        }

        public static TableWidth TableWidth(string size)
        {
            return new TableWidth()
            {
                Width = size,
                Type = TableWidthUnitValues.Dxa
            };
        }

        public static TableCell CompetetionsCell(string text, ushort size)
        {
            TableCell cell = new TableCell();
            cell.SetTableCellProperties(size);

            ParagraphMarkRunProperties properties = new
                ParagraphMarkRunProperties();

            properties.Append(ComplexItalic(), EastAsia());

            Paragraph paragraph = ParagraphPreset("00D551C2");
            paragraph.SetCellParagraphProperties(properties,
                Outline(1), Center(), new KeepNext());

            Run run = RunPreset("00D551C2");
            run.SetCellRunProperties(text, ComplexItalic(), EastAsia());

            paragraph.Append(run);
            cell.Append(paragraph);

            return cell;
        }

        public static void FillRow(this TableRow row,
            Func<string, ushort, TableCell> addCell,
            string[] columns, ushort[] sizes)
        {
            int count = Math.Min(columns.Length, sizes.Length);
            for (byte i = 0; i < count; i++)
            {
                TableCell cell = addCell(columns[i], sizes[i]);
                row.Append(cell);
            }
        }

        public static TableLayout FixedLayout()
        {
            return new TableLayout()
            {
                Type = TableLayoutValues.Fixed
            };
        }

        public static Table TablePreset(ushort[] sizes, params OpenXmlElement[] properties)
        {
            Table table3 = new Table();

            TableProperties
                tableProperties3 = new
                TableProperties();

            TableBorders tableBorders1 = new
                TableBorders();

            tableBorders1.SetBorders();

            TableLook tableLook3 = new TableLook()
            {
                Val = "04A0"
            };

            tableProperties3.Append(properties);
            tableProperties3.Append(tableBorders1);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            tableGrid3.SetGrid(sizes);

            table3.Append(tableProperties3);
            table3.Append(tableGrid3);

            return table3;
        }

        public static Table CompetetionsTable(DisciplineProgram program)
        {
            string[] columns = {
                "Код компетенции",
                "Формулировка компетенции",
                "Знания, умения, практический опыт"
            };

            ushort[] sizes = { 1565, 3298, 4482 };

            Table table3 = TablePreset(sizes, AutoTableWidth());

            TableRow tableRow23 = new TableRow()
            {
                RsidTableRowMarkRevision = "00D551C2",
                RsidTableRowAddition = "00D551C2",
                RsidTableRowProperties = "00D82FF5"
            };

            tableRow23.FillRow(CompetetionsCell, columns, sizes);

            table3.Append(tableRow23);
            table3.Append(CompetetionsTableRows(program));

            return table3;
        }

        public static List<TableRow> CompetetionsTableRows(DisciplineProgram program)
        {
            List<TableRow> rows = new List<TableRow>();

            List<Competetion>
                generalCompetetions = program.GeneralCompetetions;
            for (byte i = 0; i < program.GeneralCompetetions.Count; i++)
            {
                Competetion general = generalCompetetions[i];
                List<TableRow> row = CompetetionAdd(
                    general.PrefixNo,
                    general.Name,
                    general.Abilities
                    );
                rows.AddRange(row);
            }

            List<List<Competetion>>
                professionalCompetetions = program.ProfessionalCompetetions;
            for (byte i = 0; i < program.ProfessionalCompetetions.Count; i++)
            {
                List<Competetion> professionalGroup = professionalCompetetions[i];
                for (byte ii = 0; ii < professionalGroup.Count; ii++)
                {
                    Competetion professional = professionalGroup[ii];
                    List<TableRow> row = CompetetionAdd(
                        professional.PrefixNo,
                        professional.Name,
                        professional.Abilities
                        );
                    rows.AddRange(row);
                }
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
                Task skill = skills[i];
                Run skillsName = RunAdd(skill.Name + " ", new Bold());
                Run skillsDescription = RunAdd(skill.Hours);
                Paragraph skillsParagraphPart = ParagraphAdd(JustificationValues.Left, skillsName, skillsDescription);
                skillsParagraph.Add(skillsParagraphPart);
            }

            TableCell[] cells = TableCellsTemplate3(
                idParagraph,
                nameParagraph,
                skillsParagraph[0],
                new VerticalMerge
                {
                    Val = MergedCellValues.Restart
                },
                new VerticalMerge
                {
                    Val = MergedCellValues.Restart
                });

            TableRow tableRow = TableRowAdd(cells);

            rows.Add(tableRow);
            for (byte i = 1; i < skillsParagraph.Count; i++)
            {
                TableCell[] cells3 = TableCellsTemplate3(
                    ParagraphAdd(JustificationValues.Left),
                    ParagraphAdd(JustificationValues.Left),
                    skillsParagraph[i],
                    new VerticalMerge(),
                    new VerticalMerge());

                TableRow tableRow2 = TableRowAdd(cells3);
                rows.Add(tableRow2);
            }
            return rows;
        }

        public static void SetGrid(this TableGrid grid, params ushort[] sizes)
        {
            for (byte i = 0; i < sizes.Length; i++)
            {
                grid.Append(Column(sizes[i]));
            }
        }

        public static void SetTableCellProperties(this TableCell cell, ushort size)
        {
            TableCellProperties
                properties = new
                TableCellProperties();

            TableCellWidth
                width = new
                TableCellWidth()
                {
                    Width = size.ToString(),
                    Type = TableWidthUnitValues.Dxa
                };

            Shading shading = new Shading()
            {
                Val = ShadingPatternValues.Clear,
                Color = "auto",
                Fill = "auto"
            };

            properties.Append(width);
            properties.Append(shading);
            cell.Append(properties);
        }

        public static void SetCellParagraphProperties(this Paragraph paragraph, params OpenXmlElement[] elements)
        {
            ParagraphProperties
                paragraphProperties = new
                ParagraphProperties();

            paragraphProperties.Append(TableTabs());
            paragraphProperties.Append(elements);

            paragraph.Append(paragraphProperties);
        }

        public static BoldComplexScript ComplexBold()
        {
            return new BoldComplexScript();
        }

        public static Bold Bold()
        {
            return new Bold();
        }

        public static Justification Center()
        {
            return new Justification()
            {
                Val = JustificationValues.Center
            };
        }

        public static Justification Left()
        {
            return new Justification()
            {
                Val = JustificationValues.Left
            };
        }

        public static Justification Right()
        {
            return new Justification()
            {
                Val = JustificationValues.Right
            };
        }


        public static void SetCellRunProperties(this Run run, string text, params OpenXmlElement[] elements)
        {
            RunProperties
                runProperties161 = new
                RunProperties();

            runProperties161.Append(elements);

            Text text307 = new Text
            {
                Text = text
            };

            run.Append(runProperties161);
            run.Append(text307);
        }

        public static TableCell ThemePlanCell(Paragraph paragraph,
            Justification justify, string text, ushort size,
            params OpenXmlElement[] cellProperties)
        {
            Run run = RunPreset("000C238F");
            run.SetCellRunProperties(text, ComplexBold());

            return ThemePlanCell(paragraph, justify, run, size, cellProperties);
        }

        public static TableCell ThemePlanCell(
            Paragraph paragraph, Justification justify, Run run,
            ushort size, params OpenXmlElement[] cellProperties)
        {
            TableCell cell = new TableCell();
            cell.SetTableCellProperties(size);

            ParagraphMarkRunProperties properties = new
                ParagraphMarkRunProperties();

            properties.Append(ComplexBold());

            paragraph.SetCellParagraphProperties(justify, properties);
            paragraph.Append(run);

            cell.Append(cellProperties);
            cell.Append(paragraph);

            return cell;
        }

        public static GridSpan GridSpan(int size)
        {
            return new GridSpan()
            {
                Val = size
            };
        }

        public static Paragraph[] ThemePlanHeaders()
        {
            return new Paragraph[]
            {
                ParagraphPreset
                ("000C238F", "00015275",
                "00C32A4C", "00015275"),
                ParagraphPreset
                ("000C238F", "00015275",
                "00C32A4C", "00015275"),
                ParagraphPreset
                ("000C238F", "00015275",
                "00015275", "00015275"),
                ParagraphPreset
                ("00015275", "00F352B2",
                "00C32A4C", "00F352B2"),
                ParagraphPreset
                ("00015275", "0026510F",
                "0026510F", "00015275")
            };
        }

        public static Paragraph ThemePlanBottom()
        {
            return ParagraphPreset
                ("00C32A4C", "00015275",
                "00C32A4C", "00015275");
        }

        public static Table ThemePlanTable(DisciplineProgram program)
        {
            ushort[] sizes = { 2235, 425, 3544, 992, 1559, 992 };

            ushort merged1to2 = (sizes[1] + sizes[2]).ToUShort();
            ushort merged0to2 = (sizes[0] + merged1to2).ToUShort();

            string[] columns = {
                "Наименование разделов и тем",
                "Содержание учебного материала, лабораторные работы и практические занятия, самостоятельная работа обучающихся, курсовая работа (проект)",
                "Количество часов",
                "Коды компетенций, формированию которых способствует элемент программы",
                "Уровни освоения"
            };

            Paragraph[] headers = ThemePlanHeaders();

            Table table5 = TablePreset(sizes,
                TableWidth(sizes.Sum().ToString()), FixedLayout());

            TableRow tableRow43 = new TableRow()
            {
                RsidTableRowMarkRevision = "000C238F",
                RsidTableRowAddition = "00015275",
                RsidTableRowProperties = "00015275"
            };

            tableRow43.Append(ThemePlanCell(headers[0],
                Center(), columns[0], sizes[0]));

            tableRow43.Append(
                ThemePlanCell(headers[1], Center(),
                columns[1], merged1to2, GridSpan(2)));

            tableRow43.Append(ThemePlanCell(headers[2],
                Center(), columns[2], sizes[3]));

            tableRow43.Append(ThemePlanCell(headers[3],
                Center(), columns[3], sizes[4]));

            tableRow43.Append(ThemePlanCell(headers[4],
                Center(), columns[4], sizes[5]));


            headers = ThemePlanHeaders();

            TableRow tableRow44 = new TableRow()
            {
                RsidTableRowAddition = "00015275",
                RsidTableRowProperties = "00015275"
            };

            tableRow44.Append(
                ThemePlanCell(headers[0],
                Center(), "1", sizes[0]));

            tableRow44.Append(ThemePlanCell(headers[1],
                Center(), "2", merged1to2, GridSpan(2)));

            tableRow44.Append(
                ThemePlanCell(headers[2],
                Center(), "3", sizes[3]));

            tableRow44.Append(
                ThemePlanCell(headers[3],
                Center(), "4", sizes[4]));

            tableRow44.Append(
                ThemePlanCell(headers[4],
                Center(), "5", sizes[5]));

            System.Diagnostics.Trace.WriteLine("GREAT SCOTT");


            TableRow tableRow68 = new TableRow()
            {
                RsidTableRowAddition = "00015275",
                RsidTableRowProperties = "00015275"
            };

            tableRow68.Append(
                ThemePlanCell(ThemePlanBottom(), Left(),
                "Примерная тематика курсовой работы (проекта)",
                merged0to2, GridSpan(3)));

            tableRow68.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "*", sizes[3]));

            tableRow68.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[4]));

            tableRow68.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[5]));


            TableRow tableRow69 = new TableRow()
            {
                RsidTableRowAddition = "00015275",
                RsidTableRowProperties = "00015275"
            };

            tableRow69.Append(ThemePlanCell(ThemePlanBottom(), Left(),
                "Самостоятельная работа обучающихся над курсовой работой (проектом)",
                merged0to2, GridSpan(3)));

            tableRow69.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "*", sizes[3]));

            tableRow69.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[4]));

            tableRow69.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[5]));


            TableRow tableRow70 = new TableRow()
            {
                RsidTableRowAddition = "00015275",
                RsidTableRowProperties = "00015275"
            };

            Run run = RunPreset("000C238F");
            run.SetCellRunProperties("Всего:",
                ComplexBold(), Bold());

            tableRow70.Append(ThemePlanCell(
                ThemePlanBottom(), Right(),
                run, merged0to2, GridSpan(3)));

            tableRow70.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "*", sizes[3]));

            tableRow70.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[4]));

            tableRow70.Append(ThemePlanCell(
                ThemePlanBottom(), Center(),
                "", sizes[5]));

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

        public static List<Paragraph> Literature(List<Source> sources)
        {
            List<Paragraph> proccessedSources = new List<Paragraph>();
            for(byte i = 0; i < sources.Count; i++)
            {
                Source source = sources[i];
                List<Paragraph> paragraphs = NumberList(
                    sources.Count + 1, source.Descriptions, ". ");

                Run run = RunAdd(source.Name, new Bold());
                proccessedSources.Add(ParagraphAdd(JustificationValues.Both, run));
                proccessedSources.AddRange(paragraphs);
            }
            return proccessedSources;
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
        public static List<Paragraph> NumberList(
            in int start, List<string> values, string sequence
            )
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
