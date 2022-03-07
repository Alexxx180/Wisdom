using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace Wisdom.Writers.Markup
{
    public static class Decorators
    {
        public static TabStop TabStop(int position)
        {
            return new TabStop()
            {
                Val = TabStopValues.Left,
                Position = position
            };
        }

        public static Tabs TableTabs()
        {
            Tabs tabs = new Tabs();

            ushort[] positions = { 916, 1832, 2748, 3664, 4580, 5496, 6412,
                7328, 8244, 9160, 10076, 10992, 11908, 12824, 13740, 14656 };

            for (byte i = 0; i < positions.Length; i++)
            {
                tabs.Append(TabStop(positions[i]));
            }

            return tabs;
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

        public static GridSpan GridSpan(int size)
        {
            return new GridSpan()
            {
                Val = size
            };
        }

        public static GridColumn Column(string width)
        {
            return new GridColumn() { Width = width };
        }

        public static GridColumn Column(ushort width)
        {
            return Column(width.ToString());
        }

        public static TableLayout FixedLayout()
        {
            return new TableLayout()
            {
                Type = TableLayoutValues.Fixed
            };
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

        public static TableBorders BordersPreset()
        {
            TableBorders
                borders = new
                TableBorders();

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
                    Size = 4U,
                    Space = 0U
                };

            BottomBorder
                bottomBorder = new
                BottomBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = 4U,
                    Space = 0U
                };

            RightBorder
                rightBorder = new
                RightBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = 4U,
                    Space = 0U
                };

            InsideHorizontalBorder
                insideHorizontalBorder = new
                InsideHorizontalBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = 4U,
                    Space = 0U
                };

            InsideVerticalBorder
                insideVerticalBorder = new
                InsideVerticalBorder()
                {
                    Val = BorderValues.Single,
                    Color = "auto",
                    Size = 4U,
                    Space = 0U
                };

            borders.Append(topBorder);
            borders.Append(leftBorder);
            borders.Append(bottomBorder);
            borders.Append(rightBorder);
            borders.Append(insideHorizontalBorder);
            borders.Append(insideVerticalBorder);
            return borders;
        }

        public static Table TablePreset(ushort[] sizes,
            params OpenXmlElement[] properties)
        {
            Table table = new Table();

            TableProperties
                tableProperties3 = new
                TableProperties();

            TableBorders tableBorders = BordersPreset();

            TableLook tableLook3 = new TableLook()
            {
                Val = "04A0"
            };

            tableProperties3.Append(properties);
            tableProperties3.Append(tableBorders);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            tableGrid3.SetGrid(sizes);

            table.Append(tableProperties3);
            table.Append(tableGrid3);

            return table;
        }

        public static TableCell CellBase(ushort width)
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

        public static Justification Both()
        {
            return new Justification()
            {
                Val = JustificationValues.Both
            };
        }

        public static VerticalMerge MergeRestart()
        {
            return new VerticalMerge
            {
                Val = MergedCellValues.Restart
            };
        }

        public static BoldComplexScript ComplexBold()
        {
            return new BoldComplexScript();
        }

        public static Bold Bold()
        {
            return new Bold();
        }

        public static Text Text(string textPart)
        {
            return new Text
            {
                Text = textPart,
                Space = SpaceProcessingModeValues.Preserve
            };
        }

        public static Run RunBase(string text = "")
        {
            Run run = new Run();
            run.Append(Text(text));
            return run;
        }

        public static Run RunBase(string text, params OpenXmlElement[] elements)
        {
            Run run = new Run();

            RunProperties properties = new RunProperties();
            properties.SetTextProperties();
            properties.Append(elements);

            run.Append(properties);
            run.Append(Text(text));
            return run;
        }

        public static Paragraph ParagraphBase(Justification justify, params Run[] runs)
        {
            Paragraph paragraph = new Paragraph()
            {
                RsidParagraphAddition = "009B27E8",
                RsidRunAdditionDefault = "009B27E8"
            };

            ParagraphProperties
                paragraphProperties = new
                ParagraphProperties();

            WidowControl
                widowControl = new
                WidowControl()
                {
                    Val = false
                };

            AutoSpaceDE
                autoSpaceDE = new
                AutoSpaceDE()
                {
                    Val = false
                };

            AutoSpaceDN
                autoSpaceDN = new
                AutoSpaceDN()
                {
                    Val = false
                };

            AdjustRightIndent
                adjustRightIndent = new
                AdjustRightIndent()
                {
                    Val = false
                };

            SpacingBetweenLines
                spacingBetweenLines = new
                SpacingBetweenLines()
                {
                    After = "0",
                    Line = "240",
                    LineRule = LineSpacingRuleValues.Auto
                };

            ParagraphMarkRunProperties
                paragraphMarkRunProperties = new
                ParagraphMarkRunProperties();

            paragraphMarkRunProperties.SetTextProperties();

            paragraphProperties.Append(widowControl);
            paragraphProperties.Append(autoSpaceDE);
            paragraphProperties.Append(autoSpaceDN);
            paragraphProperties.Append(adjustRightIndent);
            paragraphProperties.Append(spacingBetweenLines);
            paragraphProperties.Append(justify);
            paragraphProperties.Append(paragraphMarkRunProperties);

            paragraph.Append(paragraphProperties);
            paragraph.Append(runs);
            
            return paragraph;
        }

        public static Paragraph TableParagraphBase(Justification justify, params Run[] runs)
        {
            Paragraph paragraph = ParagraphBase(justify, runs);
            paragraph.ParagraphProperties.Append(TableTabs());
            return paragraph;
        }

        public static Paragraph PageBreak()
        {
            Break pageBreak = new Break()
            {
                Type = BreakValues.Page
            };
            Run runPageBreak = new Run(pageBreak);
            return new Paragraph(runPageBreak);
        }

        public static List<Paragraph> NumberList
            (List<string> values, string sequence)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                int no = i + 1;
                Run sourceRun = RunBase(sequence + no + values[i]);
                paragraphs.Add(ParagraphBase(Both(), sourceRun));
            }

            return paragraphs;
        }

        public static List<Paragraph> MarkerList
            (List<string> values, string sequence)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();
            for (byte i = 0; i < values.Count; i++)
            {
                Run sourceRun = RunBase(sequence + values[i]);
                paragraphs.Add(ParagraphBase(Both(), sourceRun));
            }
            return paragraphs;
        }

        public static Section SectionBase(Justification justification, Run run, ushort width, params OpenXmlElement[] elements)
        {
            return new Section
            {
                Header = run,
                Width = width,
                Properties = elements,
                Justification = justification
            };
        }

        public static TableCell TableCellBase(Paragraph fragment, ushort width, params OpenXmlElement[] cellProps)
        {
            TableCell tableCell36 = CellBase(width);
            tableCell36.Append(cellProps);
            tableCell36.Append(fragment);
            return tableCell36;
        }

        public static TableRow TableRowBase(params TableCell[] cells)
        {
            TableRow tableRow = new TableRow()
            {
                RsidTableRowAddition = "009B27E8",
                RsidTableRowProperties = "00DA092C"
            };
            tableRow.Append(cells);
            return tableRow;
        }

        public static TableCell[] CustomizeableSection(params Section[] columns)
        {
            TableCell[] cells = new TableCell[columns.Length];

            for (byte i = 0; i < columns.Length; i++)
            {
                Section column = columns[i];
                cells[i] = TableCellBase(TableParagraphBase(
                    column.Justification, column.Header),
                    column.Width, column.Properties);
            }

            return cells;
        }

        public static void SetTextProperties(this OpenXmlCompositeElement properties)
        {
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

        public static void SetCellRunProperties(this Run run, string text, params OpenXmlElement[] elements)
        {
            RunProperties
                runProperties161 = new
                RunProperties();

            runProperties161.Append(elements);

            Text text307 = new Text
            {
                Text = text,
                Space = SpaceProcessingModeValues.Preserve
            };

            run.Append(runProperties161);
            run.Append(text307);
        }
    }
}