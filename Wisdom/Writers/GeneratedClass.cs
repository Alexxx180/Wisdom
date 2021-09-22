using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using W14 = DocumentFormat.OpenXml.Office2010.Word;
using W15 = DocumentFormat.OpenXml.Office2013.Word;
using Thm15 = DocumentFormat.OpenXml.Office2013.Theme;

namespace Wisdom.Writers
{
    public class GeneratedClass
    {
        private ushort EduHours = 48;
        private ushort SelfHours = 10;
        private string Lections = "18";
        private string Practices = "25";
        private string ControlWs = "10";
        private string CourseWs = "0";
        // Creates a WordprocessingDocument.
        public void CreatePackage(string filePath)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(WordprocessingDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId3");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId2");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId6");
            GenerateThemePart1Content(themePart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId5");
            GenerateFontTablePart1Content(fontTablePart1);

            ImagePart imagePart1 = mainDocumentPart1.AddNewPart<ImagePart>("image/png", "rId4");
            GenerateImagePart1Content(imagePart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Normal.dotm";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "31";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "10";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "1093";
            Ap.Characters characters1 = new Ap.Characters();
            characters1.Text = "6235";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "51";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "14";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Название";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "";

            vTVector2.Append(vTLPSTR2);

            titlesOfParts1.Append(vTVector2);
            Ap.Company company1 = new Ap.Company();
            company1.Text = "";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "7314";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "16.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
            document1.AddNamespaceDeclaration("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            document1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            TableLayout tableLayout1 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);
            TableLook tableLook1 = new TableLook() { Val = "0000" };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableIndentation1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLayout1);
            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "1440" };
            GridColumn gridColumn2 = new GridColumn() { Width = "8327" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            TableRow tableRow1 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00E60584" };

            TableRowProperties tableRowProperties1 = new TableRowProperties();
            TableRowHeight tableRowHeight1 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties1.Append(tableRowHeight1);

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "1440", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge1 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(verticalMerge1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "0026275A" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            WidowControl widowControl1 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE1 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN1 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent1 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification1 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color1 = new Color() { Val = "000000" };
            FontSize fontSize1 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "24" };
            Languages languages1 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(color1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);
            paragraphMarkRunProperties1.Append(languages1);

            paragraphProperties1.Append(widowControl1);
            paragraphProperties1.Append(autoSpaceDE1);
            paragraphProperties1.Append(autoSpaceDN1);
            paragraphProperties1.Append(adjustRightIndent1);
            paragraphProperties1.Append(spacingBetweenLines1);
            paragraphProperties1.Append(justification1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof1 = new NoProof();
            Color color2 = new Color() { Val = "000000" };
            FontSize fontSize2 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "24" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(noProof1);
            runProperties1.Append(color2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);

            Drawing drawing1 = new Drawing();

            Wp.Inline inline1 = new Wp.Inline() { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U };
            Wp.Extent extent1 = new Wp.Extent() { Cx = 890210L, Cy = 876300L };
            Wp.EffectExtent effectExtent1 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 5715L, BottomEdge = 0L };
            Wp.DocProperties docProperties1 = new Wp.DocProperties() { Id = (UInt32Value)1U, Name = "Рисунок 1" };

            Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new Wp.NonVisualGraphicFrameDrawingProperties();

            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks() { NoChangeAspect = true };
            graphicFrameLocks1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            A.Graphic graphic1 = new A.Graphic();
            graphic1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" };

            Pic.Picture picture1 = new Pic.Picture();
            picture1.AddNamespaceDeclaration("pic", "http://schemas.openxmlformats.org/drawingml/2006/picture");

            Pic.NonVisualPictureProperties nonVisualPictureProperties1 = new Pic.NonVisualPictureProperties();
            Pic.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Pic.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "Picture 1" };

            Pic.NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new Pic.NonVisualPictureDrawingProperties();
            A.PictureLocks pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true, NoChangeArrowheads = true };

            nonVisualPictureDrawingProperties1.Append(pictureLocks1);

            nonVisualPictureProperties1.Append(nonVisualDrawingProperties1);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);

            Pic.BlipFill blipFill1 = new Pic.BlipFill();

            A.Blip blip1 = new A.Blip() { Embed = "rId4" };

            A.BlipExtensionList blipExtensionList1 = new A.BlipExtensionList();

            A.BlipExtension blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };

            A14.UseLocalDpi useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            blipExtension1.Append(useLocalDpi1);

            blipExtensionList1.Append(blipExtension1);

            blip1.Append(blipExtensionList1);
            A.SourceRectangle sourceRectangle1 = new A.SourceRectangle();

            A.Stretch stretch1 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();

            stretch1.Append(fillRectangle1);

            blipFill1.Append(blip1);
            blipFill1.Append(sourceRectangle1);
            blipFill1.Append(stretch1);

            Pic.ShapeProperties shapeProperties1 = new Pic.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents() { Cx = 901042L, Cy = 886963L };

            transform2D1.Append(offset1);
            transform2D1.Append(extents1);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);
            A.NoFill noFill1 = new A.NoFill();

            A.Outline outline1 = new A.Outline();
            A.NoFill noFill2 = new A.NoFill();

            outline1.Append(noFill2);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            shapeProperties1.Append(noFill1);
            shapeProperties1.Append(outline1);

            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill1);
            picture1.Append(shapeProperties1);

            graphicData1.Append(picture1);

            graphic1.Append(graphicData1);

            inline1.Append(extent1);
            inline1.Append(effectExtent1);
            inline1.Append(docProperties1);
            inline1.Append(nonVisualGraphicFrameDrawingProperties1);
            inline1.Append(graphic1);

            drawing1.Append(inline1);

            run1.Append(runProperties1);
            run1.Append(drawing1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "8327", Type = TableWidthUnitValues.Dxa };

            tableCellProperties2.Append(tableCellWidth2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            WidowControl widowControl2 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE2 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN2 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent2 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification2 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color3 = new Color() { Val = "000000" };
            FontSize fontSize3 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "24" };
            Languages languages2 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties2.Append(runFonts3);
            paragraphMarkRunProperties2.Append(color3);
            paragraphMarkRunProperties2.Append(fontSize3);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript3);
            paragraphMarkRunProperties2.Append(languages2);

            paragraphProperties2.Append(widowControl2);
            paragraphProperties2.Append(autoSpaceDE2);
            paragraphProperties2.Append(autoSpaceDN2);
            paragraphProperties2.Append(adjustRightIndent2);
            paragraphProperties2.Append(spacingBetweenLines2);
            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color4 = new Color() { Val = "000000" };
            FontSize fontSize4 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "24" };
            Languages languages3 = new Languages() { Val = "ru" };

            runProperties2.Append(runFonts4);
            runProperties2.Append(color4);
            runProperties2.Append(fontSize4);
            runProperties2.Append(fontSizeComplexScript4);
            runProperties2.Append(languages3);
            Text text1 = new Text();
            text1.Text = "Министерство образования и науки Российской Федерации Федеральное государственное бюджетное образовательное учреждение высшего образования «Новгородский государственный университет имени Ярослава Мудрого»";

            run2.Append(runProperties2);
            run2.Append(text1);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color5 = new Color() { Val = "000000" };
            FontSize fontSize5 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "24" };
            Languages languages4 = new Languages() { Val = "ru" };

            runProperties3.Append(runFonts5);
            runProperties3.Append(color5);
            runProperties3.Append(fontSize5);
            runProperties3.Append(fontSizeComplexScript5);
            runProperties3.Append(languages4);
            Break break1 = new Break();

            run3.Append(runProperties3);
            run3.Append(break1);

            Run run4 = new Run();

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold1 = new Bold();
            Color color6 = new Color() { Val = "000000" };
            FontSize fontSize6 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "24" };
            Languages languages5 = new Languages() { Val = "ru" };

            runProperties4.Append(runFonts6);
            runProperties4.Append(bold1);
            runProperties4.Append(color6);
            runProperties4.Append(fontSize6);
            runProperties4.Append(fontSizeComplexScript6);
            runProperties4.Append(languages5);
            Text text2 = new Text();
            text2.Text = "ПОЛИТЕХНИЧЕСКИЙ КОЛЛЕДЖ";

            run4.Append(runProperties4);
            run4.Append(text2);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);
            paragraph2.Append(run3);
            paragraph2.Append(run4);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph2);

            tableRow1.Append(tableRowProperties1);
            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            TableRow tableRow2 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00E60584" };

            TableRowProperties tableRowProperties2 = new TableRowProperties();
            TableRowHeight tableRowHeight2 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties2.Append(tableRowHeight2);

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "1440", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge2 = new VerticalMerge();

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(verticalMerge2);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();
            WidowControl widowControl3 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE3 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN3 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent3 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines3 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification3 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color7 = new Color() { Val = "000000" };
            FontSize fontSize7 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "24" };
            Languages languages6 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties3.Append(runFonts7);
            paragraphMarkRunProperties3.Append(color7);
            paragraphMarkRunProperties3.Append(fontSize7);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript7);
            paragraphMarkRunProperties3.Append(languages6);

            paragraphProperties3.Append(widowControl3);
            paragraphProperties3.Append(autoSpaceDE3);
            paragraphProperties3.Append(autoSpaceDN3);
            paragraphProperties3.Append(adjustRightIndent3);
            paragraphProperties3.Append(spacingBetweenLines3);
            paragraphProperties3.Append(justification3);
            paragraphProperties3.Append(paragraphMarkRunProperties3);

            paragraph3.Append(paragraphProperties3);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph3);

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "8327", Type = TableWidthUnitValues.Dxa };

            tableCellProperties4.Append(tableCellWidth4);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();
            WidowControl widowControl4 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE4 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN4 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent4 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification4 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold2 = new Bold();
            Color color8 = new Color() { Val = "000000" };
            FontSize fontSize8 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "24" };
            Languages languages7 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties4.Append(runFonts8);
            paragraphMarkRunProperties4.Append(bold2);
            paragraphMarkRunProperties4.Append(color8);
            paragraphMarkRunProperties4.Append(fontSize8);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript8);
            paragraphMarkRunProperties4.Append(languages7);

            paragraphProperties4.Append(widowControl4);
            paragraphProperties4.Append(autoSpaceDE4);
            paragraphProperties4.Append(autoSpaceDN4);
            paragraphProperties4.Append(adjustRightIndent4);
            paragraphProperties4.Append(spacingBetweenLines4);
            paragraphProperties4.Append(justification4);
            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run5 = new Run();

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold3 = new Bold();
            Color color9 = new Color() { Val = "000000" };
            FontSize fontSize9 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "24" };
            Languages languages8 = new Languages() { Val = "ru" };

            runProperties5.Append(runFonts9);
            runProperties5.Append(bold3);
            runProperties5.Append(color9);
            runProperties5.Append(fontSize9);
            runProperties5.Append(fontSizeComplexScript9);
            runProperties5.Append(languages8);
            Text text3 = new Text();
            text3.Text = "Учебно-методическая документация";

            run5.Append(runProperties5);
            run5.Append(text3);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run5);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph4);

            tableRow2.Append(tableRowProperties2);
            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();
            WidowControl widowControl5 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE5 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN5 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent5 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines5 = new SpacingBetweenLines() { Before = "1200", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification5 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold4 = new Bold();
            Color color10 = new Color() { Val = "000000" };
            FontSize fontSize10 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "24" };
            Languages languages9 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties5.Append(runFonts10);
            paragraphMarkRunProperties5.Append(bold4);
            paragraphMarkRunProperties5.Append(color10);
            paragraphMarkRunProperties5.Append(fontSize10);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript10);
            paragraphMarkRunProperties5.Append(languages9);

            paragraphProperties5.Append(widowControl5);
            paragraphProperties5.Append(autoSpaceDE5);
            paragraphProperties5.Append(autoSpaceDN5);
            paragraphProperties5.Append(adjustRightIndent5);
            paragraphProperties5.Append(spacingBetweenLines5);
            paragraphProperties5.Append(justification5);
            paragraphProperties5.Append(paragraphMarkRunProperties5);

            paragraph5.Append(paragraphProperties5);

            Table table2 = new Table();

            TableProperties tableProperties2 = new TableProperties();
            TableWidth tableWidth2 = new TableWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout2 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault2 = new TableCellMarginDefault();
            TopMargin topMargin2 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin2 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin2 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault2.Append(topMargin2);
            tableCellMarginDefault2.Append(tableCellLeftMargin2);
            tableCellMarginDefault2.Append(bottomMargin2);
            tableCellMarginDefault2.Append(tableCellRightMargin2);
            TableLook tableLook2 = new TableLook() { Val = "0000" };

            tableProperties2.Append(tableWidth2);
            tableProperties2.Append(tableIndentation2);
            tableProperties2.Append(tableLayout2);
            tableProperties2.Append(tableCellMarginDefault2);
            tableProperties2.Append(tableLook2);

            TableGrid tableGrid2 = new TableGrid();
            GridColumn gridColumn3 = new GridColumn() { Width = "5944" };
            GridColumn gridColumn4 = new GridColumn() { Width = "3823" };

            tableGrid2.Append(gridColumn3);
            tableGrid2.Append(gridColumn4);

            TableRow tableRow3 = new TableRow() { RsidTableRowAddition = "00524100", RsidTableRowProperties = "00524100" };

            TableRowProperties tableRowProperties3 = new TableRowProperties();
            TableRowHeight tableRowHeight3 = new TableRowHeight() { Val = (UInt32Value)1354U };

            tableRowProperties3.Append(tableRowHeight3);

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "5944", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder2);
            tableCellBorders1.Append(leftBorder2);
            tableCellBorders1.Append(bottomBorder2);
            tableCellBorders1.Append(rightBorder2);

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(tableCellBorders1);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "009B27E8", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();
            WidowControl widowControl6 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE6 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN6 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent6 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines6 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification6 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color11 = new Color() { Val = "000000" };
            FontSize fontSize11 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "24" };
            Languages languages10 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties6.Append(runFonts11);
            paragraphMarkRunProperties6.Append(color11);
            paragraphMarkRunProperties6.Append(fontSize11);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript11);
            paragraphMarkRunProperties6.Append(languages10);

            paragraphProperties6.Append(widowControl6);
            paragraphProperties6.Append(autoSpaceDE6);
            paragraphProperties6.Append(autoSpaceDN6);
            paragraphProperties6.Append(adjustRightIndent6);
            paragraphProperties6.Append(spacingBetweenLines6);
            paragraphProperties6.Append(justification6);
            paragraphProperties6.Append(paragraphMarkRunProperties6);

            paragraph6.Append(paragraphProperties6);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph6);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "3823", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders2.Append(topBorder3);
            tableCellBorders2.Append(leftBorder3);
            tableCellBorders2.Append(bottomBorder3);
            tableCellBorders2.Append(rightBorder3);

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(tableCellBorders2);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "009B27E8", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();
            WidowControl widowControl7 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE7 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN7 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent7 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines7 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color12 = new Color() { Val = "000000" };
            FontSize fontSize12 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "24" };
            Languages languages11 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties7.Append(runFonts12);
            paragraphMarkRunProperties7.Append(color12);
            paragraphMarkRunProperties7.Append(fontSize12);
            paragraphMarkRunProperties7.Append(fontSizeComplexScript12);
            paragraphMarkRunProperties7.Append(languages11);

            paragraphProperties7.Append(widowControl7);
            paragraphProperties7.Append(autoSpaceDE7);
            paragraphProperties7.Append(autoSpaceDN7);
            paragraphProperties7.Append(adjustRightIndent7);
            paragraphProperties7.Append(spacingBetweenLines7);
            paragraphProperties7.Append(paragraphMarkRunProperties7);

            Run run6 = new Run();

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color13 = new Color() { Val = "000000" };
            FontSize fontSize13 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "24" };
            Languages languages12 = new Languages() { Val = "ru" };

            runProperties6.Append(runFonts13);
            runProperties6.Append(color13);
            runProperties6.Append(fontSize13);
            runProperties6.Append(fontSizeComplexScript13);
            runProperties6.Append(languages12);
            Text text4 = new Text();
            text4.Text = "УТВЕРЖДАЮ";

            run6.Append(runProperties6);
            run6.Append(text4);

            paragraph7.Append(paragraphProperties7);
            paragraph7.Append(run6);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "009B27E8", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();
            WidowControl widowControl8 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE8 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN8 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent8 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color14 = new Color() { Val = "000000" };
            FontSize fontSize14 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "24" };
            Languages languages13 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties8.Append(runFonts14);
            paragraphMarkRunProperties8.Append(color14);
            paragraphMarkRunProperties8.Append(fontSize14);
            paragraphMarkRunProperties8.Append(fontSizeComplexScript14);
            paragraphMarkRunProperties8.Append(languages13);

            paragraphProperties8.Append(widowControl8);
            paragraphProperties8.Append(autoSpaceDE8);
            paragraphProperties8.Append(autoSpaceDN8);
            paragraphProperties8.Append(adjustRightIndent8);
            paragraphProperties8.Append(spacingBetweenLines8);
            paragraphProperties8.Append(paragraphMarkRunProperties8);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts15 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color15 = new Color() { Val = "000000" };
            FontSize fontSize15 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "24" };
            Languages languages14 = new Languages() { Val = "ru" };

            runProperties7.Append(runFonts15);
            runProperties7.Append(color15);
            runProperties7.Append(fontSize15);
            runProperties7.Append(fontSizeComplexScript15);
            runProperties7.Append(languages14);
            Text text5 = new Text();
            text5.Text = "Директор ПТК НовГУ";

            run7.Append(runProperties7);
            run7.Append(text5);

            paragraph8.Append(paragraphProperties8);
            paragraph8.Append(run7);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "009B27E8", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties9 = new ParagraphProperties();
            WidowControl widowControl9 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE9 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN9 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent9 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines9 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
            RunFonts runFonts16 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color16 = new Color() { Val = "000000" };
            FontSize fontSize16 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "24" };
            Languages languages15 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties9.Append(runFonts16);
            paragraphMarkRunProperties9.Append(color16);
            paragraphMarkRunProperties9.Append(fontSize16);
            paragraphMarkRunProperties9.Append(fontSizeComplexScript16);
            paragraphMarkRunProperties9.Append(languages15);

            paragraphProperties9.Append(widowControl9);
            paragraphProperties9.Append(autoSpaceDE9);
            paragraphProperties9.Append(autoSpaceDN9);
            paragraphProperties9.Append(adjustRightIndent9);
            paragraphProperties9.Append(spacingBetweenLines9);
            paragraphProperties9.Append(paragraphMarkRunProperties9);

            Run run8 = new Run();

            RunProperties runProperties8 = new RunProperties();
            RunFonts runFonts17 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color17 = new Color() { Val = "000000" };
            FontSize fontSize17 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "24" };
            Languages languages16 = new Languages() { Val = "ru" };

            runProperties8.Append(runFonts17);
            runProperties8.Append(color17);
            runProperties8.Append(fontSize17);
            runProperties8.Append(fontSizeComplexScript17);
            runProperties8.Append(languages16);
            Text text6 = new Text();
            text6.Text = "_________";

            run8.Append(runProperties8);
            run8.Append(text6);

            Run run9 = new Run() { RsidRunProperties = "00524100" };

            RunProperties runProperties9 = new RunProperties();
            RunFonts runFonts18 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color18 = new Color() { Val = "000000" };
            FontSize fontSize18 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "24" };

            runProperties9.Append(runFonts18);
            runProperties9.Append(color18);
            runProperties9.Append(fontSize18);
            runProperties9.Append(fontSizeComplexScript18);
            Text text7 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text7.Text = " ";

            run9.Append(runProperties9);
            run9.Append(text7);

            Run run10 = new Run();

            RunProperties runProperties10 = new RunProperties();
            RunFonts runFonts19 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color19 = new Color() { Val = "000000" };
            FontSize fontSize19 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "24" };
            Languages languages17 = new Languages() { Val = "ru" };

            runProperties10.Append(runFonts19);
            runProperties10.Append(color19);
            runProperties10.Append(fontSize19);
            runProperties10.Append(fontSizeComplexScript19);
            runProperties10.Append(languages17);
            Text text8 = new Text();
            text8.Text = "В.А.Шульцев";

            run10.Append(runProperties10);
            run10.Append(text8);

            paragraph9.Append(paragraphProperties9);
            paragraph9.Append(run8);
            paragraph9.Append(run9);
            paragraph9.Append(run10);

            Paragraph paragraph10 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "009B27E8", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties10 = new ParagraphProperties();
            WidowControl widowControl10 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE10 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN10 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent10 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines10 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
            RunFonts runFonts20 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color20 = new Color() { Val = "000000" };
            FontSize fontSize20 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "24" };
            Languages languages18 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties10.Append(runFonts20);
            paragraphMarkRunProperties10.Append(color20);
            paragraphMarkRunProperties10.Append(fontSize20);
            paragraphMarkRunProperties10.Append(fontSizeComplexScript20);
            paragraphMarkRunProperties10.Append(languages18);

            paragraphProperties10.Append(widowControl10);
            paragraphProperties10.Append(autoSpaceDE10);
            paragraphProperties10.Append(autoSpaceDN10);
            paragraphProperties10.Append(adjustRightIndent10);
            paragraphProperties10.Append(spacingBetweenLines10);
            paragraphProperties10.Append(paragraphMarkRunProperties10);

            Run run11 = new Run();

            RunProperties runProperties11 = new RunProperties();
            RunFonts runFonts21 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color21 = new Color() { Val = "000000" };
            FontSize fontSize21 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "24" };
            Languages languages19 = new Languages() { Val = "ru" };

            runProperties11.Append(runFonts21);
            runProperties11.Append(color21);
            runProperties11.Append(fontSize21);
            runProperties11.Append(fontSizeComplexScript21);
            runProperties11.Append(languages19);
            Text text9 = new Text();
            text9.Text = "«__» _________ 20__г.";

            run11.Append(runProperties11);
            run11.Append(text9);

            paragraph10.Append(paragraphProperties10);
            paragraph10.Append(run11);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph7);
            tableCell6.Append(paragraph8);
            tableCell6.Append(paragraph9);
            tableCell6.Append(paragraph10);

            tableRow3.Append(tableRowProperties3);
            tableRow3.Append(tableCell5);
            tableRow3.Append(tableCell6);

            table2.Append(tableProperties2);
            table2.Append(tableGrid2);
            table2.Append(tableRow3);

            Paragraph paragraph11 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "00524100", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties11 = new ParagraphProperties();
            WidowControl widowControl11 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE11 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN11 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent11 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines11 = new SpacingBetweenLines() { Before = "1200", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification7 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
            RunFonts runFonts22 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold5 = new Bold();
            Color color22 = new Color() { Val = "000000" };
            FontSize fontSize22 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "24" };
            Languages languages20 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties11.Append(runFonts22);
            paragraphMarkRunProperties11.Append(bold5);
            paragraphMarkRunProperties11.Append(color22);
            paragraphMarkRunProperties11.Append(fontSize22);
            paragraphMarkRunProperties11.Append(fontSizeComplexScript22);
            paragraphMarkRunProperties11.Append(languages20);

            paragraphProperties11.Append(widowControl11);
            paragraphProperties11.Append(autoSpaceDE11);
            paragraphProperties11.Append(autoSpaceDN11);
            paragraphProperties11.Append(adjustRightIndent11);
            paragraphProperties11.Append(spacingBetweenLines11);
            paragraphProperties11.Append(justification7);
            paragraphProperties11.Append(paragraphMarkRunProperties11);

            paragraph11.Append(paragraphProperties11);

            Paragraph paragraph12 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties12 = new ParagraphProperties();
            WidowControl widowControl12 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE12 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN12 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent12 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines12 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification8 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
            RunFonts runFonts23 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold6 = new Bold();
            Color color23 = new Color() { Val = "000000" };
            FontSize fontSize23 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "24" };
            Languages languages21 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties12.Append(runFonts23);
            paragraphMarkRunProperties12.Append(bold6);
            paragraphMarkRunProperties12.Append(color23);
            paragraphMarkRunProperties12.Append(fontSize23);
            paragraphMarkRunProperties12.Append(fontSizeComplexScript23);
            paragraphMarkRunProperties12.Append(languages21);

            paragraphProperties12.Append(widowControl12);
            paragraphProperties12.Append(autoSpaceDE12);
            paragraphProperties12.Append(autoSpaceDN12);
            paragraphProperties12.Append(adjustRightIndent12);
            paragraphProperties12.Append(spacingBetweenLines12);
            paragraphProperties12.Append(justification8);
            paragraphProperties12.Append(paragraphMarkRunProperties12);

            Run run12 = new Run();

            RunProperties runProperties12 = new RunProperties();
            RunFonts runFonts24 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold7 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            Color color24 = new Color() { Val = "000000" };
            FontSize fontSize24 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "28" };
            Languages languages22 = new Languages() { Val = "ru" };

            runProperties12.Append(runFonts24);
            runProperties12.Append(bold7);
            runProperties12.Append(boldComplexScript1);
            runProperties12.Append(color24);
            runProperties12.Append(fontSize24);
            runProperties12.Append(fontSizeComplexScript24);
            runProperties12.Append(languages22);
            Text text10 = new Text();
            text10.Text = "ОГСЭ.01 Основы философии";

            run12.Append(runProperties12);
            run12.Append(text10);

            paragraph12.Append(paragraphProperties12);
            paragraph12.Append(run12);

            Paragraph paragraph13 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties13 = new ParagraphProperties();
            WidowControl widowControl13 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE13 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN13 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent13 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines13 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification9 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
            RunFonts runFonts25 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold8 = new Bold();
            Color color25 = new Color() { Val = "000000" };
            FontSize fontSize25 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "24" };
            Languages languages23 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties13.Append(runFonts25);
            paragraphMarkRunProperties13.Append(bold8);
            paragraphMarkRunProperties13.Append(color25);
            paragraphMarkRunProperties13.Append(fontSize25);
            paragraphMarkRunProperties13.Append(fontSizeComplexScript25);
            paragraphMarkRunProperties13.Append(languages23);

            paragraphProperties13.Append(widowControl13);
            paragraphProperties13.Append(autoSpaceDE13);
            paragraphProperties13.Append(autoSpaceDN13);
            paragraphProperties13.Append(adjustRightIndent13);
            paragraphProperties13.Append(spacingBetweenLines13);
            paragraphProperties13.Append(justification9);
            paragraphProperties13.Append(paragraphMarkRunProperties13);

            paragraph13.Append(paragraphProperties13);

            Paragraph paragraph14 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties14 = new ParagraphProperties();
            WidowControl widowControl14 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE14 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN14 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent14 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines14 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification10 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
            RunFonts runFonts26 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color26 = new Color() { Val = "000000" };
            FontSize fontSize26 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "24" };
            Languages languages24 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties14.Append(runFonts26);
            paragraphMarkRunProperties14.Append(color26);
            paragraphMarkRunProperties14.Append(fontSize26);
            paragraphMarkRunProperties14.Append(fontSizeComplexScript26);
            paragraphMarkRunProperties14.Append(languages24);

            paragraphProperties14.Append(widowControl14);
            paragraphProperties14.Append(autoSpaceDE14);
            paragraphProperties14.Append(autoSpaceDN14);
            paragraphProperties14.Append(adjustRightIndent14);
            paragraphProperties14.Append(spacingBetweenLines14);
            paragraphProperties14.Append(justification10);
            paragraphProperties14.Append(paragraphMarkRunProperties14);

            Run run13 = new Run();

            RunProperties runProperties13 = new RunProperties();
            RunFonts runFonts27 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color27 = new Color() { Val = "000000" };
            FontSize fontSize27 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "24" };
            Languages languages25 = new Languages() { Val = "ru" };

            runProperties13.Append(runFonts27);
            runProperties13.Append(color27);
            runProperties13.Append(fontSize27);
            runProperties13.Append(fontSizeComplexScript27);
            runProperties13.Append(languages25);
            Text text11 = new Text();
            text11.Text = "Специальности:";

            run13.Append(runProperties13);
            run13.Append(text11);

            paragraph14.Append(paragraphProperties14);
            paragraph14.Append(run13);

            Paragraph paragraph15 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties15 = new ParagraphProperties();
            WidowControl widowControl15 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE15 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN15 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent15 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines15 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification11 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
            RunFonts runFonts28 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold9 = new Bold();
            Color color28 = new Color() { Val = "000000" };
            FontSize fontSize28 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "24" };
            Languages languages26 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties15.Append(runFonts28);
            paragraphMarkRunProperties15.Append(bold9);
            paragraphMarkRunProperties15.Append(color28);
            paragraphMarkRunProperties15.Append(fontSize28);
            paragraphMarkRunProperties15.Append(fontSizeComplexScript28);
            paragraphMarkRunProperties15.Append(languages26);

            paragraphProperties15.Append(widowControl15);
            paragraphProperties15.Append(autoSpaceDE15);
            paragraphProperties15.Append(autoSpaceDN15);
            paragraphProperties15.Append(adjustRightIndent15);
            paragraphProperties15.Append(spacingBetweenLines15);
            paragraphProperties15.Append(justification11);
            paragraphProperties15.Append(paragraphMarkRunProperties15);

            paragraph15.Append(paragraphProperties15);

            Paragraph paragraph16 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties16 = new ParagraphProperties();
            WidowControl widowControl16 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE16 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN16 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent16 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines16 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification12 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
            RunFonts runFonts29 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color29 = new Color() { Val = "000000" };
            FontSize fontSize29 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript29 = new FontSizeComplexScript() { Val = "24" };
            Languages languages27 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties16.Append(runFonts29);
            paragraphMarkRunProperties16.Append(color29);
            paragraphMarkRunProperties16.Append(fontSize29);
            paragraphMarkRunProperties16.Append(fontSizeComplexScript29);
            paragraphMarkRunProperties16.Append(languages27);

            paragraphProperties16.Append(widowControl16);
            paragraphProperties16.Append(autoSpaceDE16);
            paragraphProperties16.Append(autoSpaceDN16);
            paragraphProperties16.Append(adjustRightIndent16);
            paragraphProperties16.Append(spacingBetweenLines16);
            paragraphProperties16.Append(justification12);
            paragraphProperties16.Append(paragraphMarkRunProperties16);

            Run run14 = new Run();

            RunProperties runProperties14 = new RunProperties();
            RunFonts runFonts30 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color30 = new Color() { Val = "000000" };
            FontSize fontSize30 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript30 = new FontSizeComplexScript() { Val = "24" };
            Languages languages28 = new Languages() { Val = "ru" };

            runProperties14.Append(runFonts30);
            runProperties14.Append(color30);
            runProperties14.Append(fontSize30);
            runProperties14.Append(fontSizeComplexScript30);
            runProperties14.Append(languages28);
            Text text12 = new Text();
            text12.Text = "Квалификация выпускника: техник";

            run14.Append(runProperties14);
            run14.Append(text12);

            paragraph16.Append(paragraphProperties16);
            paragraph16.Append(run14);

            Paragraph paragraph17 = new Paragraph() { RsidParagraphAddition = "00524100", RsidParagraphProperties = "00524100", RsidRunAdditionDefault = "00524100" };

            ParagraphProperties paragraphProperties17 = new ParagraphProperties();
            WidowControl widowControl17 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE17 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN17 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent17 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines17 = new SpacingBetweenLines() { After = "1800", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification13 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
            RunFonts runFonts31 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color31 = new Color() { Val = "000000" };
            FontSize fontSize31 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript31 = new FontSizeComplexScript() { Val = "24" };
            Languages languages29 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties17.Append(runFonts31);
            paragraphMarkRunProperties17.Append(color31);
            paragraphMarkRunProperties17.Append(fontSize31);
            paragraphMarkRunProperties17.Append(fontSizeComplexScript31);
            paragraphMarkRunProperties17.Append(languages29);

            paragraphProperties17.Append(widowControl17);
            paragraphProperties17.Append(autoSpaceDE17);
            paragraphProperties17.Append(autoSpaceDN17);
            paragraphProperties17.Append(adjustRightIndent17);
            paragraphProperties17.Append(spacingBetweenLines17);
            paragraphProperties17.Append(justification13);
            paragraphProperties17.Append(paragraphMarkRunProperties17);

            paragraph17.Append(paragraphProperties17);

            Paragraph paragraph18 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties18 = new ParagraphProperties();
            WidowControl widowControl18 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE18 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN18 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent18 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines18 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification14 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
            RunFonts runFonts32 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color32 = new Color() { Val = "000000" };
            FontSize fontSize32 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript32 = new FontSizeComplexScript() { Val = "24" };
            Languages languages30 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties18.Append(runFonts32);
            paragraphMarkRunProperties18.Append(color32);
            paragraphMarkRunProperties18.Append(fontSize32);
            paragraphMarkRunProperties18.Append(fontSizeComplexScript32);
            paragraphMarkRunProperties18.Append(languages30);

            paragraphProperties18.Append(widowControl18);
            paragraphProperties18.Append(autoSpaceDE18);
            paragraphProperties18.Append(autoSpaceDN18);
            paragraphProperties18.Append(adjustRightIndent18);
            paragraphProperties18.Append(spacingBetweenLines18);
            paragraphProperties18.Append(justification14);
            paragraphProperties18.Append(paragraphMarkRunProperties18);

            Run run15 = new Run();

            RunProperties runProperties15 = new RunProperties();
            RunFonts runFonts33 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color33 = new Color() { Val = "000000" };
            FontSize fontSize33 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript33 = new FontSizeComplexScript() { Val = "24" };
            Languages languages31 = new Languages() { Val = "ru" };

            runProperties15.Append(runFonts33);
            runProperties15.Append(color33);
            runProperties15.Append(fontSize33);
            runProperties15.Append(fontSizeComplexScript33);
            runProperties15.Append(languages31);
            Text text13 = new Text();
            text13.Text = "Согласовано";

            run15.Append(runProperties15);
            run15.Append(text13);

            paragraph18.Append(paragraphProperties18);
            paragraph18.Append(run15);

            Paragraph paragraph19 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties19 = new ParagraphProperties();
            WidowControl widowControl19 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE19 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN19 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent19 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines19 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification15 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
            RunFonts runFonts34 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color34 = new Color() { Val = "000000" };
            FontSize fontSize34 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript34 = new FontSizeComplexScript() { Val = "24" };
            Languages languages32 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties19.Append(runFonts34);
            paragraphMarkRunProperties19.Append(color34);
            paragraphMarkRunProperties19.Append(fontSize34);
            paragraphMarkRunProperties19.Append(fontSizeComplexScript34);
            paragraphMarkRunProperties19.Append(languages32);

            paragraphProperties19.Append(widowControl19);
            paragraphProperties19.Append(autoSpaceDE19);
            paragraphProperties19.Append(autoSpaceDN19);
            paragraphProperties19.Append(adjustRightIndent19);
            paragraphProperties19.Append(spacingBetweenLines19);
            paragraphProperties19.Append(justification15);
            paragraphProperties19.Append(paragraphMarkRunProperties19);

            Run run16 = new Run();

            RunProperties runProperties16 = new RunProperties();
            RunFonts runFonts35 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color35 = new Color() { Val = "000000" };
            FontSize fontSize35 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript35 = new FontSizeComplexScript() { Val = "24" };
            Languages languages33 = new Languages() { Val = "ru" };

            runProperties16.Append(runFonts35);
            runProperties16.Append(color35);
            runProperties16.Append(fontSize35);
            runProperties16.Append(fontSizeComplexScript35);
            runProperties16.Append(languages33);
            Text text14 = new Text();
            text14.Text = "Зам. начальника УМУ НовГУ по СПО";

            run16.Append(runProperties16);
            run16.Append(text14);

            paragraph19.Append(paragraphProperties19);
            paragraph19.Append(run16);

            Paragraph paragraph20 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties20 = new ParagraphProperties();
            WidowControl widowControl20 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE20 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN20 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent20 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines20 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification16 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
            RunFonts runFonts36 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color36 = new Color() { Val = "000000" };
            FontSize fontSize36 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript36 = new FontSizeComplexScript() { Val = "24" };
            Languages languages34 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties20.Append(runFonts36);
            paragraphMarkRunProperties20.Append(color36);
            paragraphMarkRunProperties20.Append(fontSize36);
            paragraphMarkRunProperties20.Append(fontSizeComplexScript36);
            paragraphMarkRunProperties20.Append(languages34);

            paragraphProperties20.Append(widowControl20);
            paragraphProperties20.Append(autoSpaceDE20);
            paragraphProperties20.Append(autoSpaceDN20);
            paragraphProperties20.Append(adjustRightIndent20);
            paragraphProperties20.Append(spacingBetweenLines20);
            paragraphProperties20.Append(justification16);
            paragraphProperties20.Append(paragraphMarkRunProperties20);

            Run run17 = new Run();

            RunProperties runProperties17 = new RunProperties();
            RunFonts runFonts37 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color37 = new Color() { Val = "000000" };
            FontSize fontSize37 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript37 = new FontSizeComplexScript() { Val = "24" };
            Languages languages35 = new Languages() { Val = "ru" };

            runProperties17.Append(runFonts37);
            runProperties17.Append(color37);
            runProperties17.Append(fontSize37);
            runProperties17.Append(fontSizeComplexScript37);
            runProperties17.Append(languages35);
            Text text15 = new Text();
            text15.Text = "__________________ /М.В.Никифорова/";

            run17.Append(runProperties17);
            run17.Append(text15);

            paragraph20.Append(paragraphProperties20);
            paragraph20.Append(run17);

            Paragraph paragraph21 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties21 = new ParagraphProperties();
            WidowControl widowControl21 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE21 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN21 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent21 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines21 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification17 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
            RunFonts runFonts38 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color38 = new Color() { Val = "000000" };
            FontSize fontSize38 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript38 = new FontSizeComplexScript() { Val = "24" };
            Languages languages36 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties21.Append(runFonts38);
            paragraphMarkRunProperties21.Append(color38);
            paragraphMarkRunProperties21.Append(fontSize38);
            paragraphMarkRunProperties21.Append(fontSizeComplexScript38);
            paragraphMarkRunProperties21.Append(languages36);

            paragraphProperties21.Append(widowControl21);
            paragraphProperties21.Append(autoSpaceDE21);
            paragraphProperties21.Append(autoSpaceDN21);
            paragraphProperties21.Append(adjustRightIndent21);
            paragraphProperties21.Append(spacingBetweenLines21);
            paragraphProperties21.Append(justification17);
            paragraphProperties21.Append(paragraphMarkRunProperties21);

            Run run18 = new Run();

            RunProperties runProperties18 = new RunProperties();
            RunFonts runFonts39 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color39 = new Color() { Val = "000000" };
            FontSize fontSize39 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "24" };
            Languages languages37 = new Languages() { Val = "ru" };

            runProperties18.Append(runFonts39);
            runProperties18.Append(color39);
            runProperties18.Append(fontSize39);
            runProperties18.Append(fontSizeComplexScript39);
            runProperties18.Append(languages37);
            Text text16 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text16.Text = "     (подпись)";

            run18.Append(runProperties18);
            run18.Append(text16);

            paragraph21.Append(paragraphProperties21);
            paragraph21.Append(run18);

            Paragraph paragraph22 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties22 = new ParagraphProperties();
            WidowControl widowControl22 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE22 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN22 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent22 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines22 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification18 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
            RunFonts runFonts40 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color40 = new Color() { Val = "000000" };
            FontSize fontSize40 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "24" };
            Languages languages38 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties22.Append(runFonts40);
            paragraphMarkRunProperties22.Append(color40);
            paragraphMarkRunProperties22.Append(fontSize40);
            paragraphMarkRunProperties22.Append(fontSizeComplexScript40);
            paragraphMarkRunProperties22.Append(languages38);

            paragraphProperties22.Append(widowControl22);
            paragraphProperties22.Append(autoSpaceDE22);
            paragraphProperties22.Append(autoSpaceDN22);
            paragraphProperties22.Append(adjustRightIndent22);
            paragraphProperties22.Append(spacingBetweenLines22);
            paragraphProperties22.Append(justification18);
            paragraphProperties22.Append(paragraphMarkRunProperties22);

            Run run19 = new Run();

            RunProperties runProperties19 = new RunProperties();
            RunFonts runFonts41 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color41 = new Color() { Val = "000000" };
            FontSize fontSize41 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "24" };
            Languages languages39 = new Languages() { Val = "ru" };

            runProperties19.Append(runFonts41);
            runProperties19.Append(color41);
            runProperties19.Append(fontSize41);
            runProperties19.Append(fontSizeComplexScript41);
            runProperties19.Append(languages39);
            Text text17 = new Text();
            text17.Text = "«__» __________________ 20__г.";

            run19.Append(runProperties19);
            run19.Append(text17);

            paragraph22.Append(paragraphProperties22);
            paragraph22.Append(run19);

            Paragraph paragraph23 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties23 = new ParagraphProperties();
            WidowControl widowControl23 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE23 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN23 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent23 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines23 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification19 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
            RunFonts runFonts42 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color42 = new Color() { Val = "000000" };
            FontSize fontSize42 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript42 = new FontSizeComplexScript() { Val = "24" };
            Languages languages40 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties23.Append(runFonts42);
            paragraphMarkRunProperties23.Append(color42);
            paragraphMarkRunProperties23.Append(fontSize42);
            paragraphMarkRunProperties23.Append(fontSizeComplexScript42);
            paragraphMarkRunProperties23.Append(languages40);

            paragraphProperties23.Append(widowControl23);
            paragraphProperties23.Append(autoSpaceDE23);
            paragraphProperties23.Append(autoSpaceDN23);
            paragraphProperties23.Append(adjustRightIndent23);
            paragraphProperties23.Append(spacingBetweenLines23);
            paragraphProperties23.Append(justification19);
            paragraphProperties23.Append(paragraphMarkRunProperties23);

            Run run20 = new Run();

            RunProperties runProperties20 = new RunProperties();
            RunFonts runFonts43 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color43 = new Color() { Val = "000000" };
            FontSize fontSize43 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript43 = new FontSizeComplexScript() { Val = "24" };
            Languages languages41 = new Languages() { Val = "ru" };

            runProperties20.Append(runFonts43);
            runProperties20.Append(color43);
            runProperties20.Append(fontSize43);
            runProperties20.Append(fontSizeComplexScript43);
            runProperties20.Append(languages41);
            Text text18 = new Text();
            text18.Text = "Заместитель директора по УМ и ВР";

            run20.Append(runProperties20);
            run20.Append(text18);

            paragraph23.Append(paragraphProperties23);
            paragraph23.Append(run20);

            Paragraph paragraph24 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties24 = new ParagraphProperties();
            WidowControl widowControl24 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE24 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN24 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent24 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines24 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification20 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
            RunFonts runFonts44 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color44 = new Color() { Val = "000000" };
            FontSize fontSize44 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript44 = new FontSizeComplexScript() { Val = "24" };
            Languages languages42 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties24.Append(runFonts44);
            paragraphMarkRunProperties24.Append(color44);
            paragraphMarkRunProperties24.Append(fontSize44);
            paragraphMarkRunProperties24.Append(fontSizeComplexScript44);
            paragraphMarkRunProperties24.Append(languages42);

            paragraphProperties24.Append(widowControl24);
            paragraphProperties24.Append(autoSpaceDE24);
            paragraphProperties24.Append(autoSpaceDN24);
            paragraphProperties24.Append(adjustRightIndent24);
            paragraphProperties24.Append(spacingBetweenLines24);
            paragraphProperties24.Append(justification20);
            paragraphProperties24.Append(paragraphMarkRunProperties24);

            Run run21 = new Run();

            RunProperties runProperties21 = new RunProperties();
            RunFonts runFonts45 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color45 = new Color() { Val = "000000" };
            FontSize fontSize45 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript45 = new FontSizeComplexScript() { Val = "24" };
            Languages languages43 = new Languages() { Val = "ru" };

            runProperties21.Append(runFonts45);
            runProperties21.Append(color45);
            runProperties21.Append(fontSize45);
            runProperties21.Append(fontSizeComplexScript45);
            runProperties21.Append(languages43);
            Text text19 = new Text();
            text19.Text = "_____________________ /Л. Н. Иванова/";

            run21.Append(runProperties21);
            run21.Append(text19);

            paragraph24.Append(paragraphProperties24);
            paragraph24.Append(run21);

            Paragraph paragraph25 = new Paragraph() { RsidParagraphAddition = "00524100", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties25 = new ParagraphProperties();
            WidowControl widowControl25 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE25 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN25 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent25 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines25 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification21 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
            RunFonts runFonts46 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color46 = new Color() { Val = "000000" };
            FontSize fontSize46 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript46 = new FontSizeComplexScript() { Val = "24" };
            Languages languages44 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties25.Append(runFonts46);
            paragraphMarkRunProperties25.Append(color46);
            paragraphMarkRunProperties25.Append(fontSize46);
            paragraphMarkRunProperties25.Append(fontSizeComplexScript46);
            paragraphMarkRunProperties25.Append(languages44);

            paragraphProperties25.Append(widowControl25);
            paragraphProperties25.Append(autoSpaceDE25);
            paragraphProperties25.Append(autoSpaceDN25);
            paragraphProperties25.Append(adjustRightIndent25);
            paragraphProperties25.Append(spacingBetweenLines25);
            paragraphProperties25.Append(justification21);
            paragraphProperties25.Append(paragraphMarkRunProperties25);

            Run run22 = new Run();

            RunProperties runProperties22 = new RunProperties();
            RunFonts runFonts47 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color47 = new Color() { Val = "000000" };
            FontSize fontSize47 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript47 = new FontSizeComplexScript() { Val = "24" };
            Languages languages45 = new Languages() { Val = "ru" };

            runProperties22.Append(runFonts47);
            runProperties22.Append(color47);
            runProperties22.Append(fontSize47);
            runProperties22.Append(fontSizeComplexScript47);
            runProperties22.Append(languages45);
            Text text20 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text20.Text = "     (подпись)";

            run22.Append(runProperties22);
            run22.Append(text20);

            paragraph25.Append(paragraphProperties25);
            paragraph25.Append(run22);

            Paragraph paragraph26 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties26 = new ParagraphProperties();
            WidowControl widowControl26 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE26 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN26 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent26 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines26 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification22 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
            RunFonts runFonts48 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color48 = new Color() { Val = "000000" };
            FontSize fontSize48 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript48 = new FontSizeComplexScript() { Val = "24" };
            Languages languages46 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties26.Append(runFonts48);
            paragraphMarkRunProperties26.Append(color48);
            paragraphMarkRunProperties26.Append(fontSize48);
            paragraphMarkRunProperties26.Append(fontSizeComplexScript48);
            paragraphMarkRunProperties26.Append(languages46);

            paragraphProperties26.Append(widowControl26);
            paragraphProperties26.Append(autoSpaceDE26);
            paragraphProperties26.Append(autoSpaceDN26);
            paragraphProperties26.Append(adjustRightIndent26);
            paragraphProperties26.Append(spacingBetweenLines26);
            paragraphProperties26.Append(justification22);
            paragraphProperties26.Append(paragraphMarkRunProperties26);

            Run run23 = new Run();

            RunProperties runProperties23 = new RunProperties();
            RunFonts runFonts49 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color49 = new Color() { Val = "000000" };
            FontSize fontSize49 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript49 = new FontSizeComplexScript() { Val = "24" };
            Languages languages47 = new Languages() { Val = "ru" };

            runProperties23.Append(runFonts49);
            runProperties23.Append(color49);
            runProperties23.Append(fontSize49);
            runProperties23.Append(fontSizeComplexScript49);
            runProperties23.Append(languages47);
            Text text21 = new Text();
            text21.Text = "«__» __________________ 20__г.";

            run23.Append(runProperties23);
            run23.Append(text21);

            paragraph26.Append(paragraphProperties26);
            paragraph26.Append(run23);

            Paragraph paragraph27 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00E60584" };

            ParagraphProperties paragraphProperties27 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE27 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN27 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent27 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines27 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification23 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
            RunFonts runFonts50 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color50 = new Color() { Val = "000000" };
            FontSize fontSize50 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript50 = new FontSizeComplexScript() { Val = "28" };
            Languages languages48 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties27.Append(runFonts50);
            paragraphMarkRunProperties27.Append(color50);
            paragraphMarkRunProperties27.Append(fontSize50);
            paragraphMarkRunProperties27.Append(fontSizeComplexScript50);
            paragraphMarkRunProperties27.Append(languages48);

            paragraphProperties27.Append(autoSpaceDE27);
            paragraphProperties27.Append(autoSpaceDN27);
            paragraphProperties27.Append(adjustRightIndent27);
            paragraphProperties27.Append(spacingBetweenLines27);
            paragraphProperties27.Append(justification23);
            paragraphProperties27.Append(paragraphMarkRunProperties27);

            Run run24 = new Run();

            RunProperties runProperties24 = new RunProperties();
            RunFonts runFonts51 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color51 = new Color() { Val = "000000" };
            FontSize fontSize51 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript51 = new FontSizeComplexScript() { Val = "24" };
            Languages languages49 = new Languages() { Val = "ru" };

            runProperties24.Append(runFonts51);
            runProperties24.Append(color51);
            runProperties24.Append(fontSize51);
            runProperties24.Append(fontSizeComplexScript51);
            runProperties24.Append(languages49);
            Break break2 = new Break() { Type = BreakValues.Page };

            run24.Append(runProperties24);
            run24.Append(break2);

            Run run25 = new Run() { RsidRunAddition = "00FC168C" };

            RunProperties runProperties25 = new RunProperties();
            RunFonts runFonts52 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold10 = new Bold();
            Color color52 = new Color() { Val = "000000" };
            FontSize fontSize52 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript52 = new FontSizeComplexScript() { Val = "28" };
            Languages languages50 = new Languages() { Val = "ru" };

            runProperties25.Append(runFonts52);
            runProperties25.Append(bold10);
            runProperties25.Append(color52);
            runProperties25.Append(fontSize52);
            runProperties25.Append(fontSizeComplexScript52);
            runProperties25.Append(languages50);
            LastRenderedPageBreak lastRenderedPageBreak1 = new LastRenderedPageBreak();
            Text text22 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text22.Text = "    ";

            run25.Append(runProperties25);
            run25.Append(lastRenderedPageBreak1);
            run25.Append(text22);

            Run run26 = new Run() { RsidRunAddition = "00FC168C" };

            RunProperties runProperties26 = new RunProperties();
            RunFonts runFonts53 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color53 = new Color() { Val = "000000" };
            FontSize fontSize53 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript53 = new FontSizeComplexScript() { Val = "28" };
            Languages languages51 = new Languages() { Val = "ru" };

            runProperties26.Append(runFonts53);
            runProperties26.Append(color53);
            runProperties26.Append(fontSize53);
            runProperties26.Append(fontSizeComplexScript53);
            runProperties26.Append(languages51);
            Text text23 = new Text();
            text23.Text = "Рабочая программа учебной дисциплины разработана на основе Федерального государственного образовательного стандарта (далее - ФГОС) (приказ Министерства образования и науки РФ от 18.04.2014 № 349) по специальности среднего профессионального образования (далее СПО) 15.02.07 Автоматизация технологических процессов и производств (по отраслям), в соответствии с учебным планом.";

            run26.Append(runProperties26);
            run26.Append(text23);

            paragraph27.Append(paragraphProperties27);
            paragraph27.Append(run24);
            paragraph27.Append(run25);
            paragraph27.Append(run26);

            Paragraph paragraph28 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties28 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE28 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN28 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent28 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines28 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification24 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
            RunFonts runFonts54 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color54 = new Color() { Val = "000000" };
            FontSize fontSize54 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript54 = new FontSizeComplexScript() { Val = "28" };
            Languages languages52 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties28.Append(runFonts54);
            paragraphMarkRunProperties28.Append(color54);
            paragraphMarkRunProperties28.Append(fontSize54);
            paragraphMarkRunProperties28.Append(fontSizeComplexScript54);
            paragraphMarkRunProperties28.Append(languages52);

            paragraphProperties28.Append(autoSpaceDE28);
            paragraphProperties28.Append(autoSpaceDN28);
            paragraphProperties28.Append(adjustRightIndent28);
            paragraphProperties28.Append(spacingBetweenLines28);
            paragraphProperties28.Append(justification24);
            paragraphProperties28.Append(paragraphMarkRunProperties28);

            paragraph28.Append(paragraphProperties28);

            Paragraph paragraph29 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties29 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE29 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN29 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent29 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines29 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification25 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
            RunFonts runFonts55 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color55 = new Color() { Val = "000000" };
            FontSize fontSize55 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript55 = new FontSizeComplexScript() { Val = "28" };
            Languages languages53 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties29.Append(runFonts55);
            paragraphMarkRunProperties29.Append(color55);
            paragraphMarkRunProperties29.Append(fontSize55);
            paragraphMarkRunProperties29.Append(fontSizeComplexScript55);
            paragraphMarkRunProperties29.Append(languages53);

            paragraphProperties29.Append(autoSpaceDE29);
            paragraphProperties29.Append(autoSpaceDN29);
            paragraphProperties29.Append(adjustRightIndent29);
            paragraphProperties29.Append(spacingBetweenLines29);
            paragraphProperties29.Append(justification25);
            paragraphProperties29.Append(paragraphMarkRunProperties29);

            Run run27 = new Run();

            RunProperties runProperties27 = new RunProperties();
            RunFonts runFonts56 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold11 = new Bold();
            Color color56 = new Color() { Val = "000000" };
            FontSize fontSize56 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript56 = new FontSizeComplexScript() { Val = "28" };
            Languages languages54 = new Languages() { Val = "ru" };

            runProperties27.Append(runFonts56);
            runProperties27.Append(bold11);
            runProperties27.Append(color56);
            runProperties27.Append(fontSize56);
            runProperties27.Append(fontSizeComplexScript56);
            runProperties27.Append(languages54);
            Text text24 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text24.Text = "    Организация разработчик:";

            run27.Append(runProperties27);
            run27.Append(text24);

            Run run28 = new Run();

            RunProperties runProperties28 = new RunProperties();
            RunFonts runFonts57 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color57 = new Color() { Val = "000000" };
            FontSize fontSize57 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript57 = new FontSizeComplexScript() { Val = "28" };
            Languages languages55 = new Languages() { Val = "ru" };

            runProperties28.Append(runFonts57);
            runProperties28.Append(color57);
            runProperties28.Append(fontSize57);
            runProperties28.Append(fontSizeComplexScript57);
            runProperties28.Append(languages55);
            Text text25 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text25.Text = " Федеральное государственное бюджетное образовательное учреждение высшего образования «Новгородский государственный университет имени Ярослава Мудрого» Многопрофильный колледж НовГУ, Политехнический колледж.";

            run28.Append(runProperties28);
            run28.Append(text25);

            paragraph29.Append(paragraphProperties29);
            paragraph29.Append(run27);
            paragraph29.Append(run28);

            Paragraph paragraph30 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties30 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE30 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN30 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent30 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines30 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification26 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
            RunFonts runFonts58 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color58 = new Color() { Val = "000000" };
            FontSize fontSize58 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript58 = new FontSizeComplexScript() { Val = "28" };
            Languages languages56 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties30.Append(runFonts58);
            paragraphMarkRunProperties30.Append(color58);
            paragraphMarkRunProperties30.Append(fontSize58);
            paragraphMarkRunProperties30.Append(fontSizeComplexScript58);
            paragraphMarkRunProperties30.Append(languages56);

            paragraphProperties30.Append(autoSpaceDE30);
            paragraphProperties30.Append(autoSpaceDN30);
            paragraphProperties30.Append(adjustRightIndent30);
            paragraphProperties30.Append(spacingBetweenLines30);
            paragraphProperties30.Append(justification26);
            paragraphProperties30.Append(paragraphMarkRunProperties30);

            paragraph30.Append(paragraphProperties30);

            Paragraph paragraph31 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties31 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE31 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN31 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent31 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines31 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification27 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
            RunFonts runFonts59 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold12 = new Bold();
            Color color59 = new Color() { Val = "000000" };
            FontSize fontSize59 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript59 = new FontSizeComplexScript() { Val = "28" };
            Languages languages57 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties31.Append(runFonts59);
            paragraphMarkRunProperties31.Append(bold12);
            paragraphMarkRunProperties31.Append(color59);
            paragraphMarkRunProperties31.Append(fontSize59);
            paragraphMarkRunProperties31.Append(fontSizeComplexScript59);
            paragraphMarkRunProperties31.Append(languages57);

            paragraphProperties31.Append(autoSpaceDE31);
            paragraphProperties31.Append(autoSpaceDN31);
            paragraphProperties31.Append(adjustRightIndent31);
            paragraphProperties31.Append(spacingBetweenLines31);
            paragraphProperties31.Append(justification27);
            paragraphProperties31.Append(paragraphMarkRunProperties31);

            Run run29 = new Run();

            RunProperties runProperties29 = new RunProperties();
            RunFonts runFonts60 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold13 = new Bold();
            Color color60 = new Color() { Val = "000000" };
            FontSize fontSize60 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript60 = new FontSizeComplexScript() { Val = "28" };
            Languages languages58 = new Languages() { Val = "ru" };

            runProperties29.Append(runFonts60);
            runProperties29.Append(bold13);
            runProperties29.Append(color60);
            runProperties29.Append(fontSize60);
            runProperties29.Append(fontSizeComplexScript60);
            runProperties29.Append(languages58);
            Text text26 = new Text();
            text26.Text = "Разработчик:";

            run29.Append(runProperties29);
            run29.Append(text26);

            paragraph31.Append(paragraphProperties31);
            paragraph31.Append(run29);

            Paragraph paragraph32 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties32 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE32 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN32 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent32 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines32 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification28 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties32 = new ParagraphMarkRunProperties();
            RunFonts runFonts61 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold14 = new Bold();
            Color color61 = new Color() { Val = "000000" };
            FontSize fontSize61 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript61 = new FontSizeComplexScript() { Val = "28" };
            Languages languages59 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties32.Append(runFonts61);
            paragraphMarkRunProperties32.Append(bold14);
            paragraphMarkRunProperties32.Append(color61);
            paragraphMarkRunProperties32.Append(fontSize61);
            paragraphMarkRunProperties32.Append(fontSizeComplexScript61);
            paragraphMarkRunProperties32.Append(languages59);

            paragraphProperties32.Append(autoSpaceDE32);
            paragraphProperties32.Append(autoSpaceDN32);
            paragraphProperties32.Append(adjustRightIndent32);
            paragraphProperties32.Append(spacingBetweenLines32);
            paragraphProperties32.Append(justification28);
            paragraphProperties32.Append(paragraphMarkRunProperties32);

            paragraph32.Append(paragraphProperties32);

            Paragraph paragraph33 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties33 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE33 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN33 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent33 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines33 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification29 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
            RunFonts runFonts62 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color62 = new Color() { Val = "000000" };
            FontSize fontSize62 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript62 = new FontSizeComplexScript() { Val = "28" };
            Languages languages60 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties33.Append(runFonts62);
            paragraphMarkRunProperties33.Append(color62);
            paragraphMarkRunProperties33.Append(fontSize62);
            paragraphMarkRunProperties33.Append(fontSizeComplexScript62);
            paragraphMarkRunProperties33.Append(languages60);

            paragraphProperties33.Append(autoSpaceDE33);
            paragraphProperties33.Append(autoSpaceDN33);
            paragraphProperties33.Append(adjustRightIndent33);
            paragraphProperties33.Append(spacingBetweenLines33);
            paragraphProperties33.Append(justification29);
            paragraphProperties33.Append(paragraphMarkRunProperties33);

            Run run30 = new Run();

            RunProperties runProperties30 = new RunProperties();
            RunFonts runFonts63 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color63 = new Color() { Val = "000000" };
            FontSize fontSize63 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript63 = new FontSizeComplexScript() { Val = "28" };
            Languages languages61 = new Languages() { Val = "ru" };

            runProperties30.Append(runFonts63);
            runProperties30.Append(color63);
            runProperties30.Append(fontSize63);
            runProperties30.Append(fontSizeComplexScript63);
            runProperties30.Append(languages61);
            Text text27 = new Text();
            text27.Text = "Спиров А.М. - преподаватель гуманитарных и социально-экономических дисциплин ПТК МПК НовГУ";

            run30.Append(runProperties30);
            run30.Append(text27);

            paragraph33.Append(paragraphProperties33);
            paragraph33.Append(run30);

            Paragraph paragraph34 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties34 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE34 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN34 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent34 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines34 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification30 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
            RunFonts runFonts64 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color64 = new Color() { Val = "000000" };
            FontSize fontSize64 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript64 = new FontSizeComplexScript() { Val = "28" };
            Languages languages62 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties34.Append(runFonts64);
            paragraphMarkRunProperties34.Append(color64);
            paragraphMarkRunProperties34.Append(fontSize64);
            paragraphMarkRunProperties34.Append(fontSizeComplexScript64);
            paragraphMarkRunProperties34.Append(languages62);

            paragraphProperties34.Append(autoSpaceDE34);
            paragraphProperties34.Append(autoSpaceDN34);
            paragraphProperties34.Append(adjustRightIndent34);
            paragraphProperties34.Append(spacingBetweenLines34);
            paragraphProperties34.Append(justification30);
            paragraphProperties34.Append(paragraphMarkRunProperties34);

            paragraph34.Append(paragraphProperties34);

            Paragraph paragraph35 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties35 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE35 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN35 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent35 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines35 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification31 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties35 = new ParagraphMarkRunProperties();
            RunFonts runFonts65 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color65 = new Color() { Val = "000000" };
            FontSize fontSize65 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript65 = new FontSizeComplexScript() { Val = "28" };
            Languages languages63 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties35.Append(runFonts65);
            paragraphMarkRunProperties35.Append(color65);
            paragraphMarkRunProperties35.Append(fontSize65);
            paragraphMarkRunProperties35.Append(fontSizeComplexScript65);
            paragraphMarkRunProperties35.Append(languages63);

            paragraphProperties35.Append(autoSpaceDE35);
            paragraphProperties35.Append(autoSpaceDN35);
            paragraphProperties35.Append(adjustRightIndent35);
            paragraphProperties35.Append(spacingBetweenLines35);
            paragraphProperties35.Append(justification31);
            paragraphProperties35.Append(paragraphMarkRunProperties35);

            Run run31 = new Run();

            RunProperties runProperties31 = new RunProperties();
            RunFonts runFonts66 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color66 = new Color() { Val = "000000" };
            FontSize fontSize66 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript66 = new FontSizeComplexScript() { Val = "28" };
            Languages languages64 = new Languages() { Val = "ru" };

            runProperties31.Append(runFonts66);
            runProperties31.Append(color66);
            runProperties31.Append(fontSize66);
            runProperties31.Append(fontSizeComplexScript66);
            runProperties31.Append(languages64);
            Text text28 = new Text();
            text28.Text = "Методические рекомендации (указания) по практическим заданиям приняты на заседании общеобразовательных, общих гуманитарных и социально-экономических и естественно-научных дисциплин колледжа, протокол №___ от___________";

            run31.Append(runProperties31);
            run31.Append(text28);

            paragraph35.Append(paragraphProperties35);
            paragraph35.Append(run31);

            Paragraph paragraph36 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties36 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE36 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN36 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent36 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines36 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification32 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties36 = new ParagraphMarkRunProperties();
            RunFonts runFonts67 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color67 = new Color() { Val = "000000" };
            FontSize fontSize67 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript67 = new FontSizeComplexScript() { Val = "28" };
            Languages languages65 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties36.Append(runFonts67);
            paragraphMarkRunProperties36.Append(color67);
            paragraphMarkRunProperties36.Append(fontSize67);
            paragraphMarkRunProperties36.Append(fontSizeComplexScript67);
            paragraphMarkRunProperties36.Append(languages65);

            paragraphProperties36.Append(autoSpaceDE36);
            paragraphProperties36.Append(autoSpaceDN36);
            paragraphProperties36.Append(adjustRightIndent36);
            paragraphProperties36.Append(spacingBetweenLines36);
            paragraphProperties36.Append(justification32);
            paragraphProperties36.Append(paragraphMarkRunProperties36);

            paragraph36.Append(paragraphProperties36);

            Paragraph paragraph37 = new Paragraph() { RsidParagraphAddition = "00FC168C", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00FC168C" };

            ParagraphProperties paragraphProperties37 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE37 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN37 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent37 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines37 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification33 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties37 = new ParagraphMarkRunProperties();
            RunFonts runFonts68 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color68 = new Color() { Val = "000000" };
            FontSize fontSize68 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript68 = new FontSizeComplexScript() { Val = "28" };
            Languages languages66 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties37.Append(runFonts68);
            paragraphMarkRunProperties37.Append(color68);
            paragraphMarkRunProperties37.Append(fontSize68);
            paragraphMarkRunProperties37.Append(fontSizeComplexScript68);
            paragraphMarkRunProperties37.Append(languages66);

            paragraphProperties37.Append(autoSpaceDE37);
            paragraphProperties37.Append(autoSpaceDN37);
            paragraphProperties37.Append(adjustRightIndent37);
            paragraphProperties37.Append(spacingBetweenLines37);
            paragraphProperties37.Append(justification33);
            paragraphProperties37.Append(paragraphMarkRunProperties37);

            Run run32 = new Run();

            RunProperties runProperties32 = new RunProperties();
            RunFonts runFonts69 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color69 = new Color() { Val = "000000" };
            FontSize fontSize69 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript69 = new FontSizeComplexScript() { Val = "28" };
            Languages languages67 = new Languages() { Val = "ru" };

            runProperties32.Append(runFonts69);
            runProperties32.Append(color69);
            runProperties32.Append(fontSize69);
            runProperties32.Append(fontSizeComplexScript69);
            runProperties32.Append(languages67);
            Text text29 = new Text();
            text29.Text = "Председатель предметной (цикловой) комиссии ________ Л.П. Белорусова";

            run32.Append(runProperties32);
            run32.Append(text29);

            paragraph37.Append(paragraphProperties37);
            paragraph37.Append(run32);

            Paragraph paragraph38 = new Paragraph() { RsidParagraphAddition = "00E60584", RsidParagraphProperties = "00FC168C", RsidRunAdditionDefault = "00E60584" };

            ParagraphProperties paragraphProperties38 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties38 = new ParagraphMarkRunProperties();
            RunFonts runFonts70 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color70 = new Color() { Val = "000000" };
            FontSize fontSize70 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript70 = new FontSizeComplexScript() { Val = "24" };
            Languages languages68 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties38.Append(runFonts70);
            paragraphMarkRunProperties38.Append(color70);
            paragraphMarkRunProperties38.Append(fontSize70);
            paragraphMarkRunProperties38.Append(fontSizeComplexScript70);
            paragraphMarkRunProperties38.Append(languages68);

            paragraphProperties38.Append(paragraphMarkRunProperties38);

            Run run33 = new Run();

            RunProperties runProperties33 = new RunProperties();
            RunFonts runFonts71 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color71 = new Color() { Val = "000000" };
            FontSize fontSize71 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript71 = new FontSizeComplexScript() { Val = "24" };
            Languages languages69 = new Languages() { Val = "ru" };

            runProperties33.Append(runFonts71);
            runProperties33.Append(color71);
            runProperties33.Append(fontSize71);
            runProperties33.Append(fontSizeComplexScript71);
            runProperties33.Append(languages69);
            Break break3 = new Break() { Type = BreakValues.Page };

            run33.Append(runProperties33);
            run33.Append(break3);

            paragraph38.Append(paragraphProperties38);
            paragraph38.Append(run33);

            Paragraph paragraph39 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties39 = new ParagraphProperties();
            WidowControl widowControl27 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE38 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN38 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent38 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines38 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification34 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties39 = new ParagraphMarkRunProperties();
            RunFonts runFonts72 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold15 = new Bold();
            Color color72 = new Color() { Val = "000000" };
            FontSize fontSize72 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript72 = new FontSizeComplexScript() { Val = "24" };
            Languages languages70 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties39.Append(runFonts72);
            paragraphMarkRunProperties39.Append(bold15);
            paragraphMarkRunProperties39.Append(color72);
            paragraphMarkRunProperties39.Append(fontSize72);
            paragraphMarkRunProperties39.Append(fontSizeComplexScript72);
            paragraphMarkRunProperties39.Append(languages70);

            paragraphProperties39.Append(widowControl27);
            paragraphProperties39.Append(autoSpaceDE38);
            paragraphProperties39.Append(autoSpaceDN38);
            paragraphProperties39.Append(adjustRightIndent38);
            paragraphProperties39.Append(spacingBetweenLines38);
            paragraphProperties39.Append(justification34);
            paragraphProperties39.Append(paragraphMarkRunProperties39);

            Run run34 = new Run();

            RunProperties runProperties34 = new RunProperties();
            RunFonts runFonts73 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold16 = new Bold();
            Color color73 = new Color() { Val = "000000" };
            FontSize fontSize73 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript73 = new FontSizeComplexScript() { Val = "24" };
            Languages languages71 = new Languages() { Val = "ru" };

            runProperties34.Append(runFonts73);
            runProperties34.Append(bold16);
            runProperties34.Append(color73);
            runProperties34.Append(fontSize73);
            runProperties34.Append(fontSizeComplexScript73);
            runProperties34.Append(languages71);
            LastRenderedPageBreak lastRenderedPageBreak2 = new LastRenderedPageBreak();
            Text text30 = new Text();
            text30.Text = "СОДЕРЖАНИЕ";

            run34.Append(runProperties34);
            run34.Append(lastRenderedPageBreak2);
            run34.Append(text30);

            paragraph39.Append(paragraphProperties39);
            paragraph39.Append(run34);

            Paragraph paragraph40 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties40 = new ParagraphProperties();
            WidowControl widowControl28 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE39 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN39 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent39 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines39 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification35 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties40 = new ParagraphMarkRunProperties();
            RunFonts runFonts74 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold17 = new Bold();
            Color color74 = new Color() { Val = "000000" };
            FontSize fontSize74 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript74 = new FontSizeComplexScript() { Val = "24" };
            Languages languages72 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties40.Append(runFonts74);
            paragraphMarkRunProperties40.Append(bold17);
            paragraphMarkRunProperties40.Append(color74);
            paragraphMarkRunProperties40.Append(fontSize74);
            paragraphMarkRunProperties40.Append(fontSizeComplexScript74);
            paragraphMarkRunProperties40.Append(languages72);

            paragraphProperties40.Append(widowControl28);
            paragraphProperties40.Append(autoSpaceDE39);
            paragraphProperties40.Append(autoSpaceDN39);
            paragraphProperties40.Append(adjustRightIndent39);
            paragraphProperties40.Append(spacingBetweenLines39);
            paragraphProperties40.Append(justification35);
            paragraphProperties40.Append(paragraphMarkRunProperties40);

            paragraph40.Append(paragraphProperties40);

            Paragraph paragraph41 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties41 = new ParagraphProperties();
            WidowControl widowControl29 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE40 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN40 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent40 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines40 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification36 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties41 = new ParagraphMarkRunProperties();
            RunFonts runFonts75 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color75 = new Color() { Val = "000000" };
            FontSize fontSize75 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript75 = new FontSizeComplexScript() { Val = "24" };
            Languages languages73 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties41.Append(runFonts75);
            paragraphMarkRunProperties41.Append(color75);
            paragraphMarkRunProperties41.Append(fontSize75);
            paragraphMarkRunProperties41.Append(fontSizeComplexScript75);
            paragraphMarkRunProperties41.Append(languages73);

            paragraphProperties41.Append(widowControl29);
            paragraphProperties41.Append(autoSpaceDE40);
            paragraphProperties41.Append(autoSpaceDN40);
            paragraphProperties41.Append(adjustRightIndent40);
            paragraphProperties41.Append(spacingBetweenLines40);
            paragraphProperties41.Append(justification36);
            paragraphProperties41.Append(paragraphMarkRunProperties41);

            Run run35 = new Run();

            RunProperties runProperties35 = new RunProperties();
            RunFonts runFonts76 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color76 = new Color() { Val = "000000" };
            FontSize fontSize76 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript76 = new FontSizeComplexScript() { Val = "24" };
            Languages languages74 = new Languages() { Val = "ru" };

            runProperties35.Append(runFonts76);
            runProperties35.Append(color76);
            runProperties35.Append(fontSize76);
            runProperties35.Append(fontSizeComplexScript76);
            runProperties35.Append(languages74);
            Text text31 = new Text();
            text31.Text = "1. ПАСПОРТ РАБОЧЕЙ ПРОГРАММЫ УЧЕБНОЙ ДИСЦИПЛИНЫ .................4";

            run35.Append(runProperties35);
            run35.Append(text31);

            paragraph41.Append(paragraphProperties41);
            paragraph41.Append(run35);

            Paragraph paragraph42 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties42 = new ParagraphProperties();
            WidowControl widowControl30 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE41 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN41 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent41 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines41 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification37 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties42 = new ParagraphMarkRunProperties();
            RunFonts runFonts77 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color77 = new Color() { Val = "000000" };
            FontSize fontSize77 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript77 = new FontSizeComplexScript() { Val = "24" };
            Languages languages75 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties42.Append(runFonts77);
            paragraphMarkRunProperties42.Append(color77);
            paragraphMarkRunProperties42.Append(fontSize77);
            paragraphMarkRunProperties42.Append(fontSizeComplexScript77);
            paragraphMarkRunProperties42.Append(languages75);

            paragraphProperties42.Append(widowControl30);
            paragraphProperties42.Append(autoSpaceDE41);
            paragraphProperties42.Append(autoSpaceDN41);
            paragraphProperties42.Append(adjustRightIndent41);
            paragraphProperties42.Append(spacingBetweenLines41);
            paragraphProperties42.Append(justification37);
            paragraphProperties42.Append(paragraphMarkRunProperties42);

            paragraph42.Append(paragraphProperties42);

            Paragraph paragraph43 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties43 = new ParagraphProperties();
            WidowControl widowControl31 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE42 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN42 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent42 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines42 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification38 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties43 = new ParagraphMarkRunProperties();
            RunFonts runFonts78 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color78 = new Color() { Val = "000000" };
            FontSize fontSize78 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript78 = new FontSizeComplexScript() { Val = "24" };
            Languages languages76 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties43.Append(runFonts78);
            paragraphMarkRunProperties43.Append(color78);
            paragraphMarkRunProperties43.Append(fontSize78);
            paragraphMarkRunProperties43.Append(fontSizeComplexScript78);
            paragraphMarkRunProperties43.Append(languages76);

            paragraphProperties43.Append(widowControl31);
            paragraphProperties43.Append(autoSpaceDE42);
            paragraphProperties43.Append(autoSpaceDN42);
            paragraphProperties43.Append(adjustRightIndent42);
            paragraphProperties43.Append(spacingBetweenLines42);
            paragraphProperties43.Append(justification38);
            paragraphProperties43.Append(paragraphMarkRunProperties43);

            Run run36 = new Run();

            RunProperties runProperties36 = new RunProperties();
            RunFonts runFonts79 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color79 = new Color() { Val = "000000" };
            FontSize fontSize79 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript79 = new FontSizeComplexScript() { Val = "24" };
            Languages languages77 = new Languages() { Val = "ru" };

            runProperties36.Append(runFonts79);
            runProperties36.Append(color79);
            runProperties36.Append(fontSize79);
            runProperties36.Append(fontSizeComplexScript79);
            runProperties36.Append(languages77);
            Text text32 = new Text();
            text32.Text = "1.1 Область применения программы.........................................................................4";

            run36.Append(runProperties36);
            run36.Append(text32);

            paragraph43.Append(paragraphProperties43);
            paragraph43.Append(run36);

            Paragraph paragraph44 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties44 = new ParagraphProperties();
            WidowControl widowControl32 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE43 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN43 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent43 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines43 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification39 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties44 = new ParagraphMarkRunProperties();
            RunFonts runFonts80 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color80 = new Color() { Val = "000000" };
            FontSize fontSize80 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript80 = new FontSizeComplexScript() { Val = "24" };
            Languages languages78 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties44.Append(runFonts80);
            paragraphMarkRunProperties44.Append(color80);
            paragraphMarkRunProperties44.Append(fontSize80);
            paragraphMarkRunProperties44.Append(fontSizeComplexScript80);
            paragraphMarkRunProperties44.Append(languages78);

            paragraphProperties44.Append(widowControl32);
            paragraphProperties44.Append(autoSpaceDE43);
            paragraphProperties44.Append(autoSpaceDN43);
            paragraphProperties44.Append(adjustRightIndent43);
            paragraphProperties44.Append(spacingBetweenLines43);
            paragraphProperties44.Append(justification39);
            paragraphProperties44.Append(paragraphMarkRunProperties44);

            paragraph44.Append(paragraphProperties44);

            Paragraph paragraph45 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties45 = new ParagraphProperties();
            WidowControl widowControl33 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE44 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN44 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent44 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines44 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification40 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties45 = new ParagraphMarkRunProperties();
            RunFonts runFonts81 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color81 = new Color() { Val = "000000" };
            FontSize fontSize81 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript81 = new FontSizeComplexScript() { Val = "24" };
            Languages languages79 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties45.Append(runFonts81);
            paragraphMarkRunProperties45.Append(color81);
            paragraphMarkRunProperties45.Append(fontSize81);
            paragraphMarkRunProperties45.Append(fontSizeComplexScript81);
            paragraphMarkRunProperties45.Append(languages79);

            paragraphProperties45.Append(widowControl33);
            paragraphProperties45.Append(autoSpaceDE44);
            paragraphProperties45.Append(autoSpaceDN44);
            paragraphProperties45.Append(adjustRightIndent44);
            paragraphProperties45.Append(spacingBetweenLines44);
            paragraphProperties45.Append(justification40);
            paragraphProperties45.Append(paragraphMarkRunProperties45);

            Run run37 = new Run();

            RunProperties runProperties37 = new RunProperties();
            RunFonts runFonts82 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color82 = new Color() { Val = "000000" };
            FontSize fontSize82 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript82 = new FontSizeComplexScript() { Val = "24" };
            Languages languages80 = new Languages() { Val = "ru" };

            runProperties37.Append(runFonts82);
            runProperties37.Append(color82);
            runProperties37.Append(fontSize82);
            runProperties37.Append(fontSizeComplexScript82);
            runProperties37.Append(languages80);
            Text text33 = new Text();
            text33.Text = "1.2 Место учебной дисциплины в структуре основной профессиональной образовательной программы......................................................................................4";

            run37.Append(runProperties37);
            run37.Append(text33);

            paragraph45.Append(paragraphProperties45);
            paragraph45.Append(run37);

            Paragraph paragraph46 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties46 = new ParagraphProperties();
            WidowControl widowControl34 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE45 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN45 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent45 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines45 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification41 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties46 = new ParagraphMarkRunProperties();
            RunFonts runFonts83 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color83 = new Color() { Val = "000000" };
            FontSize fontSize83 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript83 = new FontSizeComplexScript() { Val = "24" };
            Languages languages81 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties46.Append(runFonts83);
            paragraphMarkRunProperties46.Append(color83);
            paragraphMarkRunProperties46.Append(fontSize83);
            paragraphMarkRunProperties46.Append(fontSizeComplexScript83);
            paragraphMarkRunProperties46.Append(languages81);

            paragraphProperties46.Append(widowControl34);
            paragraphProperties46.Append(autoSpaceDE45);
            paragraphProperties46.Append(autoSpaceDN45);
            paragraphProperties46.Append(adjustRightIndent45);
            paragraphProperties46.Append(spacingBetweenLines45);
            paragraphProperties46.Append(justification41);
            paragraphProperties46.Append(paragraphMarkRunProperties46);

            paragraph46.Append(paragraphProperties46);

            Paragraph paragraph47 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties47 = new ParagraphProperties();
            WidowControl widowControl35 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE46 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN46 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent46 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines46 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification42 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties47 = new ParagraphMarkRunProperties();
            RunFonts runFonts84 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color84 = new Color() { Val = "000000" };
            FontSize fontSize84 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript84 = new FontSizeComplexScript() { Val = "24" };
            Languages languages82 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties47.Append(runFonts84);
            paragraphMarkRunProperties47.Append(color84);
            paragraphMarkRunProperties47.Append(fontSize84);
            paragraphMarkRunProperties47.Append(fontSizeComplexScript84);
            paragraphMarkRunProperties47.Append(languages82);

            paragraphProperties47.Append(widowControl35);
            paragraphProperties47.Append(autoSpaceDE46);
            paragraphProperties47.Append(autoSpaceDN46);
            paragraphProperties47.Append(adjustRightIndent46);
            paragraphProperties47.Append(spacingBetweenLines46);
            paragraphProperties47.Append(justification42);
            paragraphProperties47.Append(paragraphMarkRunProperties47);

            Run run38 = new Run();

            RunProperties runProperties38 = new RunProperties();
            RunFonts runFonts85 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color85 = new Color() { Val = "000000" };
            FontSize fontSize85 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript85 = new FontSizeComplexScript() { Val = "24" };
            Languages languages83 = new Languages() { Val = "ru" };

            runProperties38.Append(runFonts85);
            runProperties38.Append(color85);
            runProperties38.Append(fontSize85);
            runProperties38.Append(fontSizeComplexScript85);
            runProperties38.Append(languages83);
            Text text34 = new Text();
            text34.Text = "1.3 Цели и задачи учебной дисциплины - требования к результатам освоения учебной дисциплины ..................................................................................................4";

            run38.Append(runProperties38);
            run38.Append(text34);

            paragraph47.Append(paragraphProperties47);
            paragraph47.Append(run38);

            Paragraph paragraph48 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties48 = new ParagraphProperties();
            WidowControl widowControl36 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE47 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN47 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent47 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines47 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification43 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties48 = new ParagraphMarkRunProperties();
            RunFonts runFonts86 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color86 = new Color() { Val = "000000" };
            FontSize fontSize86 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript86 = new FontSizeComplexScript() { Val = "24" };
            Languages languages84 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties48.Append(runFonts86);
            paragraphMarkRunProperties48.Append(color86);
            paragraphMarkRunProperties48.Append(fontSize86);
            paragraphMarkRunProperties48.Append(fontSizeComplexScript86);
            paragraphMarkRunProperties48.Append(languages84);

            paragraphProperties48.Append(widowControl36);
            paragraphProperties48.Append(autoSpaceDE47);
            paragraphProperties48.Append(autoSpaceDN47);
            paragraphProperties48.Append(adjustRightIndent47);
            paragraphProperties48.Append(spacingBetweenLines47);
            paragraphProperties48.Append(justification43);
            paragraphProperties48.Append(paragraphMarkRunProperties48);

            paragraph48.Append(paragraphProperties48);

            Paragraph paragraph49 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties49 = new ParagraphProperties();
            WidowControl widowControl37 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE48 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN48 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent48 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines48 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification44 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties49 = new ParagraphMarkRunProperties();
            RunFonts runFonts87 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color87 = new Color() { Val = "000000" };
            FontSize fontSize87 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript87 = new FontSizeComplexScript() { Val = "24" };
            Languages languages85 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties49.Append(runFonts87);
            paragraphMarkRunProperties49.Append(color87);
            paragraphMarkRunProperties49.Append(fontSize87);
            paragraphMarkRunProperties49.Append(fontSizeComplexScript87);
            paragraphMarkRunProperties49.Append(languages85);

            paragraphProperties49.Append(widowControl37);
            paragraphProperties49.Append(autoSpaceDE48);
            paragraphProperties49.Append(autoSpaceDN48);
            paragraphProperties49.Append(adjustRightIndent48);
            paragraphProperties49.Append(spacingBetweenLines48);
            paragraphProperties49.Append(justification44);
            paragraphProperties49.Append(paragraphMarkRunProperties49);

            Run run39 = new Run();

            RunProperties runProperties39 = new RunProperties();
            RunFonts runFonts88 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color88 = new Color() { Val = "000000" };
            FontSize fontSize88 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript88 = new FontSizeComplexScript() { Val = "24" };
            Languages languages86 = new Languages() { Val = "ru" };

            runProperties39.Append(runFonts88);
            runProperties39.Append(color88);
            runProperties39.Append(fontSize88);
            runProperties39.Append(fontSizeComplexScript88);
            runProperties39.Append(languages86);
            Text text35 = new Text();
            text35.Text = "1.4 Перечень формируемых компетенций.................................................................4";

            run39.Append(runProperties39);
            run39.Append(text35);

            paragraph49.Append(paragraphProperties49);
            paragraph49.Append(run39);

            Paragraph paragraph50 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties50 = new ParagraphProperties();
            WidowControl widowControl38 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE49 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN49 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent49 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines49 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification45 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties50 = new ParagraphMarkRunProperties();
            RunFonts runFonts89 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color89 = new Color() { Val = "000000" };
            FontSize fontSize89 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript89 = new FontSizeComplexScript() { Val = "24" };
            Languages languages87 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties50.Append(runFonts89);
            paragraphMarkRunProperties50.Append(color89);
            paragraphMarkRunProperties50.Append(fontSize89);
            paragraphMarkRunProperties50.Append(fontSizeComplexScript89);
            paragraphMarkRunProperties50.Append(languages87);

            paragraphProperties50.Append(widowControl38);
            paragraphProperties50.Append(autoSpaceDE49);
            paragraphProperties50.Append(autoSpaceDN49);
            paragraphProperties50.Append(adjustRightIndent49);
            paragraphProperties50.Append(spacingBetweenLines49);
            paragraphProperties50.Append(justification45);
            paragraphProperties50.Append(paragraphMarkRunProperties50);

            paragraph50.Append(paragraphProperties50);

            Paragraph paragraph51 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties51 = new ParagraphProperties();
            WidowControl widowControl39 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE50 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN50 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent50 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines50 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification46 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties51 = new ParagraphMarkRunProperties();
            RunFonts runFonts90 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color90 = new Color() { Val = "000000" };
            FontSize fontSize90 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript90 = new FontSizeComplexScript() { Val = "24" };
            Languages languages88 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties51.Append(runFonts90);
            paragraphMarkRunProperties51.Append(color90);
            paragraphMarkRunProperties51.Append(fontSize90);
            paragraphMarkRunProperties51.Append(fontSizeComplexScript90);
            paragraphMarkRunProperties51.Append(languages88);

            paragraphProperties51.Append(widowControl39);
            paragraphProperties51.Append(autoSpaceDE50);
            paragraphProperties51.Append(autoSpaceDN50);
            paragraphProperties51.Append(adjustRightIndent50);
            paragraphProperties51.Append(spacingBetweenLines50);
            paragraphProperties51.Append(justification46);
            paragraphProperties51.Append(paragraphMarkRunProperties51);

            Run run40 = new Run();

            RunProperties runProperties40 = new RunProperties();
            RunFonts runFonts91 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color91 = new Color() { Val = "000000" };
            FontSize fontSize91 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript91 = new FontSizeComplexScript() { Val = "24" };
            Languages languages89 = new Languages() { Val = "ru" };

            runProperties40.Append(runFonts91);
            runProperties40.Append(color91);
            runProperties40.Append(fontSize91);
            runProperties40.Append(fontSizeComplexScript91);
            runProperties40.Append(languages89);
            Text text36 = new Text();
            text36.Text = "1.5 Рекомендуемое количество часов на освоение учебной дисциплины.............5";

            run40.Append(runProperties40);
            run40.Append(text36);

            paragraph51.Append(paragraphProperties51);
            paragraph51.Append(run40);

            Paragraph paragraph52 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties52 = new ParagraphProperties();
            WidowControl widowControl40 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE51 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN51 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent51 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines51 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification47 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties52 = new ParagraphMarkRunProperties();
            RunFonts runFonts92 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color92 = new Color() { Val = "000000" };
            FontSize fontSize92 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript92 = new FontSizeComplexScript() { Val = "24" };
            Languages languages90 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties52.Append(runFonts92);
            paragraphMarkRunProperties52.Append(color92);
            paragraphMarkRunProperties52.Append(fontSize92);
            paragraphMarkRunProperties52.Append(fontSizeComplexScript92);
            paragraphMarkRunProperties52.Append(languages90);

            paragraphProperties52.Append(widowControl40);
            paragraphProperties52.Append(autoSpaceDE51);
            paragraphProperties52.Append(autoSpaceDN51);
            paragraphProperties52.Append(adjustRightIndent51);
            paragraphProperties52.Append(spacingBetweenLines51);
            paragraphProperties52.Append(justification47);
            paragraphProperties52.Append(paragraphMarkRunProperties52);

            paragraph52.Append(paragraphProperties52);

            Paragraph paragraph53 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties53 = new ParagraphProperties();
            WidowControl widowControl41 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE52 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN52 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent52 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines52 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification48 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties53 = new ParagraphMarkRunProperties();
            RunFonts runFonts93 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color93 = new Color() { Val = "000000" };
            FontSize fontSize93 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript93 = new FontSizeComplexScript() { Val = "24" };
            Languages languages91 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties53.Append(runFonts93);
            paragraphMarkRunProperties53.Append(color93);
            paragraphMarkRunProperties53.Append(fontSize93);
            paragraphMarkRunProperties53.Append(fontSizeComplexScript93);
            paragraphMarkRunProperties53.Append(languages91);

            paragraphProperties53.Append(widowControl41);
            paragraphProperties53.Append(autoSpaceDE52);
            paragraphProperties53.Append(autoSpaceDN52);
            paragraphProperties53.Append(adjustRightIndent52);
            paragraphProperties53.Append(spacingBetweenLines52);
            paragraphProperties53.Append(justification48);
            paragraphProperties53.Append(paragraphMarkRunProperties53);

            Run run41 = new Run();

            RunProperties runProperties41 = new RunProperties();
            RunFonts runFonts94 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color94 = new Color() { Val = "000000" };
            FontSize fontSize94 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript94 = new FontSizeComplexScript() { Val = "24" };
            Languages languages92 = new Languages() { Val = "ru" };

            runProperties41.Append(runFonts94);
            runProperties41.Append(color94);
            runProperties41.Append(fontSize94);
            runProperties41.Append(fontSizeComplexScript94);
            runProperties41.Append(languages92);
            Text text37 = new Text();
            text37.Text = "2. СТРУКТУРА И СОДЕРЖАНИЕ УЧЕБНОЙ ДИСЦИПЛИНЫ...........................6";

            run41.Append(runProperties41);
            run41.Append(text37);

            paragraph53.Append(paragraphProperties53);
            paragraph53.Append(run41);

            Paragraph paragraph54 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties54 = new ParagraphProperties();
            WidowControl widowControl42 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE53 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN53 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent53 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines53 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification49 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties54 = new ParagraphMarkRunProperties();
            RunFonts runFonts95 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color95 = new Color() { Val = "000000" };
            FontSize fontSize95 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript95 = new FontSizeComplexScript() { Val = "24" };
            Languages languages93 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties54.Append(runFonts95);
            paragraphMarkRunProperties54.Append(color95);
            paragraphMarkRunProperties54.Append(fontSize95);
            paragraphMarkRunProperties54.Append(fontSizeComplexScript95);
            paragraphMarkRunProperties54.Append(languages93);

            paragraphProperties54.Append(widowControl42);
            paragraphProperties54.Append(autoSpaceDE53);
            paragraphProperties54.Append(autoSpaceDN53);
            paragraphProperties54.Append(adjustRightIndent53);
            paragraphProperties54.Append(spacingBetweenLines53);
            paragraphProperties54.Append(justification49);
            paragraphProperties54.Append(paragraphMarkRunProperties54);

            paragraph54.Append(paragraphProperties54);

            Paragraph paragraph55 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties55 = new ParagraphProperties();
            WidowControl widowControl43 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE54 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN54 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent54 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines54 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification50 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties55 = new ParagraphMarkRunProperties();
            RunFonts runFonts96 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color96 = new Color() { Val = "000000" };
            FontSize fontSize96 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript96 = new FontSizeComplexScript() { Val = "24" };
            Languages languages94 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties55.Append(runFonts96);
            paragraphMarkRunProperties55.Append(color96);
            paragraphMarkRunProperties55.Append(fontSize96);
            paragraphMarkRunProperties55.Append(fontSizeComplexScript96);
            paragraphMarkRunProperties55.Append(languages94);

            paragraphProperties55.Append(widowControl43);
            paragraphProperties55.Append(autoSpaceDE54);
            paragraphProperties55.Append(autoSpaceDN54);
            paragraphProperties55.Append(adjustRightIndent54);
            paragraphProperties55.Append(spacingBetweenLines54);
            paragraphProperties55.Append(justification50);
            paragraphProperties55.Append(paragraphMarkRunProperties55);

            Run run42 = new Run();

            RunProperties runProperties42 = new RunProperties();
            RunFonts runFonts97 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color97 = new Color() { Val = "000000" };
            FontSize fontSize97 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript97 = new FontSizeComplexScript() { Val = "24" };
            Languages languages95 = new Languages() { Val = "ru" };

            runProperties42.Append(runFonts97);
            runProperties42.Append(color97);
            runProperties42.Append(fontSize97);
            runProperties42.Append(fontSizeComplexScript97);
            runProperties42.Append(languages95);
            Text text38 = new Text();
            text38.Text = "2.1 Объем учебной дисциплины и виды учебной работы.......................................6";

            run42.Append(runProperties42);
            run42.Append(text38);

            paragraph55.Append(paragraphProperties55);
            paragraph55.Append(run42);

            Paragraph paragraph56 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties56 = new ParagraphProperties();
            WidowControl widowControl44 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE55 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN55 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent55 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines55 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification51 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties56 = new ParagraphMarkRunProperties();
            RunFonts runFonts98 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color98 = new Color() { Val = "000000" };
            FontSize fontSize98 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript98 = new FontSizeComplexScript() { Val = "24" };
            Languages languages96 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties56.Append(runFonts98);
            paragraphMarkRunProperties56.Append(color98);
            paragraphMarkRunProperties56.Append(fontSize98);
            paragraphMarkRunProperties56.Append(fontSizeComplexScript98);
            paragraphMarkRunProperties56.Append(languages96);

            paragraphProperties56.Append(widowControl44);
            paragraphProperties56.Append(autoSpaceDE55);
            paragraphProperties56.Append(autoSpaceDN55);
            paragraphProperties56.Append(adjustRightIndent55);
            paragraphProperties56.Append(spacingBetweenLines55);
            paragraphProperties56.Append(justification51);
            paragraphProperties56.Append(paragraphMarkRunProperties56);

            paragraph56.Append(paragraphProperties56);

            Paragraph paragraph57 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties57 = new ParagraphProperties();
            WidowControl widowControl45 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE56 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN56 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent56 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines56 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification52 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties57 = new ParagraphMarkRunProperties();
            RunFonts runFonts99 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color99 = new Color() { Val = "000000" };
            FontSize fontSize99 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript99 = new FontSizeComplexScript() { Val = "24" };
            Languages languages97 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties57.Append(runFonts99);
            paragraphMarkRunProperties57.Append(color99);
            paragraphMarkRunProperties57.Append(fontSize99);
            paragraphMarkRunProperties57.Append(fontSizeComplexScript99);
            paragraphMarkRunProperties57.Append(languages97);

            paragraphProperties57.Append(widowControl45);
            paragraphProperties57.Append(autoSpaceDE56);
            paragraphProperties57.Append(autoSpaceDN56);
            paragraphProperties57.Append(adjustRightIndent56);
            paragraphProperties57.Append(spacingBetweenLines56);
            paragraphProperties57.Append(justification52);
            paragraphProperties57.Append(paragraphMarkRunProperties57);

            Run run43 = new Run();

            RunProperties runProperties43 = new RunProperties();
            RunFonts runFonts100 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color100 = new Color() { Val = "000000" };
            FontSize fontSize100 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript100 = new FontSizeComplexScript() { Val = "24" };
            Languages languages98 = new Languages() { Val = "ru" };

            runProperties43.Append(runFonts100);
            runProperties43.Append(color100);
            runProperties43.Append(fontSize100);
            runProperties43.Append(fontSizeComplexScript100);
            runProperties43.Append(languages98);
            Text text39 = new Text();
            text39.Text = "2.2 Тематический план и содержание учебной дисциплины..................................7";

            run43.Append(runProperties43);
            run43.Append(text39);

            paragraph57.Append(paragraphProperties57);
            paragraph57.Append(run43);

            Paragraph paragraph58 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties58 = new ParagraphProperties();
            WidowControl widowControl46 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE57 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN57 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent57 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines57 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification53 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties58 = new ParagraphMarkRunProperties();
            RunFonts runFonts101 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color101 = new Color() { Val = "000000" };
            FontSize fontSize101 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript101 = new FontSizeComplexScript() { Val = "24" };
            Languages languages99 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties58.Append(runFonts101);
            paragraphMarkRunProperties58.Append(color101);
            paragraphMarkRunProperties58.Append(fontSize101);
            paragraphMarkRunProperties58.Append(fontSizeComplexScript101);
            paragraphMarkRunProperties58.Append(languages99);

            paragraphProperties58.Append(widowControl46);
            paragraphProperties58.Append(autoSpaceDE57);
            paragraphProperties58.Append(autoSpaceDN57);
            paragraphProperties58.Append(adjustRightIndent57);
            paragraphProperties58.Append(spacingBetweenLines57);
            paragraphProperties58.Append(justification53);
            paragraphProperties58.Append(paragraphMarkRunProperties58);

            paragraph58.Append(paragraphProperties58);

            Paragraph paragraph59 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties59 = new ParagraphProperties();
            WidowControl widowControl47 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE58 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN58 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent58 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines58 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification54 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties59 = new ParagraphMarkRunProperties();
            RunFonts runFonts102 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color102 = new Color() { Val = "000000" };
            FontSize fontSize102 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript102 = new FontSizeComplexScript() { Val = "24" };
            Languages languages100 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties59.Append(runFonts102);
            paragraphMarkRunProperties59.Append(color102);
            paragraphMarkRunProperties59.Append(fontSize102);
            paragraphMarkRunProperties59.Append(fontSizeComplexScript102);
            paragraphMarkRunProperties59.Append(languages100);

            paragraphProperties59.Append(widowControl47);
            paragraphProperties59.Append(autoSpaceDE58);
            paragraphProperties59.Append(autoSpaceDN58);
            paragraphProperties59.Append(adjustRightIndent58);
            paragraphProperties59.Append(spacingBetweenLines58);
            paragraphProperties59.Append(justification54);
            paragraphProperties59.Append(paragraphMarkRunProperties59);

            Run run44 = new Run();

            RunProperties runProperties44 = new RunProperties();
            RunFonts runFonts103 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color103 = new Color() { Val = "000000" };
            FontSize fontSize103 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript103 = new FontSizeComplexScript() { Val = "24" };
            Languages languages101 = new Languages() { Val = "ru" };

            runProperties44.Append(runFonts103);
            runProperties44.Append(color103);
            runProperties44.Append(fontSize103);
            runProperties44.Append(fontSizeComplexScript103);
            runProperties44.Append(languages101);
            Text text40 = new Text();
            text40.Text = "3. УСЛОВИЯ РЕАЛИЗАЦИИ УЧЕБНОЙ ДИСЦИПЛИНЫ.................................11";

            run44.Append(runProperties44);
            run44.Append(text40);

            paragraph59.Append(paragraphProperties59);
            paragraph59.Append(run44);

            Paragraph paragraph60 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties60 = new ParagraphProperties();
            WidowControl widowControl48 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE59 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN59 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent59 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines59 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification55 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties60 = new ParagraphMarkRunProperties();
            RunFonts runFonts104 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color104 = new Color() { Val = "000000" };
            FontSize fontSize104 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript104 = new FontSizeComplexScript() { Val = "24" };
            Languages languages102 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties60.Append(runFonts104);
            paragraphMarkRunProperties60.Append(color104);
            paragraphMarkRunProperties60.Append(fontSize104);
            paragraphMarkRunProperties60.Append(fontSizeComplexScript104);
            paragraphMarkRunProperties60.Append(languages102);

            paragraphProperties60.Append(widowControl48);
            paragraphProperties60.Append(autoSpaceDE59);
            paragraphProperties60.Append(autoSpaceDN59);
            paragraphProperties60.Append(adjustRightIndent59);
            paragraphProperties60.Append(spacingBetweenLines59);
            paragraphProperties60.Append(justification55);
            paragraphProperties60.Append(paragraphMarkRunProperties60);

            paragraph60.Append(paragraphProperties60);

            Paragraph paragraph61 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties61 = new ParagraphProperties();
            WidowControl widowControl49 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE60 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN60 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent60 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines60 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification56 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties61 = new ParagraphMarkRunProperties();
            RunFonts runFonts105 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color105 = new Color() { Val = "000000" };
            FontSize fontSize105 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript105 = new FontSizeComplexScript() { Val = "24" };
            Languages languages103 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties61.Append(runFonts105);
            paragraphMarkRunProperties61.Append(color105);
            paragraphMarkRunProperties61.Append(fontSize105);
            paragraphMarkRunProperties61.Append(fontSizeComplexScript105);
            paragraphMarkRunProperties61.Append(languages103);

            paragraphProperties61.Append(widowControl49);
            paragraphProperties61.Append(autoSpaceDE60);
            paragraphProperties61.Append(autoSpaceDN60);
            paragraphProperties61.Append(adjustRightIndent60);
            paragraphProperties61.Append(spacingBetweenLines60);
            paragraphProperties61.Append(justification56);
            paragraphProperties61.Append(paragraphMarkRunProperties61);

            Run run45 = new Run();

            RunProperties runProperties45 = new RunProperties();
            RunFonts runFonts106 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color106 = new Color() { Val = "000000" };
            FontSize fontSize106 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript106 = new FontSizeComplexScript() { Val = "24" };
            Languages languages104 = new Languages() { Val = "ru" };

            runProperties45.Append(runFonts106);
            runProperties45.Append(color106);
            runProperties45.Append(fontSize106);
            runProperties45.Append(fontSizeComplexScript106);
            runProperties45.Append(languages104);
            Text text41 = new Text();
            text41.Text = "3.1";

            run45.Append(runProperties45);
            run45.Append(text41);

            Run run46 = new Run();

            RunProperties runProperties46 = new RunProperties();
            RunFonts runFonts107 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color107 = new Color() { Val = "000000" };
            FontSize fontSize107 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript107 = new FontSizeComplexScript() { Val = "24" };
            Languages languages105 = new Languages() { Val = "en-US" };

            runProperties46.Append(runFonts107);
            runProperties46.Append(color107);
            runProperties46.Append(fontSize107);
            runProperties46.Append(fontSizeComplexScript107);
            runProperties46.Append(languages105);
            Text text42 = new Text();
            text42.Text = " ";

            run46.Append(runProperties46);
            run46.Append(text42);

            Run run47 = new Run();

            RunProperties runProperties47 = new RunProperties();
            RunFonts runFonts108 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color108 = new Color() { Val = "000000" };
            FontSize fontSize108 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript108 = new FontSizeComplexScript() { Val = "24" };
            Languages languages106 = new Languages() { Val = "ru" };

            runProperties47.Append(runFonts108);
            runProperties47.Append(color108);
            runProperties47.Append(fontSize108);
            runProperties47.Append(fontSizeComplexScript108);
            runProperties47.Append(languages106);
            Text text43 = new Text();
            text43.Text = "Требования к";

            run47.Append(runProperties47);
            run47.Append(text43);

            Run run48 = new Run() { RsidRunProperties = "009B27E8" };

            RunProperties runProperties48 = new RunProperties();
            RunFonts runFonts109 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color109 = new Color() { Val = "000000" };
            FontSize fontSize109 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript109 = new FontSizeComplexScript() { Val = "24" };

            runProperties48.Append(runFonts109);
            runProperties48.Append(color109);
            runProperties48.Append(fontSize109);
            runProperties48.Append(fontSizeComplexScript109);
            Text text44 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text44.Text = " ";

            run48.Append(runProperties48);
            run48.Append(text44);

            Run run49 = new Run();

            RunProperties runProperties49 = new RunProperties();
            RunFonts runFonts110 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color110 = new Color() { Val = "000000" };
            FontSize fontSize110 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript110 = new FontSizeComplexScript() { Val = "24" };
            Languages languages107 = new Languages() { Val = "ru" };

            runProperties49.Append(runFonts110);
            runProperties49.Append(color110);
            runProperties49.Append(fontSize110);
            runProperties49.Append(fontSizeComplexScript110);
            runProperties49.Append(languages107);
            Text text45 = new Text();
            text45.Text = "минимальному матери";

            run49.Append(runProperties49);
            run49.Append(text45);

            Run run50 = new Run() { RsidRunAddition = "00E21CEE" };

            RunProperties runProperties50 = new RunProperties();
            RunFonts runFonts111 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color111 = new Color() { Val = "000000" };
            FontSize fontSize111 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript111 = new FontSizeComplexScript() { Val = "24" };
            Languages languages108 = new Languages() { Val = "ru" };

            runProperties50.Append(runFonts111);
            runProperties50.Append(color111);
            runProperties50.Append(fontSize111);
            runProperties50.Append(fontSizeComplexScript111);
            runProperties50.Append(languages108);
            Text text46 = new Text();
            text46.Text = "а";

            run50.Append(runProperties50);
            run50.Append(text46);

            Run run51 = new Run();

            RunProperties runProperties51 = new RunProperties();
            RunFonts runFonts112 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color112 = new Color() { Val = "000000" };
            FontSize fontSize112 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript112 = new FontSizeComplexScript() { Val = "24" };
            Languages languages109 = new Languages() { Val = "ru" };

            runProperties51.Append(runFonts112);
            runProperties51.Append(color112);
            runProperties51.Append(fontSize112);
            runProperties51.Append(fontSizeComplexScript112);
            runProperties51.Append(languages109);
            Text text47 = new Text();
            text47.Text = "льно-техническому обеспечению";

            run51.Append(runProperties51);
            run51.Append(text47);

            Run run52 = new Run() { RsidRunProperties = "009B27E8" };

            RunProperties runProperties52 = new RunProperties();
            RunFonts runFonts113 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color113 = new Color() { Val = "000000" };
            FontSize fontSize113 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript113 = new FontSizeComplexScript() { Val = "24" };

            runProperties52.Append(runFonts113);
            runProperties52.Append(color113);
            runProperties52.Append(fontSize113);
            runProperties52.Append(fontSizeComplexScript113);
            Text text48 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text48.Text = " ";

            run52.Append(runProperties52);
            run52.Append(text48);

            Run run53 = new Run();

            RunProperties runProperties53 = new RunProperties();
            RunFonts runFonts114 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color114 = new Color() { Val = "000000" };
            FontSize fontSize114 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript114 = new FontSizeComplexScript() { Val = "24" };
            Languages languages110 = new Languages() { Val = "ru" };

            runProperties53.Append(runFonts114);
            runProperties53.Append(color114);
            runProperties53.Append(fontSize114);
            runProperties53.Append(fontSizeComplexScript114);
            runProperties53.Append(languages110);
            Text text49 = new Text();
            text49.Text = ".........";

            run53.Append(runProperties53);
            run53.Append(text49);

            Run run54 = new Run() { RsidRunProperties = "00067D40", RsidRunAddition = "00067D40" };

            RunProperties runProperties54 = new RunProperties();
            RunFonts runFonts115 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color115 = new Color() { Val = "000000" };
            FontSize fontSize115 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript115 = new FontSizeComplexScript() { Val = "24" };
            Languages languages111 = new Languages() { Val = "ru" };

            runProperties54.Append(runFonts115);
            runProperties54.Append(color115);
            runProperties54.Append(fontSize115);
            runProperties54.Append(fontSizeComplexScript115);
            runProperties54.Append(languages111);
            Text text50 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text50.Text = " ";

            run54.Append(runProperties54);
            run54.Append(text50);

            Run run55 = new Run() { RsidRunAddition = "00067D40" };

            RunProperties runProperties55 = new RunProperties();
            RunFonts runFonts116 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color116 = new Color() { Val = "000000" };
            FontSize fontSize116 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript116 = new FontSizeComplexScript() { Val = "24" };
            Languages languages112 = new Languages() { Val = "ru" };

            runProperties55.Append(runFonts116);
            runProperties55.Append(color116);
            runProperties55.Append(fontSize116);
            runProperties55.Append(fontSizeComplexScript116);
            runProperties55.Append(languages112);
            Text text51 = new Text();
            text51.Text = "........................................................................................................";

            run55.Append(runProperties55);
            run55.Append(text51);

            Run run56 = new Run() { RsidRunProperties = "000B1615", RsidRunAddition = "00067D40" };

            RunProperties runProperties56 = new RunProperties();
            RunFonts runFonts117 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color117 = new Color() { Val = "000000" };
            FontSize fontSize117 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript117 = new FontSizeComplexScript() { Val = "24" };

            runProperties56.Append(runFonts117);
            runProperties56.Append(color117);
            runProperties56.Append(fontSize117);
            runProperties56.Append(fontSizeComplexScript117);
            Text text52 = new Text();
            text52.Text = ".";

            run56.Append(runProperties56);
            run56.Append(text52);

            Run run57 = new Run() { RsidRunAddition = "00067D40" };

            RunProperties runProperties57 = new RunProperties();
            RunFonts runFonts118 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color118 = new Color() { Val = "000000" };
            FontSize fontSize118 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript118 = new FontSizeComplexScript() { Val = "24" };
            Languages languages113 = new Languages() { Val = "ru" };

            runProperties57.Append(runFonts118);
            runProperties57.Append(color118);
            runProperties57.Append(fontSize118);
            runProperties57.Append(fontSizeComplexScript118);
            runProperties57.Append(languages113);
            Text text53 = new Text();
            text53.Text = "............................";

            run57.Append(runProperties57);
            run57.Append(text53);

            Run run58 = new Run() { RsidRunProperties = "000B1615", RsidRunAddition = "00067D40" };

            RunProperties runProperties58 = new RunProperties();
            RunFonts runFonts119 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color119 = new Color() { Val = "000000" };
            FontSize fontSize119 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript119 = new FontSizeComplexScript() { Val = "24" };

            runProperties58.Append(runFonts119);
            runProperties58.Append(color119);
            runProperties58.Append(fontSize119);
            runProperties58.Append(fontSizeComplexScript119);
            Text text54 = new Text();
            text54.Text = ".";

            run58.Append(runProperties58);
            run58.Append(text54);

            Run run59 = new Run();

            RunProperties runProperties59 = new RunProperties();
            RunFonts runFonts120 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color120 = new Color() { Val = "000000" };
            FontSize fontSize120 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript120 = new FontSizeComplexScript() { Val = "24" };
            Languages languages114 = new Languages() { Val = "ru" };

            runProperties59.Append(runFonts120);
            runProperties59.Append(color120);
            runProperties59.Append(fontSize120);
            runProperties59.Append(fontSizeComplexScript120);
            runProperties59.Append(languages114);
            Text text55 = new Text();
            text55.Text = "11";

            run59.Append(runProperties59);
            run59.Append(text55);

            paragraph61.Append(paragraphProperties61);
            paragraph61.Append(run45);
            paragraph61.Append(run46);
            paragraph61.Append(run47);
            paragraph61.Append(run48);
            paragraph61.Append(run49);
            paragraph61.Append(run50);
            paragraph61.Append(run51);
            paragraph61.Append(run52);
            paragraph61.Append(run53);
            paragraph61.Append(run54);
            paragraph61.Append(run55);
            paragraph61.Append(run56);
            paragraph61.Append(run57);
            paragraph61.Append(run58);
            paragraph61.Append(run59);

            Paragraph paragraph62 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties62 = new ParagraphProperties();
            WidowControl widowControl50 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE61 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN61 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent61 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines61 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification57 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties62 = new ParagraphMarkRunProperties();
            RunFonts runFonts121 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color121 = new Color() { Val = "000000" };
            FontSize fontSize121 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript121 = new FontSizeComplexScript() { Val = "24" };
            Languages languages115 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties62.Append(runFonts121);
            paragraphMarkRunProperties62.Append(color121);
            paragraphMarkRunProperties62.Append(fontSize121);
            paragraphMarkRunProperties62.Append(fontSizeComplexScript121);
            paragraphMarkRunProperties62.Append(languages115);

            paragraphProperties62.Append(widowControl50);
            paragraphProperties62.Append(autoSpaceDE61);
            paragraphProperties62.Append(autoSpaceDN61);
            paragraphProperties62.Append(adjustRightIndent61);
            paragraphProperties62.Append(spacingBetweenLines61);
            paragraphProperties62.Append(justification57);
            paragraphProperties62.Append(paragraphMarkRunProperties62);

            paragraph62.Append(paragraphProperties62);

            Paragraph paragraph63 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties63 = new ParagraphProperties();
            WidowControl widowControl51 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE62 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN62 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent62 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines62 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification58 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties63 = new ParagraphMarkRunProperties();
            RunFonts runFonts122 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color122 = new Color() { Val = "000000" };
            FontSize fontSize122 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript122 = new FontSizeComplexScript() { Val = "24" };
            Languages languages116 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties63.Append(runFonts122);
            paragraphMarkRunProperties63.Append(color122);
            paragraphMarkRunProperties63.Append(fontSize122);
            paragraphMarkRunProperties63.Append(fontSizeComplexScript122);
            paragraphMarkRunProperties63.Append(languages116);

            paragraphProperties63.Append(widowControl51);
            paragraphProperties63.Append(autoSpaceDE62);
            paragraphProperties63.Append(autoSpaceDN62);
            paragraphProperties63.Append(adjustRightIndent62);
            paragraphProperties63.Append(spacingBetweenLines62);
            paragraphProperties63.Append(justification58);
            paragraphProperties63.Append(paragraphMarkRunProperties63);

            Run run60 = new Run();

            RunProperties runProperties60 = new RunProperties();
            RunFonts runFonts123 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color123 = new Color() { Val = "000000" };
            FontSize fontSize123 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript123 = new FontSizeComplexScript() { Val = "24" };
            Languages languages117 = new Languages() { Val = "ru" };

            runProperties60.Append(runFonts123);
            runProperties60.Append(color123);
            runProperties60.Append(fontSize123);
            runProperties60.Append(fontSizeComplexScript123);
            runProperties60.Append(languages117);
            Text text56 = new Text();
            text56.Text = "3.2 Информационное обеспечение обучения..........................................................11";

            run60.Append(runProperties60);
            run60.Append(text56);

            paragraph63.Append(paragraphProperties63);
            paragraph63.Append(run60);

            Paragraph paragraph64 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties64 = new ParagraphProperties();
            WidowControl widowControl52 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE63 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN63 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent63 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines63 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification59 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties64 = new ParagraphMarkRunProperties();
            RunFonts runFonts124 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color124 = new Color() { Val = "000000" };
            FontSize fontSize124 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript124 = new FontSizeComplexScript() { Val = "24" };
            Languages languages118 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties64.Append(runFonts124);
            paragraphMarkRunProperties64.Append(color124);
            paragraphMarkRunProperties64.Append(fontSize124);
            paragraphMarkRunProperties64.Append(fontSizeComplexScript124);
            paragraphMarkRunProperties64.Append(languages118);

            paragraphProperties64.Append(widowControl52);
            paragraphProperties64.Append(autoSpaceDE63);
            paragraphProperties64.Append(autoSpaceDN63);
            paragraphProperties64.Append(adjustRightIndent63);
            paragraphProperties64.Append(spacingBetweenLines63);
            paragraphProperties64.Append(justification59);
            paragraphProperties64.Append(paragraphMarkRunProperties64);

            paragraph64.Append(paragraphProperties64);

            Paragraph paragraph65 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties65 = new ParagraphProperties();
            WidowControl widowControl53 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE64 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN64 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent64 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines64 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification60 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties65 = new ParagraphMarkRunProperties();
            RunFonts runFonts125 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color125 = new Color() { Val = "000000" };
            FontSize fontSize125 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript125 = new FontSizeComplexScript() { Val = "24" };
            Languages languages119 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties65.Append(runFonts125);
            paragraphMarkRunProperties65.Append(color125);
            paragraphMarkRunProperties65.Append(fontSize125);
            paragraphMarkRunProperties65.Append(fontSizeComplexScript125);
            paragraphMarkRunProperties65.Append(languages119);

            paragraphProperties65.Append(widowControl53);
            paragraphProperties65.Append(autoSpaceDE64);
            paragraphProperties65.Append(autoSpaceDN64);
            paragraphProperties65.Append(adjustRightIndent64);
            paragraphProperties65.Append(spacingBetweenLines64);
            paragraphProperties65.Append(justification60);
            paragraphProperties65.Append(paragraphMarkRunProperties65);

            Run run61 = new Run();

            RunProperties runProperties61 = new RunProperties();
            RunFonts runFonts126 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color126 = new Color() { Val = "000000" };
            FontSize fontSize126 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript126 = new FontSizeComplexScript() { Val = "24" };
            Languages languages120 = new Languages() { Val = "ru" };

            runProperties61.Append(runFonts126);
            runProperties61.Append(color126);
            runProperties61.Append(fontSize126);
            runProperties61.Append(fontSizeComplexScript126);
            runProperties61.Append(languages120);
            Text text57 = new Text();
            text57.Text = "4. КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ УЧЕБНОЙ ДИСЦИПЛИНЫ........................................................................................................12";

            run61.Append(runProperties61);
            run61.Append(text57);

            paragraph65.Append(paragraphProperties65);
            paragraph65.Append(run61);

            Paragraph paragraph66 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties66 = new ParagraphProperties();
            WidowControl widowControl54 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE65 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN65 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent65 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines65 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification61 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties66 = new ParagraphMarkRunProperties();
            RunFonts runFonts127 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color127 = new Color() { Val = "000000" };
            FontSize fontSize127 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript127 = new FontSizeComplexScript() { Val = "24" };
            Languages languages121 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties66.Append(runFonts127);
            paragraphMarkRunProperties66.Append(color127);
            paragraphMarkRunProperties66.Append(fontSize127);
            paragraphMarkRunProperties66.Append(fontSizeComplexScript127);
            paragraphMarkRunProperties66.Append(languages121);

            paragraphProperties66.Append(widowControl54);
            paragraphProperties66.Append(autoSpaceDE65);
            paragraphProperties66.Append(autoSpaceDN65);
            paragraphProperties66.Append(adjustRightIndent65);
            paragraphProperties66.Append(spacingBetweenLines65);
            paragraphProperties66.Append(justification61);
            paragraphProperties66.Append(paragraphMarkRunProperties66);

            paragraph66.Append(paragraphProperties66);

            Paragraph paragraph67 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties67 = new ParagraphProperties();
            WidowControl widowControl55 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE66 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN66 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent66 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines66 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification62 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties67 = new ParagraphMarkRunProperties();
            RunFonts runFonts128 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color128 = new Color() { Val = "000000" };
            FontSize fontSize128 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript128 = new FontSizeComplexScript() { Val = "24" };
            Languages languages122 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties67.Append(runFonts128);
            paragraphMarkRunProperties67.Append(color128);
            paragraphMarkRunProperties67.Append(fontSize128);
            paragraphMarkRunProperties67.Append(fontSizeComplexScript128);
            paragraphMarkRunProperties67.Append(languages122);

            paragraphProperties67.Append(widowControl55);
            paragraphProperties67.Append(autoSpaceDE66);
            paragraphProperties67.Append(autoSpaceDN66);
            paragraphProperties67.Append(adjustRightIndent66);
            paragraphProperties67.Append(spacingBetweenLines66);
            paragraphProperties67.Append(justification62);
            paragraphProperties67.Append(paragraphMarkRunProperties67);

            Run run62 = new Run();

            RunProperties runProperties62 = new RunProperties();
            RunFonts runFonts129 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color129 = new Color() { Val = "000000" };
            FontSize fontSize129 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript129 = new FontSizeComplexScript() { Val = "24" };
            Languages languages123 = new Languages() { Val = "ru" };

            runProperties62.Append(runFonts129);
            runProperties62.Append(color129);
            runProperties62.Append(fontSize129);
            runProperties62.Append(fontSizeComplexScript129);
            runProperties62.Append(languages123);
            Text text58 = new Text();
            text58.Text = "ПРИЛОЖЕНИЕ.........................................................................................................13";

            run62.Append(runProperties62);
            run62.Append(text58);

            paragraph67.Append(paragraphProperties67);
            paragraph67.Append(run62);

            Paragraph paragraph68 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties68 = new ParagraphProperties();
            WidowControl widowControl56 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE67 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN67 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent67 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines67 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification63 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties68 = new ParagraphMarkRunProperties();
            RunFonts runFonts130 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color130 = new Color() { Val = "000000" };
            FontSize fontSize130 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript130 = new FontSizeComplexScript() { Val = "24" };
            Languages languages124 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties68.Append(runFonts130);
            paragraphMarkRunProperties68.Append(color130);
            paragraphMarkRunProperties68.Append(fontSize130);
            paragraphMarkRunProperties68.Append(fontSizeComplexScript130);
            paragraphMarkRunProperties68.Append(languages124);

            paragraphProperties68.Append(widowControl56);
            paragraphProperties68.Append(autoSpaceDE67);
            paragraphProperties68.Append(autoSpaceDN67);
            paragraphProperties68.Append(adjustRightIndent67);
            paragraphProperties68.Append(spacingBetweenLines67);
            paragraphProperties68.Append(justification63);
            paragraphProperties68.Append(paragraphMarkRunProperties68);

            paragraph68.Append(paragraphProperties68);

            Paragraph paragraph69 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties69 = new ParagraphProperties();
            WidowControl widowControl57 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE68 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN68 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent68 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines68 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification64 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties69 = new ParagraphMarkRunProperties();
            RunFonts runFonts131 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color131 = new Color() { Val = "000000" };
            FontSize fontSize131 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript131 = new FontSizeComplexScript() { Val = "24" };
            Languages languages125 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties69.Append(runFonts131);
            paragraphMarkRunProperties69.Append(color131);
            paragraphMarkRunProperties69.Append(fontSize131);
            paragraphMarkRunProperties69.Append(fontSizeComplexScript131);
            paragraphMarkRunProperties69.Append(languages125);

            paragraphProperties69.Append(widowControl57);
            paragraphProperties69.Append(autoSpaceDE68);
            paragraphProperties69.Append(autoSpaceDN68);
            paragraphProperties69.Append(adjustRightIndent68);
            paragraphProperties69.Append(spacingBetweenLines68);
            paragraphProperties69.Append(justification64);
            paragraphProperties69.Append(paragraphMarkRunProperties69);

            Run run63 = new Run();

            RunProperties runProperties63 = new RunProperties();
            RunFonts runFonts132 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color132 = new Color() { Val = "000000" };
            FontSize fontSize132 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript132 = new FontSizeComplexScript() { Val = "24" };
            Languages languages126 = new Languages() { Val = "ru" };

            runProperties63.Append(runFonts132);
            runProperties63.Append(color132);
            runProperties63.Append(fontSize132);
            runProperties63.Append(fontSizeComplexScript132);
            runProperties63.Append(languages126);
            Text text59 = new Text();
            text59.Text = "ЛИСТ РЕГИСТРАЦИИ ИЗМЕНЕНИЙ...................................................................14";

            run63.Append(runProperties63);
            run63.Append(text59);

            paragraph69.Append(paragraphProperties69);
            paragraph69.Append(run63);

            Paragraph paragraph70 = new Paragraph() { RsidParagraphAddition = "00E21CEE", RsidRunAdditionDefault = "00E21CEE" };

            ParagraphProperties paragraphProperties70 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties70 = new ParagraphMarkRunProperties();
            RunFonts runFonts133 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color133 = new Color() { Val = "000000" };
            FontSize fontSize133 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript133 = new FontSizeComplexScript() { Val = "24" };
            Languages languages127 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties70.Append(runFonts133);
            paragraphMarkRunProperties70.Append(color133);
            paragraphMarkRunProperties70.Append(fontSize133);
            paragraphMarkRunProperties70.Append(fontSizeComplexScript133);
            paragraphMarkRunProperties70.Append(languages127);

            paragraphProperties70.Append(paragraphMarkRunProperties70);

            Run run64 = new Run();

            RunProperties runProperties64 = new RunProperties();
            RunFonts runFonts134 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color134 = new Color() { Val = "000000" };
            FontSize fontSize134 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript134 = new FontSizeComplexScript() { Val = "24" };
            Languages languages128 = new Languages() { Val = "ru" };

            runProperties64.Append(runFonts134);
            runProperties64.Append(color134);
            runProperties64.Append(fontSize134);
            runProperties64.Append(fontSizeComplexScript134);
            runProperties64.Append(languages128);
            Break break4 = new Break() { Type = BreakValues.Page };

            run64.Append(runProperties64);
            run64.Append(break4);

            paragraph70.Append(paragraphProperties70);
            paragraph70.Append(run64);

            Paragraph paragraph71 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties71 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE69 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN69 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent69 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines69 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification65 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties71 = new ParagraphMarkRunProperties();
            RunFonts runFonts135 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color135 = new Color() { Val = "000000" };
            FontSize fontSize135 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript135 = new FontSizeComplexScript() { Val = "28" };
            Languages languages129 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties71.Append(runFonts135);
            paragraphMarkRunProperties71.Append(color135);
            paragraphMarkRunProperties71.Append(fontSize135);
            paragraphMarkRunProperties71.Append(fontSizeComplexScript135);
            paragraphMarkRunProperties71.Append(languages129);

            paragraphProperties71.Append(autoSpaceDE69);
            paragraphProperties71.Append(autoSpaceDN69);
            paragraphProperties71.Append(adjustRightIndent69);
            paragraphProperties71.Append(spacingBetweenLines69);
            paragraphProperties71.Append(justification65);
            paragraphProperties71.Append(paragraphMarkRunProperties71);

            Run run65 = new Run();

            RunProperties runProperties65 = new RunProperties();
            RunFonts runFonts136 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold18 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            Color color136 = new Color() { Val = "000000" };
            FontSize fontSize136 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript136 = new FontSizeComplexScript() { Val = "28" };
            Languages languages130 = new Languages() { Val = "ru" };

            runProperties65.Append(runFonts136);
            runProperties65.Append(bold18);
            runProperties65.Append(boldComplexScript2);
            runProperties65.Append(color136);
            runProperties65.Append(fontSize136);
            runProperties65.Append(fontSizeComplexScript136);
            runProperties65.Append(languages130);
            LastRenderedPageBreak lastRenderedPageBreak3 = new LastRenderedPageBreak();
            Text text60 = new Text();
            text60.Text = "1. ПАСПОРТ РАБОЧЕЙ  ПРОГРАММЫ УЧЕБНОЙ ДИСЦИПЛИНЫ";

            run65.Append(runProperties65);
            run65.Append(lastRenderedPageBreak3);
            run65.Append(text60);

            Run run66 = new Run();

            RunProperties runProperties66 = new RunProperties();
            RunFonts runFonts137 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color137 = new Color() { Val = "000000" };
            FontSize fontSize137 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript137 = new FontSizeComplexScript() { Val = "28" };
            Languages languages131 = new Languages() { Val = "ru" };

            runProperties66.Append(runFonts137);
            runProperties66.Append(color137);
            runProperties66.Append(fontSize137);
            runProperties66.Append(fontSizeComplexScript137);
            runProperties66.Append(languages131);
            Break break5 = new Break();
            Text text61 = new Text();
            text61.Text = "«";

            run66.Append(runProperties66);
            run66.Append(break5);
            run66.Append(text61);

            Run run67 = new Run() { RsidRunProperties = "008A11BA", RsidRunAddition = "00E43A47" };

            RunProperties runProperties67 = new RunProperties();
            RunFonts runFonts138 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            Color color138 = new Color() { Val = "000000" };
            FontSize fontSize138 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript138 = new FontSizeComplexScript() { Val = "28" };
            Languages languages132 = new Languages() { Val = "ru" };

            runProperties67.Append(runFonts138);
            runProperties67.Append(boldComplexScript3);
            runProperties67.Append(color138);
            runProperties67.Append(fontSize138);
            runProperties67.Append(fontSizeComplexScript138);
            runProperties67.Append(languages132);
            Text text62 = new Text();
            text62.Text = "Основы философии";

            run67.Append(runProperties67);
            run67.Append(text62);

            Run run68 = new Run();

            RunProperties runProperties68 = new RunProperties();
            RunFonts runFonts139 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color139 = new Color() { Val = "000000" };
            FontSize fontSize139 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript139 = new FontSizeComplexScript() { Val = "28" };
            Languages languages133 = new Languages() { Val = "ru" };

            runProperties68.Append(runFonts139);
            runProperties68.Append(color139);
            runProperties68.Append(fontSize139);
            runProperties68.Append(fontSizeComplexScript139);
            runProperties68.Append(languages133);
            Text text63 = new Text();
            text63.Text = "»";

            run68.Append(runProperties68);
            run68.Append(text63);

            paragraph71.Append(paragraphProperties71);
            paragraph71.Append(run65);
            paragraph71.Append(run66);
            paragraph71.Append(run67);
            paragraph71.Append(run68);

            Paragraph paragraph72 = new Paragraph() { RsidParagraphAddition = "008A11BA", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "008A11BA" };

            ParagraphProperties paragraphProperties72 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE70 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN70 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent70 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines70 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification66 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties72 = new ParagraphMarkRunProperties();
            RunFonts runFonts140 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color140 = new Color() { Val = "000000" };
            FontSize fontSize140 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript140 = new FontSizeComplexScript() { Val = "28" };
            Languages languages134 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties72.Append(runFonts140);
            paragraphMarkRunProperties72.Append(color140);
            paragraphMarkRunProperties72.Append(fontSize140);
            paragraphMarkRunProperties72.Append(fontSizeComplexScript140);
            paragraphMarkRunProperties72.Append(languages134);

            paragraphProperties72.Append(autoSpaceDE70);
            paragraphProperties72.Append(autoSpaceDN70);
            paragraphProperties72.Append(adjustRightIndent70);
            paragraphProperties72.Append(spacingBetweenLines70);
            paragraphProperties72.Append(justification66);
            paragraphProperties72.Append(paragraphMarkRunProperties72);

            paragraph72.Append(paragraphProperties72);

            Paragraph paragraph73 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties73 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE71 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN71 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent71 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines71 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification67 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties73 = new ParagraphMarkRunProperties();
            RunFonts runFonts141 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color141 = new Color() { Val = "000000" };
            FontSize fontSize141 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript141 = new FontSizeComplexScript() { Val = "24" };
            Languages languages135 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties73.Append(runFonts141);
            paragraphMarkRunProperties73.Append(color141);
            paragraphMarkRunProperties73.Append(fontSize141);
            paragraphMarkRunProperties73.Append(fontSizeComplexScript141);
            paragraphMarkRunProperties73.Append(languages135);

            paragraphProperties73.Append(autoSpaceDE71);
            paragraphProperties73.Append(autoSpaceDN71);
            paragraphProperties73.Append(adjustRightIndent71);
            paragraphProperties73.Append(spacingBetweenLines71);
            paragraphProperties73.Append(justification67);
            paragraphProperties73.Append(paragraphMarkRunProperties73);

            Run run69 = new Run();

            RunProperties runProperties69 = new RunProperties();
            RunFonts runFonts142 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold19 = new Bold();
            Color color142 = new Color() { Val = "000000" };
            FontSize fontSize142 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript142 = new FontSizeComplexScript() { Val = "24" };
            Languages languages136 = new Languages() { Val = "ru" };

            runProperties69.Append(runFonts142);
            runProperties69.Append(bold19);
            runProperties69.Append(color142);
            runProperties69.Append(fontSize142);
            runProperties69.Append(fontSizeComplexScript142);
            runProperties69.Append(languages136);
            Text text64 = new Text();
            text64.Text = "1.1. Область применения рабочей программы";

            run69.Append(runProperties69);
            run69.Append(text64);

            Run run70 = new Run();

            RunProperties runProperties70 = new RunProperties();
            RunFonts runFonts143 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color143 = new Color() { Val = "000000" };
            FontSize fontSize143 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript143 = new FontSizeComplexScript() { Val = "24" };
            Languages languages137 = new Languages() { Val = "ru" };

            runProperties70.Append(runFonts143);
            runProperties70.Append(color143);
            runProperties70.Append(fontSize143);
            runProperties70.Append(fontSizeComplexScript143);
            runProperties70.Append(languages137);
            Text text65 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text65.Text = "     Рабочая программа учебной дисциплины является частью основной профессиональной образовательной программы в соответствии с ФГОС по специальности СПО 210723";

            run70.Append(runProperties70);
            run70.Append(text65);

            paragraph73.Append(paragraphProperties73);
            paragraph73.Append(run69);
            paragraph73.Append(run70);

            Paragraph paragraph74 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties74 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE72 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN72 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent72 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines72 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification68 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties74 = new ParagraphMarkRunProperties();
            RunFonts runFonts144 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color144 = new Color() { Val = "000000" };
            FontSize fontSize144 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript144 = new FontSizeComplexScript() { Val = "24" };
            Languages languages138 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties74.Append(runFonts144);
            paragraphMarkRunProperties74.Append(color144);
            paragraphMarkRunProperties74.Append(fontSize144);
            paragraphMarkRunProperties74.Append(fontSizeComplexScript144);
            paragraphMarkRunProperties74.Append(languages138);

            paragraphProperties74.Append(autoSpaceDE72);
            paragraphProperties74.Append(autoSpaceDN72);
            paragraphProperties74.Append(adjustRightIndent72);
            paragraphProperties74.Append(spacingBetweenLines72);
            paragraphProperties74.Append(justification68);
            paragraphProperties74.Append(paragraphMarkRunProperties74);

            Run run71 = new Run();

            RunProperties runProperties71 = new RunProperties();
            RunFonts runFonts145 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold20 = new Bold();
            Color color145 = new Color() { Val = "000000" };
            FontSize fontSize145 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript145 = new FontSizeComplexScript() { Val = "24" };
            Languages languages139 = new Languages() { Val = "ru" };

            runProperties71.Append(runFonts145);
            runProperties71.Append(bold20);
            runProperties71.Append(color145);
            runProperties71.Append(fontSize145);
            runProperties71.Append(fontSizeComplexScript145);
            runProperties71.Append(languages139);
            Text text66 = new Text();
            text66.Text = "1.2 Место учебной дисциплины в структуре основной профессиональной образовательной программы:";

            run71.Append(runProperties71);
            run71.Append(text66);

            Run run72 = new Run();

            RunProperties runProperties72 = new RunProperties();
            RunFonts runFonts146 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color146 = new Color() { Val = "000000" };
            FontSize fontSize146 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript146 = new FontSizeComplexScript() { Val = "24" };
            Languages languages140 = new Languages() { Val = "ru" };

            runProperties72.Append(runFonts146);
            runProperties72.Append(color146);
            runProperties72.Append(fontSize146);
            runProperties72.Append(fontSizeComplexScript146);
            runProperties72.Append(languages140);
            Break break6 = new Break();
            Text text67 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text67.Text = "    Рабочая дисциплина  «  »  относится к общему гуманитарному и социально-экономическому циклу основной профессиональной образовательной программы.";

            run72.Append(runProperties72);
            run72.Append(break6);
            run72.Append(text67);

            paragraph74.Append(paragraphProperties74);
            paragraph74.Append(run71);
            paragraph74.Append(run72);

            Paragraph paragraph75 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties75 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE73 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN73 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent73 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines73 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties75 = new ParagraphMarkRunProperties();
            RunFonts runFonts147 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color147 = new Color() { Val = "000000" };
            FontSize fontSize147 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript147 = new FontSizeComplexScript() { Val = "24" };
            Languages languages141 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties75.Append(runFonts147);
            paragraphMarkRunProperties75.Append(color147);
            paragraphMarkRunProperties75.Append(fontSize147);
            paragraphMarkRunProperties75.Append(fontSizeComplexScript147);
            paragraphMarkRunProperties75.Append(languages141);

            paragraphProperties75.Append(autoSpaceDE73);
            paragraphProperties75.Append(autoSpaceDN73);
            paragraphProperties75.Append(adjustRightIndent73);
            paragraphProperties75.Append(spacingBetweenLines73);
            paragraphProperties75.Append(paragraphMarkRunProperties75);

            Run run73 = new Run();

            RunProperties runProperties73 = new RunProperties();
            RunFonts runFonts148 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold21 = new Bold();
            Color color148 = new Color() { Val = "000000" };
            FontSize fontSize148 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript148 = new FontSizeComplexScript() { Val = "24" };
            Languages languages142 = new Languages() { Val = "ru" };

            runProperties73.Append(runFonts148);
            runProperties73.Append(bold21);
            runProperties73.Append(color148);
            runProperties73.Append(fontSize148);
            runProperties73.Append(fontSizeComplexScript148);
            runProperties73.Append(languages142);
            Text text68 = new Text();
            text68.Text = "1.3 Цели и задачи учебной дисциплины - требования к результатам освоения учебной дисциплины";

            run73.Append(runProperties73);
            run73.Append(text68);

            Run run74 = new Run();

            RunProperties runProperties74 = new RunProperties();
            RunFonts runFonts149 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color149 = new Color() { Val = "000000" };
            FontSize fontSize149 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript149 = new FontSizeComplexScript() { Val = "24" };
            Languages languages143 = new Languages() { Val = "ru" };

            runProperties74.Append(runFonts149);
            runProperties74.Append(color149);
            runProperties74.Append(fontSize149);
            runProperties74.Append(fontSizeComplexScript149);
            runProperties74.Append(languages143);
            Break break7 = new Break();
            Text text69 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text69.Text = "    В результате освоения дисциплины обучающийся должен уметь:";

            run74.Append(runProperties74);
            run74.Append(break7);
            run74.Append(text69);

            paragraph75.Append(paragraphProperties75);
            paragraph75.Append(run73);
            paragraph75.Append(run74);

            Paragraph paragraph76 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties76 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE74 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN74 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent74 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines74 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties76 = new ParagraphMarkRunProperties();
            RunFonts runFonts150 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color150 = new Color() { Val = "000000" };
            FontSize fontSize150 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript150 = new FontSizeComplexScript() { Val = "24" };
            Languages languages144 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties76.Append(runFonts150);
            paragraphMarkRunProperties76.Append(color150);
            paragraphMarkRunProperties76.Append(fontSize150);
            paragraphMarkRunProperties76.Append(fontSizeComplexScript150);
            paragraphMarkRunProperties76.Append(languages144);

            paragraphProperties76.Append(autoSpaceDE74);
            paragraphProperties76.Append(autoSpaceDN74);
            paragraphProperties76.Append(adjustRightIndent74);
            paragraphProperties76.Append(spacingBetweenLines74);
            paragraphProperties76.Append(paragraphMarkRunProperties76);

            Run run75 = new Run();

            RunProperties runProperties75 = new RunProperties();
            RunFonts runFonts151 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color151 = new Color() { Val = "000000" };
            FontSize fontSize151 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript151 = new FontSizeComplexScript() { Val = "24" };
            Languages languages145 = new Languages() { Val = "ru" };

            runProperties75.Append(runFonts151);
            runProperties75.Append(color151);
            runProperties75.Append(fontSize151);
            runProperties75.Append(fontSizeComplexScript151);
            runProperties75.Append(languages145);
            Break break8 = new Break();
            Text text70 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text70.Text = "    В результате освоения дисциплины обучающийся должен знать:";

            run75.Append(runProperties75);
            run75.Append(break8);
            run75.Append(text70);

            paragraph76.Append(paragraphProperties76);
            paragraph76.Append(run75);

            Paragraph paragraph77 = new Paragraph() { RsidParagraphAddition = "003678C0", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "003678C0" };

            ParagraphProperties paragraphProperties77 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE75 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN75 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent75 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines75 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties77 = new ParagraphMarkRunProperties();
            RunFonts runFonts152 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color152 = new Color() { Val = "000000" };
            FontSize fontSize152 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript152 = new FontSizeComplexScript() { Val = "24" };
            Languages languages146 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties77.Append(runFonts152);
            paragraphMarkRunProperties77.Append(color152);
            paragraphMarkRunProperties77.Append(fontSize152);
            paragraphMarkRunProperties77.Append(fontSizeComplexScript152);
            paragraphMarkRunProperties77.Append(languages146);

            paragraphProperties77.Append(autoSpaceDE75);
            paragraphProperties77.Append(autoSpaceDN75);
            paragraphProperties77.Append(adjustRightIndent75);
            paragraphProperties77.Append(spacingBetweenLines75);
            paragraphProperties77.Append(paragraphMarkRunProperties77);

            paragraph77.Append(paragraphProperties77);

            Paragraph paragraph78 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties78 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE76 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN76 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent76 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines76 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification69 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties78 = new ParagraphMarkRunProperties();
            RunFonts runFonts153 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold22 = new Bold();
            Color color153 = new Color() { Val = "000000" };
            FontSize fontSize153 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript153 = new FontSizeComplexScript() { Val = "24" };
            Languages languages147 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties78.Append(runFonts153);
            paragraphMarkRunProperties78.Append(bold22);
            paragraphMarkRunProperties78.Append(color153);
            paragraphMarkRunProperties78.Append(fontSize153);
            paragraphMarkRunProperties78.Append(fontSizeComplexScript153);
            paragraphMarkRunProperties78.Append(languages147);

            paragraphProperties78.Append(autoSpaceDE76);
            paragraphProperties78.Append(autoSpaceDN76);
            paragraphProperties78.Append(adjustRightIndent76);
            paragraphProperties78.Append(spacingBetweenLines76);
            paragraphProperties78.Append(justification69);
            paragraphProperties78.Append(paragraphMarkRunProperties78);

            Run run76 = new Run();

            RunProperties runProperties76 = new RunProperties();
            RunFonts runFonts154 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold23 = new Bold();
            Color color154 = new Color() { Val = "000000" };
            FontSize fontSize154 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript154 = new FontSizeComplexScript() { Val = "24" };
            Languages languages148 = new Languages() { Val = "ru" };

            runProperties76.Append(runFonts154);
            runProperties76.Append(bold23);
            runProperties76.Append(color154);
            runProperties76.Append(fontSize154);
            runProperties76.Append(fontSizeComplexScript154);
            runProperties76.Append(languages148);
            Text text71 = new Text();
            text71.Text = "1.4 Перечень формируемых компетенций";

            run76.Append(runProperties76);
            run76.Append(text71);

            paragraph78.Append(paragraphProperties78);
            paragraph78.Append(run76);

            Paragraph paragraph79 = new Paragraph() { RsidParagraphAddition = "003678C0", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "003678C0" };

            ParagraphProperties paragraphProperties79 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE77 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN77 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent77 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines77 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification70 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties79 = new ParagraphMarkRunProperties();
            RunFonts runFonts155 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color155 = new Color() { Val = "000000" };
            FontSize fontSize155 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript155 = new FontSizeComplexScript() { Val = "24" };
            Languages languages149 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties79.Append(runFonts155);
            paragraphMarkRunProperties79.Append(color155);
            paragraphMarkRunProperties79.Append(fontSize155);
            paragraphMarkRunProperties79.Append(fontSizeComplexScript155);
            paragraphMarkRunProperties79.Append(languages149);

            paragraphProperties79.Append(autoSpaceDE77);
            paragraphProperties79.Append(autoSpaceDN77);
            paragraphProperties79.Append(adjustRightIndent77);
            paragraphProperties79.Append(spacingBetweenLines77);
            paragraphProperties79.Append(justification70);
            paragraphProperties79.Append(paragraphMarkRunProperties79);

            paragraph79.Append(paragraphProperties79);

            Paragraph paragraph80 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties80 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE78 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN78 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent78 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines78 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification71 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties80 = new ParagraphMarkRunProperties();
            RunFonts runFonts156 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold24 = new Bold();
            Color color156 = new Color() { Val = "000000" };
            FontSize fontSize156 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript156 = new FontSizeComplexScript() { Val = "24" };
            Languages languages150 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties80.Append(runFonts156);
            paragraphMarkRunProperties80.Append(bold24);
            paragraphMarkRunProperties80.Append(color156);
            paragraphMarkRunProperties80.Append(fontSize156);
            paragraphMarkRunProperties80.Append(fontSizeComplexScript156);
            paragraphMarkRunProperties80.Append(languages150);

            paragraphProperties80.Append(autoSpaceDE78);
            paragraphProperties80.Append(autoSpaceDN78);
            paragraphProperties80.Append(adjustRightIndent78);
            paragraphProperties80.Append(spacingBetweenLines78);
            paragraphProperties80.Append(justification71);
            paragraphProperties80.Append(paragraphMarkRunProperties80);

            Run run77 = new Run();

            RunProperties runProperties77 = new RunProperties();
            RunFonts runFonts157 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold25 = new Bold();
            Color color157 = new Color() { Val = "000000" };
            FontSize fontSize157 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript157 = new FontSizeComplexScript() { Val = "24" };
            Languages languages151 = new Languages() { Val = "ru" };

            runProperties77.Append(runFonts157);
            runProperties77.Append(bold25);
            runProperties77.Append(color157);
            runProperties77.Append(fontSize157);
            runProperties77.Append(fontSizeComplexScript157);
            runProperties77.Append(languages151);
            Text text72 = new Text();
            text72.Text = "Общие компетенции (ОК)";

            run77.Append(runProperties77);
            run77.Append(text72);

            paragraph80.Append(paragraphProperties80);
            paragraph80.Append(run77);

            Paragraph paragraph81 = new Paragraph() { RsidParagraphAddition = "003678C0", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "003678C0" };

            ParagraphProperties paragraphProperties81 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE79 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN79 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent79 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines79 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification72 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties81 = new ParagraphMarkRunProperties();
            RunFonts runFonts158 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color158 = new Color() { Val = "000000" };
            FontSize fontSize158 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript158 = new FontSizeComplexScript() { Val = "24" };
            Languages languages152 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties81.Append(runFonts158);
            paragraphMarkRunProperties81.Append(color158);
            paragraphMarkRunProperties81.Append(fontSize158);
            paragraphMarkRunProperties81.Append(fontSizeComplexScript158);
            paragraphMarkRunProperties81.Append(languages152);

            paragraphProperties81.Append(autoSpaceDE79);
            paragraphProperties81.Append(autoSpaceDN79);
            paragraphProperties81.Append(adjustRightIndent79);
            paragraphProperties81.Append(spacingBetweenLines79);
            paragraphProperties81.Append(justification72);
            paragraphProperties81.Append(paragraphMarkRunProperties81);

            paragraph81.Append(paragraphProperties81);

            Paragraph paragraph82 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties82 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE80 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN80 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent80 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines80 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification73 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties82 = new ParagraphMarkRunProperties();
            RunFonts runFonts159 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color159 = new Color() { Val = "000000" };
            FontSize fontSize159 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript159 = new FontSizeComplexScript() { Val = "24" };
            Languages languages153 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties82.Append(runFonts159);
            paragraphMarkRunProperties82.Append(color159);
            paragraphMarkRunProperties82.Append(fontSize159);
            paragraphMarkRunProperties82.Append(fontSizeComplexScript159);
            paragraphMarkRunProperties82.Append(languages153);

            paragraphProperties82.Append(autoSpaceDE80);
            paragraphProperties82.Append(autoSpaceDN80);
            paragraphProperties82.Append(adjustRightIndent80);
            paragraphProperties82.Append(spacingBetweenLines80);
            paragraphProperties82.Append(justification73);
            paragraphProperties82.Append(paragraphMarkRunProperties82);

            Run run78 = new Run();

            RunProperties runProperties78 = new RunProperties();
            RunFonts runFonts160 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold26 = new Bold();
            Color color160 = new Color() { Val = "000000" };
            FontSize fontSize160 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript160 = new FontSizeComplexScript() { Val = "24" };
            Languages languages154 = new Languages() { Val = "ru" };

            runProperties78.Append(runFonts160);
            runProperties78.Append(bold26);
            runProperties78.Append(color160);
            runProperties78.Append(fontSize160);
            runProperties78.Append(fontSizeComplexScript160);
            runProperties78.Append(languages154);
            Text text73 = new Text();
            text73.Text = "1.5 Рекомендуемое количество часов на освоение учебной дисциплины";

            run78.Append(runProperties78);
            run78.Append(text73);

            Run run79 = new Run();

            RunProperties runProperties79 = new RunProperties();
            RunFonts runFonts161 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color161 = new Color() { Val = "000000" };
            FontSize fontSize161 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript161 = new FontSizeComplexScript() { Val = "24" };
            Languages languages155 = new Languages() { Val = "ru" };

            runProperties79.Append(runFonts161);
            runProperties79.Append(color161);
            runProperties79.Append(fontSize161);
            runProperties79.Append(fontSizeComplexScript161);
            runProperties79.Append(languages155);
            Text text74 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text74.Text = "     Максимальная учебная нагрузка обучающегося ";

            run79.Append(runProperties79);
            run79.Append(text74);

            Run run80 = new Run() { RsidRunProperties = "00E43A47" };

            RunProperties runProperties80 = new RunProperties();
            RunFonts runFonts162 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color162 = new Color() { Val = "000000" };
            FontSize fontSize162 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript162 = new FontSizeComplexScript() { Val = "24" };

            runProperties80.Append(runFonts162);
            runProperties80.Append(color162);
            runProperties80.Append(fontSize162);
            runProperties80.Append(fontSizeComplexScript162);
            Text text75 = new Text();
            text75.Text = "2";

            run80.Append(runProperties80);
            run80.Append(text75);

            Run run81 = new Run();

            RunProperties runProperties81 = new RunProperties();
            RunFonts runFonts163 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color163 = new Color() { Val = "000000" };
            FontSize fontSize163 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript163 = new FontSizeComplexScript() { Val = "24" };
            Languages languages156 = new Languages() { Val = "ru" };

            runProperties81.Append(runFonts163);
            runProperties81.Append(color163);
            runProperties81.Append(fontSize163);
            runProperties81.Append(fontSizeComplexScript163);
            runProperties81.Append(languages156);
            Text text76 = new Text();
            text76.Text = "0 часов, в том числе:";

            run81.Append(runProperties81);
            run81.Append(text76);

            paragraph82.Append(paragraphProperties82);
            paragraph82.Append(run78);
            paragraph82.Append(run79);
            paragraph82.Append(run80);
            paragraph82.Append(run81);

            Paragraph paragraph83 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties83 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE81 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN81 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent81 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines81 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification74 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties83 = new ParagraphMarkRunProperties();
            RunFonts runFonts164 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color164 = new Color() { Val = "000000" };
            FontSize fontSize164 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript164 = new FontSizeComplexScript() { Val = "24" };
            Languages languages157 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties83.Append(runFonts164);
            paragraphMarkRunProperties83.Append(color164);
            paragraphMarkRunProperties83.Append(fontSize164);
            paragraphMarkRunProperties83.Append(fontSizeComplexScript164);
            paragraphMarkRunProperties83.Append(languages157);

            paragraphProperties83.Append(autoSpaceDE81);
            paragraphProperties83.Append(autoSpaceDN81);
            paragraphProperties83.Append(adjustRightIndent81);
            paragraphProperties83.Append(spacingBetweenLines81);
            paragraphProperties83.Append(justification74);
            paragraphProperties83.Append(paragraphMarkRunProperties83);

            Run run82 = new Run();

            RunProperties runProperties82 = new RunProperties();
            RunFonts runFonts165 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color165 = new Color() { Val = "000000" };
            FontSize fontSize165 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript165 = new FontSizeComplexScript() { Val = "24" };
            Languages languages158 = new Languages() { Val = "ru" };

            runProperties82.Append(runFonts165);
            runProperties82.Append(color165);
            runProperties82.Append(fontSize165);
            runProperties82.Append(fontSizeComplexScript165);
            runProperties82.Append(languages158);
            Text text77 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text77.Text = "- обязательная аудиторная учебная нагрузка ";

            run82.Append(runProperties82);
            run82.Append(text77);

            Run run83 = new Run() { RsidRunProperties = "00D73B0F" };

            RunProperties runProperties83 = new RunProperties();
            RunFonts runFonts166 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color166 = new Color() { Val = "000000" };
            FontSize fontSize166 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript166 = new FontSizeComplexScript() { Val = "24" };

            runProperties83.Append(runFonts166);
            runProperties83.Append(color166);
            runProperties83.Append(fontSize166);
            runProperties83.Append(fontSizeComplexScript166);
            Text text78 = new Text();
            text78.Text = EduHours.ToString();

            run83.Append(runProperties83);
            run83.Append(text78);

            Run run84 = new Run();

            RunProperties runProperties84 = new RunProperties();
            RunFonts runFonts167 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color167 = new Color() { Val = "000000" };
            FontSize fontSize167 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript167 = new FontSizeComplexScript() { Val = "24" };
            Languages languages159 = new Languages() { Val = "ru" };

            runProperties84.Append(runFonts167);
            runProperties84.Append(color167);
            runProperties84.Append(fontSize167);
            runProperties84.Append(fontSizeComplexScript167);
            runProperties84.Append(languages159);
            Text text79 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text79.Text = " часов";

            run84.Append(runProperties84);
            run84.Append(text79);

            Run run85 = new Run();

            RunProperties runProperties85 = new RunProperties();
            RunFonts runFonts168 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color168 = new Color() { Val = "000000" };
            FontSize fontSize168 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript168 = new FontSizeComplexScript() { Val = "24" };
            Languages languages160 = new Languages() { Val = "ru" };

            runProperties85.Append(runFonts168);
            runProperties85.Append(color168);
            runProperties85.Append(fontSize168);
            runProperties85.Append(fontSizeComplexScript168);
            runProperties85.Append(languages160);
            Text text80 = new Text();
            text80.Text = ";";

            run85.Append(runProperties85);
            run85.Append(text80);

            paragraph83.Append(paragraphProperties83);
            paragraph83.Append(run82);
            paragraph83.Append(run83);
            paragraph83.Append(run84);
            paragraph83.Append(run85);

            Paragraph paragraph84 = new Paragraph() { RsidParagraphAddition = "00D73B0F", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties84 = new ParagraphProperties();
            AutoSpaceDE autoSpaceDE82 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN82 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent82 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines82 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification75 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties84 = new ParagraphMarkRunProperties();
            RunFonts runFonts169 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color169 = new Color() { Val = "000000" };
            FontSize fontSize169 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript169 = new FontSizeComplexScript() { Val = "24" };
            Languages languages161 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties84.Append(runFonts169);
            paragraphMarkRunProperties84.Append(color169);
            paragraphMarkRunProperties84.Append(fontSize169);
            paragraphMarkRunProperties84.Append(fontSizeComplexScript169);
            paragraphMarkRunProperties84.Append(languages161);

            paragraphProperties84.Append(autoSpaceDE82);
            paragraphProperties84.Append(autoSpaceDN82);
            paragraphProperties84.Append(adjustRightIndent82);
            paragraphProperties84.Append(spacingBetweenLines82);
            paragraphProperties84.Append(justification75);
            paragraphProperties84.Append(paragraphMarkRunProperties84);

            Run run86 = new Run();

            RunProperties runProperties86 = new RunProperties();
            RunFonts runFonts170 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color170 = new Color() { Val = "000000" };
            FontSize fontSize170 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript170 = new FontSizeComplexScript() { Val = "24" };
            Languages languages162 = new Languages() { Val = "ru" };

            runProperties86.Append(runFonts170);
            runProperties86.Append(color170);
            runProperties86.Append(fontSize170);
            runProperties86.Append(fontSizeComplexScript170);
            runProperties86.Append(languages162);
            Text text81 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text81.Text = "- самостоятельная работа обучающегося ";

            run86.Append(runProperties86);
            run86.Append(text81);

            Run run87 = new Run();

            RunProperties runProperties87 = new RunProperties();
            RunFonts runFonts171 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color171 = new Color() { Val = "000000" };
            FontSize fontSize171 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript171 = new FontSizeComplexScript() { Val = "24" };
            Languages languages163 = new Languages() { Val = "en-US" };

            runProperties87.Append(runFonts171);
            runProperties87.Append(color171);
            runProperties87.Append(fontSize171);
            runProperties87.Append(fontSizeComplexScript171);
            runProperties87.Append(languages163);
            Text text82 = new Text();
            text82.Text = SelfHours.ToString();

            run87.Append(runProperties87);
            run87.Append(text82);

            Run run88 = new Run();

            RunProperties runProperties88 = new RunProperties();
            RunFonts runFonts172 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color172 = new Color() { Val = "000000" };
            FontSize fontSize172 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript172 = new FontSizeComplexScript() { Val = "24" };
            Languages languages164 = new Languages() { Val = "ru" };

            runProperties88.Append(runFonts172);
            runProperties88.Append(color172);
            runProperties88.Append(fontSize172);
            runProperties88.Append(fontSizeComplexScript172);
            runProperties88.Append(languages164);
            Text text83 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text83.Text = " часов.";

            run88.Append(runProperties88);
            run88.Append(text83);

            paragraph84.Append(paragraphProperties84);
            paragraph84.Append(run86);
            paragraph84.Append(run87);
            paragraph84.Append(run88);

            Paragraph paragraph85 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00D73B0F", RsidRunAdditionDefault = "00D73B0F" };

            ParagraphProperties paragraphProperties85 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties85 = new ParagraphMarkRunProperties();
            RunFonts runFonts173 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color173 = new Color() { Val = "000000" };
            FontSize fontSize173 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript173 = new FontSizeComplexScript() { Val = "24" };
            Languages languages165 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties85.Append(runFonts173);
            paragraphMarkRunProperties85.Append(color173);
            paragraphMarkRunProperties85.Append(fontSize173);
            paragraphMarkRunProperties85.Append(fontSizeComplexScript173);
            paragraphMarkRunProperties85.Append(languages165);

            paragraphProperties85.Append(paragraphMarkRunProperties85);

            Run run89 = new Run();

            RunProperties runProperties89 = new RunProperties();
            RunFonts runFonts174 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color174 = new Color() { Val = "000000" };
            FontSize fontSize174 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript174 = new FontSizeComplexScript() { Val = "24" };
            Languages languages166 = new Languages() { Val = "ru" };

            runProperties89.Append(runFonts174);
            runProperties89.Append(color174);
            runProperties89.Append(fontSize174);
            runProperties89.Append(fontSizeComplexScript174);
            runProperties89.Append(languages166);
            Break break9 = new Break() { Type = BreakValues.Page };

            run89.Append(runProperties89);
            run89.Append(break9);

            paragraph85.Append(paragraphProperties85);
            paragraph85.Append(run89);

            Paragraph paragraph86 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties86 = new ParagraphProperties();
            WidowControl widowControl58 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE83 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN83 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent83 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines83 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification76 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties86 = new ParagraphMarkRunProperties();
            RunFonts runFonts175 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold27 = new Bold();
            Color color175 = new Color() { Val = "000000" };
            FontSize fontSize175 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript175 = new FontSizeComplexScript() { Val = "24" };
            Languages languages167 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties86.Append(runFonts175);
            paragraphMarkRunProperties86.Append(bold27);
            paragraphMarkRunProperties86.Append(color175);
            paragraphMarkRunProperties86.Append(fontSize175);
            paragraphMarkRunProperties86.Append(fontSizeComplexScript175);
            paragraphMarkRunProperties86.Append(languages167);

            paragraphProperties86.Append(widowControl58);
            paragraphProperties86.Append(autoSpaceDE83);
            paragraphProperties86.Append(autoSpaceDN83);
            paragraphProperties86.Append(adjustRightIndent83);
            paragraphProperties86.Append(spacingBetweenLines83);
            paragraphProperties86.Append(justification76);
            paragraphProperties86.Append(paragraphMarkRunProperties86);

            Run run90 = new Run();

            RunProperties runProperties90 = new RunProperties();
            RunFonts runFonts176 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold28 = new Bold();
            Color color176 = new Color() { Val = "000000" };
            FontSize fontSize176 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript176 = new FontSizeComplexScript() { Val = "24" };
            Languages languages168 = new Languages() { Val = "ru" };

            runProperties90.Append(runFonts176);
            runProperties90.Append(bold28);
            runProperties90.Append(color176);
            runProperties90.Append(fontSize176);
            runProperties90.Append(fontSizeComplexScript176);
            runProperties90.Append(languages168);
            LastRenderedPageBreak lastRenderedPageBreak4 = new LastRenderedPageBreak();
            Text text84 = new Text();
            text84.Text = "2. СТРУКТУРА И СОДЕРЖАНИЕ УЧЕБНОЙ ДИСЦИПЛИНЫ";

            run90.Append(runProperties90);
            run90.Append(lastRenderedPageBreak4);
            run90.Append(text84);

            paragraph86.Append(paragraphProperties86);
            paragraph86.Append(run90);

            Paragraph paragraph87 = new Paragraph() { RsidParagraphAddition = "0031269F", RsidRunAdditionDefault = "0031269F" };

            ParagraphProperties paragraphProperties87 = new ParagraphProperties();
            WidowControl widowControl59 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE84 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN84 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent84 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines84 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification77 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties87 = new ParagraphMarkRunProperties();
            RunFonts runFonts177 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color177 = new Color() { Val = "000000" };
            FontSize fontSize177 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript177 = new FontSizeComplexScript() { Val = "24" };
            Languages languages169 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties87.Append(runFonts177);
            paragraphMarkRunProperties87.Append(color177);
            paragraphMarkRunProperties87.Append(fontSize177);
            paragraphMarkRunProperties87.Append(fontSizeComplexScript177);
            paragraphMarkRunProperties87.Append(languages169);

            paragraphProperties87.Append(widowControl59);
            paragraphProperties87.Append(autoSpaceDE84);
            paragraphProperties87.Append(autoSpaceDN84);
            paragraphProperties87.Append(adjustRightIndent84);
            paragraphProperties87.Append(spacingBetweenLines84);
            paragraphProperties87.Append(justification77);
            paragraphProperties87.Append(paragraphMarkRunProperties87);

            paragraph87.Append(paragraphProperties87);

            Paragraph paragraph88 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties88 = new ParagraphProperties();
            WidowControl widowControl60 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE85 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN85 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent85 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines85 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification78 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties88 = new ParagraphMarkRunProperties();
            RunFonts runFonts178 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold29 = new Bold();
            Color color178 = new Color() { Val = "000000" };
            FontSize fontSize178 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript178 = new FontSizeComplexScript() { Val = "24" };
            Languages languages170 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties88.Append(runFonts178);
            paragraphMarkRunProperties88.Append(bold29);
            paragraphMarkRunProperties88.Append(color178);
            paragraphMarkRunProperties88.Append(fontSize178);
            paragraphMarkRunProperties88.Append(fontSizeComplexScript178);
            paragraphMarkRunProperties88.Append(languages170);

            paragraphProperties88.Append(widowControl60);
            paragraphProperties88.Append(autoSpaceDE85);
            paragraphProperties88.Append(autoSpaceDN85);
            paragraphProperties88.Append(adjustRightIndent85);
            paragraphProperties88.Append(spacingBetweenLines85);
            paragraphProperties88.Append(justification78);
            paragraphProperties88.Append(paragraphMarkRunProperties88);

            Run run91 = new Run();

            RunProperties runProperties91 = new RunProperties();
            RunFonts runFonts179 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold30 = new Bold();
            Color color179 = new Color() { Val = "000000" };
            FontSize fontSize179 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript179 = new FontSizeComplexScript() { Val = "24" };
            Languages languages171 = new Languages() { Val = "ru" };

            runProperties91.Append(runFonts179);
            runProperties91.Append(bold30);
            runProperties91.Append(color179);
            runProperties91.Append(fontSize179);
            runProperties91.Append(fontSizeComplexScript179);
            runProperties91.Append(languages171);
            Text text85 = new Text();
            text85.Text = "2.1. Объем учебной дисциплины и виды учебной работы";

            run91.Append(runProperties91);
            run91.Append(text85);

            paragraph88.Append(paragraphProperties88);
            paragraph88.Append(run91);

            Paragraph paragraph89 = new Paragraph() { RsidParagraphAddition = "00C8780D", RsidRunAdditionDefault = "00C8780D" };

            ParagraphProperties paragraphProperties89 = new ParagraphProperties();
            WidowControl widowControl61 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE86 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN86 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent86 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines86 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification79 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties89 = new ParagraphMarkRunProperties();
            RunFonts runFonts180 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color180 = new Color() { Val = "000000" };
            FontSize fontSize180 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript180 = new FontSizeComplexScript() { Val = "24" };
            Languages languages172 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties89.Append(runFonts180);
            paragraphMarkRunProperties89.Append(color180);
            paragraphMarkRunProperties89.Append(fontSize180);
            paragraphMarkRunProperties89.Append(fontSizeComplexScript180);
            paragraphMarkRunProperties89.Append(languages172);

            paragraphProperties89.Append(widowControl61);
            paragraphProperties89.Append(autoSpaceDE86);
            paragraphProperties89.Append(autoSpaceDN86);
            paragraphProperties89.Append(adjustRightIndent86);
            paragraphProperties89.Append(spacingBetweenLines86);
            paragraphProperties89.Append(justification79);
            paragraphProperties89.Append(paragraphMarkRunProperties89);

            paragraph89.Append(paragraphProperties89);

            Table table3 = new Table();

            TableProperties tableProperties3 = new TableProperties();
            TableWidth tableWidth3 = new TableWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation3 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders2 = new TableBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders2.Append(topBorder4);
            tableBorders2.Append(leftBorder4);
            tableBorders2.Append(bottomBorder4);
            tableBorders2.Append(rightBorder4);
            tableBorders2.Append(insideHorizontalBorder2);
            tableBorders2.Append(insideVerticalBorder2);
            TableLayout tableLayout3 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault3 = new TableCellMarginDefault();
            TopMargin topMargin3 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin3 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin3 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin3 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault3.Append(topMargin3);
            tableCellMarginDefault3.Append(tableCellLeftMargin3);
            tableCellMarginDefault3.Append(bottomMargin3);
            tableCellMarginDefault3.Append(tableCellRightMargin3);
            TableLook tableLook3 = new TableLook() { Val = "0000" };

            tableProperties3.Append(tableWidth3);
            tableProperties3.Append(tableIndentation3);
            tableProperties3.Append(tableBorders2);
            tableProperties3.Append(tableLayout3);
            tableProperties3.Append(tableCellMarginDefault3);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            GridColumn gridColumn5 = new GridColumn() { Width = "7357" };
            GridColumn gridColumn6 = new GridColumn() { Width = "2410" };

            tableGrid3.Append(gridColumn5);
            tableGrid3.Append(gridColumn6);

            TableRow tableRow4 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell7 = new TableCell();

            TableCellProperties tableCellProperties7 = new TableCellProperties();
            TableCellWidth tableCellWidth7 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties7.Append(tableCellWidth7);

            Paragraph paragraph90 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties90 = new ParagraphProperties();
            WidowControl widowControl62 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE87 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN87 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent87 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines87 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification80 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties90 = new ParagraphMarkRunProperties();
            RunFonts runFonts181 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color181 = new Color() { Val = "000000" };
            FontSize fontSize181 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript181 = new FontSizeComplexScript() { Val = "24" };
            Languages languages173 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties90.Append(runFonts181);
            paragraphMarkRunProperties90.Append(color181);
            paragraphMarkRunProperties90.Append(fontSize181);
            paragraphMarkRunProperties90.Append(fontSizeComplexScript181);
            paragraphMarkRunProperties90.Append(languages173);

            paragraphProperties90.Append(widowControl62);
            paragraphProperties90.Append(autoSpaceDE87);
            paragraphProperties90.Append(autoSpaceDN87);
            paragraphProperties90.Append(adjustRightIndent87);
            paragraphProperties90.Append(spacingBetweenLines87);
            paragraphProperties90.Append(justification80);
            paragraphProperties90.Append(paragraphMarkRunProperties90);

            Run run92 = new Run();

            RunProperties runProperties92 = new RunProperties();
            RunFonts runFonts182 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold31 = new Bold();
            Color color182 = new Color() { Val = "000000" };
            FontSize fontSize182 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript182 = new FontSizeComplexScript() { Val = "24" };
            Languages languages174 = new Languages() { Val = "ru" };

            runProperties92.Append(runFonts182);
            runProperties92.Append(bold31);
            runProperties92.Append(color182);
            runProperties92.Append(fontSize182);
            runProperties92.Append(fontSizeComplexScript182);
            runProperties92.Append(languages174);
            Text text86 = new Text();
            text86.Text = "Вид учебной работы";

            run92.Append(runProperties92);
            run92.Append(text86);

            paragraph90.Append(paragraphProperties90);
            paragraph90.Append(run92);

            tableCell7.Append(tableCellProperties7);
            tableCell7.Append(paragraph90);

            TableCell tableCell8 = new TableCell();

            TableCellProperties tableCellProperties8 = new TableCellProperties();
            TableCellWidth tableCellWidth8 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties8.Append(tableCellWidth8);

            Paragraph paragraph91 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties91 = new ParagraphProperties();
            WidowControl widowControl63 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE88 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN88 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent88 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines88 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification81 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties91 = new ParagraphMarkRunProperties();
            RunFonts runFonts183 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color183 = new Color() { Val = "000000" };
            FontSize fontSize183 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript183 = new FontSizeComplexScript() { Val = "24" };
            Languages languages175 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties91.Append(runFonts183);
            paragraphMarkRunProperties91.Append(color183);
            paragraphMarkRunProperties91.Append(fontSize183);
            paragraphMarkRunProperties91.Append(fontSizeComplexScript183);
            paragraphMarkRunProperties91.Append(languages175);

            paragraphProperties91.Append(widowControl63);
            paragraphProperties91.Append(autoSpaceDE88);
            paragraphProperties91.Append(autoSpaceDN88);
            paragraphProperties91.Append(adjustRightIndent88);
            paragraphProperties91.Append(spacingBetweenLines88);
            paragraphProperties91.Append(justification81);
            paragraphProperties91.Append(paragraphMarkRunProperties91);

            Run run93 = new Run();

            RunProperties runProperties93 = new RunProperties();
            RunFonts runFonts184 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold32 = new Bold();
            Color color184 = new Color() { Val = "000000" };
            FontSize fontSize184 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript184 = new FontSizeComplexScript() { Val = "24" };
            Languages languages176 = new Languages() { Val = "ru" };

            runProperties93.Append(runFonts184);
            runProperties93.Append(bold32);
            runProperties93.Append(color184);
            runProperties93.Append(fontSize184);
            runProperties93.Append(fontSizeComplexScript184);
            runProperties93.Append(languages176);
            Text text87 = new Text();
            text87.Text = "Объем часов";

            run93.Append(runProperties93);
            run93.Append(text87);

            paragraph91.Append(paragraphProperties91);
            paragraph91.Append(run93);

            tableCell8.Append(tableCellProperties8);
            tableCell8.Append(paragraph91);

            tableRow4.Append(tableCell7);
            tableRow4.Append(tableCell8);

            TableRow tableRow5 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell9 = new TableCell();

            TableCellProperties tableCellProperties9 = new TableCellProperties();
            TableCellWidth tableCellWidth9 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties9.Append(tableCellWidth9);

            Paragraph paragraph92 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties92 = new ParagraphProperties();
            WidowControl widowControl64 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE89 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN89 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent89 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines89 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties92 = new ParagraphMarkRunProperties();
            RunFonts runFonts185 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color185 = new Color() { Val = "000000" };
            FontSize fontSize185 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript185 = new FontSizeComplexScript() { Val = "24" };
            Languages languages177 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties92.Append(runFonts185);
            paragraphMarkRunProperties92.Append(color185);
            paragraphMarkRunProperties92.Append(fontSize185);
            paragraphMarkRunProperties92.Append(fontSizeComplexScript185);
            paragraphMarkRunProperties92.Append(languages177);

            paragraphProperties92.Append(widowControl64);
            paragraphProperties92.Append(autoSpaceDE89);
            paragraphProperties92.Append(autoSpaceDN89);
            paragraphProperties92.Append(adjustRightIndent89);
            paragraphProperties92.Append(spacingBetweenLines89);
            paragraphProperties92.Append(paragraphMarkRunProperties92);

            Run run94 = new Run();

            RunProperties runProperties94 = new RunProperties();
            RunFonts runFonts186 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold33 = new Bold();
            Color color186 = new Color() { Val = "000000" };
            FontSize fontSize186 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript186 = new FontSizeComplexScript() { Val = "24" };
            Languages languages178 = new Languages() { Val = "ru" };

            runProperties94.Append(runFonts186);
            runProperties94.Append(bold33);
            runProperties94.Append(color186);
            runProperties94.Append(fontSize186);
            runProperties94.Append(fontSizeComplexScript186);
            runProperties94.Append(languages178);
            Text text88 = new Text();
            text88.Text = "Максимальная учебная нагрузка (всего)";

            run94.Append(runProperties94);
            run94.Append(text88);

            paragraph92.Append(paragraphProperties92);
            paragraph92.Append(run94);

            tableCell9.Append(tableCellProperties9);
            tableCell9.Append(paragraph92);

            TableCell tableCell10 = new TableCell();

            TableCellProperties tableCellProperties10 = new TableCellProperties();
            TableCellWidth tableCellWidth10 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties10.Append(tableCellWidth10);

            Paragraph paragraph93 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties93 = new ParagraphProperties();
            WidowControl widowControl65 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE90 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN90 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent90 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines90 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification82 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties93 = new ParagraphMarkRunProperties();
            RunFonts runFonts187 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color187 = new Color() { Val = "000000" };
            FontSize fontSize187 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript187 = new FontSizeComplexScript() { Val = "24" };
            Languages languages179 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties93.Append(runFonts187);
            paragraphMarkRunProperties93.Append(color187);
            paragraphMarkRunProperties93.Append(fontSize187);
            paragraphMarkRunProperties93.Append(fontSizeComplexScript187);
            paragraphMarkRunProperties93.Append(languages179);

            paragraphProperties93.Append(widowControl65);
            paragraphProperties93.Append(autoSpaceDE90);
            paragraphProperties93.Append(autoSpaceDN90);
            paragraphProperties93.Append(adjustRightIndent90);
            paragraphProperties93.Append(spacingBetweenLines90);
            paragraphProperties93.Append(justification82);
            paragraphProperties93.Append(paragraphMarkRunProperties93);

            Run run95 = new Run();

            RunProperties runProperties95 = new RunProperties();
            RunFonts runFonts188 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color188 = new Color() { Val = "000000" };
            FontSize fontSize188 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript188 = new FontSizeComplexScript() { Val = "24" };
            Languages languages180 = new Languages() { Val = "ru" };

            runProperties95.Append(runFonts188);
            runProperties95.Append(color188);
            runProperties95.Append(fontSize188);
            runProperties95.Append(fontSizeComplexScript188);
            runProperties95.Append(languages180);
            Text text89 = new Text();
            text89.Text = "0";

            run95.Append(runProperties95);
            run95.Append(text89);

            paragraph93.Append(paragraphProperties93);
            paragraph93.Append(run95);

            tableCell10.Append(tableCellProperties10);
            tableCell10.Append(paragraph93);

            tableRow5.Append(tableCell9);
            tableRow5.Append(tableCell10);

            TableRow tableRow6 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell11 = new TableCell();

            TableCellProperties tableCellProperties11 = new TableCellProperties();
            TableCellWidth tableCellWidth11 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties11.Append(tableCellWidth11);

            Paragraph paragraph94 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties94 = new ParagraphProperties();
            WidowControl widowControl66 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE91 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN91 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent91 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines91 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties94 = new ParagraphMarkRunProperties();
            RunFonts runFonts189 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color189 = new Color() { Val = "000000" };
            FontSize fontSize189 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript189 = new FontSizeComplexScript() { Val = "24" };
            Languages languages181 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties94.Append(runFonts189);
            paragraphMarkRunProperties94.Append(color189);
            paragraphMarkRunProperties94.Append(fontSize189);
            paragraphMarkRunProperties94.Append(fontSizeComplexScript189);
            paragraphMarkRunProperties94.Append(languages181);

            paragraphProperties94.Append(widowControl66);
            paragraphProperties94.Append(autoSpaceDE91);
            paragraphProperties94.Append(autoSpaceDN91);
            paragraphProperties94.Append(adjustRightIndent91);
            paragraphProperties94.Append(spacingBetweenLines91);
            paragraphProperties94.Append(paragraphMarkRunProperties94);

            Run run96 = new Run();

            RunProperties runProperties96 = new RunProperties();
            RunFonts runFonts190 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold34 = new Bold();
            Color color190 = new Color() { Val = "000000" };
            FontSize fontSize190 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript190 = new FontSizeComplexScript() { Val = "24" };
            Languages languages182 = new Languages() { Val = "ru" };

            runProperties96.Append(runFonts190);
            runProperties96.Append(bold34);
            runProperties96.Append(color190);
            runProperties96.Append(fontSize190);
            runProperties96.Append(fontSizeComplexScript190);
            runProperties96.Append(languages182);
            Text text90 = new Text();
            text90.Text = "Обязательная аудиторная учебная нагрузка (всего)";

            run96.Append(runProperties96);
            run96.Append(text90);

            paragraph94.Append(paragraphProperties94);
            paragraph94.Append(run96);

            tableCell11.Append(tableCellProperties11);
            tableCell11.Append(paragraph94);

            TableCell tableCell12 = new TableCell();

            TableCellProperties tableCellProperties12 = new TableCellProperties();
            TableCellWidth tableCellWidth12 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties12.Append(tableCellWidth12);

            Paragraph paragraph95 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties95 = new ParagraphProperties();
            WidowControl widowControl67 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE92 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN92 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent92 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines92 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification83 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties95 = new ParagraphMarkRunProperties();
            RunFonts runFonts191 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color191 = new Color() { Val = "000000" };
            FontSize fontSize191 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript191 = new FontSizeComplexScript() { Val = "24" };
            Languages languages183 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties95.Append(runFonts191);
            paragraphMarkRunProperties95.Append(color191);
            paragraphMarkRunProperties95.Append(fontSize191);
            paragraphMarkRunProperties95.Append(fontSizeComplexScript191);
            paragraphMarkRunProperties95.Append(languages183);

            paragraphProperties95.Append(widowControl67);
            paragraphProperties95.Append(autoSpaceDE92);
            paragraphProperties95.Append(autoSpaceDN92);
            paragraphProperties95.Append(adjustRightIndent92);
            paragraphProperties95.Append(spacingBetweenLines92);
            paragraphProperties95.Append(justification83);
            paragraphProperties95.Append(paragraphMarkRunProperties95);

            paragraph95.Append(paragraphProperties95);

            tableCell12.Append(tableCellProperties12);
            tableCell12.Append(paragraph95);

            tableRow6.Append(tableCell11);
            tableRow6.Append(tableCell12);

            TableRow tableRow7 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell13 = new TableCell();

            TableCellProperties tableCellProperties13 = new TableCellProperties();
            TableCellWidth tableCellWidth13 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties13.Append(tableCellWidth13);

            Paragraph paragraph96 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties96 = new ParagraphProperties();
            WidowControl widowControl68 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE93 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN93 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent93 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines93 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties96 = new ParagraphMarkRunProperties();
            RunFonts runFonts192 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color192 = new Color() { Val = "000000" };
            FontSize fontSize192 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript192 = new FontSizeComplexScript() { Val = "24" };
            Languages languages184 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties96.Append(runFonts192);
            paragraphMarkRunProperties96.Append(color192);
            paragraphMarkRunProperties96.Append(fontSize192);
            paragraphMarkRunProperties96.Append(fontSizeComplexScript192);
            paragraphMarkRunProperties96.Append(languages184);

            paragraphProperties96.Append(widowControl68);
            paragraphProperties96.Append(autoSpaceDE93);
            paragraphProperties96.Append(autoSpaceDN93);
            paragraphProperties96.Append(adjustRightIndent93);
            paragraphProperties96.Append(spacingBetweenLines93);
            paragraphProperties96.Append(paragraphMarkRunProperties96);

            Run run97 = new Run();

            RunProperties runProperties97 = new RunProperties();
            RunFonts runFonts193 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color193 = new Color() { Val = "000000" };
            FontSize fontSize193 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript193 = new FontSizeComplexScript() { Val = "24" };
            Languages languages185 = new Languages() { Val = "ru" };

            runProperties97.Append(runFonts193);
            runProperties97.Append(color193);
            runProperties97.Append(fontSize193);
            runProperties97.Append(fontSizeComplexScript193);
            runProperties97.Append(languages185);
            Text text91 = new Text();
            text91.Text = "в том числе:";

            run97.Append(runProperties97);
            run97.Append(text91);

            paragraph96.Append(paragraphProperties96);
            paragraph96.Append(run97);

            tableCell13.Append(tableCellProperties13);
            tableCell13.Append(paragraph96);

            TableCell tableCell14 = new TableCell();

            TableCellProperties tableCellProperties14 = new TableCellProperties();
            TableCellWidth tableCellWidth14 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties14.Append(tableCellWidth14);

            Paragraph paragraph97 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties97 = new ParagraphProperties();
            WidowControl widowControl69 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE94 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN94 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent94 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines94 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification84 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties97 = new ParagraphMarkRunProperties();
            RunFonts runFonts194 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color194 = new Color() { Val = "000000" };
            FontSize fontSize194 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript194 = new FontSizeComplexScript() { Val = "24" };
            Languages languages186 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties97.Append(runFonts194);
            paragraphMarkRunProperties97.Append(color194);
            paragraphMarkRunProperties97.Append(fontSize194);
            paragraphMarkRunProperties97.Append(fontSizeComplexScript194);
            paragraphMarkRunProperties97.Append(languages186);

            paragraphProperties97.Append(widowControl69);
            paragraphProperties97.Append(autoSpaceDE94);
            paragraphProperties97.Append(autoSpaceDN94);
            paragraphProperties97.Append(adjustRightIndent94);
            paragraphProperties97.Append(spacingBetweenLines94);
            paragraphProperties97.Append(justification84);
            paragraphProperties97.Append(paragraphMarkRunProperties97);

            paragraph97.Append(paragraphProperties97);

            tableCell14.Append(tableCellProperties14);
            tableCell14.Append(paragraph97);

            tableRow7.Append(tableCell13);
            tableRow7.Append(tableCell14);

            TableRow tableRow8 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell15 = new TableCell();

            TableCellProperties tableCellProperties15 = new TableCellProperties();
            TableCellWidth tableCellWidth15 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties15.Append(tableCellWidth15);

            Paragraph paragraph98 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties98 = new ParagraphProperties();
            WidowControl widowControl70 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE95 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN95 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent95 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines95 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties98 = new ParagraphMarkRunProperties();
            RunFonts runFonts195 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color195 = new Color() { Val = "000000" };
            FontSize fontSize195 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript195 = new FontSizeComplexScript() { Val = "24" };
            Languages languages187 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties98.Append(runFonts195);
            paragraphMarkRunProperties98.Append(color195);
            paragraphMarkRunProperties98.Append(fontSize195);
            paragraphMarkRunProperties98.Append(fontSizeComplexScript195);
            paragraphMarkRunProperties98.Append(languages187);

            paragraphProperties98.Append(widowControl70);
            paragraphProperties98.Append(autoSpaceDE95);
            paragraphProperties98.Append(autoSpaceDN95);
            paragraphProperties98.Append(adjustRightIndent95);
            paragraphProperties98.Append(spacingBetweenLines95);
            paragraphProperties98.Append(paragraphMarkRunProperties98);

            Run run98 = new Run();

            RunProperties runProperties98 = new RunProperties();
            RunFonts runFonts196 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color196 = new Color() { Val = "000000" };
            FontSize fontSize196 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript196 = new FontSizeComplexScript() { Val = "24" };
            Languages languages188 = new Languages() { Val = "ru" };

            runProperties98.Append(runFonts196);
            runProperties98.Append(color196);
            runProperties98.Append(fontSize196);
            runProperties98.Append(fontSizeComplexScript196);
            runProperties98.Append(languages188);
            Text text92 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text92.Text = "    лекции";

            run98.Append(runProperties98);
            run98.Append(text92);

            paragraph98.Append(paragraphProperties98);
            paragraph98.Append(run98);

            tableCell15.Append(tableCellProperties15);
            tableCell15.Append(paragraph98);

            TableCell tableCell16 = new TableCell();

            TableCellProperties tableCellProperties16 = new TableCellProperties();
            TableCellWidth tableCellWidth16 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties16.Append(tableCellWidth16);

            Paragraph paragraph99 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties99 = new ParagraphProperties();
            WidowControl widowControl71 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE96 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN96 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent96 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines96 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification85 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties99 = new ParagraphMarkRunProperties();
            RunFonts runFonts197 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color197 = new Color() { Val = "000000" };
            FontSize fontSize197 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript197 = new FontSizeComplexScript() { Val = "24" };
            Languages languages189 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties99.Append(runFonts197);
            paragraphMarkRunProperties99.Append(color197);
            paragraphMarkRunProperties99.Append(fontSize197);
            paragraphMarkRunProperties99.Append(fontSizeComplexScript197);
            paragraphMarkRunProperties99.Append(languages189);

            paragraphProperties99.Append(widowControl71);
            paragraphProperties99.Append(autoSpaceDE96);
            paragraphProperties99.Append(autoSpaceDN96);
            paragraphProperties99.Append(adjustRightIndent96);
            paragraphProperties99.Append(spacingBetweenLines96);
            paragraphProperties99.Append(justification85);
            paragraphProperties99.Append(paragraphMarkRunProperties99);

            paragraph99.Append(paragraphProperties99);

            tableCell16.Append(tableCellProperties16);
            tableCell16.Append(paragraph99);

            tableRow8.Append(tableCell15);
            tableRow8.Append(tableCell16);

            TableRow tableRow9 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell17 = new TableCell();

            TableCellProperties tableCellProperties17 = new TableCellProperties();
            TableCellWidth tableCellWidth17 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties17.Append(tableCellWidth17);

            Paragraph paragraph100 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties100 = new ParagraphProperties();
            WidowControl widowControl72 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE97 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN97 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent97 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines97 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties100 = new ParagraphMarkRunProperties();
            RunFonts runFonts198 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color198 = new Color() { Val = "000000" };
            FontSize fontSize198 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript198 = new FontSizeComplexScript() { Val = "24" };
            Languages languages190 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties100.Append(runFonts198);
            paragraphMarkRunProperties100.Append(color198);
            paragraphMarkRunProperties100.Append(fontSize198);
            paragraphMarkRunProperties100.Append(fontSizeComplexScript198);
            paragraphMarkRunProperties100.Append(languages190);

            paragraphProperties100.Append(widowControl72);
            paragraphProperties100.Append(autoSpaceDE97);
            paragraphProperties100.Append(autoSpaceDN97);
            paragraphProperties100.Append(adjustRightIndent97);
            paragraphProperties100.Append(spacingBetweenLines97);
            paragraphProperties100.Append(paragraphMarkRunProperties100);

            Run run99 = new Run();

            RunProperties runProperties99 = new RunProperties();
            RunFonts runFonts199 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color199 = new Color() { Val = "000000" };
            FontSize fontSize199 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript199 = new FontSizeComplexScript() { Val = "24" };
            Languages languages191 = new Languages() { Val = "ru" };

            runProperties99.Append(runFonts199);
            runProperties99.Append(color199);
            runProperties99.Append(fontSize199);
            runProperties99.Append(fontSizeComplexScript199);
            runProperties99.Append(languages191);
            Text text93 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text93.Text = "    лабораторные работы";

            run99.Append(runProperties99);
            run99.Append(text93);

            paragraph100.Append(paragraphProperties100);
            paragraph100.Append(run99);

            tableCell17.Append(tableCellProperties17);
            tableCell17.Append(paragraph100);

            TableCell tableCell18 = new TableCell();

            TableCellProperties tableCellProperties18 = new TableCellProperties();
            TableCellWidth tableCellWidth18 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties18.Append(tableCellWidth18);

            Paragraph paragraph101 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties101 = new ParagraphProperties();
            WidowControl widowControl73 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE98 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN98 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent98 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines98 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification86 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties101 = new ParagraphMarkRunProperties();
            RunFonts runFonts200 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color200 = new Color() { Val = "000000" };
            FontSize fontSize200 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript200 = new FontSizeComplexScript() { Val = "24" };
            Languages languages192 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties101.Append(runFonts200);
            paragraphMarkRunProperties101.Append(color200);
            paragraphMarkRunProperties101.Append(fontSize200);
            paragraphMarkRunProperties101.Append(fontSizeComplexScript200);
            paragraphMarkRunProperties101.Append(languages192);

            paragraphProperties101.Append(widowControl73);
            paragraphProperties101.Append(autoSpaceDE98);
            paragraphProperties101.Append(autoSpaceDN98);
            paragraphProperties101.Append(adjustRightIndent98);
            paragraphProperties101.Append(spacingBetweenLines98);
            paragraphProperties101.Append(justification86);
            paragraphProperties101.Append(paragraphMarkRunProperties101);

            paragraph101.Append(paragraphProperties101);

            tableCell18.Append(tableCellProperties18);
            tableCell18.Append(paragraph101);

            tableRow9.Append(tableCell17);
            tableRow9.Append(tableCell18);

            TableRow tableRow10 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell19 = new TableCell();

            TableCellProperties tableCellProperties19 = new TableCellProperties();
            TableCellWidth tableCellWidth19 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties19.Append(tableCellWidth19);

            Paragraph paragraph102 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties102 = new ParagraphProperties();
            WidowControl widowControl74 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE99 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN99 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent99 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines99 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties102 = new ParagraphMarkRunProperties();
            RunFonts runFonts201 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color201 = new Color() { Val = "000000" };
            FontSize fontSize201 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript201 = new FontSizeComplexScript() { Val = "24" };
            Languages languages193 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties102.Append(runFonts201);
            paragraphMarkRunProperties102.Append(color201);
            paragraphMarkRunProperties102.Append(fontSize201);
            paragraphMarkRunProperties102.Append(fontSizeComplexScript201);
            paragraphMarkRunProperties102.Append(languages193);

            paragraphProperties102.Append(widowControl74);
            paragraphProperties102.Append(autoSpaceDE99);
            paragraphProperties102.Append(autoSpaceDN99);
            paragraphProperties102.Append(adjustRightIndent99);
            paragraphProperties102.Append(spacingBetweenLines99);
            paragraphProperties102.Append(paragraphMarkRunProperties102);

            Run run100 = new Run();

            RunProperties runProperties100 = new RunProperties();
            RunFonts runFonts202 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color202 = new Color() { Val = "000000" };
            FontSize fontSize202 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript202 = new FontSizeComplexScript() { Val = "24" };
            Languages languages194 = new Languages() { Val = "ru" };

            runProperties100.Append(runFonts202);
            runProperties100.Append(color202);
            runProperties100.Append(fontSize202);
            runProperties100.Append(fontSizeComplexScript202);
            runProperties100.Append(languages194);
            Text text94 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text94.Text = "    практические занятия";

            run100.Append(runProperties100);
            run100.Append(text94);

            paragraph102.Append(paragraphProperties102);
            paragraph102.Append(run100);

            tableCell19.Append(tableCellProperties19);
            tableCell19.Append(paragraph102);

            TableCell tableCell20 = new TableCell();

            TableCellProperties tableCellProperties20 = new TableCellProperties();
            TableCellWidth tableCellWidth20 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties20.Append(tableCellWidth20);

            Paragraph paragraph103 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties103 = new ParagraphProperties();
            WidowControl widowControl75 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE100 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN100 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent100 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines100 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification87 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties103 = new ParagraphMarkRunProperties();
            RunFonts runFonts203 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color203 = new Color() { Val = "000000" };
            FontSize fontSize203 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript203 = new FontSizeComplexScript() { Val = "24" };
            Languages languages195 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties103.Append(runFonts203);
            paragraphMarkRunProperties103.Append(color203);
            paragraphMarkRunProperties103.Append(fontSize203);
            paragraphMarkRunProperties103.Append(fontSizeComplexScript203);
            paragraphMarkRunProperties103.Append(languages195);

            paragraphProperties103.Append(widowControl75);
            paragraphProperties103.Append(autoSpaceDE100);
            paragraphProperties103.Append(autoSpaceDN100);
            paragraphProperties103.Append(adjustRightIndent100);
            paragraphProperties103.Append(spacingBetweenLines100);
            paragraphProperties103.Append(justification87);
            paragraphProperties103.Append(paragraphMarkRunProperties103);

            paragraph103.Append(paragraphProperties103);

            tableCell20.Append(tableCellProperties20);
            tableCell20.Append(paragraph103);

            tableRow10.Append(tableCell19);
            tableRow10.Append(tableCell20);

            TableRow tableRow11 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell21 = new TableCell();

            TableCellProperties tableCellProperties21 = new TableCellProperties();
            TableCellWidth tableCellWidth21 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties21.Append(tableCellWidth21);

            Paragraph paragraph104 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties104 = new ParagraphProperties();
            WidowControl widowControl76 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE101 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN101 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent101 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines101 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties104 = new ParagraphMarkRunProperties();
            RunFonts runFonts204 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color204 = new Color() { Val = "000000" };
            FontSize fontSize204 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript204 = new FontSizeComplexScript() { Val = "24" };
            Languages languages196 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties104.Append(runFonts204);
            paragraphMarkRunProperties104.Append(color204);
            paragraphMarkRunProperties104.Append(fontSize204);
            paragraphMarkRunProperties104.Append(fontSizeComplexScript204);
            paragraphMarkRunProperties104.Append(languages196);

            paragraphProperties104.Append(widowControl76);
            paragraphProperties104.Append(autoSpaceDE101);
            paragraphProperties104.Append(autoSpaceDN101);
            paragraphProperties104.Append(adjustRightIndent101);
            paragraphProperties104.Append(spacingBetweenLines101);
            paragraphProperties104.Append(paragraphMarkRunProperties104);

            Run run101 = new Run();

            RunProperties runProperties101 = new RunProperties();
            RunFonts runFonts205 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color205 = new Color() { Val = "000000" };
            FontSize fontSize205 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript205 = new FontSizeComplexScript() { Val = "24" };
            Languages languages197 = new Languages() { Val = "ru" };

            runProperties101.Append(runFonts205);
            runProperties101.Append(color205);
            runProperties101.Append(fontSize205);
            runProperties101.Append(fontSizeComplexScript205);
            runProperties101.Append(languages197);
            Text text95 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text95.Text = "    контрольные работы";

            run101.Append(runProperties101);
            run101.Append(text95);

            paragraph104.Append(paragraphProperties104);
            paragraph104.Append(run101);

            tableCell21.Append(tableCellProperties21);
            tableCell21.Append(paragraph104);

            TableCell tableCell22 = new TableCell();

            TableCellProperties tableCellProperties22 = new TableCellProperties();
            TableCellWidth tableCellWidth22 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties22.Append(tableCellWidth22);

            Paragraph paragraph105 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties105 = new ParagraphProperties();
            WidowControl widowControl77 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE102 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN102 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent102 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines102 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification88 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties105 = new ParagraphMarkRunProperties();
            RunFonts runFonts206 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color206 = new Color() { Val = "000000" };
            FontSize fontSize206 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript206 = new FontSizeComplexScript() { Val = "24" };
            Languages languages198 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties105.Append(runFonts206);
            paragraphMarkRunProperties105.Append(color206);
            paragraphMarkRunProperties105.Append(fontSize206);
            paragraphMarkRunProperties105.Append(fontSizeComplexScript206);
            paragraphMarkRunProperties105.Append(languages198);

            paragraphProperties105.Append(widowControl77);
            paragraphProperties105.Append(autoSpaceDE102);
            paragraphProperties105.Append(autoSpaceDN102);
            paragraphProperties105.Append(adjustRightIndent102);
            paragraphProperties105.Append(spacingBetweenLines102);
            paragraphProperties105.Append(justification88);
            paragraphProperties105.Append(paragraphMarkRunProperties105);

            paragraph105.Append(paragraphProperties105);

            tableCell22.Append(tableCellProperties22);
            tableCell22.Append(paragraph105);

            tableRow11.Append(tableCell21);
            tableRow11.Append(tableCell22);

            TableRow tableRow12 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell23 = new TableCell();

            TableCellProperties tableCellProperties23 = new TableCellProperties();
            TableCellWidth tableCellWidth23 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties23.Append(tableCellWidth23);

            Paragraph paragraph106 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties106 = new ParagraphProperties();
            WidowControl widowControl78 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE103 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN103 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent103 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines103 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties106 = new ParagraphMarkRunProperties();
            RunFonts runFonts207 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color207 = new Color() { Val = "000000" };
            FontSize fontSize207 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript207 = new FontSizeComplexScript() { Val = "24" };
            Languages languages199 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties106.Append(runFonts207);
            paragraphMarkRunProperties106.Append(color207);
            paragraphMarkRunProperties106.Append(fontSize207);
            paragraphMarkRunProperties106.Append(fontSizeComplexScript207);
            paragraphMarkRunProperties106.Append(languages199);

            paragraphProperties106.Append(widowControl78);
            paragraphProperties106.Append(autoSpaceDE103);
            paragraphProperties106.Append(autoSpaceDN103);
            paragraphProperties106.Append(adjustRightIndent103);
            paragraphProperties106.Append(spacingBetweenLines103);
            paragraphProperties106.Append(paragraphMarkRunProperties106);

            Run run102 = new Run();

            RunProperties runProperties102 = new RunProperties();
            RunFonts runFonts208 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color208 = new Color() { Val = "000000" };
            FontSize fontSize208 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript208 = new FontSizeComplexScript() { Val = "24" };
            Languages languages200 = new Languages() { Val = "ru" };

            runProperties102.Append(runFonts208);
            runProperties102.Append(color208);
            runProperties102.Append(fontSize208);
            runProperties102.Append(fontSizeComplexScript208);
            runProperties102.Append(languages200);
            Text text96 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text96.Text = "    курсовая работа (если предусмотрена)";

            run102.Append(runProperties102);
            run102.Append(text96);

            paragraph106.Append(paragraphProperties106);
            paragraph106.Append(run102);

            tableCell23.Append(tableCellProperties23);
            tableCell23.Append(paragraph106);

            TableCell tableCell24 = new TableCell();

            TableCellProperties tableCellProperties24 = new TableCellProperties();
            TableCellWidth tableCellWidth24 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties24.Append(tableCellWidth24);

            Paragraph paragraph107 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties107 = new ParagraphProperties();
            WidowControl widowControl79 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE104 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN104 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent104 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines104 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification89 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties107 = new ParagraphMarkRunProperties();
            RunFonts runFonts209 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color209 = new Color() { Val = "000000" };
            FontSize fontSize209 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript209 = new FontSizeComplexScript() { Val = "24" };
            Languages languages201 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties107.Append(runFonts209);
            paragraphMarkRunProperties107.Append(color209);
            paragraphMarkRunProperties107.Append(fontSize209);
            paragraphMarkRunProperties107.Append(fontSizeComplexScript209);
            paragraphMarkRunProperties107.Append(languages201);

            paragraphProperties107.Append(widowControl79);
            paragraphProperties107.Append(autoSpaceDE104);
            paragraphProperties107.Append(autoSpaceDN104);
            paragraphProperties107.Append(adjustRightIndent104);
            paragraphProperties107.Append(spacingBetweenLines104);
            paragraphProperties107.Append(justification89);
            paragraphProperties107.Append(paragraphMarkRunProperties107);

            paragraph107.Append(paragraphProperties107);

            tableCell24.Append(tableCellProperties24);
            tableCell24.Append(paragraph107);

            tableRow12.Append(tableCell23);
            tableRow12.Append(tableCell24);

            TableRow tableRow13 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell25 = new TableCell();

            TableCellProperties tableCellProperties25 = new TableCellProperties();
            TableCellWidth tableCellWidth25 = new TableCellWidth() { Width = "7357", Type = TableWidthUnitValues.Dxa };

            tableCellProperties25.Append(tableCellWidth25);

            Paragraph paragraph108 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties108 = new ParagraphProperties();
            WidowControl widowControl80 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE105 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN105 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent105 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines105 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties108 = new ParagraphMarkRunProperties();
            RunFonts runFonts210 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color210 = new Color() { Val = "000000" };
            FontSize fontSize210 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript210 = new FontSizeComplexScript() { Val = "24" };
            Languages languages202 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties108.Append(runFonts210);
            paragraphMarkRunProperties108.Append(color210);
            paragraphMarkRunProperties108.Append(fontSize210);
            paragraphMarkRunProperties108.Append(fontSizeComplexScript210);
            paragraphMarkRunProperties108.Append(languages202);

            paragraphProperties108.Append(widowControl80);
            paragraphProperties108.Append(autoSpaceDE105);
            paragraphProperties108.Append(autoSpaceDN105);
            paragraphProperties108.Append(adjustRightIndent105);
            paragraphProperties108.Append(spacingBetweenLines105);
            paragraphProperties108.Append(paragraphMarkRunProperties108);

            Run run103 = new Run();

            RunProperties runProperties103 = new RunProperties();
            RunFonts runFonts211 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold35 = new Bold();
            Color color211 = new Color() { Val = "000000" };
            FontSize fontSize211 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript211 = new FontSizeComplexScript() { Val = "24" };
            Languages languages203 = new Languages() { Val = "ru" };

            runProperties103.Append(runFonts211);
            runProperties103.Append(bold35);
            runProperties103.Append(color211);
            runProperties103.Append(fontSize211);
            runProperties103.Append(fontSizeComplexScript211);
            runProperties103.Append(languages203);
            Text text97 = new Text();
            text97.Text = "Самостоятельная работа обучающегося (всего)";

            run103.Append(runProperties103);
            run103.Append(text97);

            paragraph108.Append(paragraphProperties108);
            paragraph108.Append(run103);

            tableCell25.Append(tableCellProperties25);
            tableCell25.Append(paragraph108);

            TableCell tableCell26 = new TableCell();

            TableCellProperties tableCellProperties26 = new TableCellProperties();
            TableCellWidth tableCellWidth26 = new TableCellWidth() { Width = "2410", Type = TableWidthUnitValues.Dxa };

            tableCellProperties26.Append(tableCellWidth26);

            Paragraph paragraph109 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties109 = new ParagraphProperties();
            WidowControl widowControl81 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE106 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN106 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent106 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines106 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification90 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties109 = new ParagraphMarkRunProperties();
            RunFonts runFonts212 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color212 = new Color() { Val = "000000" };
            FontSize fontSize212 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript212 = new FontSizeComplexScript() { Val = "24" };
            Languages languages204 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties109.Append(runFonts212);
            paragraphMarkRunProperties109.Append(color212);
            paragraphMarkRunProperties109.Append(fontSize212);
            paragraphMarkRunProperties109.Append(fontSizeComplexScript212);
            paragraphMarkRunProperties109.Append(languages204);

            paragraphProperties109.Append(widowControl81);
            paragraphProperties109.Append(autoSpaceDE106);
            paragraphProperties109.Append(autoSpaceDN106);
            paragraphProperties109.Append(adjustRightIndent106);
            paragraphProperties109.Append(spacingBetweenLines106);
            paragraphProperties109.Append(justification90);
            paragraphProperties109.Append(paragraphMarkRunProperties109);

            paragraph109.Append(paragraphProperties109);

            tableCell26.Append(tableCellProperties26);
            tableCell26.Append(paragraph109);

            tableRow13.Append(tableCell25);
            tableRow13.Append(tableCell26);

            TableRow tableRow14 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00913E98" };

            TableCell tableCell27 = new TableCell();

            TableCellProperties tableCellProperties27 = new TableCellProperties();
            TableCellWidth tableCellWidth27 = new TableCellWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan1 = new GridSpan() { Val = 2 };

            tableCellProperties27.Append(tableCellWidth27);
            tableCellProperties27.Append(gridSpan1);

            Paragraph paragraph110 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00913E98", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties110 = new ParagraphProperties();
            WidowControl widowControl82 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE107 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN107 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent107 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines107 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            ParagraphMarkRunProperties paragraphMarkRunProperties110 = new ParagraphMarkRunProperties();
            RunFonts runFonts213 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color213 = new Color() { Val = "000000" };
            FontSize fontSize213 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript213 = new FontSizeComplexScript() { Val = "24" };
            Languages languages205 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties110.Append(runFonts213);
            paragraphMarkRunProperties110.Append(color213);
            paragraphMarkRunProperties110.Append(fontSize213);
            paragraphMarkRunProperties110.Append(fontSizeComplexScript213);
            paragraphMarkRunProperties110.Append(languages205);

            paragraphProperties110.Append(widowControl82);
            paragraphProperties110.Append(autoSpaceDE107);
            paragraphProperties110.Append(autoSpaceDN107);
            paragraphProperties110.Append(adjustRightIndent107);
            paragraphProperties110.Append(spacingBetweenLines107);
            paragraphProperties110.Append(paragraphMarkRunProperties110);

            Run run104 = new Run();

            RunProperties runProperties104 = new RunProperties();
            RunFonts runFonts214 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Italic italic1 = new Italic();
            Color color214 = new Color() { Val = "000000" };
            FontSize fontSize214 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript214 = new FontSizeComplexScript() { Val = "24" };
            Languages languages206 = new Languages() { Val = "ru" };

            runProperties104.Append(runFonts214);
            runProperties104.Append(italic1);
            runProperties104.Append(color214);
            runProperties104.Append(fontSize214);
            runProperties104.Append(fontSizeComplexScript214);
            runProperties104.Append(languages206);
            Text text98 = new Text();
            text98.Text = "Итоговая аттестация в форме дифф";

            run104.Append(runProperties104);
            run104.Append(text98);

            Run run105 = new Run() { RsidRunAddition = "00913E98" };

            RunProperties runProperties105 = new RunProperties();
            RunFonts runFonts215 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Italic italic2 = new Italic();
            Color color215 = new Color() { Val = "000000" };
            FontSize fontSize215 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript215 = new FontSizeComplexScript() { Val = "24" };
            Languages languages207 = new Languages() { Val = "ru" };

            runProperties105.Append(runFonts215);
            runProperties105.Append(italic2);
            runProperties105.Append(color215);
            runProperties105.Append(fontSize215);
            runProperties105.Append(fontSizeComplexScript215);
            runProperties105.Append(languages207);
            Text text99 = new Text();
            text99.Text = "е";

            run105.Append(runProperties105);
            run105.Append(text99);

            Run run106 = new Run();

            RunProperties runProperties106 = new RunProperties();
            RunFonts runFonts216 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Italic italic3 = new Italic();
            Color color216 = new Color() { Val = "000000" };
            FontSize fontSize216 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript216 = new FontSizeComplexScript() { Val = "24" };
            Languages languages208 = new Languages() { Val = "ru" };

            runProperties106.Append(runFonts216);
            runProperties106.Append(italic3);
            runProperties106.Append(color216);
            runProperties106.Append(fontSize216);
            runProperties106.Append(fontSizeComplexScript216);
            runProperties106.Append(languages208);
            Text text100 = new Text();
            text100.Text = "ренцированного зачета в 4 семестре";

            run106.Append(runProperties106);
            run106.Append(text100);

            paragraph110.Append(paragraphProperties110);
            paragraph110.Append(run104);
            paragraph110.Append(run105);
            paragraph110.Append(run106);

            tableCell27.Append(tableCellProperties27);
            tableCell27.Append(paragraph110);

            tableRow14.Append(tableCell27);

            table3.Append(tableProperties3);
            table3.Append(tableGrid3);
            table3.Append(tableRow4);
            table3.Append(tableRow5);
            table3.Append(tableRow6);
            table3.Append(tableRow7);
            table3.Append(tableRow8);
            table3.Append(tableRow9);
            table3.Append(tableRow10);
            table3.Append(tableRow11);
            table3.Append(tableRow12);
            table3.Append(tableRow13);
            table3.Append(tableRow14);

            Paragraph paragraph111 = new Paragraph() { RsidParagraphAddition = "001E02D3", RsidRunAdditionDefault = "001E02D3" };

            ParagraphProperties paragraphProperties111 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties111 = new ParagraphMarkRunProperties();
            RunFonts runFonts217 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold36 = new Bold();
            Color color217 = new Color() { Val = "000000" };
            FontSize fontSize217 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript217 = new FontSizeComplexScript() { Val = "24" };
            Languages languages209 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties111.Append(runFonts217);
            paragraphMarkRunProperties111.Append(bold36);
            paragraphMarkRunProperties111.Append(color217);
            paragraphMarkRunProperties111.Append(fontSize217);
            paragraphMarkRunProperties111.Append(fontSizeComplexScript217);
            paragraphMarkRunProperties111.Append(languages209);

            paragraphProperties111.Append(paragraphMarkRunProperties111);

            Run run107 = new Run();

            RunProperties runProperties107 = new RunProperties();
            RunFonts runFonts218 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold37 = new Bold();
            Color color218 = new Color() { Val = "000000" };
            FontSize fontSize218 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript218 = new FontSizeComplexScript() { Val = "24" };
            Languages languages210 = new Languages() { Val = "ru" };

            runProperties107.Append(runFonts218);
            runProperties107.Append(bold37);
            runProperties107.Append(color218);
            runProperties107.Append(fontSize218);
            runProperties107.Append(fontSizeComplexScript218);
            runProperties107.Append(languages210);
            Break break10 = new Break() { Type = BreakValues.Page };

            run107.Append(runProperties107);
            run107.Append(break10);

            paragraph111.Append(paragraphProperties111);
            paragraph111.Append(run107);

            Paragraph paragraph112 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties112 = new ParagraphProperties();
            WidowControl widowControl83 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE108 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN108 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent108 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines108 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification91 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties112 = new ParagraphMarkRunProperties();
            RunFonts runFonts219 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold38 = new Bold();
            Color color219 = new Color() { Val = "000000" };
            FontSize fontSize219 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript219 = new FontSizeComplexScript() { Val = "24" };
            Languages languages211 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties112.Append(runFonts219);
            paragraphMarkRunProperties112.Append(bold38);
            paragraphMarkRunProperties112.Append(color219);
            paragraphMarkRunProperties112.Append(fontSize219);
            paragraphMarkRunProperties112.Append(fontSizeComplexScript219);
            paragraphMarkRunProperties112.Append(languages211);

            paragraphProperties112.Append(widowControl83);
            paragraphProperties112.Append(autoSpaceDE108);
            paragraphProperties112.Append(autoSpaceDN108);
            paragraphProperties112.Append(adjustRightIndent108);
            paragraphProperties112.Append(spacingBetweenLines108);
            paragraphProperties112.Append(justification91);
            paragraphProperties112.Append(paragraphMarkRunProperties112);

            Run run108 = new Run();

            RunProperties runProperties108 = new RunProperties();
            RunFonts runFonts220 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold39 = new Bold();
            Color color220 = new Color() { Val = "000000" };
            FontSize fontSize220 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript220 = new FontSizeComplexScript() { Val = "24" };
            Languages languages212 = new Languages() { Val = "ru" };

            runProperties108.Append(runFonts220);
            runProperties108.Append(bold39);
            runProperties108.Append(color220);
            runProperties108.Append(fontSize220);
            runProperties108.Append(fontSizeComplexScript220);
            runProperties108.Append(languages212);
            LastRenderedPageBreak lastRenderedPageBreak5 = new LastRenderedPageBreak();
            Text text101 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text101.Text = "    2.2 Тематический план и содержан";

            run108.Append(runProperties108);
            run108.Append(lastRenderedPageBreak5);
            run108.Append(text101);

            Run run109 = new Run() { RsidRunAddition = "00F369AA" };

            RunProperties runProperties109 = new RunProperties();
            RunFonts runFonts221 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold40 = new Bold();
            Color color221 = new Color() { Val = "000000" };
            FontSize fontSize221 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript221 = new FontSizeComplexScript() { Val = "24" };
            Languages languages213 = new Languages() { Val = "ru" };

            runProperties109.Append(runFonts221);
            runProperties109.Append(bold40);
            runProperties109.Append(color221);
            runProperties109.Append(fontSize221);
            runProperties109.Append(fontSizeComplexScript221);
            runProperties109.Append(languages213);
            Text text102 = new Text();
            text102.Text = "ие учебной дисциплины";

            run109.Append(runProperties109);
            run109.Append(text102);

            paragraph112.Append(paragraphProperties112);
            paragraph112.Append(run108);
            paragraph112.Append(run109);

            Paragraph paragraph113 = new Paragraph() { RsidParagraphAddition = "00F369AA", RsidRunAdditionDefault = "00F369AA" };

            ParagraphProperties paragraphProperties113 = new ParagraphProperties();
            WidowControl widowControl84 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE109 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN109 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent109 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines109 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification92 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties113 = new ParagraphMarkRunProperties();
            RunFonts runFonts222 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color222 = new Color() { Val = "000000" };
            FontSize fontSize222 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript222 = new FontSizeComplexScript() { Val = "24" };
            Languages languages214 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties113.Append(runFonts222);
            paragraphMarkRunProperties113.Append(color222);
            paragraphMarkRunProperties113.Append(fontSize222);
            paragraphMarkRunProperties113.Append(fontSizeComplexScript222);
            paragraphMarkRunProperties113.Append(languages214);

            paragraphProperties113.Append(widowControl84);
            paragraphProperties113.Append(autoSpaceDE109);
            paragraphProperties113.Append(autoSpaceDN109);
            paragraphProperties113.Append(adjustRightIndent109);
            paragraphProperties113.Append(spacingBetweenLines109);
            paragraphProperties113.Append(justification92);
            paragraphProperties113.Append(paragraphMarkRunProperties113);

            paragraph113.Append(paragraphProperties113);

            Table table4 = new Table();

            TableProperties tableProperties4 = new TableProperties();
            TableWidth tableWidth4 = new TableWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation4 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders3 = new TableBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder3 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder3 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders3.Append(topBorder5);
            tableBorders3.Append(leftBorder5);
            tableBorders3.Append(bottomBorder5);
            tableBorders3.Append(rightBorder5);
            tableBorders3.Append(insideHorizontalBorder3);
            tableBorders3.Append(insideVerticalBorder3);
            TableLayout tableLayout4 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault4 = new TableCellMarginDefault();
            TopMargin topMargin4 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin4 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin4 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin4 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault4.Append(topMargin4);
            tableCellMarginDefault4.Append(tableCellLeftMargin4);
            tableCellMarginDefault4.Append(bottomMargin4);
            tableCellMarginDefault4.Append(tableCellRightMargin4);
            TableLook tableLook4 = new TableLook() { Val = "0000" };

            tableProperties4.Append(tableWidth4);
            tableProperties4.Append(tableIndentation4);
            tableProperties4.Append(tableBorders3);
            tableProperties4.Append(tableLayout4);
            tableProperties4.Append(tableCellMarginDefault4);
            tableProperties4.Append(tableLook4);

            TableGrid tableGrid4 = new TableGrid();
            GridColumn gridColumn7 = new GridColumn() { Width = "2113" };
            GridColumn gridColumn8 = new GridColumn() { Width = "5386" };
            GridColumn gridColumn9 = new GridColumn() { Width = "992" };
            GridColumn gridColumn10 = new GridColumn() { Width = "1276" };

            tableGrid4.Append(gridColumn7);
            tableGrid4.Append(gridColumn8);
            tableGrid4.Append(gridColumn9);
            tableGrid4.Append(gridColumn10);

            TableRow tableRow15 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };

            TableCell tableCell28 = new TableCell();

            TableCellProperties tableCellProperties28 = new TableCellProperties();
            TableCellWidth tableCellWidth28 = new TableCellWidth() { Width = "2113", Type = TableWidthUnitValues.Dxa };

            tableCellProperties28.Append(tableCellWidth28);

            Paragraph paragraph114 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties114 = new ParagraphProperties();
            WidowControl widowControl85 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE110 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN110 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent110 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines110 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification93 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties114 = new ParagraphMarkRunProperties();
            RunFonts runFonts223 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color223 = new Color() { Val = "000000" };
            FontSize fontSize223 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript223 = new FontSizeComplexScript() { Val = "24" };
            Languages languages215 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties114.Append(runFonts223);
            paragraphMarkRunProperties114.Append(color223);
            paragraphMarkRunProperties114.Append(fontSize223);
            paragraphMarkRunProperties114.Append(fontSizeComplexScript223);
            paragraphMarkRunProperties114.Append(languages215);

            paragraphProperties114.Append(widowControl85);
            paragraphProperties114.Append(autoSpaceDE110);
            paragraphProperties114.Append(autoSpaceDN110);
            paragraphProperties114.Append(adjustRightIndent110);
            paragraphProperties114.Append(spacingBetweenLines110);
            paragraphProperties114.Append(justification93);
            paragraphProperties114.Append(paragraphMarkRunProperties114);

            Run run110 = new Run();

            RunProperties runProperties110 = new RunProperties();
            RunFonts runFonts224 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold41 = new Bold();
            Color color224 = new Color() { Val = "000000" };
            FontSize fontSize224 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript224 = new FontSizeComplexScript() { Val = "24" };
            Languages languages216 = new Languages() { Val = "ru" };

            runProperties110.Append(runFonts224);
            runProperties110.Append(bold41);
            runProperties110.Append(color224);
            runProperties110.Append(fontSize224);
            runProperties110.Append(fontSizeComplexScript224);
            runProperties110.Append(languages216);
            Text text103 = new Text();
            text103.Text = "Наименование разделов и тем";

            run110.Append(runProperties110);
            run110.Append(text103);

            paragraph114.Append(paragraphProperties114);
            paragraph114.Append(run110);

            tableCell28.Append(tableCellProperties28);
            tableCell28.Append(paragraph114);

            TableCell tableCell29 = new TableCell();

            TableCellProperties tableCellProperties29 = new TableCellProperties();
            TableCellWidth tableCellWidth29 = new TableCellWidth() { Width = "5386", Type = TableWidthUnitValues.Dxa };

            tableCellProperties29.Append(tableCellWidth29);

            Paragraph paragraph115 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties115 = new ParagraphProperties();
            WidowControl widowControl86 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE111 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN111 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent111 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines111 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification94 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties115 = new ParagraphMarkRunProperties();
            RunFonts runFonts225 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color225 = new Color() { Val = "000000" };
            FontSize fontSize225 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript225 = new FontSizeComplexScript() { Val = "24" };
            Languages languages217 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties115.Append(runFonts225);
            paragraphMarkRunProperties115.Append(color225);
            paragraphMarkRunProperties115.Append(fontSize225);
            paragraphMarkRunProperties115.Append(fontSizeComplexScript225);
            paragraphMarkRunProperties115.Append(languages217);

            paragraphProperties115.Append(widowControl86);
            paragraphProperties115.Append(autoSpaceDE111);
            paragraphProperties115.Append(autoSpaceDN111);
            paragraphProperties115.Append(adjustRightIndent111);
            paragraphProperties115.Append(spacingBetweenLines111);
            paragraphProperties115.Append(justification94);
            paragraphProperties115.Append(paragraphMarkRunProperties115);

            Run run111 = new Run();

            RunProperties runProperties111 = new RunProperties();
            RunFonts runFonts226 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold42 = new Bold();
            Color color226 = new Color() { Val = "000000" };
            FontSize fontSize226 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript226 = new FontSizeComplexScript() { Val = "24" };
            Languages languages218 = new Languages() { Val = "ru" };

            runProperties111.Append(runFonts226);
            runProperties111.Append(bold42);
            runProperties111.Append(color226);
            runProperties111.Append(fontSize226);
            runProperties111.Append(fontSizeComplexScript226);
            runProperties111.Append(languages218);
            Text text104 = new Text();
            text104.Text = "Содержание учебного материала, лабораторные и практические работы, самостоятельная работа обучающихся, курсовая работа (проект)";

            run111.Append(runProperties111);
            run111.Append(text104);

            paragraph115.Append(paragraphProperties115);
            paragraph115.Append(run111);

            tableCell29.Append(tableCellProperties29);
            tableCell29.Append(paragraph115);

            TableCell tableCell30 = new TableCell();

            TableCellProperties tableCellProperties30 = new TableCellProperties();
            TableCellWidth tableCellWidth30 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties30.Append(tableCellWidth30);

            Paragraph paragraph116 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties116 = new ParagraphProperties();
            WidowControl widowControl87 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE112 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN112 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent112 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines112 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification95 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties116 = new ParagraphMarkRunProperties();
            RunFonts runFonts227 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color227 = new Color() { Val = "000000" };
            FontSize fontSize227 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript227 = new FontSizeComplexScript() { Val = "24" };
            Languages languages219 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties116.Append(runFonts227);
            paragraphMarkRunProperties116.Append(color227);
            paragraphMarkRunProperties116.Append(fontSize227);
            paragraphMarkRunProperties116.Append(fontSizeComplexScript227);
            paragraphMarkRunProperties116.Append(languages219);

            paragraphProperties116.Append(widowControl87);
            paragraphProperties116.Append(autoSpaceDE112);
            paragraphProperties116.Append(autoSpaceDN112);
            paragraphProperties116.Append(adjustRightIndent112);
            paragraphProperties116.Append(spacingBetweenLines112);
            paragraphProperties116.Append(justification95);
            paragraphProperties116.Append(paragraphMarkRunProperties116);

            Run run112 = new Run();

            RunProperties runProperties112 = new RunProperties();
            RunFonts runFonts228 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold43 = new Bold();
            Color color228 = new Color() { Val = "000000" };
            FontSize fontSize228 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript228 = new FontSizeComplexScript() { Val = "24" };
            Languages languages220 = new Languages() { Val = "ru" };

            runProperties112.Append(runFonts228);
            runProperties112.Append(bold43);
            runProperties112.Append(color228);
            runProperties112.Append(fontSize228);
            runProperties112.Append(fontSizeComplexScript228);
            runProperties112.Append(languages220);
            Text text105 = new Text();
            text105.Text = "Объем часов";

            run112.Append(runProperties112);
            run112.Append(text105);

            paragraph116.Append(paragraphProperties116);
            paragraph116.Append(run112);

            tableCell30.Append(tableCellProperties30);
            tableCell30.Append(paragraph116);

            TableCell tableCell31 = new TableCell();

            TableCellProperties tableCellProperties31 = new TableCellProperties();
            TableCellWidth tableCellWidth31 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            tableCellProperties31.Append(tableCellWidth31);

            Paragraph paragraph117 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties117 = new ParagraphProperties();
            WidowControl widowControl88 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE113 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN113 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent113 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines113 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification96 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties117 = new ParagraphMarkRunProperties();
            RunFonts runFonts229 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color229 = new Color() { Val = "000000" };
            FontSize fontSize229 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript229 = new FontSizeComplexScript() { Val = "24" };
            Languages languages221 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties117.Append(runFonts229);
            paragraphMarkRunProperties117.Append(color229);
            paragraphMarkRunProperties117.Append(fontSize229);
            paragraphMarkRunProperties117.Append(fontSizeComplexScript229);
            paragraphMarkRunProperties117.Append(languages221);

            paragraphProperties117.Append(widowControl88);
            paragraphProperties117.Append(autoSpaceDE113);
            paragraphProperties117.Append(autoSpaceDN113);
            paragraphProperties117.Append(adjustRightIndent113);
            paragraphProperties117.Append(spacingBetweenLines113);
            paragraphProperties117.Append(justification96);
            paragraphProperties117.Append(paragraphMarkRunProperties117);

            Run run113 = new Run();

            RunProperties runProperties113 = new RunProperties();
            RunFonts runFonts230 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold44 = new Bold();
            Color color230 = new Color() { Val = "000000" };
            FontSize fontSize230 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript230 = new FontSizeComplexScript() { Val = "24" };
            Languages languages222 = new Languages() { Val = "ru" };

            runProperties113.Append(runFonts230);
            runProperties113.Append(bold44);
            runProperties113.Append(color230);
            runProperties113.Append(fontSize230);
            runProperties113.Append(fontSizeComplexScript230);
            runProperties113.Append(languages222);
            Text text106 = new Text();
            text106.Text = "Уровень освоения";

            run113.Append(runProperties113);
            run113.Append(text106);

            paragraph117.Append(paragraphProperties117);
            paragraph117.Append(run113);

            tableCell31.Append(tableCellProperties31);
            tableCell31.Append(paragraph117);

            tableRow15.Append(tableCell28);
            tableRow15.Append(tableCell29);
            tableRow15.Append(tableCell30);
            tableRow15.Append(tableCell31);

            TableRow tableRow16 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };

            TableCell tableCell32 = new TableCell();

            TableCellProperties tableCellProperties32 = new TableCellProperties();
            TableCellWidth tableCellWidth32 = new TableCellWidth() { Width = "2113", Type = TableWidthUnitValues.Dxa };

            tableCellProperties32.Append(tableCellWidth32);

            Paragraph paragraph118 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties118 = new ParagraphProperties();
            WidowControl widowControl89 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE114 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN114 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent114 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines114 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification97 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties118 = new ParagraphMarkRunProperties();
            RunFonts runFonts231 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color231 = new Color() { Val = "000000" };
            FontSize fontSize231 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript231 = new FontSizeComplexScript() { Val = "24" };
            Languages languages223 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties118.Append(runFonts231);
            paragraphMarkRunProperties118.Append(color231);
            paragraphMarkRunProperties118.Append(fontSize231);
            paragraphMarkRunProperties118.Append(fontSizeComplexScript231);
            paragraphMarkRunProperties118.Append(languages223);

            paragraphProperties118.Append(widowControl89);
            paragraphProperties118.Append(autoSpaceDE114);
            paragraphProperties118.Append(autoSpaceDN114);
            paragraphProperties118.Append(adjustRightIndent114);
            paragraphProperties118.Append(spacingBetweenLines114);
            paragraphProperties118.Append(justification97);
            paragraphProperties118.Append(paragraphMarkRunProperties118);

            Run run114 = new Run();

            RunProperties runProperties114 = new RunProperties();
            RunFonts runFonts232 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold45 = new Bold();
            Color color232 = new Color() { Val = "000000" };
            FontSize fontSize232 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript232 = new FontSizeComplexScript() { Val = "24" };
            Languages languages224 = new Languages() { Val = "ru" };

            runProperties114.Append(runFonts232);
            runProperties114.Append(bold45);
            runProperties114.Append(color232);
            runProperties114.Append(fontSize232);
            runProperties114.Append(fontSizeComplexScript232);
            runProperties114.Append(languages224);
            Text text107 = new Text();
            text107.Text = "1";

            run114.Append(runProperties114);
            run114.Append(text107);

            paragraph118.Append(paragraphProperties118);
            paragraph118.Append(run114);

            tableCell32.Append(tableCellProperties32);
            tableCell32.Append(paragraph118);

            TableCell tableCell33 = new TableCell();

            TableCellProperties tableCellProperties33 = new TableCellProperties();
            TableCellWidth tableCellWidth33 = new TableCellWidth() { Width = "5386", Type = TableWidthUnitValues.Dxa };

            tableCellProperties33.Append(tableCellWidth33);

            Paragraph paragraph119 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties119 = new ParagraphProperties();
            WidowControl widowControl90 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE115 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN115 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent115 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines115 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification98 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties119 = new ParagraphMarkRunProperties();
            RunFonts runFonts233 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color233 = new Color() { Val = "000000" };
            FontSize fontSize233 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript233 = new FontSizeComplexScript() { Val = "24" };
            Languages languages225 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties119.Append(runFonts233);
            paragraphMarkRunProperties119.Append(color233);
            paragraphMarkRunProperties119.Append(fontSize233);
            paragraphMarkRunProperties119.Append(fontSizeComplexScript233);
            paragraphMarkRunProperties119.Append(languages225);

            paragraphProperties119.Append(widowControl90);
            paragraphProperties119.Append(autoSpaceDE115);
            paragraphProperties119.Append(autoSpaceDN115);
            paragraphProperties119.Append(adjustRightIndent115);
            paragraphProperties119.Append(spacingBetweenLines115);
            paragraphProperties119.Append(justification98);
            paragraphProperties119.Append(paragraphMarkRunProperties119);

            Run run115 = new Run();

            RunProperties runProperties115 = new RunProperties();
            RunFonts runFonts234 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold46 = new Bold();
            Color color234 = new Color() { Val = "000000" };
            FontSize fontSize234 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript234 = new FontSizeComplexScript() { Val = "24" };
            Languages languages226 = new Languages() { Val = "ru" };

            runProperties115.Append(runFonts234);
            runProperties115.Append(bold46);
            runProperties115.Append(color234);
            runProperties115.Append(fontSize234);
            runProperties115.Append(fontSizeComplexScript234);
            runProperties115.Append(languages226);
            Text text108 = new Text();
            text108.Text = "2";

            run115.Append(runProperties115);
            run115.Append(text108);

            paragraph119.Append(paragraphProperties119);
            paragraph119.Append(run115);

            tableCell33.Append(tableCellProperties33);
            tableCell33.Append(paragraph119);

            TableCell tableCell34 = new TableCell();

            TableCellProperties tableCellProperties34 = new TableCellProperties();
            TableCellWidth tableCellWidth34 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties34.Append(tableCellWidth34);

            Paragraph paragraph120 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties120 = new ParagraphProperties();
            WidowControl widowControl91 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE116 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN116 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent116 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines116 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification99 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties120 = new ParagraphMarkRunProperties();
            RunFonts runFonts235 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color235 = new Color() { Val = "000000" };
            FontSize fontSize235 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript235 = new FontSizeComplexScript() { Val = "24" };
            Languages languages227 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties120.Append(runFonts235);
            paragraphMarkRunProperties120.Append(color235);
            paragraphMarkRunProperties120.Append(fontSize235);
            paragraphMarkRunProperties120.Append(fontSizeComplexScript235);
            paragraphMarkRunProperties120.Append(languages227);

            paragraphProperties120.Append(widowControl91);
            paragraphProperties120.Append(autoSpaceDE116);
            paragraphProperties120.Append(autoSpaceDN116);
            paragraphProperties120.Append(adjustRightIndent116);
            paragraphProperties120.Append(spacingBetweenLines116);
            paragraphProperties120.Append(justification99);
            paragraphProperties120.Append(paragraphMarkRunProperties120);

            Run run116 = new Run();

            RunProperties runProperties116 = new RunProperties();
            RunFonts runFonts236 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold47 = new Bold();
            Color color236 = new Color() { Val = "000000" };
            FontSize fontSize236 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript236 = new FontSizeComplexScript() { Val = "24" };
            Languages languages228 = new Languages() { Val = "ru" };

            runProperties116.Append(runFonts236);
            runProperties116.Append(bold47);
            runProperties116.Append(color236);
            runProperties116.Append(fontSize236);
            runProperties116.Append(fontSizeComplexScript236);
            runProperties116.Append(languages228);
            Text text109 = new Text();
            text109.Text = "3";

            run116.Append(runProperties116);
            run116.Append(text109);

            paragraph120.Append(paragraphProperties120);
            paragraph120.Append(run116);

            tableCell34.Append(tableCellProperties34);
            tableCell34.Append(paragraph120);

            TableCell tableCell35 = new TableCell();

            TableCellProperties tableCellProperties35 = new TableCellProperties();
            TableCellWidth tableCellWidth35 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            tableCellProperties35.Append(tableCellWidth35);

            Paragraph paragraph121 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties121 = new ParagraphProperties();
            WidowControl widowControl92 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE117 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN117 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent117 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines117 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification100 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties121 = new ParagraphMarkRunProperties();
            RunFonts runFonts237 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color237 = new Color() { Val = "000000" };
            FontSize fontSize237 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript237 = new FontSizeComplexScript() { Val = "24" };
            Languages languages229 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties121.Append(runFonts237);
            paragraphMarkRunProperties121.Append(color237);
            paragraphMarkRunProperties121.Append(fontSize237);
            paragraphMarkRunProperties121.Append(fontSizeComplexScript237);
            paragraphMarkRunProperties121.Append(languages229);

            paragraphProperties121.Append(widowControl92);
            paragraphProperties121.Append(autoSpaceDE117);
            paragraphProperties121.Append(autoSpaceDN117);
            paragraphProperties121.Append(adjustRightIndent117);
            paragraphProperties121.Append(spacingBetweenLines117);
            paragraphProperties121.Append(justification100);
            paragraphProperties121.Append(paragraphMarkRunProperties121);

            Run run117 = new Run();

            RunProperties runProperties117 = new RunProperties();
            RunFonts runFonts238 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold48 = new Bold();
            Color color238 = new Color() { Val = "000000" };
            FontSize fontSize238 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript238 = new FontSizeComplexScript() { Val = "24" };
            Languages languages230 = new Languages() { Val = "ru" };

            runProperties117.Append(runFonts238);
            runProperties117.Append(bold48);
            runProperties117.Append(color238);
            runProperties117.Append(fontSize238);
            runProperties117.Append(fontSizeComplexScript238);
            runProperties117.Append(languages230);
            Text text110 = new Text();
            text110.Text = "4";

            run117.Append(runProperties117);
            run117.Append(text110);

            paragraph121.Append(paragraphProperties121);
            paragraph121.Append(run117);

            tableCell35.Append(tableCellProperties35);
            tableCell35.Append(paragraph121);

            tableRow16.Append(tableCell32);
            tableRow16.Append(tableCell33);
            tableRow16.Append(tableCell34);
            tableRow16.Append(tableCell35);

            TableRow tableRow17 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };

            TableCell tableCell36 = new TableCell();

            TableCellProperties tableCellProperties36 = new TableCellProperties();
            TableCellWidth tableCellWidth36 = new TableCellWidth() { Width = "2113", Type = TableWidthUnitValues.Dxa };

            tableCellProperties36.Append(tableCellWidth36);

            Paragraph paragraph122 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties122 = new ParagraphProperties();
            WidowControl widowControl93 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE118 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN118 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent118 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines118 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification101 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties122 = new ParagraphMarkRunProperties();
            RunFonts runFonts239 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color239 = new Color() { Val = "000000" };
            FontSize fontSize239 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript239 = new FontSizeComplexScript() { Val = "24" };
            Languages languages231 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties122.Append(runFonts239);
            paragraphMarkRunProperties122.Append(color239);
            paragraphMarkRunProperties122.Append(fontSize239);
            paragraphMarkRunProperties122.Append(fontSizeComplexScript239);
            paragraphMarkRunProperties122.Append(languages231);

            paragraphProperties122.Append(widowControl93);
            paragraphProperties122.Append(autoSpaceDE118);
            paragraphProperties122.Append(autoSpaceDN118);
            paragraphProperties122.Append(adjustRightIndent118);
            paragraphProperties122.Append(spacingBetweenLines118);
            paragraphProperties122.Append(justification101);
            paragraphProperties122.Append(paragraphMarkRunProperties122);

            Run run118 = new Run();

            RunProperties runProperties118 = new RunProperties();
            RunFonts runFonts240 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold49 = new Bold();
            Color color240 = new Color() { Val = "000000" };
            FontSize fontSize240 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript240 = new FontSizeComplexScript() { Val = "24" };
            Languages languages232 = new Languages() { Val = "ru" };

            runProperties118.Append(runFonts240);
            runProperties118.Append(bold49);
            runProperties118.Append(color240);
            runProperties118.Append(fontSize240);
            runProperties118.Append(fontSizeComplexScript240);
            runProperties118.Append(languages232);
            Text text111 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text111.Text = "Раздел 1. ";

            run118.Append(runProperties118);
            run118.Append(text111);

            paragraph122.Append(paragraphProperties122);
            paragraph122.Append(run118);

            tableCell36.Append(tableCellProperties36);
            tableCell36.Append(paragraph122);

            TableCell tableCell37 = new TableCell();

            TableCellProperties tableCellProperties37 = new TableCellProperties();
            TableCellWidth tableCellWidth37 = new TableCellWidth() { Width = "5386", Type = TableWidthUnitValues.Dxa };

            tableCellProperties37.Append(tableCellWidth37);

            Paragraph paragraph123 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties123 = new ParagraphProperties();
            WidowControl widowControl94 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE119 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN119 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent119 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines119 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification102 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties123 = new ParagraphMarkRunProperties();
            RunFonts runFonts241 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color241 = new Color() { Val = "000000" };
            FontSize fontSize241 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript241 = new FontSizeComplexScript() { Val = "24" };
            Languages languages233 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties123.Append(runFonts241);
            paragraphMarkRunProperties123.Append(color241);
            paragraphMarkRunProperties123.Append(fontSize241);
            paragraphMarkRunProperties123.Append(fontSizeComplexScript241);
            paragraphMarkRunProperties123.Append(languages233);

            paragraphProperties123.Append(widowControl94);
            paragraphProperties123.Append(autoSpaceDE119);
            paragraphProperties123.Append(autoSpaceDN119);
            paragraphProperties123.Append(adjustRightIndent119);
            paragraphProperties123.Append(spacingBetweenLines119);
            paragraphProperties123.Append(justification102);
            paragraphProperties123.Append(paragraphMarkRunProperties123);

            paragraph123.Append(paragraphProperties123);

            tableCell37.Append(tableCellProperties37);
            tableCell37.Append(paragraph123);

            TableCell tableCell38 = new TableCell();

            TableCellProperties tableCellProperties38 = new TableCellProperties();
            TableCellWidth tableCellWidth38 = new TableCellWidth() { Width = "992", Type = TableWidthUnitValues.Dxa };

            tableCellProperties38.Append(tableCellWidth38);

            Paragraph paragraph124 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties124 = new ParagraphProperties();
            WidowControl widowControl95 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE120 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN120 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent120 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines120 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification103 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties124 = new ParagraphMarkRunProperties();
            RunFonts runFonts242 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color242 = new Color() { Val = "000000" };
            FontSize fontSize242 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript242 = new FontSizeComplexScript() { Val = "24" };
            Languages languages234 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties124.Append(runFonts242);
            paragraphMarkRunProperties124.Append(color242);
            paragraphMarkRunProperties124.Append(fontSize242);
            paragraphMarkRunProperties124.Append(fontSizeComplexScript242);
            paragraphMarkRunProperties124.Append(languages234);

            paragraphProperties124.Append(widowControl95);
            paragraphProperties124.Append(autoSpaceDE120);
            paragraphProperties124.Append(autoSpaceDN120);
            paragraphProperties124.Append(adjustRightIndent120);
            paragraphProperties124.Append(spacingBetweenLines120);
            paragraphProperties124.Append(justification103);
            paragraphProperties124.Append(paragraphMarkRunProperties124);

            paragraph124.Append(paragraphProperties124);

            tableCell38.Append(tableCellProperties38);
            tableCell38.Append(paragraph124);

            TableCell tableCell39 = new TableCell();

            TableCellProperties tableCellProperties39 = new TableCellProperties();
            TableCellWidth tableCellWidth39 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            tableCellProperties39.Append(tableCellWidth39);

            Paragraph paragraph125 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties125 = new ParagraphProperties();
            WidowControl widowControl96 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE121 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN121 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent121 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines121 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification104 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties125 = new ParagraphMarkRunProperties();
            RunFonts runFonts243 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color243 = new Color() { Val = "000000" };
            FontSize fontSize243 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript243 = new FontSizeComplexScript() { Val = "24" };
            Languages languages235 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties125.Append(runFonts243);
            paragraphMarkRunProperties125.Append(color243);
            paragraphMarkRunProperties125.Append(fontSize243);
            paragraphMarkRunProperties125.Append(fontSizeComplexScript243);
            paragraphMarkRunProperties125.Append(languages235);

            paragraphProperties125.Append(widowControl96);
            paragraphProperties125.Append(autoSpaceDE121);
            paragraphProperties125.Append(autoSpaceDN121);
            paragraphProperties125.Append(adjustRightIndent121);
            paragraphProperties125.Append(spacingBetweenLines121);
            paragraphProperties125.Append(justification104);
            paragraphProperties125.Append(paragraphMarkRunProperties125);

            paragraph125.Append(paragraphProperties125);

            tableCell39.Append(tableCellProperties39);
            tableCell39.Append(paragraph125);

            tableRow17.Append(tableCell36);
            tableRow17.Append(tableCell37);
            tableRow17.Append(tableCell38);
            tableRow17.Append(tableCell39);

            TableRow tableRow18 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00DA092C" };

            TableRowProperties tableRowProperties4 = new TableRowProperties();
            TableRowHeight tableRowHeight4 = new TableRowHeight() { Val = (UInt32Value)210U };

            tableRowProperties4.Append(tableRowHeight4);

            TableCell tableCell40 = new TableCell();

            TableCellProperties tableCellProperties40 = new TableCellProperties();
            TableCellWidth tableCellWidth40 = new TableCellWidth() { Width = "2113", Type = TableWidthUnitValues.Dxa };

            tableCellProperties40.Append(tableCellWidth40);

            Paragraph paragraph126 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties126 = new ParagraphProperties();
            WidowControl widowControl97 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE122 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN122 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent122 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines122 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification105 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties126 = new ParagraphMarkRunProperties();
            RunFonts runFonts244 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color244 = new Color() { Val = "000000" };
            FontSize fontSize244 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript244 = new FontSizeComplexScript() { Val = "24" };
            Languages languages236 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties126.Append(runFonts244);
            paragraphMarkRunProperties126.Append(color244);
            paragraphMarkRunProperties126.Append(fontSize244);
            paragraphMarkRunProperties126.Append(fontSizeComplexScript244);
            paragraphMarkRunProperties126.Append(languages236);

            paragraphProperties126.Append(widowControl97);
            paragraphProperties126.Append(autoSpaceDE122);
            paragraphProperties126.Append(autoSpaceDN122);
            paragraphProperties126.Append(adjustRightIndent122);
            paragraphProperties126.Append(spacingBetweenLines122);
            paragraphProperties126.Append(justification105);
            paragraphProperties126.Append(paragraphMarkRunProperties126);

            Run run119 = new Run();

            RunProperties runProperties119 = new RunProperties();
            RunFonts runFonts245 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold50 = new Bold();
            Color color245 = new Color() { Val = "000000" };
            FontSize fontSize245 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript245 = new FontSizeComplexScript() { Val = "24" };
            Languages languages237 = new Languages() { Val = "ru" };

            runProperties119.Append(runFonts245);
            runProperties119.Append(bold50);
            runProperties119.Append(color245);
            runProperties119.Append(fontSize245);
            runProperties119.Append(fontSizeComplexScript245);
            runProperties119.Append(languages237);
            Text text112 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text112.Text = "Тема 1.1. ";

            run119.Append(runProperties119);
            run119.Append(text112);

            paragraph126.Append(paragraphProperties126);
            paragraph126.Append(run119);

            tableCell40.Append(tableCellProperties40);
            tableCell40.Append(paragraph126);

            TableCell tableCell41 = new TableCell();

            TableCellProperties tableCellProperties41 = new TableCellProperties();
            TableCellWidth tableCellWidth41 = new TableCellWidth() { Width = "6378", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan2 = new GridSpan() { Val = 2 };

            tableCellProperties41.Append(tableCellWidth41);
            tableCellProperties41.Append(gridSpan2);

            Table table5 = new Table();

            TableProperties tableProperties5 = new TableProperties();
            TableWidth tableWidth5 = new TableWidth() { Width = "6400", Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders4 = new TableBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder6 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder6 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder4 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder4 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders4.Append(topBorder6);
            tableBorders4.Append(leftBorder6);
            tableBorders4.Append(bottomBorder6);
            tableBorders4.Append(rightBorder6);
            tableBorders4.Append(insideHorizontalBorder4);
            tableBorders4.Append(insideVerticalBorder4);
            TableLayout tableLayout5 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault5 = new TableCellMarginDefault();
            TopMargin topMargin5 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin5 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin5 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin5 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault5.Append(topMargin5);
            tableCellMarginDefault5.Append(tableCellLeftMargin5);
            tableCellMarginDefault5.Append(bottomMargin5);
            tableCellMarginDefault5.Append(tableCellRightMargin5);
            TableLook tableLook5 = new TableLook() { Val = "0000" };

            tableProperties5.Append(tableWidth5);
            tableProperties5.Append(tableBorders4);
            tableProperties5.Append(tableLayout5);
            tableProperties5.Append(tableCellMarginDefault5);
            tableProperties5.Append(tableLook5);

            TableGrid tableGrid5 = new TableGrid();
            GridColumn gridColumn11 = new GridColumn() { Width = "5364" };
            GridColumn gridColumn12 = new GridColumn() { Width = "1036" };

            tableGrid5.Append(gridColumn11);
            tableGrid5.Append(gridColumn12);

            TableRow tableRow19 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "009C74B9" };

            TableCell tableCell42 = new TableCell();

            TableCellProperties tableCellProperties42 = new TableCellProperties();
            TableCellWidth tableCellWidth42 = new TableCellWidth() { Width = "5364", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder7 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder7 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableCellBorders3.Append(topBorder7);
            tableCellBorders3.Append(leftBorder7);
            tableCellBorders3.Append(bottomBorder7);
            tableCellBorders3.Append(rightBorder7);

            tableCellProperties42.Append(tableCellWidth42);
            tableCellProperties42.Append(tableCellBorders3);

            Paragraph paragraph127 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00DA092C", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties127 = new ParagraphProperties();
            WidowControl widowControl98 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE123 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN123 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent123 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines123 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Indentation indentation1 = new Indentation() { Start = "-3", FirstLine = "3" };
            Justification justification106 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties127 = new ParagraphMarkRunProperties();
            RunFonts runFonts246 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color246 = new Color() { Val = "000000" };
            FontSize fontSize246 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript246 = new FontSizeComplexScript() { Val = "24" };
            Languages languages238 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties127.Append(runFonts246);
            paragraphMarkRunProperties127.Append(color246);
            paragraphMarkRunProperties127.Append(fontSize246);
            paragraphMarkRunProperties127.Append(fontSizeComplexScript246);
            paragraphMarkRunProperties127.Append(languages238);

            paragraphProperties127.Append(widowControl98);
            paragraphProperties127.Append(autoSpaceDE123);
            paragraphProperties127.Append(autoSpaceDN123);
            paragraphProperties127.Append(adjustRightIndent123);
            paragraphProperties127.Append(spacingBetweenLines123);
            paragraphProperties127.Append(indentation1);
            paragraphProperties127.Append(justification106);
            paragraphProperties127.Append(paragraphMarkRunProperties127);

            Run run120 = new Run();

            RunProperties runProperties120 = new RunProperties();
            RunFonts runFonts247 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color247 = new Color() { Val = "000000" };
            FontSize fontSize247 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript247 = new FontSizeComplexScript() { Val = "24" };
            Languages languages239 = new Languages() { Val = "ru" };

            runProperties120.Append(runFonts247);
            runProperties120.Append(color247);
            runProperties120.Append(fontSize247);
            runProperties120.Append(fontSizeComplexScript247);
            runProperties120.Append(languages239);
            Text text113 = new Text();
            text113.Text = "Содержание учебного материала";

            run120.Append(runProperties120);
            run120.Append(text113);

            paragraph127.Append(paragraphProperties127);
            paragraph127.Append(run120);

            tableCell42.Append(tableCellProperties42);
            tableCell42.Append(paragraph127);

            TableCell tableCell43 = new TableCell();

            TableCellProperties tableCellProperties43 = new TableCellProperties();
            TableCellWidth tableCellWidth43 = new TableCellWidth() { Width = "1036", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder8 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder8 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder8 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder8 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableCellBorders4.Append(topBorder8);
            tableCellBorders4.Append(leftBorder8);
            tableCellBorders4.Append(bottomBorder8);
            tableCellBorders4.Append(rightBorder8);

            tableCellProperties43.Append(tableCellWidth43);
            tableCellProperties43.Append(tableCellBorders4);

            Paragraph paragraph128 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties128 = new ParagraphProperties();
            WidowControl widowControl99 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE124 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN124 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent124 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines124 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification107 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties128 = new ParagraphMarkRunProperties();
            RunFonts runFonts248 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color248 = new Color() { Val = "000000" };
            FontSize fontSize248 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript248 = new FontSizeComplexScript() { Val = "24" };
            Languages languages240 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties128.Append(runFonts248);
            paragraphMarkRunProperties128.Append(color248);
            paragraphMarkRunProperties128.Append(fontSize248);
            paragraphMarkRunProperties128.Append(fontSizeComplexScript248);
            paragraphMarkRunProperties128.Append(languages240);

            paragraphProperties128.Append(widowControl99);
            paragraphProperties128.Append(autoSpaceDE124);
            paragraphProperties128.Append(autoSpaceDN124);
            paragraphProperties128.Append(adjustRightIndent124);
            paragraphProperties128.Append(spacingBetweenLines124);
            paragraphProperties128.Append(justification107);
            paragraphProperties128.Append(paragraphMarkRunProperties128);

            paragraph128.Append(paragraphProperties128);

            tableCell43.Append(tableCellProperties43);
            tableCell43.Append(paragraph128);

            tableRow19.Append(tableCell42);
            tableRow19.Append(tableCell43);

            table5.Append(tableProperties5);
            table5.Append(tableGrid5);
            table5.Append(tableRow19);

            Paragraph paragraph129 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties129 = new ParagraphProperties();
            WidowControl widowControl100 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE125 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN125 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent125 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines125 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification108 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties129 = new ParagraphMarkRunProperties();
            RunFonts runFonts249 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color249 = new Color() { Val = "000000" };
            FontSize fontSize249 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript249 = new FontSizeComplexScript() { Val = "24" };
            Languages languages241 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties129.Append(runFonts249);
            paragraphMarkRunProperties129.Append(color249);
            paragraphMarkRunProperties129.Append(fontSize249);
            paragraphMarkRunProperties129.Append(fontSizeComplexScript249);
            paragraphMarkRunProperties129.Append(languages241);

            paragraphProperties129.Append(widowControl100);
            paragraphProperties129.Append(autoSpaceDE125);
            paragraphProperties129.Append(autoSpaceDN125);
            paragraphProperties129.Append(adjustRightIndent125);
            paragraphProperties129.Append(spacingBetweenLines125);
            paragraphProperties129.Append(justification108);
            paragraphProperties129.Append(paragraphMarkRunProperties129);

            paragraph129.Append(paragraphProperties129);

            tableCell41.Append(tableCellProperties41);
            tableCell41.Append(table5);
            tableCell41.Append(paragraph129);

            TableCell tableCell44 = new TableCell();

            TableCellProperties tableCellProperties44 = new TableCellProperties();
            TableCellWidth tableCellWidth44 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            tableCellProperties44.Append(tableCellWidth44);

            Paragraph paragraph130 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "0031269F", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties130 = new ParagraphProperties();
            WidowControl widowControl101 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE126 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN126 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent126 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines126 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Indentation indentation2 = new Indentation() { Start = "426" };
            Justification justification109 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties130 = new ParagraphMarkRunProperties();
            RunFonts runFonts250 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color250 = new Color() { Val = "000000" };
            FontSize fontSize250 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript250 = new FontSizeComplexScript() { Val = "24" };
            Languages languages242 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties130.Append(runFonts250);
            paragraphMarkRunProperties130.Append(color250);
            paragraphMarkRunProperties130.Append(fontSize250);
            paragraphMarkRunProperties130.Append(fontSizeComplexScript250);
            paragraphMarkRunProperties130.Append(languages242);

            paragraphProperties130.Append(widowControl101);
            paragraphProperties130.Append(autoSpaceDE126);
            paragraphProperties130.Append(autoSpaceDN126);
            paragraphProperties130.Append(adjustRightIndent126);
            paragraphProperties130.Append(spacingBetweenLines126);
            paragraphProperties130.Append(indentation2);
            paragraphProperties130.Append(justification109);
            paragraphProperties130.Append(paragraphMarkRunProperties130);

            paragraph130.Append(paragraphProperties130);

            tableCell44.Append(tableCellProperties44);
            tableCell44.Append(paragraph130);

            tableRow18.Append(tableRowProperties4);
            tableRow18.Append(tableCell40);
            tableRow18.Append(tableCell41);
            tableRow18.Append(tableCell44);

            table4.Append(tableProperties4);
            table4.Append(tableGrid4);
            table4.Append(tableRow15);
            table4.Append(tableRow16);
            table4.Append(tableRow17);
            table4.Append(tableRow18);

            Paragraph paragraph131 = new Paragraph() { RsidParagraphAddition = "00900A3F", RsidRunAdditionDefault = "00900A3F" };

            ParagraphProperties paragraphProperties131 = new ParagraphProperties();
            WidowControl widowControl102 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE127 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN127 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent127 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines127 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification110 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties131 = new ParagraphMarkRunProperties();
            RunFonts runFonts251 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color251 = new Color() { Val = "000000" };
            FontSize fontSize251 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript251 = new FontSizeComplexScript() { Val = "24" };
            Languages languages243 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties131.Append(runFonts251);
            paragraphMarkRunProperties131.Append(color251);
            paragraphMarkRunProperties131.Append(fontSize251);
            paragraphMarkRunProperties131.Append(fontSizeComplexScript251);
            paragraphMarkRunProperties131.Append(languages243);

            paragraphProperties131.Append(widowControl102);
            paragraphProperties131.Append(autoSpaceDE127);
            paragraphProperties131.Append(autoSpaceDN127);
            paragraphProperties131.Append(adjustRightIndent127);
            paragraphProperties131.Append(spacingBetweenLines127);
            paragraphProperties131.Append(justification110);
            paragraphProperties131.Append(paragraphMarkRunProperties131);

            paragraph131.Append(paragraphProperties131);

            Paragraph paragraph132 = new Paragraph() { RsidParagraphAddition = "00E769EC", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties132 = new ParagraphProperties();
            WidowControl widowControl103 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE128 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN128 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent128 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines128 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification111 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties132 = new ParagraphMarkRunProperties();
            RunFonts runFonts252 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color252 = new Color() { Val = "000000" };
            FontSize fontSize252 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript252 = new FontSizeComplexScript() { Val = "24" };
            Languages languages244 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties132.Append(runFonts252);
            paragraphMarkRunProperties132.Append(color252);
            paragraphMarkRunProperties132.Append(fontSize252);
            paragraphMarkRunProperties132.Append(fontSizeComplexScript252);
            paragraphMarkRunProperties132.Append(languages244);

            paragraphProperties132.Append(widowControl103);
            paragraphProperties132.Append(autoSpaceDE128);
            paragraphProperties132.Append(autoSpaceDN128);
            paragraphProperties132.Append(adjustRightIndent128);
            paragraphProperties132.Append(spacingBetweenLines128);
            paragraphProperties132.Append(justification111);
            paragraphProperties132.Append(paragraphMarkRunProperties132);

            Run run121 = new Run();

            RunProperties runProperties121 = new RunProperties();
            RunFonts runFonts253 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color253 = new Color() { Val = "000000" };
            FontSize fontSize253 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript253 = new FontSizeComplexScript() { Val = "24" };
            Languages languages245 = new Languages() { Val = "ru" };

            runProperties121.Append(runFonts253);
            runProperties121.Append(color253);
            runProperties121.Append(fontSize253);
            runProperties121.Append(fontSizeComplexScript253);
            runProperties121.Append(languages245);
            Text text114 = new Text();
            text114.Text = "Для характеристики уровня освоения учебного материала используются следующие обозначения:";

            run121.Append(runProperties121);
            run121.Append(text114);

            Run run122 = new Run();

            RunProperties runProperties122 = new RunProperties();
            RunFonts runFonts254 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color254 = new Color() { Val = "000000" };
            FontSize fontSize254 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript254 = new FontSizeComplexScript() { Val = "24" };
            Languages languages246 = new Languages() { Val = "ru" };

            runProperties122.Append(runFonts254);
            runProperties122.Append(color254);
            runProperties122.Append(fontSize254);
            runProperties122.Append(fontSizeComplexScript254);
            runProperties122.Append(languages246);
            Break break11 = new Break();
            Text text115 = new Text();
            text115.Text = "1. - ознакомительный (узнавание ран";

            run122.Append(runProperties122);
            run122.Append(break11);
            run122.Append(text115);

            Run run123 = new Run() { RsidRunAddition = "00E769EC" };

            RunProperties runProperties123 = new RunProperties();
            RunFonts runFonts255 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color255 = new Color() { Val = "000000" };
            FontSize fontSize255 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript255 = new FontSizeComplexScript() { Val = "24" };
            Languages languages247 = new Languages() { Val = "ru" };

            runProperties123.Append(runFonts255);
            runProperties123.Append(color255);
            runProperties123.Append(fontSize255);
            runProperties123.Append(fontSizeComplexScript255);
            runProperties123.Append(languages247);
            Text text116 = new Text();
            text116.Text = "ее изученных объектов, свойств)";

            run123.Append(runProperties123);
            run123.Append(text116);

            paragraph132.Append(paragraphProperties132);
            paragraph132.Append(run121);
            paragraph132.Append(run122);
            paragraph132.Append(run123);

            Paragraph paragraph133 = new Paragraph() { RsidParagraphAddition = "00E769EC", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties133 = new ParagraphProperties();
            WidowControl widowControl104 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE129 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN129 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent129 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines129 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification112 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties133 = new ParagraphMarkRunProperties();
            RunFonts runFonts256 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color256 = new Color() { Val = "000000" };
            FontSize fontSize256 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript256 = new FontSizeComplexScript() { Val = "24" };
            Languages languages248 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties133.Append(runFonts256);
            paragraphMarkRunProperties133.Append(color256);
            paragraphMarkRunProperties133.Append(fontSize256);
            paragraphMarkRunProperties133.Append(fontSizeComplexScript256);
            paragraphMarkRunProperties133.Append(languages248);

            paragraphProperties133.Append(widowControl104);
            paragraphProperties133.Append(autoSpaceDE129);
            paragraphProperties133.Append(autoSpaceDN129);
            paragraphProperties133.Append(adjustRightIndent129);
            paragraphProperties133.Append(spacingBetweenLines129);
            paragraphProperties133.Append(justification112);
            paragraphProperties133.Append(paragraphMarkRunProperties133);

            Run run124 = new Run();

            RunProperties runProperties124 = new RunProperties();
            RunFonts runFonts257 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color257 = new Color() { Val = "000000" };
            FontSize fontSize257 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript257 = new FontSizeComplexScript() { Val = "24" };
            Languages languages249 = new Languages() { Val = "ru" };

            runProperties124.Append(runFonts257);
            runProperties124.Append(color257);
            runProperties124.Append(fontSize257);
            runProperties124.Append(fontSizeComplexScript257);
            runProperties124.Append(languages249);
            Text text117 = new Text();
            text117.Text = "2. - репродуктивный (выполнение деятельности по образцу, инструкции или по";

            run124.Append(runProperties124);
            run124.Append(text117);

            Run run125 = new Run() { RsidRunAddition = "00E769EC" };

            RunProperties runProperties125 = new RunProperties();
            RunFonts runFonts258 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color258 = new Color() { Val = "000000" };
            FontSize fontSize258 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript258 = new FontSizeComplexScript() { Val = "24" };
            Languages languages250 = new Languages() { Val = "ru" };

            runProperties125.Append(runFonts258);
            runProperties125.Append(color258);
            runProperties125.Append(fontSize258);
            runProperties125.Append(fontSizeComplexScript258);
            runProperties125.Append(languages250);
            Text text118 = new Text();
            text118.Text = "д руководством)";

            run125.Append(runProperties125);
            run125.Append(text118);

            paragraph133.Append(paragraphProperties133);
            paragraph133.Append(run124);
            paragraph133.Append(run125);

            Paragraph paragraph134 = new Paragraph() { RsidParagraphAddition = "00900A3F", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties134 = new ParagraphProperties();
            WidowControl widowControl105 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE130 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN130 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent130 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines130 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification113 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties134 = new ParagraphMarkRunProperties();
            RunFonts runFonts259 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color259 = new Color() { Val = "000000" };
            FontSize fontSize259 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript259 = new FontSizeComplexScript() { Val = "24" };
            Languages languages251 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties134.Append(runFonts259);
            paragraphMarkRunProperties134.Append(color259);
            paragraphMarkRunProperties134.Append(fontSize259);
            paragraphMarkRunProperties134.Append(fontSizeComplexScript259);
            paragraphMarkRunProperties134.Append(languages251);

            paragraphProperties134.Append(widowControl105);
            paragraphProperties134.Append(autoSpaceDE130);
            paragraphProperties134.Append(autoSpaceDN130);
            paragraphProperties134.Append(adjustRightIndent130);
            paragraphProperties134.Append(spacingBetweenLines130);
            paragraphProperties134.Append(justification113);
            paragraphProperties134.Append(paragraphMarkRunProperties134);

            Run run126 = new Run();

            RunProperties runProperties126 = new RunProperties();
            RunFonts runFonts260 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color260 = new Color() { Val = "000000" };
            FontSize fontSize260 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript260 = new FontSizeComplexScript() { Val = "24" };
            Languages languages252 = new Languages() { Val = "ru" };

            runProperties126.Append(runFonts260);
            runProperties126.Append(color260);
            runProperties126.Append(fontSize260);
            runProperties126.Append(fontSizeComplexScript260);
            runProperties126.Append(languages252);
            Text text119 = new Text();
            text119.Text = "3. - продуктивный (планирование и самостоятельное выполнение деятельности, решение проблемных задач)";

            run126.Append(runProperties126);
            run126.Append(text119);

            paragraph134.Append(paragraphProperties134);
            paragraph134.Append(run126);

            Paragraph paragraph135 = new Paragraph() { RsidParagraphAddition = "00900A3F", RsidRunAdditionDefault = "00900A3F" };

            ParagraphProperties paragraphProperties135 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties135 = new ParagraphMarkRunProperties();
            RunFonts runFonts261 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color261 = new Color() { Val = "000000" };
            FontSize fontSize261 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript261 = new FontSizeComplexScript() { Val = "24" };
            Languages languages253 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties135.Append(runFonts261);
            paragraphMarkRunProperties135.Append(color261);
            paragraphMarkRunProperties135.Append(fontSize261);
            paragraphMarkRunProperties135.Append(fontSizeComplexScript261);
            paragraphMarkRunProperties135.Append(languages253);

            paragraphProperties135.Append(paragraphMarkRunProperties135);

            Run run127 = new Run();

            RunProperties runProperties127 = new RunProperties();
            RunFonts runFonts262 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color262 = new Color() { Val = "000000" };
            FontSize fontSize262 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript262 = new FontSizeComplexScript() { Val = "24" };
            Languages languages254 = new Languages() { Val = "ru" };

            runProperties127.Append(runFonts262);
            runProperties127.Append(color262);
            runProperties127.Append(fontSize262);
            runProperties127.Append(fontSizeComplexScript262);
            runProperties127.Append(languages254);
            Break break12 = new Break() { Type = BreakValues.Page };

            run127.Append(runProperties127);
            run127.Append(break12);

            paragraph135.Append(paragraphProperties135);
            paragraph135.Append(run127);

            Paragraph paragraph136 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties136 = new ParagraphProperties();
            WidowControl widowControl106 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE131 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN131 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent131 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines131 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification114 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties136 = new ParagraphMarkRunProperties();
            RunFonts runFonts263 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color263 = new Color() { Val = "000000" };
            FontSize fontSize263 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript263 = new FontSizeComplexScript() { Val = "24" };
            Languages languages255 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties136.Append(runFonts263);
            paragraphMarkRunProperties136.Append(color263);
            paragraphMarkRunProperties136.Append(fontSize263);
            paragraphMarkRunProperties136.Append(fontSizeComplexScript263);
            paragraphMarkRunProperties136.Append(languages255);

            paragraphProperties136.Append(widowControl106);
            paragraphProperties136.Append(autoSpaceDE131);
            paragraphProperties136.Append(autoSpaceDN131);
            paragraphProperties136.Append(adjustRightIndent131);
            paragraphProperties136.Append(spacingBetweenLines131);
            paragraphProperties136.Append(justification114);
            paragraphProperties136.Append(paragraphMarkRunProperties136);

            paragraph136.Append(paragraphProperties136);

            Paragraph paragraph137 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties137 = new ParagraphProperties();
            WidowControl widowControl107 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE132 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN132 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent132 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines132 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification115 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties137 = new ParagraphMarkRunProperties();
            RunFonts runFonts264 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color264 = new Color() { Val = "000000" };
            FontSize fontSize264 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript264 = new FontSizeComplexScript() { Val = "24" };
            Languages languages256 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties137.Append(runFonts264);
            paragraphMarkRunProperties137.Append(color264);
            paragraphMarkRunProperties137.Append(fontSize264);
            paragraphMarkRunProperties137.Append(fontSizeComplexScript264);
            paragraphMarkRunProperties137.Append(languages256);

            paragraphProperties137.Append(widowControl107);
            paragraphProperties137.Append(autoSpaceDE132);
            paragraphProperties137.Append(autoSpaceDN132);
            paragraphProperties137.Append(adjustRightIndent132);
            paragraphProperties137.Append(spacingBetweenLines132);
            paragraphProperties137.Append(justification115);
            paragraphProperties137.Append(paragraphMarkRunProperties137);

            Run run128 = new Run();

            RunProperties runProperties128 = new RunProperties();
            RunFonts runFonts265 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold51 = new Bold();
            Color color265 = new Color() { Val = "000000" };
            FontSize fontSize265 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript265 = new FontSizeComplexScript() { Val = "24" };
            Languages languages257 = new Languages() { Val = "ru" };

            runProperties128.Append(runFonts265);
            runProperties128.Append(bold51);
            runProperties128.Append(color265);
            runProperties128.Append(fontSize265);
            runProperties128.Append(fontSizeComplexScript265);
            runProperties128.Append(languages257);
            Text text120 = new Text();
            text120.Text = "3. УСЛОВИЯ РЕАЛИЗАЦИИ УЧЕБНОЙ ДИСЦИПЛИНЫ";

            run128.Append(runProperties128);
            run128.Append(text120);

            Run run129 = new Run();

            RunProperties runProperties129 = new RunProperties();
            RunFonts runFonts266 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color266 = new Color() { Val = "000000" };
            FontSize fontSize266 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript266 = new FontSizeComplexScript() { Val = "24" };
            Languages languages258 = new Languages() { Val = "ru" };

            runProperties129.Append(runFonts266);
            runProperties129.Append(color266);
            runProperties129.Append(fontSize266);
            runProperties129.Append(fontSizeComplexScript266);
            runProperties129.Append(languages258);
            Break break13 = new Break();

            run129.Append(runProperties129);
            run129.Append(break13);

            paragraph137.Append(paragraphProperties137);
            paragraph137.Append(run128);
            paragraph137.Append(run129);

            Paragraph paragraph138 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties138 = new ParagraphProperties();
            WidowControl widowControl108 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE133 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN133 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent133 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines133 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification116 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties138 = new ParagraphMarkRunProperties();
            RunFonts runFonts267 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color267 = new Color() { Val = "000000" };
            FontSize fontSize267 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript267 = new FontSizeComplexScript() { Val = "24" };
            Languages languages259 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties138.Append(runFonts267);
            paragraphMarkRunProperties138.Append(color267);
            paragraphMarkRunProperties138.Append(fontSize267);
            paragraphMarkRunProperties138.Append(fontSizeComplexScript267);
            paragraphMarkRunProperties138.Append(languages259);

            paragraphProperties138.Append(widowControl108);
            paragraphProperties138.Append(autoSpaceDE133);
            paragraphProperties138.Append(autoSpaceDN133);
            paragraphProperties138.Append(adjustRightIndent133);
            paragraphProperties138.Append(spacingBetweenLines133);
            paragraphProperties138.Append(justification116);
            paragraphProperties138.Append(paragraphMarkRunProperties138);

            Run run130 = new Run();

            RunProperties runProperties130 = new RunProperties();
            RunFonts runFonts268 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold52 = new Bold();
            Color color268 = new Color() { Val = "000000" };
            FontSize fontSize268 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript268 = new FontSizeComplexScript() { Val = "24" };
            Languages languages260 = new Languages() { Val = "ru" };

            runProperties130.Append(runFonts268);
            runProperties130.Append(bold52);
            runProperties130.Append(color268);
            runProperties130.Append(fontSize268);
            runProperties130.Append(fontSizeComplexScript268);
            runProperties130.Append(languages260);
            Text text121 = new Text();
            text121.Text = "3.1. Требования к минимальному материально-техническому обеспечению";

            run130.Append(runProperties130);
            run130.Append(text121);

            Run run131 = new Run();

            RunProperties runProperties131 = new RunProperties();
            RunFonts runFonts269 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color269 = new Color() { Val = "000000" };
            FontSize fontSize269 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript269 = new FontSizeComplexScript() { Val = "24" };
            Languages languages261 = new Languages() { Val = "ru" };

            runProperties131.Append(runFonts269);
            runProperties131.Append(color269);
            runProperties131.Append(fontSize269);
            runProperties131.Append(fontSizeComplexScript269);
            runProperties131.Append(languages261);
            Break break14 = new Break();
            Text text122 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text122.Text = "    Реализация программы учебной дисциплины требует наличия учебного кабинета основ философии";

            run131.Append(runProperties131);
            run131.Append(break14);
            run131.Append(text122);

            paragraph138.Append(paragraphProperties138);
            paragraph138.Append(run130);
            paragraph138.Append(run131);

            Paragraph paragraph139 = new Paragraph() { RsidParagraphAddition = "00706F3D", RsidRunAdditionDefault = "00706F3D" };

            ParagraphProperties paragraphProperties139 = new ParagraphProperties();
            WidowControl widowControl109 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE134 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN134 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent134 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines134 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification117 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties139 = new ParagraphMarkRunProperties();
            RunFonts runFonts270 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color270 = new Color() { Val = "000000" };
            FontSize fontSize270 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript270 = new FontSizeComplexScript() { Val = "24" };
            Languages languages262 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties139.Append(runFonts270);
            paragraphMarkRunProperties139.Append(color270);
            paragraphMarkRunProperties139.Append(fontSize270);
            paragraphMarkRunProperties139.Append(fontSizeComplexScript270);
            paragraphMarkRunProperties139.Append(languages262);

            paragraphProperties139.Append(widowControl109);
            paragraphProperties139.Append(autoSpaceDE134);
            paragraphProperties139.Append(autoSpaceDN134);
            paragraphProperties139.Append(adjustRightIndent134);
            paragraphProperties139.Append(spacingBetweenLines134);
            paragraphProperties139.Append(justification117);
            paragraphProperties139.Append(paragraphMarkRunProperties139);

            paragraph139.Append(paragraphProperties139);

            Paragraph paragraph140 = new Paragraph() { RsidParagraphAddition = "00EC1B6C", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties140 = new ParagraphProperties();
            WidowControl widowControl110 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE135 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN135 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent135 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines135 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification118 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties140 = new ParagraphMarkRunProperties();
            RunFonts runFonts271 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color271 = new Color() { Val = "000000" };
            FontSize fontSize271 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript271 = new FontSizeComplexScript() { Val = "24" };
            Languages languages263 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties140.Append(runFonts271);
            paragraphMarkRunProperties140.Append(color271);
            paragraphMarkRunProperties140.Append(fontSize271);
            paragraphMarkRunProperties140.Append(fontSizeComplexScript271);
            paragraphMarkRunProperties140.Append(languages263);

            paragraphProperties140.Append(widowControl110);
            paragraphProperties140.Append(autoSpaceDE135);
            paragraphProperties140.Append(autoSpaceDN135);
            paragraphProperties140.Append(adjustRightIndent135);
            paragraphProperties140.Append(spacingBetweenLines135);
            paragraphProperties140.Append(justification118);
            paragraphProperties140.Append(paragraphMarkRunProperties140);

            Run run132 = new Run();

            RunProperties runProperties132 = new RunProperties();
            RunFonts runFonts272 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold53 = new Bold();
            Color color272 = new Color() { Val = "000000" };
            FontSize fontSize272 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript272 = new FontSizeComplexScript() { Val = "24" };
            Languages languages264 = new Languages() { Val = "ru" };

            runProperties132.Append(runFonts272);
            runProperties132.Append(bold53);
            runProperties132.Append(color272);
            runProperties132.Append(fontSize272);
            runProperties132.Append(fontSizeComplexScript272);
            runProperties132.Append(languages264);
            Text text123 = new Text();
            text123.Text = "3.2 Информационное обеспечение обучения";

            run132.Append(runProperties132);
            run132.Append(text123);

            Run run133 = new Run();

            RunProperties runProperties133 = new RunProperties();
            RunFonts runFonts273 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color273 = new Color() { Val = "000000" };
            FontSize fontSize273 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript273 = new FontSizeComplexScript() { Val = "24" };
            Languages languages265 = new Languages() { Val = "ru" };

            runProperties133.Append(runFonts273);
            runProperties133.Append(color273);
            runProperties133.Append(fontSize273);
            runProperties133.Append(fontSizeComplexScript273);
            runProperties133.Append(languages265);
            Break break15 = new Break();
            Text text124 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text124.Text = "    Перечень реко";

            run133.Append(runProperties133);
            run133.Append(break15);
            run133.Append(text124);

            Run run134 = new Run() { RsidRunAddition = "003106D5" };

            RunProperties runProperties134 = new RunProperties();
            RunFonts runFonts274 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color274 = new Color() { Val = "000000" };
            FontSize fontSize274 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript274 = new FontSizeComplexScript() { Val = "24" };
            Languages languages266 = new Languages() { Val = "ru" };

            runProperties134.Append(runFonts274);
            runProperties134.Append(color274);
            runProperties134.Append(fontSize274);
            runProperties134.Append(fontSizeComplexScript274);
            runProperties134.Append(languages266);
            Text text125 = new Text();
            text125.Text = "м";

            run134.Append(runProperties134);
            run134.Append(text125);

            Run run135 = new Run();

            RunProperties runProperties135 = new RunProperties();
            RunFonts runFonts275 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color275 = new Color() { Val = "000000" };
            FontSize fontSize275 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript275 = new FontSizeComplexScript() { Val = "24" };
            Languages languages267 = new Languages() { Val = "ru" };

            runProperties135.Append(runFonts275);
            runProperties135.Append(color275);
            runProperties135.Append(fontSize275);
            runProperties135.Append(fontSizeComplexScript275);
            runProperties135.Append(languages267);
            Text text126 = new Text();
            text126.Text = "ендуемых компетенций, Интернет-ресурсов, дополнительной литер";

            run135.Append(runProperties135);
            run135.Append(text126);

            Run run136 = new Run() { RsidRunAddition = "003106D5" };

            RunProperties runProperties136 = new RunProperties();
            RunFonts runFonts276 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color276 = new Color() { Val = "000000" };
            FontSize fontSize276 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript276 = new FontSizeComplexScript() { Val = "24" };
            Languages languages268 = new Languages() { Val = "ru" };

            runProperties136.Append(runFonts276);
            runProperties136.Append(color276);
            runProperties136.Append(fontSize276);
            runProperties136.Append(fontSizeComplexScript276);
            runProperties136.Append(languages268);
            Text text127 = new Text();
            text127.Text = "а";

            run136.Append(runProperties136);
            run136.Append(text127);

            Run run137 = new Run();

            RunProperties runProperties137 = new RunProperties();
            RunFonts runFonts277 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color277 = new Color() { Val = "000000" };
            FontSize fontSize277 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript277 = new FontSizeComplexScript() { Val = "24" };
            Languages languages269 = new Languages() { Val = "ru" };

            runProperties137.Append(runFonts277);
            runProperties137.Append(color277);
            runProperties137.Append(fontSize277);
            runProperties137.Append(fontSizeComplexScript277);
            runProperties137.Append(languages269);
            Text text128 = new Text();
            text128.Text = "туры";

            run137.Append(runProperties137);
            run137.Append(text128);

            paragraph140.Append(paragraphProperties140);
            paragraph140.Append(run132);
            paragraph140.Append(run133);
            paragraph140.Append(run134);
            paragraph140.Append(run135);
            paragraph140.Append(run136);
            paragraph140.Append(run137);

            Paragraph paragraph141 = new Paragraph() { RsidParagraphAddition = "00EC1B6C", RsidRunAdditionDefault = "00EC1B6C" };

            ParagraphProperties paragraphProperties141 = new ParagraphProperties();
            WidowControl widowControl111 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE136 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN136 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent136 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines136 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification119 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties141 = new ParagraphMarkRunProperties();
            RunFonts runFonts278 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color278 = new Color() { Val = "000000" };
            FontSize fontSize278 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript278 = new FontSizeComplexScript() { Val = "24" };
            Languages languages270 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties141.Append(runFonts278);
            paragraphMarkRunProperties141.Append(color278);
            paragraphMarkRunProperties141.Append(fontSize278);
            paragraphMarkRunProperties141.Append(fontSizeComplexScript278);
            paragraphMarkRunProperties141.Append(languages270);

            paragraphProperties141.Append(widowControl111);
            paragraphProperties141.Append(autoSpaceDE136);
            paragraphProperties141.Append(autoSpaceDN136);
            paragraphProperties141.Append(adjustRightIndent136);
            paragraphProperties141.Append(spacingBetweenLines136);
            paragraphProperties141.Append(justification119);
            paragraphProperties141.Append(paragraphMarkRunProperties141);

            paragraph141.Append(paragraphProperties141);

            Paragraph paragraph142 = new Paragraph() { RsidParagraphAddition = "003106D5", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties142 = new ParagraphProperties();
            WidowControl widowControl112 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE137 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN137 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent137 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines137 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification120 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties142 = new ParagraphMarkRunProperties();
            RunFonts runFonts279 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold54 = new Bold();
            Color color279 = new Color() { Val = "000000" };
            FontSize fontSize279 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript279 = new FontSizeComplexScript() { Val = "24" };
            Languages languages271 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties142.Append(runFonts279);
            paragraphMarkRunProperties142.Append(bold54);
            paragraphMarkRunProperties142.Append(color279);
            paragraphMarkRunProperties142.Append(fontSize279);
            paragraphMarkRunProperties142.Append(fontSizeComplexScript279);
            paragraphMarkRunProperties142.Append(languages271);

            paragraphProperties142.Append(widowControl112);
            paragraphProperties142.Append(autoSpaceDE137);
            paragraphProperties142.Append(autoSpaceDN137);
            paragraphProperties142.Append(adjustRightIndent137);
            paragraphProperties142.Append(spacingBetweenLines137);
            paragraphProperties142.Append(justification120);
            paragraphProperties142.Append(paragraphMarkRunProperties142);

            Run run138 = new Run();

            RunProperties runProperties138 = new RunProperties();
            RunFonts runFonts280 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold55 = new Bold();
            Color color280 = new Color() { Val = "000000" };
            FontSize fontSize280 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript280 = new FontSizeComplexScript() { Val = "24" };
            Languages languages272 = new Languages() { Val = "ru" };

            runProperties138.Append(runFonts280);
            runProperties138.Append(bold55);
            runProperties138.Append(color280);
            runProperties138.Append(fontSize280);
            runProperties138.Append(fontSizeComplexScript280);
            runProperties138.Append(languages272);
            Text text129 = new Text();
            text129.Text = "Основные источники:";

            run138.Append(runProperties138);
            run138.Append(text129);

            paragraph142.Append(paragraphProperties142);
            paragraph142.Append(run138);

            Paragraph paragraph143 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00FF310F", RsidRunAdditionDefault = "003106D5" };

            ParagraphProperties paragraphProperties143 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties143 = new ParagraphMarkRunProperties();
            RunFonts runFonts281 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color281 = new Color() { Val = "000000" };
            FontSize fontSize281 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript281 = new FontSizeComplexScript() { Val = "24" };
            Languages languages273 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties143.Append(runFonts281);
            paragraphMarkRunProperties143.Append(color281);
            paragraphMarkRunProperties143.Append(fontSize281);
            paragraphMarkRunProperties143.Append(fontSizeComplexScript281);
            paragraphMarkRunProperties143.Append(languages273);

            paragraphProperties143.Append(paragraphMarkRunProperties143);

            Run run139 = new Run();

            RunProperties runProperties139 = new RunProperties();
            RunFonts runFonts282 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold56 = new Bold();
            Color color282 = new Color() { Val = "000000" };
            FontSize fontSize282 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript282 = new FontSizeComplexScript() { Val = "24" };
            Languages languages274 = new Languages() { Val = "ru" };

            runProperties139.Append(runFonts282);
            runProperties139.Append(bold56);
            runProperties139.Append(color282);
            runProperties139.Append(fontSize282);
            runProperties139.Append(fontSizeComplexScript282);
            runProperties139.Append(languages274);
            Break break16 = new Break() { Type = BreakValues.Page };

            run139.Append(runProperties139);
            run139.Append(break16);

            paragraph143.Append(paragraphProperties143);
            paragraph143.Append(run139);

            Paragraph paragraph144 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties144 = new ParagraphProperties();
            WidowControl widowControl113 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE138 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN138 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent138 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines138 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification121 = new Justification() { Val = JustificationValues.Right };

            ParagraphMarkRunProperties paragraphMarkRunProperties144 = new ParagraphMarkRunProperties();
            RunFonts runFonts283 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold57 = new Bold();
            Color color283 = new Color() { Val = "000000" };
            FontSize fontSize283 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript283 = new FontSizeComplexScript() { Val = "24" };
            Languages languages275 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties144.Append(runFonts283);
            paragraphMarkRunProperties144.Append(bold57);
            paragraphMarkRunProperties144.Append(color283);
            paragraphMarkRunProperties144.Append(fontSize283);
            paragraphMarkRunProperties144.Append(fontSizeComplexScript283);
            paragraphMarkRunProperties144.Append(languages275);

            paragraphProperties144.Append(widowControl113);
            paragraphProperties144.Append(autoSpaceDE138);
            paragraphProperties144.Append(autoSpaceDN138);
            paragraphProperties144.Append(adjustRightIndent138);
            paragraphProperties144.Append(spacingBetweenLines138);
            paragraphProperties144.Append(justification121);
            paragraphProperties144.Append(paragraphMarkRunProperties144);

            Run run140 = new Run();

            RunProperties runProperties140 = new RunProperties();
            RunFonts runFonts284 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold58 = new Bold();
            Color color284 = new Color() { Val = "000000" };
            FontSize fontSize284 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript284 = new FontSizeComplexScript() { Val = "24" };
            Languages languages276 = new Languages() { Val = "ru" };

            runProperties140.Append(runFonts284);
            runProperties140.Append(bold58);
            runProperties140.Append(color284);
            runProperties140.Append(fontSize284);
            runProperties140.Append(fontSizeComplexScript284);
            runProperties140.Append(languages276);
            LastRenderedPageBreak lastRenderedPageBreak6 = new LastRenderedPageBreak();
            Text text130 = new Text();
            text130.Text = "ПРИЛОЖЕНИЕ";

            run140.Append(runProperties140);
            run140.Append(lastRenderedPageBreak6);
            run140.Append(text130);

            paragraph144.Append(paragraphProperties144);
            paragraph144.Append(run140);

            Paragraph paragraph145 = new Paragraph() { RsidParagraphAddition = "00FF310F", RsidRunAdditionDefault = "00FF310F" };

            ParagraphProperties paragraphProperties145 = new ParagraphProperties();
            WidowControl widowControl114 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE139 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN139 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent139 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines139 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification122 = new Justification() { Val = JustificationValues.Right };

            ParagraphMarkRunProperties paragraphMarkRunProperties145 = new ParagraphMarkRunProperties();
            RunFonts runFonts285 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color285 = new Color() { Val = "000000" };
            FontSize fontSize285 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript285 = new FontSizeComplexScript() { Val = "24" };
            Languages languages277 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties145.Append(runFonts285);
            paragraphMarkRunProperties145.Append(color285);
            paragraphMarkRunProperties145.Append(fontSize285);
            paragraphMarkRunProperties145.Append(fontSizeComplexScript285);
            paragraphMarkRunProperties145.Append(languages277);

            paragraphProperties145.Append(widowControl114);
            paragraphProperties145.Append(autoSpaceDE139);
            paragraphProperties145.Append(autoSpaceDN139);
            paragraphProperties145.Append(adjustRightIndent139);
            paragraphProperties145.Append(spacingBetweenLines139);
            paragraphProperties145.Append(justification122);
            paragraphProperties145.Append(paragraphMarkRunProperties145);

            paragraph145.Append(paragraphProperties145);

            Paragraph paragraph146 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties146 = new ParagraphProperties();
            WidowControl widowControl115 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE140 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN140 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent140 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines140 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification123 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties146 = new ParagraphMarkRunProperties();
            RunFonts runFonts286 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color286 = new Color() { Val = "000000" };
            FontSize fontSize286 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript286 = new FontSizeComplexScript() { Val = "24" };
            Languages languages278 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties146.Append(runFonts286);
            paragraphMarkRunProperties146.Append(color286);
            paragraphMarkRunProperties146.Append(fontSize286);
            paragraphMarkRunProperties146.Append(fontSizeComplexScript286);
            paragraphMarkRunProperties146.Append(languages278);

            paragraphProperties146.Append(widowControl115);
            paragraphProperties146.Append(autoSpaceDE140);
            paragraphProperties146.Append(autoSpaceDN140);
            paragraphProperties146.Append(adjustRightIndent140);
            paragraphProperties146.Append(spacingBetweenLines140);
            paragraphProperties146.Append(justification123);
            paragraphProperties146.Append(paragraphMarkRunProperties146);

            Run run141 = new Run();

            RunProperties runProperties141 = new RunProperties();
            RunFonts runFonts287 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold59 = new Bold();
            Color color287 = new Color() { Val = "000000" };
            FontSize fontSize287 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript287 = new FontSizeComplexScript() { Val = "24" };
            Languages languages279 = new Languages() { Val = "ru" };

            runProperties141.Append(runFonts287);
            runProperties141.Append(bold59);
            runProperties141.Append(color287);
            runProperties141.Append(fontSize287);
            runProperties141.Append(fontSizeComplexScript287);
            runProperties141.Append(languages279);
            Text text131 = new Text();
            text131.Text = "Вопросы к дифференцированному зачету";

            run141.Append(runProperties141);
            run141.Append(text131);

            paragraph146.Append(paragraphProperties146);
            paragraph146.Append(run141);

            Paragraph paragraph147 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00FF310F", RsidRunAdditionDefault = "00FF310F" };

            ParagraphProperties paragraphProperties147 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties147 = new ParagraphMarkRunProperties();
            RunFonts runFonts288 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color288 = new Color() { Val = "000000" };
            FontSize fontSize288 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript288 = new FontSizeComplexScript() { Val = "24" };
            Languages languages280 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties147.Append(runFonts288);
            paragraphMarkRunProperties147.Append(color288);
            paragraphMarkRunProperties147.Append(fontSize288);
            paragraphMarkRunProperties147.Append(fontSizeComplexScript288);
            paragraphMarkRunProperties147.Append(languages280);

            paragraphProperties147.Append(paragraphMarkRunProperties147);

            Run run142 = new Run();

            RunProperties runProperties142 = new RunProperties();
            RunFonts runFonts289 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color289 = new Color() { Val = "000000" };
            FontSize fontSize289 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript289 = new FontSizeComplexScript() { Val = "24" };
            Languages languages281 = new Languages() { Val = "ru" };

            runProperties142.Append(runFonts289);
            runProperties142.Append(color289);
            runProperties142.Append(fontSize289);
            runProperties142.Append(fontSizeComplexScript289);
            runProperties142.Append(languages281);
            Break break17 = new Break() { Type = BreakValues.Page };

            run142.Append(runProperties142);
            run142.Append(break17);

            paragraph147.Append(paragraphProperties147);
            paragraph147.Append(run142);

            Paragraph paragraph148 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties148 = new ParagraphProperties();
            WidowControl widowControl116 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE141 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN141 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent141 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines141 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification124 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties148 = new ParagraphMarkRunProperties();
            RunFonts runFonts290 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color290 = new Color() { Val = "000000" };
            FontSize fontSize290 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript290 = new FontSizeComplexScript() { Val = "24" };
            Languages languages282 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties148.Append(runFonts290);
            paragraphMarkRunProperties148.Append(color290);
            paragraphMarkRunProperties148.Append(fontSize290);
            paragraphMarkRunProperties148.Append(fontSizeComplexScript290);
            paragraphMarkRunProperties148.Append(languages282);

            paragraphProperties148.Append(widowControl116);
            paragraphProperties148.Append(autoSpaceDE141);
            paragraphProperties148.Append(autoSpaceDN141);
            paragraphProperties148.Append(adjustRightIndent141);
            paragraphProperties148.Append(spacingBetweenLines141);
            paragraphProperties148.Append(justification124);
            paragraphProperties148.Append(paragraphMarkRunProperties148);

            Run run143 = new Run();

            RunProperties runProperties143 = new RunProperties();
            RunFonts runFonts291 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold60 = new Bold();
            Color color291 = new Color() { Val = "000000" };
            FontSize fontSize291 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript291 = new FontSizeComplexScript() { Val = "24" };
            Languages languages283 = new Languages() { Val = "ru" };

            runProperties143.Append(runFonts291);
            runProperties143.Append(bold60);
            runProperties143.Append(color291);
            runProperties143.Append(fontSize291);
            runProperties143.Append(fontSizeComplexScript291);
            runProperties143.Append(languages283);
            LastRenderedPageBreak lastRenderedPageBreak7 = new LastRenderedPageBreak();
            Text text132 = new Text();
            text132.Text = "4. КОНТРОЛЬ И ОЦЕНКА РЕЗУЛЬТАТОВ ОСВОЕНИЯ УЧЕБНОЙ ДИСЦИПЛИНЫ";

            run143.Append(runProperties143);
            run143.Append(lastRenderedPageBreak7);
            run143.Append(text132);

            paragraph148.Append(paragraphProperties148);
            paragraph148.Append(run143);

            Paragraph paragraph149 = new Paragraph() { RsidParagraphAddition = "00FF310F", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties149 = new ParagraphProperties();
            WidowControl widowControl117 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE142 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN142 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent142 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines142 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification125 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties149 = new ParagraphMarkRunProperties();
            RunFonts runFonts292 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color292 = new Color() { Val = "000000" };
            FontSize fontSize292 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript292 = new FontSizeComplexScript() { Val = "24" };
            Languages languages284 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties149.Append(runFonts292);
            paragraphMarkRunProperties149.Append(color292);
            paragraphMarkRunProperties149.Append(fontSize292);
            paragraphMarkRunProperties149.Append(fontSizeComplexScript292);
            paragraphMarkRunProperties149.Append(languages284);

            paragraphProperties149.Append(widowControl117);
            paragraphProperties149.Append(autoSpaceDE142);
            paragraphProperties149.Append(autoSpaceDN142);
            paragraphProperties149.Append(adjustRightIndent142);
            paragraphProperties149.Append(spacingBetweenLines142);
            paragraphProperties149.Append(justification125);
            paragraphProperties149.Append(paragraphMarkRunProperties149);

            Run run144 = new Run();

            RunProperties runProperties144 = new RunProperties();
            RunFonts runFonts293 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color293 = new Color() { Val = "000000" };
            FontSize fontSize293 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript293 = new FontSizeComplexScript() { Val = "24" };
            Languages languages285 = new Languages() { Val = "ru" };

            runProperties144.Append(runFonts293);
            runProperties144.Append(color293);
            runProperties144.Append(fontSize293);
            runProperties144.Append(fontSizeComplexScript293);
            runProperties144.Append(languages285);
            Text text133 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text133.Text = "        Контроль и оценка результатов освоения учебной дисциплины осуществляется преподавателем в процессе проведения практических занятий, тестирования, а также выполнения обучающимися творческих заданий, написания эссе, составления сравнительных таблиц, самостоятельной работы обучающихся с текстами.";

            run144.Append(runProperties144);
            run144.Append(text133);

            Run run145 = new Run();

            RunProperties runProperties145 = new RunProperties();
            RunFonts runFonts294 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color294 = new Color() { Val = "000000" };
            FontSize fontSize294 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript294 = new FontSizeComplexScript() { Val = "24" };
            Languages languages286 = new Languages() { Val = "ru" };

            runProperties145.Append(runFonts294);
            runProperties145.Append(color294);
            runProperties145.Append(fontSize294);
            runProperties145.Append(fontSizeComplexScript294);
            runProperties145.Append(languages286);
            Break break18 = new Break();
            Text text134 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text134.Text = "        Оценка качества освоения учебной программы включает текущий контроль, промежуточную аттестацию по итогам освоения дисциплины.";

            run145.Append(runProperties145);
            run145.Append(break18);
            run145.Append(text134);

            Run run146 = new Run();

            RunProperties runProperties146 = new RunProperties();
            RunFonts runFonts295 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color295 = new Color() { Val = "000000" };
            FontSize fontSize295 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript295 = new FontSizeComplexScript() { Val = "24" };
            Languages languages287 = new Languages() { Val = "ru" };

            runProperties146.Append(runFonts295);
            runProperties146.Append(color295);
            runProperties146.Append(fontSize295);
            runProperties146.Append(fontSizeComplexScript295);
            runProperties146.Append(languages287);
            Break break19 = new Break();
            Text text135 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text135.Text = "        Текущий контроль проводится в форме устного или письменного опроса, тестирования.";

            run146.Append(runProperties146);
            run146.Append(break19);
            run146.Append(text135);

            Run run147 = new Run();

            RunProperties runProperties147 = new RunProperties();
            RunFonts runFonts296 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color296 = new Color() { Val = "000000" };
            FontSize fontSize296 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript296 = new FontSizeComplexScript() { Val = "24" };
            Languages languages288 = new Languages() { Val = "ru" };

            runProperties147.Append(runFonts296);
            runProperties147.Append(color296);
            runProperties147.Append(fontSize296);
            runProperties147.Append(fontSizeComplexScript296);
            runProperties147.Append(languages288);
            Break break20 = new Break();
            Text text136 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text136.Text = "        Итоговая аттестация по дисциплине проводится в форме дифференцированного зачета.";

            run147.Append(runProperties147);
            run147.Append(break20);
            run147.Append(text136);

            paragraph149.Append(paragraphProperties149);
            paragraph149.Append(run144);
            paragraph149.Append(run145);
            paragraph149.Append(run146);
            paragraph149.Append(run147);

            Paragraph paragraph150 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidParagraphProperties = "00FF310F", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties150 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties150 = new ParagraphMarkRunProperties();
            RunFonts runFonts297 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color297 = new Color() { Val = "000000" };
            FontSize fontSize297 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript297 = new FontSizeComplexScript() { Val = "24" };
            Languages languages289 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties150.Append(runFonts297);
            paragraphMarkRunProperties150.Append(color297);
            paragraphMarkRunProperties150.Append(fontSize297);
            paragraphMarkRunProperties150.Append(fontSizeComplexScript297);
            paragraphMarkRunProperties150.Append(languages289);

            paragraphProperties150.Append(paragraphMarkRunProperties150);

            paragraph150.Append(paragraphProperties150);

            Table table6 = new Table();

            TableProperties tableProperties6 = new TableProperties();
            TableWidth tableWidth6 = new TableWidth() { Width = "9767", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation5 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders5 = new TableBorders();
            TopBorder topBorder9 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder9 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder9 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder9 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder5 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder5 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders5.Append(topBorder9);
            tableBorders5.Append(leftBorder9);
            tableBorders5.Append(bottomBorder9);
            tableBorders5.Append(rightBorder9);
            tableBorders5.Append(insideHorizontalBorder5);
            tableBorders5.Append(insideVerticalBorder5);
            TableLayout tableLayout6 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault6 = new TableCellMarginDefault();
            TopMargin topMargin6 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin6 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin6 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin6 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault6.Append(topMargin6);
            tableCellMarginDefault6.Append(tableCellLeftMargin6);
            tableCellMarginDefault6.Append(bottomMargin6);
            tableCellMarginDefault6.Append(tableCellRightMargin6);
            TableLook tableLook6 = new TableLook() { Val = "0000" };

            tableProperties6.Append(tableWidth6);
            tableProperties6.Append(tableIndentation5);
            tableProperties6.Append(tableBorders5);
            tableProperties6.Append(tableLayout6);
            tableProperties6.Append(tableCellMarginDefault6);
            tableProperties6.Append(tableLook6);

            TableGrid tableGrid6 = new TableGrid();
            GridColumn gridColumn13 = new GridColumn() { Width = "5089" };
            GridColumn gridColumn14 = new GridColumn() { Width = "4678" };

            tableGrid6.Append(gridColumn13);
            tableGrid6.Append(gridColumn14);

            TableRow tableRow20 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00FF310F" };

            TableRowProperties tableRowProperties5 = new TableRowProperties();
            TableRowHeight tableRowHeight5 = new TableRowHeight() { Val = (UInt32Value)524U };

            tableRowProperties5.Append(tableRowHeight5);

            TableCell tableCell45 = new TableCell();

            TableCellProperties tableCellProperties45 = new TableCellProperties();
            TableCellWidth tableCellWidth45 = new TableCellWidth() { Width = "5089", Type = TableWidthUnitValues.Dxa };

            tableCellProperties45.Append(tableCellWidth45);

            Paragraph paragraph151 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties151 = new ParagraphProperties();
            WidowControl widowControl118 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE143 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN143 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent143 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines143 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification126 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties151 = new ParagraphMarkRunProperties();
            RunFonts runFonts298 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color298 = new Color() { Val = "000000" };
            FontSize fontSize298 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript298 = new FontSizeComplexScript() { Val = "24" };
            Languages languages290 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties151.Append(runFonts298);
            paragraphMarkRunProperties151.Append(color298);
            paragraphMarkRunProperties151.Append(fontSize298);
            paragraphMarkRunProperties151.Append(fontSizeComplexScript298);
            paragraphMarkRunProperties151.Append(languages290);

            paragraphProperties151.Append(widowControl118);
            paragraphProperties151.Append(autoSpaceDE143);
            paragraphProperties151.Append(autoSpaceDN143);
            paragraphProperties151.Append(adjustRightIndent143);
            paragraphProperties151.Append(spacingBetweenLines143);
            paragraphProperties151.Append(justification126);
            paragraphProperties151.Append(paragraphMarkRunProperties151);

            Run run148 = new Run();

            RunProperties runProperties148 = new RunProperties();
            RunFonts runFonts299 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold61 = new Bold();
            Color color299 = new Color() { Val = "000000" };
            FontSize fontSize299 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript299 = new FontSizeComplexScript() { Val = "24" };
            Languages languages291 = new Languages() { Val = "ru" };

            runProperties148.Append(runFonts299);
            runProperties148.Append(bold61);
            runProperties148.Append(color299);
            runProperties148.Append(fontSize299);
            runProperties148.Append(fontSizeComplexScript299);
            runProperties148.Append(languages291);
            Text text137 = new Text();
            text137.Text = "Результаты обучения (освоенные умения, усвоенные знания)";

            run148.Append(runProperties148);
            run148.Append(text137);

            paragraph151.Append(paragraphProperties151);
            paragraph151.Append(run148);

            tableCell45.Append(tableCellProperties45);
            tableCell45.Append(paragraph151);

            TableCell tableCell46 = new TableCell();

            TableCellProperties tableCellProperties46 = new TableCellProperties();
            TableCellWidth tableCellWidth46 = new TableCellWidth() { Width = "4678", Type = TableWidthUnitValues.Dxa };

            tableCellProperties46.Append(tableCellWidth46);

            Paragraph paragraph152 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties152 = new ParagraphProperties();
            WidowControl widowControl119 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE144 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN144 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent144 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines144 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification127 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties152 = new ParagraphMarkRunProperties();
            RunFonts runFonts300 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color300 = new Color() { Val = "000000" };
            FontSize fontSize300 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript300 = new FontSizeComplexScript() { Val = "24" };
            Languages languages292 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties152.Append(runFonts300);
            paragraphMarkRunProperties152.Append(color300);
            paragraphMarkRunProperties152.Append(fontSize300);
            paragraphMarkRunProperties152.Append(fontSizeComplexScript300);
            paragraphMarkRunProperties152.Append(languages292);

            paragraphProperties152.Append(widowControl119);
            paragraphProperties152.Append(autoSpaceDE144);
            paragraphProperties152.Append(autoSpaceDN144);
            paragraphProperties152.Append(adjustRightIndent144);
            paragraphProperties152.Append(spacingBetweenLines144);
            paragraphProperties152.Append(justification127);
            paragraphProperties152.Append(paragraphMarkRunProperties152);

            Run run149 = new Run();

            RunProperties runProperties149 = new RunProperties();
            RunFonts runFonts301 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold62 = new Bold();
            Color color301 = new Color() { Val = "000000" };
            FontSize fontSize301 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript301 = new FontSizeComplexScript() { Val = "24" };
            Languages languages293 = new Languages() { Val = "ru" };

            runProperties149.Append(runFonts301);
            runProperties149.Append(bold62);
            runProperties149.Append(color301);
            runProperties149.Append(fontSize301);
            runProperties149.Append(fontSizeComplexScript301);
            runProperties149.Append(languages293);
            Text text138 = new Text();
            text138.Text = "Формы и методы контроля и оценки результатов обучения";

            run149.Append(runProperties149);
            run149.Append(text138);

            paragraph152.Append(paragraphProperties152);
            paragraph152.Append(run149);

            tableCell46.Append(tableCellProperties46);
            tableCell46.Append(paragraph152);

            tableRow20.Append(tableRowProperties5);
            tableRow20.Append(tableCell45);
            tableRow20.Append(tableCell46);

            TableRow tableRow21 = new TableRow() { RsidTableRowAddition = "009B27E8", RsidTableRowProperties = "00FF310F" };

            TableRowProperties tableRowProperties6 = new TableRowProperties();
            TableRowHeight tableRowHeight6 = new TableRowHeight() { Val = (UInt32Value)1265U };

            tableRowProperties6.Append(tableRowHeight6);

            TableCell tableCell47 = new TableCell();

            TableCellProperties tableCellProperties47 = new TableCellProperties();
            TableCellWidth tableCellWidth47 = new TableCellWidth() { Width = "5089", Type = TableWidthUnitValues.Dxa };

            tableCellProperties47.Append(tableCellWidth47);

            Paragraph paragraph153 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties153 = new ParagraphProperties();
            WidowControl widowControl120 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE145 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN145 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent145 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines145 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification128 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties153 = new ParagraphMarkRunProperties();
            RunFonts runFonts302 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color302 = new Color() { Val = "000000" };
            FontSize fontSize302 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript302 = new FontSizeComplexScript() { Val = "24" };
            Languages languages294 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties153.Append(runFonts302);
            paragraphMarkRunProperties153.Append(color302);
            paragraphMarkRunProperties153.Append(fontSize302);
            paragraphMarkRunProperties153.Append(fontSizeComplexScript302);
            paragraphMarkRunProperties153.Append(languages294);

            paragraphProperties153.Append(widowControl120);
            paragraphProperties153.Append(autoSpaceDE145);
            paragraphProperties153.Append(autoSpaceDN145);
            paragraphProperties153.Append(adjustRightIndent145);
            paragraphProperties153.Append(spacingBetweenLines145);
            paragraphProperties153.Append(justification128);
            paragraphProperties153.Append(paragraphMarkRunProperties153);

            Run run150 = new Run();

            RunProperties runProperties150 = new RunProperties();
            RunFonts runFonts303 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color303 = new Color() { Val = "000000" };
            FontSize fontSize303 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript303 = new FontSizeComplexScript() { Val = "24" };
            Languages languages295 = new Languages() { Val = "ru" };

            runProperties150.Append(runFonts303);
            runProperties150.Append(color303);
            runProperties150.Append(fontSize303);
            runProperties150.Append(fontSizeComplexScript303);
            runProperties150.Append(languages295);
            Text text139 = new Text();
            text139.Text = "В результате освоения дисциплины обучающийся должен уметь:";

            run150.Append(runProperties150);
            run150.Append(text139);

            paragraph153.Append(paragraphProperties153);
            paragraph153.Append(run150);

            Paragraph paragraph154 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties154 = new ParagraphProperties();
            WidowControl widowControl121 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE146 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN146 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent146 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines146 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification129 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties154 = new ParagraphMarkRunProperties();
            RunFonts runFonts304 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color304 = new Color() { Val = "000000" };
            FontSize fontSize304 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript304 = new FontSizeComplexScript() { Val = "24" };
            Languages languages296 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties154.Append(runFonts304);
            paragraphMarkRunProperties154.Append(color304);
            paragraphMarkRunProperties154.Append(fontSize304);
            paragraphMarkRunProperties154.Append(fontSizeComplexScript304);
            paragraphMarkRunProperties154.Append(languages296);

            paragraphProperties154.Append(widowControl121);
            paragraphProperties154.Append(autoSpaceDE146);
            paragraphProperties154.Append(autoSpaceDN146);
            paragraphProperties154.Append(adjustRightIndent146);
            paragraphProperties154.Append(spacingBetweenLines146);
            paragraphProperties154.Append(justification129);
            paragraphProperties154.Append(paragraphMarkRunProperties154);

            Run run151 = new Run();

            RunProperties runProperties151 = new RunProperties();
            RunFonts runFonts305 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color305 = new Color() { Val = "000000" };
            FontSize fontSize305 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript305 = new FontSizeComplexScript() { Val = "24" };
            Languages languages297 = new Languages() { Val = "ru" };

            runProperties151.Append(runFonts305);
            runProperties151.Append(color305);
            runProperties151.Append(fontSize305);
            runProperties151.Append(fontSizeComplexScript305);
            runProperties151.Append(languages297);
            Text text140 = new Text();
            text140.Text = "В результате освоения дисциплины обучающийся должен знать:";

            run151.Append(runProperties151);
            run151.Append(text140);

            paragraph154.Append(paragraphProperties154);
            paragraph154.Append(run151);

            Paragraph paragraph155 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties155 = new ParagraphProperties();
            WidowControl widowControl122 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE147 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN147 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent147 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines147 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification130 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties155 = new ParagraphMarkRunProperties();
            RunFonts runFonts306 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color306 = new Color() { Val = "000000" };
            FontSize fontSize306 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript306 = new FontSizeComplexScript() { Val = "24" };
            Languages languages298 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties155.Append(runFonts306);
            paragraphMarkRunProperties155.Append(color306);
            paragraphMarkRunProperties155.Append(fontSize306);
            paragraphMarkRunProperties155.Append(fontSizeComplexScript306);
            paragraphMarkRunProperties155.Append(languages298);

            paragraphProperties155.Append(widowControl122);
            paragraphProperties155.Append(autoSpaceDE147);
            paragraphProperties155.Append(autoSpaceDN147);
            paragraphProperties155.Append(adjustRightIndent147);
            paragraphProperties155.Append(spacingBetweenLines147);
            paragraphProperties155.Append(justification130);
            paragraphProperties155.Append(paragraphMarkRunProperties155);

            paragraph155.Append(paragraphProperties155);

            tableCell47.Append(tableCellProperties47);
            tableCell47.Append(paragraph153);
            tableCell47.Append(paragraph154);
            tableCell47.Append(paragraph155);

            TableCell tableCell48 = new TableCell();

            TableCellProperties tableCellProperties48 = new TableCellProperties();
            TableCellWidth tableCellWidth48 = new TableCellWidth() { Width = "4678", Type = TableWidthUnitValues.Dxa };

            tableCellProperties48.Append(tableCellWidth48);

            Paragraph paragraph156 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties156 = new ParagraphProperties();
            WidowControl widowControl123 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE148 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN148 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent148 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines148 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification131 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties156 = new ParagraphMarkRunProperties();
            RunFonts runFonts307 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color307 = new Color() { Val = "000000" };
            FontSize fontSize307 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript307 = new FontSizeComplexScript() { Val = "24" };
            Languages languages299 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties156.Append(runFonts307);
            paragraphMarkRunProperties156.Append(color307);
            paragraphMarkRunProperties156.Append(fontSize307);
            paragraphMarkRunProperties156.Append(fontSizeComplexScript307);
            paragraphMarkRunProperties156.Append(languages299);

            paragraphProperties156.Append(widowControl123);
            paragraphProperties156.Append(autoSpaceDE148);
            paragraphProperties156.Append(autoSpaceDN148);
            paragraphProperties156.Append(adjustRightIndent148);
            paragraphProperties156.Append(spacingBetweenLines148);
            paragraphProperties156.Append(justification131);
            paragraphProperties156.Append(paragraphMarkRunProperties156);

            Run run152 = new Run();

            RunProperties runProperties152 = new RunProperties();
            RunFonts runFonts308 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color308 = new Color() { Val = "000000" };
            FontSize fontSize308 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript308 = new FontSizeComplexScript() { Val = "24" };
            Languages languages300 = new Languages() { Val = "ru" };

            runProperties152.Append(runFonts308);
            runProperties152.Append(color308);
            runProperties152.Append(fontSize308);
            runProperties152.Append(fontSizeComplexScript308);
            runProperties152.Append(languages300);
            Text text141 = new Text();
            text141.Text = "Формы контроля обучения :";

            run152.Append(runProperties152);
            run152.Append(text141);

            paragraph156.Append(paragraphProperties156);
            paragraph156.Append(run152);

            Paragraph paragraph157 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties157 = new ParagraphProperties();
            WidowControl widowControl124 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE149 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN149 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent149 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines149 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification132 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties157 = new ParagraphMarkRunProperties();
            RunFonts runFonts309 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color309 = new Color() { Val = "000000" };
            FontSize fontSize309 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript309 = new FontSizeComplexScript() { Val = "24" };
            Languages languages301 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties157.Append(runFonts309);
            paragraphMarkRunProperties157.Append(color309);
            paragraphMarkRunProperties157.Append(fontSize309);
            paragraphMarkRunProperties157.Append(fontSizeComplexScript309);
            paragraphMarkRunProperties157.Append(languages301);

            paragraphProperties157.Append(widowControl124);
            paragraphProperties157.Append(autoSpaceDE149);
            paragraphProperties157.Append(autoSpaceDN149);
            paragraphProperties157.Append(adjustRightIndent149);
            paragraphProperties157.Append(spacingBetweenLines149);
            paragraphProperties157.Append(justification132);
            paragraphProperties157.Append(paragraphMarkRunProperties157);

            Run run153 = new Run();

            RunProperties runProperties153 = new RunProperties();
            RunFonts runFonts310 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color310 = new Color() { Val = "000000" };
            FontSize fontSize310 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript310 = new FontSizeComplexScript() { Val = "24" };
            Languages languages302 = new Languages() { Val = "ru" };

            runProperties153.Append(runFonts310);
            runProperties153.Append(color310);
            runProperties153.Append(fontSize310);
            runProperties153.Append(fontSizeComplexScript310);
            runProperties153.Append(languages302);
            Text text142 = new Text();
            text142.Text = "Методы оценки результатов обучения :";

            run153.Append(runProperties153);
            run153.Append(text142);

            paragraph157.Append(paragraphProperties157);
            paragraph157.Append(run153);

            Paragraph paragraph158 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties158 = new ParagraphProperties();
            WidowControl widowControl125 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE150 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN150 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent150 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines150 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification133 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties158 = new ParagraphMarkRunProperties();
            RunFonts runFonts311 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color311 = new Color() { Val = "000000" };
            FontSize fontSize311 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript311 = new FontSizeComplexScript() { Val = "24" };
            Languages languages303 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties158.Append(runFonts311);
            paragraphMarkRunProperties158.Append(color311);
            paragraphMarkRunProperties158.Append(fontSize311);
            paragraphMarkRunProperties158.Append(fontSizeComplexScript311);
            paragraphMarkRunProperties158.Append(languages303);

            paragraphProperties158.Append(widowControl125);
            paragraphProperties158.Append(autoSpaceDE150);
            paragraphProperties158.Append(autoSpaceDN150);
            paragraphProperties158.Append(adjustRightIndent150);
            paragraphProperties158.Append(spacingBetweenLines150);
            paragraphProperties158.Append(justification133);
            paragraphProperties158.Append(paragraphMarkRunProperties158);

            paragraph158.Append(paragraphProperties158);

            tableCell48.Append(tableCellProperties48);
            tableCell48.Append(paragraph156);
            tableCell48.Append(paragraph157);
            tableCell48.Append(paragraph158);

            tableRow21.Append(tableRowProperties6);
            tableRow21.Append(tableCell47);
            tableRow21.Append(tableCell48);

            table6.Append(tableProperties6);
            table6.Append(tableGrid6);
            table6.Append(tableRow20);
            table6.Append(tableRow21);

            Paragraph paragraph159 = new Paragraph() { RsidParagraphAddition = "00FF310F", RsidRunAdditionDefault = "00FF310F" };

            ParagraphProperties paragraphProperties159 = new ParagraphProperties();
            WidowControl widowControl126 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE151 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN151 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent151 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines151 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification134 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties159 = new ParagraphMarkRunProperties();
            RunFonts runFonts312 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color312 = new Color() { Val = "000000" };
            FontSize fontSize312 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript312 = new FontSizeComplexScript() { Val = "24" };
            Languages languages304 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties159.Append(runFonts312);
            paragraphMarkRunProperties159.Append(color312);
            paragraphMarkRunProperties159.Append(fontSize312);
            paragraphMarkRunProperties159.Append(fontSizeComplexScript312);
            paragraphMarkRunProperties159.Append(languages304);

            paragraphProperties159.Append(widowControl126);
            paragraphProperties159.Append(autoSpaceDE151);
            paragraphProperties159.Append(autoSpaceDN151);
            paragraphProperties159.Append(adjustRightIndent151);
            paragraphProperties159.Append(spacingBetweenLines151);
            paragraphProperties159.Append(justification134);
            paragraphProperties159.Append(paragraphMarkRunProperties159);

            paragraph159.Append(paragraphProperties159);

            Paragraph paragraph160 = new Paragraph() { RsidParagraphAddition = "00FF310F", RsidRunAdditionDefault = "00FF310F" };

            ParagraphProperties paragraphProperties160 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties160 = new ParagraphMarkRunProperties();
            RunFonts runFonts313 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color313 = new Color() { Val = "000000" };
            FontSize fontSize313 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript313 = new FontSizeComplexScript() { Val = "24" };
            Languages languages305 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties160.Append(runFonts313);
            paragraphMarkRunProperties160.Append(color313);
            paragraphMarkRunProperties160.Append(fontSize313);
            paragraphMarkRunProperties160.Append(fontSizeComplexScript313);
            paragraphMarkRunProperties160.Append(languages305);

            paragraphProperties160.Append(paragraphMarkRunProperties160);

            Run run154 = new Run();

            RunProperties runProperties154 = new RunProperties();
            RunFonts runFonts314 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color314 = new Color() { Val = "000000" };
            FontSize fontSize314 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript314 = new FontSizeComplexScript() { Val = "24" };
            Languages languages306 = new Languages() { Val = "ru" };

            runProperties154.Append(runFonts314);
            runProperties154.Append(color314);
            runProperties154.Append(fontSize314);
            runProperties154.Append(fontSizeComplexScript314);
            runProperties154.Append(languages306);
            Break break21 = new Break() { Type = BreakValues.Page };

            run154.Append(runProperties154);
            run154.Append(break21);

            paragraph160.Append(paragraphProperties160);
            paragraph160.Append(run154);

            Paragraph paragraph161 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties161 = new ParagraphProperties();
            WidowControl widowControl127 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE152 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN152 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent152 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines152 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification135 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties161 = new ParagraphMarkRunProperties();
            RunFonts runFonts315 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color315 = new Color() { Val = "000000" };
            FontSize fontSize315 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript315 = new FontSizeComplexScript() { Val = "24" };
            Languages languages307 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties161.Append(runFonts315);
            paragraphMarkRunProperties161.Append(color315);
            paragraphMarkRunProperties161.Append(fontSize315);
            paragraphMarkRunProperties161.Append(fontSizeComplexScript315);
            paragraphMarkRunProperties161.Append(languages307);

            paragraphProperties161.Append(widowControl127);
            paragraphProperties161.Append(autoSpaceDE152);
            paragraphProperties161.Append(autoSpaceDN152);
            paragraphProperties161.Append(adjustRightIndent152);
            paragraphProperties161.Append(spacingBetweenLines152);
            paragraphProperties161.Append(justification135);
            paragraphProperties161.Append(paragraphMarkRunProperties161);

            Run run155 = new Run();

            RunProperties runProperties155 = new RunProperties();
            RunFonts runFonts316 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color316 = new Color() { Val = "000000" };
            FontSize fontSize316 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript316 = new FontSizeComplexScript() { Val = "24" };
            Languages languages308 = new Languages() { Val = "ru" };

            runProperties155.Append(runFonts316);
            runProperties155.Append(color316);
            runProperties155.Append(fontSize316);
            runProperties155.Append(fontSizeComplexScript316);
            runProperties155.Append(languages308);
            LastRenderedPageBreak lastRenderedPageBreak8 = new LastRenderedPageBreak();
            Text text143 = new Text();
            text143.Text = "ЛИСТ РЕГИСТРАЦИИ ИЗМЕНЕНИЙ";

            run155.Append(runProperties155);
            run155.Append(lastRenderedPageBreak8);
            run155.Append(text143);

            paragraph161.Append(paragraphProperties161);
            paragraph161.Append(run155);

            Paragraph paragraph162 = new Paragraph() { RsidParagraphAddition = "00060844", RsidRunAdditionDefault = "00060844" };

            ParagraphProperties paragraphProperties162 = new ParagraphProperties();
            WidowControl widowControl128 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE153 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN153 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent153 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines153 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification136 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties162 = new ParagraphMarkRunProperties();
            RunFonts runFonts317 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color317 = new Color() { Val = "000000" };
            FontSize fontSize317 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript317 = new FontSizeComplexScript() { Val = "24" };
            Languages languages309 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties162.Append(runFonts317);
            paragraphMarkRunProperties162.Append(color317);
            paragraphMarkRunProperties162.Append(fontSize317);
            paragraphMarkRunProperties162.Append(fontSizeComplexScript317);
            paragraphMarkRunProperties162.Append(languages309);

            paragraphProperties162.Append(widowControl128);
            paragraphProperties162.Append(autoSpaceDE153);
            paragraphProperties162.Append(autoSpaceDN153);
            paragraphProperties162.Append(adjustRightIndent153);
            paragraphProperties162.Append(spacingBetweenLines153);
            paragraphProperties162.Append(justification136);
            paragraphProperties162.Append(paragraphMarkRunProperties162);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            paragraph162.Append(paragraphProperties162);
            paragraph162.Append(bookmarkStart1);
            paragraph162.Append(bookmarkEnd1);

            Table table7 = new Table();

            TableProperties tableProperties7 = new TableProperties();
            TableWidth tableWidth7 = new TableWidth() { Width = "10051", Type = TableWidthUnitValues.Dxa };
            TableIndentation tableIndentation6 = new TableIndentation() { Width = 10, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders6 = new TableBorders();
            TopBorder topBorder10 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            LeftBorder leftBorder10 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder10 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            RightBorder rightBorder10 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder6 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder6 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)3U, Space = (UInt32Value)0U };

            tableBorders6.Append(topBorder10);
            tableBorders6.Append(leftBorder10);
            tableBorders6.Append(bottomBorder10);
            tableBorders6.Append(rightBorder10);
            tableBorders6.Append(insideHorizontalBorder6);
            tableBorders6.Append(insideVerticalBorder6);
            TableLayout tableLayout7 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault7 = new TableCellMarginDefault();
            TopMargin topMargin7 = new TopMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin7 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin7 = new BottomMargin() { Width = "10", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin7 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault7.Append(topMargin7);
            tableCellMarginDefault7.Append(tableCellLeftMargin7);
            tableCellMarginDefault7.Append(bottomMargin7);
            tableCellMarginDefault7.Append(tableCellRightMargin7);
            TableLook tableLook7 = new TableLook() { Val = "0000" };

            tableProperties7.Append(tableWidth7);
            tableProperties7.Append(tableIndentation6);
            tableProperties7.Append(tableBorders6);
            tableProperties7.Append(tableLayout7);
            tableProperties7.Append(tableCellMarginDefault7);
            tableProperties7.Append(tableLook7);

            TableGrid tableGrid7 = new TableGrid();
            GridColumn gridColumn15 = new GridColumn() { Width = "979" };
            GridColumn gridColumn16 = new GridColumn() { Width = "850" };
            GridColumn gridColumn17 = new GridColumn() { Width = "851" };
            GridColumn gridColumn18 = new GridColumn() { Width = "850" };
            GridColumn gridColumn19 = new GridColumn() { Width = "1134" };
            GridColumn gridColumn20 = new GridColumn() { Width = "1134" };
            GridColumn gridColumn21 = new GridColumn() { Width = "1985" };
            GridColumn gridColumn22 = new GridColumn() { Width = "1134" };
            GridColumn gridColumn23 = new GridColumn() { Width = "1134" };

            tableGrid7.Append(gridColumn15);
            tableGrid7.Append(gridColumn16);
            tableGrid7.Append(gridColumn17);
            tableGrid7.Append(gridColumn18);
            tableGrid7.Append(gridColumn19);
            tableGrid7.Append(gridColumn20);
            tableGrid7.Append(gridColumn21);
            tableGrid7.Append(gridColumn22);
            tableGrid7.Append(gridColumn23);

            TableRow tableRow22 = new TableRow() { RsidTableRowAddition = "004525A9", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties7 = new TableRowProperties();
            TableRowHeight tableRowHeight7 = new TableRowHeight() { Val = (UInt32Value)322U };

            tableRowProperties7.Append(tableRowHeight7);

            TableCell tableCell49 = new TableCell();

            TableCellProperties tableCellProperties49 = new TableCellProperties();
            TableCellWidth tableCellWidth49 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge3 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties49.Append(tableCellWidth49);
            tableCellProperties49.Append(verticalMerge3);

            Paragraph paragraph163 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties163 = new ParagraphProperties();
            WidowControl widowControl129 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE154 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN154 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent154 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines154 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification137 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties163 = new ParagraphMarkRunProperties();
            RunFonts runFonts318 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color318 = new Color() { Val = "000000" };
            FontSize fontSize318 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript318 = new FontSizeComplexScript() { Val = "24" };
            Languages languages310 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties163.Append(runFonts318);
            paragraphMarkRunProperties163.Append(color318);
            paragraphMarkRunProperties163.Append(fontSize318);
            paragraphMarkRunProperties163.Append(fontSizeComplexScript318);
            paragraphMarkRunProperties163.Append(languages310);

            paragraphProperties163.Append(widowControl129);
            paragraphProperties163.Append(autoSpaceDE154);
            paragraphProperties163.Append(autoSpaceDN154);
            paragraphProperties163.Append(adjustRightIndent154);
            paragraphProperties163.Append(spacingBetweenLines154);
            paragraphProperties163.Append(justification137);
            paragraphProperties163.Append(paragraphMarkRunProperties163);

            Run run156 = new Run();

            RunProperties runProperties156 = new RunProperties();
            RunFonts runFonts319 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color319 = new Color() { Val = "000000" };
            FontSize fontSize319 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript319 = new FontSizeComplexScript() { Val = "24" };
            Languages languages311 = new Languages() { Val = "ru" };

            runProperties156.Append(runFonts319);
            runProperties156.Append(color319);
            runProperties156.Append(fontSize319);
            runProperties156.Append(fontSizeComplexScript319);
            runProperties156.Append(languages311);
            Text text144 = new Text();
            text144.Text = "Номер изменения";

            run156.Append(runProperties156);
            run156.Append(text144);

            paragraph163.Append(paragraphProperties163);
            paragraph163.Append(run156);

            tableCell49.Append(tableCellProperties49);
            tableCell49.Append(paragraph163);

            TableCell tableCell50 = new TableCell();

            TableCellProperties tableCellProperties50 = new TableCellProperties();
            TableCellWidth tableCellWidth50 = new TableCellWidth() { Width = "3685", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan3 = new GridSpan() { Val = 4 };

            tableCellProperties50.Append(tableCellWidth50);
            tableCellProperties50.Append(gridSpan3);

            Paragraph paragraph164 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties164 = new ParagraphProperties();
            WidowControl widowControl130 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE155 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN155 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent155 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines155 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification138 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties164 = new ParagraphMarkRunProperties();
            RunFonts runFonts320 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color320 = new Color() { Val = "000000" };
            FontSize fontSize320 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript320 = new FontSizeComplexScript() { Val = "24" };
            Languages languages312 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties164.Append(runFonts320);
            paragraphMarkRunProperties164.Append(color320);
            paragraphMarkRunProperties164.Append(fontSize320);
            paragraphMarkRunProperties164.Append(fontSizeComplexScript320);
            paragraphMarkRunProperties164.Append(languages312);

            paragraphProperties164.Append(widowControl130);
            paragraphProperties164.Append(autoSpaceDE155);
            paragraphProperties164.Append(autoSpaceDN155);
            paragraphProperties164.Append(adjustRightIndent155);
            paragraphProperties164.Append(spacingBetweenLines155);
            paragraphProperties164.Append(justification138);
            paragraphProperties164.Append(paragraphMarkRunProperties164);

            Run run157 = new Run();

            RunProperties runProperties157 = new RunProperties();
            RunFonts runFonts321 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color321 = new Color() { Val = "000000" };
            FontSize fontSize321 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript321 = new FontSizeComplexScript() { Val = "24" };
            Languages languages313 = new Languages() { Val = "ru" };

            runProperties157.Append(runFonts321);
            runProperties157.Append(color321);
            runProperties157.Append(fontSize321);
            runProperties157.Append(fontSizeComplexScript321);
            runProperties157.Append(languages313);
            Text text145 = new Text();
            text145.Text = "Номер листа";

            run157.Append(runProperties157);
            run157.Append(text145);

            paragraph164.Append(paragraphProperties164);
            paragraph164.Append(run157);

            tableCell50.Append(tableCellProperties50);
            tableCell50.Append(paragraph164);

            TableCell tableCell51 = new TableCell();

            TableCellProperties tableCellProperties51 = new TableCellProperties();
            TableCellWidth tableCellWidth51 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge4 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties51.Append(tableCellWidth51);
            tableCellProperties51.Append(verticalMerge4);

            Paragraph paragraph165 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties165 = new ParagraphProperties();
            WidowControl widowControl131 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE156 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN156 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent156 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines156 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification139 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties165 = new ParagraphMarkRunProperties();
            RunFonts runFonts322 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color322 = new Color() { Val = "000000" };
            FontSize fontSize322 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript322 = new FontSizeComplexScript() { Val = "24" };
            Languages languages314 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties165.Append(runFonts322);
            paragraphMarkRunProperties165.Append(color322);
            paragraphMarkRunProperties165.Append(fontSize322);
            paragraphMarkRunProperties165.Append(fontSizeComplexScript322);
            paragraphMarkRunProperties165.Append(languages314);

            paragraphProperties165.Append(widowControl131);
            paragraphProperties165.Append(autoSpaceDE156);
            paragraphProperties165.Append(autoSpaceDN156);
            paragraphProperties165.Append(adjustRightIndent156);
            paragraphProperties165.Append(spacingBetweenLines156);
            paragraphProperties165.Append(justification139);
            paragraphProperties165.Append(paragraphMarkRunProperties165);

            Run run158 = new Run();

            RunProperties runProperties158 = new RunProperties();
            RunFonts runFonts323 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color323 = new Color() { Val = "000000" };
            FontSize fontSize323 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript323 = new FontSizeComplexScript() { Val = "24" };
            Languages languages315 = new Languages() { Val = "ru" };

            runProperties158.Append(runFonts323);
            runProperties158.Append(color323);
            runProperties158.Append(fontSize323);
            runProperties158.Append(fontSizeComplexScript323);
            runProperties158.Append(languages315);
            Text text146 = new Text();
            text146.Text = "Всего листов в документе";

            run158.Append(runProperties158);
            run158.Append(text146);

            paragraph165.Append(paragraphProperties165);
            paragraph165.Append(run158);

            tableCell51.Append(tableCellProperties51);
            tableCell51.Append(paragraph165);

            TableCell tableCell52 = new TableCell();

            TableCellProperties tableCellProperties52 = new TableCellProperties();
            TableCellWidth tableCellWidth52 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge5 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties52.Append(tableCellWidth52);
            tableCellProperties52.Append(verticalMerge5);

            Paragraph paragraph166 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties166 = new ParagraphProperties();
            WidowControl widowControl132 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE157 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN157 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent157 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines157 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification140 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties166 = new ParagraphMarkRunProperties();
            RunFonts runFonts324 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color324 = new Color() { Val = "000000" };
            FontSize fontSize324 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript324 = new FontSizeComplexScript() { Val = "24" };
            Languages languages316 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties166.Append(runFonts324);
            paragraphMarkRunProperties166.Append(color324);
            paragraphMarkRunProperties166.Append(fontSize324);
            paragraphMarkRunProperties166.Append(fontSizeComplexScript324);
            paragraphMarkRunProperties166.Append(languages316);

            paragraphProperties166.Append(widowControl132);
            paragraphProperties166.Append(autoSpaceDE157);
            paragraphProperties166.Append(autoSpaceDN157);
            paragraphProperties166.Append(adjustRightIndent157);
            paragraphProperties166.Append(spacingBetweenLines157);
            paragraphProperties166.Append(justification140);
            paragraphProperties166.Append(paragraphMarkRunProperties166);

            Run run159 = new Run();

            RunProperties runProperties159 = new RunProperties();
            RunFonts runFonts325 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color325 = new Color() { Val = "000000" };
            FontSize fontSize325 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript325 = new FontSizeComplexScript() { Val = "24" };
            Languages languages317 = new Languages() { Val = "ru" };

            runProperties159.Append(runFonts325);
            runProperties159.Append(color325);
            runProperties159.Append(fontSize325);
            runProperties159.Append(fontSizeComplexScript325);
            runProperties159.Append(languages317);
            Text text147 = new Text();
            text147.Text = "ФИО и подпись ответственного за внесение изменения";

            run159.Append(runProperties159);
            run159.Append(text147);

            paragraph166.Append(paragraphProperties166);
            paragraph166.Append(run159);

            tableCell52.Append(tableCellProperties52);
            tableCell52.Append(paragraph166);

            TableCell tableCell53 = new TableCell();

            TableCellProperties tableCellProperties53 = new TableCellProperties();
            TableCellWidth tableCellWidth53 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge6 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties53.Append(tableCellWidth53);
            tableCellProperties53.Append(verticalMerge6);

            Paragraph paragraph167 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties167 = new ParagraphProperties();
            WidowControl widowControl133 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE158 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN158 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent158 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines158 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification141 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties167 = new ParagraphMarkRunProperties();
            RunFonts runFonts326 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color326 = new Color() { Val = "000000" };
            FontSize fontSize326 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript326 = new FontSizeComplexScript() { Val = "24" };
            Languages languages318 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties167.Append(runFonts326);
            paragraphMarkRunProperties167.Append(color326);
            paragraphMarkRunProperties167.Append(fontSize326);
            paragraphMarkRunProperties167.Append(fontSizeComplexScript326);
            paragraphMarkRunProperties167.Append(languages318);

            paragraphProperties167.Append(widowControl133);
            paragraphProperties167.Append(autoSpaceDE158);
            paragraphProperties167.Append(autoSpaceDN158);
            paragraphProperties167.Append(adjustRightIndent158);
            paragraphProperties167.Append(spacingBetweenLines158);
            paragraphProperties167.Append(justification141);
            paragraphProperties167.Append(paragraphMarkRunProperties167);

            Run run160 = new Run();

            RunProperties runProperties160 = new RunProperties();
            RunFonts runFonts327 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color327 = new Color() { Val = "000000" };
            FontSize fontSize327 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript327 = new FontSizeComplexScript() { Val = "24" };
            Languages languages319 = new Languages() { Val = "ru" };

            runProperties160.Append(runFonts327);
            runProperties160.Append(color327);
            runProperties160.Append(fontSize327);
            runProperties160.Append(fontSizeComplexScript327);
            runProperties160.Append(languages319);
            Text text148 = new Text();
            text148.Text = "Дата внесения изменения";

            run160.Append(runProperties160);
            run160.Append(text148);

            paragraph167.Append(paragraphProperties167);
            paragraph167.Append(run160);

            tableCell53.Append(tableCellProperties53);
            tableCell53.Append(paragraph167);

            TableCell tableCell54 = new TableCell();

            TableCellProperties tableCellProperties54 = new TableCellProperties();
            TableCellWidth tableCellWidth54 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge7 = new VerticalMerge() { Val = MergedCellValues.Restart };

            tableCellProperties54.Append(tableCellWidth54);
            tableCellProperties54.Append(verticalMerge7);

            Paragraph paragraph168 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties168 = new ParagraphProperties();
            WidowControl widowControl134 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE159 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN159 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent159 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines159 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification142 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties168 = new ParagraphMarkRunProperties();
            RunFonts runFonts328 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color328 = new Color() { Val = "000000" };
            FontSize fontSize328 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript328 = new FontSizeComplexScript() { Val = "24" };
            Languages languages320 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties168.Append(runFonts328);
            paragraphMarkRunProperties168.Append(color328);
            paragraphMarkRunProperties168.Append(fontSize328);
            paragraphMarkRunProperties168.Append(fontSizeComplexScript328);
            paragraphMarkRunProperties168.Append(languages320);

            paragraphProperties168.Append(widowControl134);
            paragraphProperties168.Append(autoSpaceDE159);
            paragraphProperties168.Append(autoSpaceDN159);
            paragraphProperties168.Append(adjustRightIndent159);
            paragraphProperties168.Append(spacingBetweenLines159);
            paragraphProperties168.Append(justification142);
            paragraphProperties168.Append(paragraphMarkRunProperties168);

            Run run161 = new Run();

            RunProperties runProperties161 = new RunProperties();
            RunFonts runFonts329 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color329 = new Color() { Val = "000000" };
            FontSize fontSize329 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript329 = new FontSizeComplexScript() { Val = "24" };
            Languages languages321 = new Languages() { Val = "ru" };

            runProperties161.Append(runFonts329);
            runProperties161.Append(color329);
            runProperties161.Append(fontSize329);
            runProperties161.Append(fontSizeComplexScript329);
            runProperties161.Append(languages321);
            Text text149 = new Text();
            text149.Text = "Дата введения изменения";

            run161.Append(runProperties161);
            run161.Append(text149);

            paragraph168.Append(paragraphProperties168);
            paragraph168.Append(run161);

            tableCell54.Append(tableCellProperties54);
            tableCell54.Append(paragraph168);

            tableRow22.Append(tableRowProperties7);
            tableRow22.Append(tableCell49);
            tableRow22.Append(tableCell50);
            tableRow22.Append(tableCell51);
            tableRow22.Append(tableCell52);
            tableRow22.Append(tableCell53);
            tableRow22.Append(tableCell54);

            TableRow tableRow23 = new TableRow() { RsidTableRowAddition = "004525A9", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties8 = new TableRowProperties();
            TableRowHeight tableRowHeight8 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties8.Append(tableRowHeight8);

            TableCell tableCell55 = new TableCell();

            TableCellProperties tableCellProperties55 = new TableCellProperties();
            TableCellWidth tableCellWidth55 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge8 = new VerticalMerge();

            tableCellProperties55.Append(tableCellWidth55);
            tableCellProperties55.Append(verticalMerge8);

            Paragraph paragraph169 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties169 = new ParagraphProperties();
            WidowControl widowControl135 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE160 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN160 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent160 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines160 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification143 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties169 = new ParagraphMarkRunProperties();
            RunFonts runFonts330 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color330 = new Color() { Val = "000000" };
            FontSize fontSize330 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript330 = new FontSizeComplexScript() { Val = "24" };
            Languages languages322 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties169.Append(runFonts330);
            paragraphMarkRunProperties169.Append(color330);
            paragraphMarkRunProperties169.Append(fontSize330);
            paragraphMarkRunProperties169.Append(fontSizeComplexScript330);
            paragraphMarkRunProperties169.Append(languages322);

            paragraphProperties169.Append(widowControl135);
            paragraphProperties169.Append(autoSpaceDE160);
            paragraphProperties169.Append(autoSpaceDN160);
            paragraphProperties169.Append(adjustRightIndent160);
            paragraphProperties169.Append(spacingBetweenLines160);
            paragraphProperties169.Append(justification143);
            paragraphProperties169.Append(paragraphMarkRunProperties169);

            paragraph169.Append(paragraphProperties169);

            tableCell55.Append(tableCellProperties55);
            tableCell55.Append(paragraph169);

            TableCell tableCell56 = new TableCell();

            TableCellProperties tableCellProperties56 = new TableCellProperties();
            TableCellWidth tableCellWidth56 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties56.Append(tableCellWidth56);

            Paragraph paragraph170 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties170 = new ParagraphProperties();
            WidowControl widowControl136 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE161 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN161 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent161 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines161 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification144 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties170 = new ParagraphMarkRunProperties();
            RunFonts runFonts331 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color331 = new Color() { Val = "000000" };
            FontSize fontSize331 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript331 = new FontSizeComplexScript() { Val = "24" };
            Languages languages323 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties170.Append(runFonts331);
            paragraphMarkRunProperties170.Append(color331);
            paragraphMarkRunProperties170.Append(fontSize331);
            paragraphMarkRunProperties170.Append(fontSizeComplexScript331);
            paragraphMarkRunProperties170.Append(languages323);

            paragraphProperties170.Append(widowControl136);
            paragraphProperties170.Append(autoSpaceDE161);
            paragraphProperties170.Append(autoSpaceDN161);
            paragraphProperties170.Append(adjustRightIndent161);
            paragraphProperties170.Append(spacingBetweenLines161);
            paragraphProperties170.Append(justification144);
            paragraphProperties170.Append(paragraphMarkRunProperties170);

            Run run162 = new Run();

            RunProperties runProperties162 = new RunProperties();
            RunFonts runFonts332 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color332 = new Color() { Val = "000000" };
            FontSize fontSize332 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript332 = new FontSizeComplexScript() { Val = "24" };
            Languages languages324 = new Languages() { Val = "ru" };

            runProperties162.Append(runFonts332);
            runProperties162.Append(color332);
            runProperties162.Append(fontSize332);
            runProperties162.Append(fontSizeComplexScript332);
            runProperties162.Append(languages324);
            Text text150 = new Text();
            text150.Text = "измененного";

            run162.Append(runProperties162);
            run162.Append(text150);

            paragraph170.Append(paragraphProperties170);
            paragraph170.Append(run162);

            tableCell56.Append(tableCellProperties56);
            tableCell56.Append(paragraph170);

            TableCell tableCell57 = new TableCell();

            TableCellProperties tableCellProperties57 = new TableCellProperties();
            TableCellWidth tableCellWidth57 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties57.Append(tableCellWidth57);

            Paragraph paragraph171 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties171 = new ParagraphProperties();
            WidowControl widowControl137 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE162 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN162 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent162 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines162 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification145 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties171 = new ParagraphMarkRunProperties();
            RunFonts runFonts333 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color333 = new Color() { Val = "000000" };
            FontSize fontSize333 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript333 = new FontSizeComplexScript() { Val = "24" };
            Languages languages325 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties171.Append(runFonts333);
            paragraphMarkRunProperties171.Append(color333);
            paragraphMarkRunProperties171.Append(fontSize333);
            paragraphMarkRunProperties171.Append(fontSizeComplexScript333);
            paragraphMarkRunProperties171.Append(languages325);

            paragraphProperties171.Append(widowControl137);
            paragraphProperties171.Append(autoSpaceDE162);
            paragraphProperties171.Append(autoSpaceDN162);
            paragraphProperties171.Append(adjustRightIndent162);
            paragraphProperties171.Append(spacingBetweenLines162);
            paragraphProperties171.Append(justification145);
            paragraphProperties171.Append(paragraphMarkRunProperties171);

            Run run163 = new Run();

            RunProperties runProperties163 = new RunProperties();
            RunFonts runFonts334 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color334 = new Color() { Val = "000000" };
            FontSize fontSize334 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript334 = new FontSizeComplexScript() { Val = "24" };
            Languages languages326 = new Languages() { Val = "ru" };

            runProperties163.Append(runFonts334);
            runProperties163.Append(color334);
            runProperties163.Append(fontSize334);
            runProperties163.Append(fontSizeComplexScript334);
            runProperties163.Append(languages326);
            Text text151 = new Text();
            text151.Text = "замененного";

            run163.Append(runProperties163);
            run163.Append(text151);

            paragraph171.Append(paragraphProperties171);
            paragraph171.Append(run163);

            tableCell57.Append(tableCellProperties57);
            tableCell57.Append(paragraph171);

            TableCell tableCell58 = new TableCell();

            TableCellProperties tableCellProperties58 = new TableCellProperties();
            TableCellWidth tableCellWidth58 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties58.Append(tableCellWidth58);

            Paragraph paragraph172 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties172 = new ParagraphProperties();
            WidowControl widowControl138 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE163 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN163 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent163 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines163 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification146 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties172 = new ParagraphMarkRunProperties();
            RunFonts runFonts335 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color335 = new Color() { Val = "000000" };
            FontSize fontSize335 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript335 = new FontSizeComplexScript() { Val = "24" };
            Languages languages327 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties172.Append(runFonts335);
            paragraphMarkRunProperties172.Append(color335);
            paragraphMarkRunProperties172.Append(fontSize335);
            paragraphMarkRunProperties172.Append(fontSizeComplexScript335);
            paragraphMarkRunProperties172.Append(languages327);

            paragraphProperties172.Append(widowControl138);
            paragraphProperties172.Append(autoSpaceDE163);
            paragraphProperties172.Append(autoSpaceDN163);
            paragraphProperties172.Append(adjustRightIndent163);
            paragraphProperties172.Append(spacingBetweenLines163);
            paragraphProperties172.Append(justification146);
            paragraphProperties172.Append(paragraphMarkRunProperties172);

            Run run164 = new Run();

            RunProperties runProperties164 = new RunProperties();
            RunFonts runFonts336 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color336 = new Color() { Val = "000000" };
            FontSize fontSize336 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript336 = new FontSizeComplexScript() { Val = "24" };
            Languages languages328 = new Languages() { Val = "ru" };

            runProperties164.Append(runFonts336);
            runProperties164.Append(color336);
            runProperties164.Append(fontSize336);
            runProperties164.Append(fontSizeComplexScript336);
            runProperties164.Append(languages328);
            Text text152 = new Text();
            text152.Text = "нового";

            run164.Append(runProperties164);
            run164.Append(text152);

            paragraph172.Append(paragraphProperties172);
            paragraph172.Append(run164);

            tableCell58.Append(tableCellProperties58);
            tableCell58.Append(paragraph172);

            TableCell tableCell59 = new TableCell();

            TableCellProperties tableCellProperties59 = new TableCellProperties();
            TableCellWidth tableCellWidth59 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties59.Append(tableCellWidth59);

            Paragraph paragraph173 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties173 = new ParagraphProperties();
            WidowControl widowControl139 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE164 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN164 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent164 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines164 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification147 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties173 = new ParagraphMarkRunProperties();
            RunFonts runFonts337 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color337 = new Color() { Val = "000000" };
            FontSize fontSize337 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript337 = new FontSizeComplexScript() { Val = "24" };
            Languages languages329 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties173.Append(runFonts337);
            paragraphMarkRunProperties173.Append(color337);
            paragraphMarkRunProperties173.Append(fontSize337);
            paragraphMarkRunProperties173.Append(fontSizeComplexScript337);
            paragraphMarkRunProperties173.Append(languages329);

            paragraphProperties173.Append(widowControl139);
            paragraphProperties173.Append(autoSpaceDE164);
            paragraphProperties173.Append(autoSpaceDN164);
            paragraphProperties173.Append(adjustRightIndent164);
            paragraphProperties173.Append(spacingBetweenLines164);
            paragraphProperties173.Append(justification147);
            paragraphProperties173.Append(paragraphMarkRunProperties173);

            Run run165 = new Run();

            RunProperties runProperties165 = new RunProperties();
            RunFonts runFonts338 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color338 = new Color() { Val = "000000" };
            FontSize fontSize338 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript338 = new FontSizeComplexScript() { Val = "24" };
            Languages languages330 = new Languages() { Val = "ru" };

            runProperties165.Append(runFonts338);
            runProperties165.Append(color338);
            runProperties165.Append(fontSize338);
            runProperties165.Append(fontSizeComplexScript338);
            runProperties165.Append(languages330);
            Text text153 = new Text();
            text153.Text = "изъятого";

            run165.Append(runProperties165);
            run165.Append(text153);

            paragraph173.Append(paragraphProperties173);
            paragraph173.Append(run165);

            tableCell59.Append(tableCellProperties59);
            tableCell59.Append(paragraph173);

            TableCell tableCell60 = new TableCell();

            TableCellProperties tableCellProperties60 = new TableCellProperties();
            TableCellWidth tableCellWidth60 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge9 = new VerticalMerge();

            tableCellProperties60.Append(tableCellWidth60);
            tableCellProperties60.Append(verticalMerge9);

            Paragraph paragraph174 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties174 = new ParagraphProperties();
            WidowControl widowControl140 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE165 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN165 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent165 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines165 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification148 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties174 = new ParagraphMarkRunProperties();
            RunFonts runFonts339 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color339 = new Color() { Val = "000000" };
            FontSize fontSize339 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript339 = new FontSizeComplexScript() { Val = "24" };
            Languages languages331 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties174.Append(runFonts339);
            paragraphMarkRunProperties174.Append(color339);
            paragraphMarkRunProperties174.Append(fontSize339);
            paragraphMarkRunProperties174.Append(fontSizeComplexScript339);
            paragraphMarkRunProperties174.Append(languages331);

            paragraphProperties174.Append(widowControl140);
            paragraphProperties174.Append(autoSpaceDE165);
            paragraphProperties174.Append(autoSpaceDN165);
            paragraphProperties174.Append(adjustRightIndent165);
            paragraphProperties174.Append(spacingBetweenLines165);
            paragraphProperties174.Append(justification148);
            paragraphProperties174.Append(paragraphMarkRunProperties174);

            paragraph174.Append(paragraphProperties174);

            tableCell60.Append(tableCellProperties60);
            tableCell60.Append(paragraph174);

            TableCell tableCell61 = new TableCell();

            TableCellProperties tableCellProperties61 = new TableCellProperties();
            TableCellWidth tableCellWidth61 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge10 = new VerticalMerge();

            tableCellProperties61.Append(tableCellWidth61);
            tableCellProperties61.Append(verticalMerge10);

            Paragraph paragraph175 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties175 = new ParagraphProperties();
            WidowControl widowControl141 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE166 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN166 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent166 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines166 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification149 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties175 = new ParagraphMarkRunProperties();
            RunFonts runFonts340 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color340 = new Color() { Val = "000000" };
            FontSize fontSize340 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript340 = new FontSizeComplexScript() { Val = "24" };
            Languages languages332 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties175.Append(runFonts340);
            paragraphMarkRunProperties175.Append(color340);
            paragraphMarkRunProperties175.Append(fontSize340);
            paragraphMarkRunProperties175.Append(fontSizeComplexScript340);
            paragraphMarkRunProperties175.Append(languages332);

            paragraphProperties175.Append(widowControl141);
            paragraphProperties175.Append(autoSpaceDE166);
            paragraphProperties175.Append(autoSpaceDN166);
            paragraphProperties175.Append(adjustRightIndent166);
            paragraphProperties175.Append(spacingBetweenLines166);
            paragraphProperties175.Append(justification149);
            paragraphProperties175.Append(paragraphMarkRunProperties175);

            paragraph175.Append(paragraphProperties175);

            tableCell61.Append(tableCellProperties61);
            tableCell61.Append(paragraph175);

            TableCell tableCell62 = new TableCell();

            TableCellProperties tableCellProperties62 = new TableCellProperties();
            TableCellWidth tableCellWidth62 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge11 = new VerticalMerge();

            tableCellProperties62.Append(tableCellWidth62);
            tableCellProperties62.Append(verticalMerge11);

            Paragraph paragraph176 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties176 = new ParagraphProperties();
            WidowControl widowControl142 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE167 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN167 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent167 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines167 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification150 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties176 = new ParagraphMarkRunProperties();
            RunFonts runFonts341 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color341 = new Color() { Val = "000000" };
            FontSize fontSize341 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript341 = new FontSizeComplexScript() { Val = "24" };
            Languages languages333 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties176.Append(runFonts341);
            paragraphMarkRunProperties176.Append(color341);
            paragraphMarkRunProperties176.Append(fontSize341);
            paragraphMarkRunProperties176.Append(fontSizeComplexScript341);
            paragraphMarkRunProperties176.Append(languages333);

            paragraphProperties176.Append(widowControl142);
            paragraphProperties176.Append(autoSpaceDE167);
            paragraphProperties176.Append(autoSpaceDN167);
            paragraphProperties176.Append(adjustRightIndent167);
            paragraphProperties176.Append(spacingBetweenLines167);
            paragraphProperties176.Append(justification150);
            paragraphProperties176.Append(paragraphMarkRunProperties176);

            paragraph176.Append(paragraphProperties176);

            tableCell62.Append(tableCellProperties62);
            tableCell62.Append(paragraph176);

            TableCell tableCell63 = new TableCell();

            TableCellProperties tableCellProperties63 = new TableCellProperties();
            TableCellWidth tableCellWidth63 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge12 = new VerticalMerge();

            tableCellProperties63.Append(tableCellWidth63);
            tableCellProperties63.Append(verticalMerge12);

            Paragraph paragraph177 = new Paragraph() { RsidParagraphAddition = "004525A9", RsidRunAdditionDefault = "004525A9" };

            ParagraphProperties paragraphProperties177 = new ParagraphProperties();
            WidowControl widowControl143 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE168 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN168 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent168 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines168 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification151 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties177 = new ParagraphMarkRunProperties();
            RunFonts runFonts342 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color342 = new Color() { Val = "000000" };
            FontSize fontSize342 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript342 = new FontSizeComplexScript() { Val = "24" };
            Languages languages334 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties177.Append(runFonts342);
            paragraphMarkRunProperties177.Append(color342);
            paragraphMarkRunProperties177.Append(fontSize342);
            paragraphMarkRunProperties177.Append(fontSizeComplexScript342);
            paragraphMarkRunProperties177.Append(languages334);

            paragraphProperties177.Append(widowControl143);
            paragraphProperties177.Append(autoSpaceDE168);
            paragraphProperties177.Append(autoSpaceDN168);
            paragraphProperties177.Append(adjustRightIndent168);
            paragraphProperties177.Append(spacingBetweenLines168);
            paragraphProperties177.Append(justification151);
            paragraphProperties177.Append(paragraphMarkRunProperties177);

            paragraph177.Append(paragraphProperties177);

            tableCell63.Append(tableCellProperties63);
            tableCell63.Append(paragraph177);

            tableRow23.Append(tableRowProperties8);
            tableRow23.Append(tableCell55);
            tableRow23.Append(tableCell56);
            tableRow23.Append(tableCell57);
            tableRow23.Append(tableCell58);
            tableRow23.Append(tableCell59);
            tableRow23.Append(tableCell60);
            tableRow23.Append(tableCell61);
            tableRow23.Append(tableCell62);
            tableRow23.Append(tableCell63);

            TableRow tableRow24 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties9 = new TableRowProperties();
            TableRowHeight tableRowHeight9 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties9.Append(tableRowHeight9);

            TableCell tableCell64 = new TableCell();

            TableCellProperties tableCellProperties64 = new TableCellProperties();
            TableCellWidth tableCellWidth64 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties64.Append(tableCellWidth64);

            Paragraph paragraph178 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties178 = new ParagraphProperties();
            WidowControl widowControl144 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE169 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN169 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent169 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines169 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification152 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties178 = new ParagraphMarkRunProperties();
            RunFonts runFonts343 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color343 = new Color() { Val = "000000" };
            FontSize fontSize343 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript343 = new FontSizeComplexScript() { Val = "24" };
            Languages languages335 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties178.Append(runFonts343);
            paragraphMarkRunProperties178.Append(color343);
            paragraphMarkRunProperties178.Append(fontSize343);
            paragraphMarkRunProperties178.Append(fontSizeComplexScript343);
            paragraphMarkRunProperties178.Append(languages335);

            paragraphProperties178.Append(widowControl144);
            paragraphProperties178.Append(autoSpaceDE169);
            paragraphProperties178.Append(autoSpaceDN169);
            paragraphProperties178.Append(adjustRightIndent169);
            paragraphProperties178.Append(spacingBetweenLines169);
            paragraphProperties178.Append(justification152);
            paragraphProperties178.Append(paragraphMarkRunProperties178);

            paragraph178.Append(paragraphProperties178);

            tableCell64.Append(tableCellProperties64);
            tableCell64.Append(paragraph178);

            TableCell tableCell65 = new TableCell();

            TableCellProperties tableCellProperties65 = new TableCellProperties();
            TableCellWidth tableCellWidth65 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties65.Append(tableCellWidth65);

            Paragraph paragraph179 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties179 = new ParagraphProperties();
            WidowControl widowControl145 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE170 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN170 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent170 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines170 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification153 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties179 = new ParagraphMarkRunProperties();
            RunFonts runFonts344 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color344 = new Color() { Val = "000000" };
            FontSize fontSize344 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript344 = new FontSizeComplexScript() { Val = "24" };
            Languages languages336 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties179.Append(runFonts344);
            paragraphMarkRunProperties179.Append(color344);
            paragraphMarkRunProperties179.Append(fontSize344);
            paragraphMarkRunProperties179.Append(fontSizeComplexScript344);
            paragraphMarkRunProperties179.Append(languages336);

            paragraphProperties179.Append(widowControl145);
            paragraphProperties179.Append(autoSpaceDE170);
            paragraphProperties179.Append(autoSpaceDN170);
            paragraphProperties179.Append(adjustRightIndent170);
            paragraphProperties179.Append(spacingBetweenLines170);
            paragraphProperties179.Append(justification153);
            paragraphProperties179.Append(paragraphMarkRunProperties179);

            paragraph179.Append(paragraphProperties179);

            tableCell65.Append(tableCellProperties65);
            tableCell65.Append(paragraph179);

            TableCell tableCell66 = new TableCell();

            TableCellProperties tableCellProperties66 = new TableCellProperties();
            TableCellWidth tableCellWidth66 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties66.Append(tableCellWidth66);

            Paragraph paragraph180 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties180 = new ParagraphProperties();
            WidowControl widowControl146 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE171 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN171 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent171 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines171 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification154 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties180 = new ParagraphMarkRunProperties();
            RunFonts runFonts345 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color345 = new Color() { Val = "000000" };
            FontSize fontSize345 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript345 = new FontSizeComplexScript() { Val = "24" };
            Languages languages337 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties180.Append(runFonts345);
            paragraphMarkRunProperties180.Append(color345);
            paragraphMarkRunProperties180.Append(fontSize345);
            paragraphMarkRunProperties180.Append(fontSizeComplexScript345);
            paragraphMarkRunProperties180.Append(languages337);

            paragraphProperties180.Append(widowControl146);
            paragraphProperties180.Append(autoSpaceDE171);
            paragraphProperties180.Append(autoSpaceDN171);
            paragraphProperties180.Append(adjustRightIndent171);
            paragraphProperties180.Append(spacingBetweenLines171);
            paragraphProperties180.Append(justification154);
            paragraphProperties180.Append(paragraphMarkRunProperties180);

            paragraph180.Append(paragraphProperties180);

            tableCell66.Append(tableCellProperties66);
            tableCell66.Append(paragraph180);

            TableCell tableCell67 = new TableCell();

            TableCellProperties tableCellProperties67 = new TableCellProperties();
            TableCellWidth tableCellWidth67 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties67.Append(tableCellWidth67);

            Paragraph paragraph181 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties181 = new ParagraphProperties();
            WidowControl widowControl147 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE172 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN172 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent172 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines172 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification155 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties181 = new ParagraphMarkRunProperties();
            RunFonts runFonts346 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color346 = new Color() { Val = "000000" };
            FontSize fontSize346 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript346 = new FontSizeComplexScript() { Val = "24" };
            Languages languages338 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties181.Append(runFonts346);
            paragraphMarkRunProperties181.Append(color346);
            paragraphMarkRunProperties181.Append(fontSize346);
            paragraphMarkRunProperties181.Append(fontSizeComplexScript346);
            paragraphMarkRunProperties181.Append(languages338);

            paragraphProperties181.Append(widowControl147);
            paragraphProperties181.Append(autoSpaceDE172);
            paragraphProperties181.Append(autoSpaceDN172);
            paragraphProperties181.Append(adjustRightIndent172);
            paragraphProperties181.Append(spacingBetweenLines172);
            paragraphProperties181.Append(justification155);
            paragraphProperties181.Append(paragraphMarkRunProperties181);

            paragraph181.Append(paragraphProperties181);

            tableCell67.Append(tableCellProperties67);
            tableCell67.Append(paragraph181);

            TableCell tableCell68 = new TableCell();

            TableCellProperties tableCellProperties68 = new TableCellProperties();
            TableCellWidth tableCellWidth68 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties68.Append(tableCellWidth68);

            Paragraph paragraph182 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties182 = new ParagraphProperties();
            WidowControl widowControl148 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE173 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN173 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent173 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines173 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification156 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties182 = new ParagraphMarkRunProperties();
            RunFonts runFonts347 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color347 = new Color() { Val = "000000" };
            FontSize fontSize347 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript347 = new FontSizeComplexScript() { Val = "24" };
            Languages languages339 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties182.Append(runFonts347);
            paragraphMarkRunProperties182.Append(color347);
            paragraphMarkRunProperties182.Append(fontSize347);
            paragraphMarkRunProperties182.Append(fontSizeComplexScript347);
            paragraphMarkRunProperties182.Append(languages339);

            paragraphProperties182.Append(widowControl148);
            paragraphProperties182.Append(autoSpaceDE173);
            paragraphProperties182.Append(autoSpaceDN173);
            paragraphProperties182.Append(adjustRightIndent173);
            paragraphProperties182.Append(spacingBetweenLines173);
            paragraphProperties182.Append(justification156);
            paragraphProperties182.Append(paragraphMarkRunProperties182);

            paragraph182.Append(paragraphProperties182);

            tableCell68.Append(tableCellProperties68);
            tableCell68.Append(paragraph182);

            TableCell tableCell69 = new TableCell();

            TableCellProperties tableCellProperties69 = new TableCellProperties();
            TableCellWidth tableCellWidth69 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties69.Append(tableCellWidth69);

            Paragraph paragraph183 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties183 = new ParagraphProperties();
            WidowControl widowControl149 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE174 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN174 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent174 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines174 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification157 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties183 = new ParagraphMarkRunProperties();
            RunFonts runFonts348 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color348 = new Color() { Val = "000000" };
            FontSize fontSize348 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript348 = new FontSizeComplexScript() { Val = "24" };
            Languages languages340 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties183.Append(runFonts348);
            paragraphMarkRunProperties183.Append(color348);
            paragraphMarkRunProperties183.Append(fontSize348);
            paragraphMarkRunProperties183.Append(fontSizeComplexScript348);
            paragraphMarkRunProperties183.Append(languages340);

            paragraphProperties183.Append(widowControl149);
            paragraphProperties183.Append(autoSpaceDE174);
            paragraphProperties183.Append(autoSpaceDN174);
            paragraphProperties183.Append(adjustRightIndent174);
            paragraphProperties183.Append(spacingBetweenLines174);
            paragraphProperties183.Append(justification157);
            paragraphProperties183.Append(paragraphMarkRunProperties183);

            paragraph183.Append(paragraphProperties183);

            tableCell69.Append(tableCellProperties69);
            tableCell69.Append(paragraph183);

            TableCell tableCell70 = new TableCell();

            TableCellProperties tableCellProperties70 = new TableCellProperties();
            TableCellWidth tableCellWidth70 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties70.Append(tableCellWidth70);

            Paragraph paragraph184 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties184 = new ParagraphProperties();
            WidowControl widowControl150 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE175 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN175 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent175 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines175 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification158 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties184 = new ParagraphMarkRunProperties();
            RunFonts runFonts349 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color349 = new Color() { Val = "000000" };
            FontSize fontSize349 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript349 = new FontSizeComplexScript() { Val = "24" };
            Languages languages341 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties184.Append(runFonts349);
            paragraphMarkRunProperties184.Append(color349);
            paragraphMarkRunProperties184.Append(fontSize349);
            paragraphMarkRunProperties184.Append(fontSizeComplexScript349);
            paragraphMarkRunProperties184.Append(languages341);

            paragraphProperties184.Append(widowControl150);
            paragraphProperties184.Append(autoSpaceDE175);
            paragraphProperties184.Append(autoSpaceDN175);
            paragraphProperties184.Append(adjustRightIndent175);
            paragraphProperties184.Append(spacingBetweenLines175);
            paragraphProperties184.Append(justification158);
            paragraphProperties184.Append(paragraphMarkRunProperties184);

            paragraph184.Append(paragraphProperties184);

            tableCell70.Append(tableCellProperties70);
            tableCell70.Append(paragraph184);

            TableCell tableCell71 = new TableCell();

            TableCellProperties tableCellProperties71 = new TableCellProperties();
            TableCellWidth tableCellWidth71 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties71.Append(tableCellWidth71);

            Paragraph paragraph185 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties185 = new ParagraphProperties();
            WidowControl widowControl151 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE176 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN176 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent176 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines176 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification159 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties185 = new ParagraphMarkRunProperties();
            RunFonts runFonts350 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color350 = new Color() { Val = "000000" };
            FontSize fontSize350 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript350 = new FontSizeComplexScript() { Val = "24" };
            Languages languages342 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties185.Append(runFonts350);
            paragraphMarkRunProperties185.Append(color350);
            paragraphMarkRunProperties185.Append(fontSize350);
            paragraphMarkRunProperties185.Append(fontSizeComplexScript350);
            paragraphMarkRunProperties185.Append(languages342);

            paragraphProperties185.Append(widowControl151);
            paragraphProperties185.Append(autoSpaceDE176);
            paragraphProperties185.Append(autoSpaceDN176);
            paragraphProperties185.Append(adjustRightIndent176);
            paragraphProperties185.Append(spacingBetweenLines176);
            paragraphProperties185.Append(justification159);
            paragraphProperties185.Append(paragraphMarkRunProperties185);

            paragraph185.Append(paragraphProperties185);

            tableCell71.Append(tableCellProperties71);
            tableCell71.Append(paragraph185);

            TableCell tableCell72 = new TableCell();

            TableCellProperties tableCellProperties72 = new TableCellProperties();
            TableCellWidth tableCellWidth72 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties72.Append(tableCellWidth72);

            Paragraph paragraph186 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties186 = new ParagraphProperties();
            WidowControl widowControl152 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE177 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN177 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent177 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines177 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification160 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties186 = new ParagraphMarkRunProperties();
            RunFonts runFonts351 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color351 = new Color() { Val = "000000" };
            FontSize fontSize351 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript351 = new FontSizeComplexScript() { Val = "24" };
            Languages languages343 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties186.Append(runFonts351);
            paragraphMarkRunProperties186.Append(color351);
            paragraphMarkRunProperties186.Append(fontSize351);
            paragraphMarkRunProperties186.Append(fontSizeComplexScript351);
            paragraphMarkRunProperties186.Append(languages343);

            paragraphProperties186.Append(widowControl152);
            paragraphProperties186.Append(autoSpaceDE177);
            paragraphProperties186.Append(autoSpaceDN177);
            paragraphProperties186.Append(adjustRightIndent177);
            paragraphProperties186.Append(spacingBetweenLines177);
            paragraphProperties186.Append(justification160);
            paragraphProperties186.Append(paragraphMarkRunProperties186);

            paragraph186.Append(paragraphProperties186);

            tableCell72.Append(tableCellProperties72);
            tableCell72.Append(paragraph186);

            tableRow24.Append(tableRowProperties9);
            tableRow24.Append(tableCell64);
            tableRow24.Append(tableCell65);
            tableRow24.Append(tableCell66);
            tableRow24.Append(tableCell67);
            tableRow24.Append(tableCell68);
            tableRow24.Append(tableCell69);
            tableRow24.Append(tableCell70);
            tableRow24.Append(tableCell71);
            tableRow24.Append(tableCell72);

            TableRow tableRow25 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties10 = new TableRowProperties();
            TableRowHeight tableRowHeight10 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties10.Append(tableRowHeight10);

            TableCell tableCell73 = new TableCell();

            TableCellProperties tableCellProperties73 = new TableCellProperties();
            TableCellWidth tableCellWidth73 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties73.Append(tableCellWidth73);

            Paragraph paragraph187 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties187 = new ParagraphProperties();
            WidowControl widowControl153 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE178 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN178 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent178 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines178 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification161 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties187 = new ParagraphMarkRunProperties();
            RunFonts runFonts352 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color352 = new Color() { Val = "000000" };
            FontSize fontSize352 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript352 = new FontSizeComplexScript() { Val = "24" };
            Languages languages344 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties187.Append(runFonts352);
            paragraphMarkRunProperties187.Append(color352);
            paragraphMarkRunProperties187.Append(fontSize352);
            paragraphMarkRunProperties187.Append(fontSizeComplexScript352);
            paragraphMarkRunProperties187.Append(languages344);

            paragraphProperties187.Append(widowControl153);
            paragraphProperties187.Append(autoSpaceDE178);
            paragraphProperties187.Append(autoSpaceDN178);
            paragraphProperties187.Append(adjustRightIndent178);
            paragraphProperties187.Append(spacingBetweenLines178);
            paragraphProperties187.Append(justification161);
            paragraphProperties187.Append(paragraphMarkRunProperties187);

            paragraph187.Append(paragraphProperties187);

            tableCell73.Append(tableCellProperties73);
            tableCell73.Append(paragraph187);

            TableCell tableCell74 = new TableCell();

            TableCellProperties tableCellProperties74 = new TableCellProperties();
            TableCellWidth tableCellWidth74 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties74.Append(tableCellWidth74);

            Paragraph paragraph188 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties188 = new ParagraphProperties();
            WidowControl widowControl154 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE179 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN179 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent179 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines179 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification162 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties188 = new ParagraphMarkRunProperties();
            RunFonts runFonts353 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color353 = new Color() { Val = "000000" };
            FontSize fontSize353 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript353 = new FontSizeComplexScript() { Val = "24" };
            Languages languages345 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties188.Append(runFonts353);
            paragraphMarkRunProperties188.Append(color353);
            paragraphMarkRunProperties188.Append(fontSize353);
            paragraphMarkRunProperties188.Append(fontSizeComplexScript353);
            paragraphMarkRunProperties188.Append(languages345);

            paragraphProperties188.Append(widowControl154);
            paragraphProperties188.Append(autoSpaceDE179);
            paragraphProperties188.Append(autoSpaceDN179);
            paragraphProperties188.Append(adjustRightIndent179);
            paragraphProperties188.Append(spacingBetweenLines179);
            paragraphProperties188.Append(justification162);
            paragraphProperties188.Append(paragraphMarkRunProperties188);

            paragraph188.Append(paragraphProperties188);

            tableCell74.Append(tableCellProperties74);
            tableCell74.Append(paragraph188);

            TableCell tableCell75 = new TableCell();

            TableCellProperties tableCellProperties75 = new TableCellProperties();
            TableCellWidth tableCellWidth75 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties75.Append(tableCellWidth75);

            Paragraph paragraph189 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties189 = new ParagraphProperties();
            WidowControl widowControl155 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE180 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN180 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent180 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines180 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification163 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties189 = new ParagraphMarkRunProperties();
            RunFonts runFonts354 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color354 = new Color() { Val = "000000" };
            FontSize fontSize354 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript354 = new FontSizeComplexScript() { Val = "24" };
            Languages languages346 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties189.Append(runFonts354);
            paragraphMarkRunProperties189.Append(color354);
            paragraphMarkRunProperties189.Append(fontSize354);
            paragraphMarkRunProperties189.Append(fontSizeComplexScript354);
            paragraphMarkRunProperties189.Append(languages346);

            paragraphProperties189.Append(widowControl155);
            paragraphProperties189.Append(autoSpaceDE180);
            paragraphProperties189.Append(autoSpaceDN180);
            paragraphProperties189.Append(adjustRightIndent180);
            paragraphProperties189.Append(spacingBetweenLines180);
            paragraphProperties189.Append(justification163);
            paragraphProperties189.Append(paragraphMarkRunProperties189);

            paragraph189.Append(paragraphProperties189);

            tableCell75.Append(tableCellProperties75);
            tableCell75.Append(paragraph189);

            TableCell tableCell76 = new TableCell();

            TableCellProperties tableCellProperties76 = new TableCellProperties();
            TableCellWidth tableCellWidth76 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties76.Append(tableCellWidth76);

            Paragraph paragraph190 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties190 = new ParagraphProperties();
            WidowControl widowControl156 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE181 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN181 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent181 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines181 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification164 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties190 = new ParagraphMarkRunProperties();
            RunFonts runFonts355 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color355 = new Color() { Val = "000000" };
            FontSize fontSize355 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript355 = new FontSizeComplexScript() { Val = "24" };
            Languages languages347 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties190.Append(runFonts355);
            paragraphMarkRunProperties190.Append(color355);
            paragraphMarkRunProperties190.Append(fontSize355);
            paragraphMarkRunProperties190.Append(fontSizeComplexScript355);
            paragraphMarkRunProperties190.Append(languages347);

            paragraphProperties190.Append(widowControl156);
            paragraphProperties190.Append(autoSpaceDE181);
            paragraphProperties190.Append(autoSpaceDN181);
            paragraphProperties190.Append(adjustRightIndent181);
            paragraphProperties190.Append(spacingBetweenLines181);
            paragraphProperties190.Append(justification164);
            paragraphProperties190.Append(paragraphMarkRunProperties190);

            paragraph190.Append(paragraphProperties190);

            tableCell76.Append(tableCellProperties76);
            tableCell76.Append(paragraph190);

            TableCell tableCell77 = new TableCell();

            TableCellProperties tableCellProperties77 = new TableCellProperties();
            TableCellWidth tableCellWidth77 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties77.Append(tableCellWidth77);

            Paragraph paragraph191 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties191 = new ParagraphProperties();
            WidowControl widowControl157 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE182 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN182 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent182 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines182 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification165 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties191 = new ParagraphMarkRunProperties();
            RunFonts runFonts356 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color356 = new Color() { Val = "000000" };
            FontSize fontSize356 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript356 = new FontSizeComplexScript() { Val = "24" };
            Languages languages348 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties191.Append(runFonts356);
            paragraphMarkRunProperties191.Append(color356);
            paragraphMarkRunProperties191.Append(fontSize356);
            paragraphMarkRunProperties191.Append(fontSizeComplexScript356);
            paragraphMarkRunProperties191.Append(languages348);

            paragraphProperties191.Append(widowControl157);
            paragraphProperties191.Append(autoSpaceDE182);
            paragraphProperties191.Append(autoSpaceDN182);
            paragraphProperties191.Append(adjustRightIndent182);
            paragraphProperties191.Append(spacingBetweenLines182);
            paragraphProperties191.Append(justification165);
            paragraphProperties191.Append(paragraphMarkRunProperties191);

            paragraph191.Append(paragraphProperties191);

            tableCell77.Append(tableCellProperties77);
            tableCell77.Append(paragraph191);

            TableCell tableCell78 = new TableCell();

            TableCellProperties tableCellProperties78 = new TableCellProperties();
            TableCellWidth tableCellWidth78 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties78.Append(tableCellWidth78);

            Paragraph paragraph192 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties192 = new ParagraphProperties();
            WidowControl widowControl158 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE183 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN183 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent183 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines183 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification166 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties192 = new ParagraphMarkRunProperties();
            RunFonts runFonts357 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color357 = new Color() { Val = "000000" };
            FontSize fontSize357 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript357 = new FontSizeComplexScript() { Val = "24" };
            Languages languages349 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties192.Append(runFonts357);
            paragraphMarkRunProperties192.Append(color357);
            paragraphMarkRunProperties192.Append(fontSize357);
            paragraphMarkRunProperties192.Append(fontSizeComplexScript357);
            paragraphMarkRunProperties192.Append(languages349);

            paragraphProperties192.Append(widowControl158);
            paragraphProperties192.Append(autoSpaceDE183);
            paragraphProperties192.Append(autoSpaceDN183);
            paragraphProperties192.Append(adjustRightIndent183);
            paragraphProperties192.Append(spacingBetweenLines183);
            paragraphProperties192.Append(justification166);
            paragraphProperties192.Append(paragraphMarkRunProperties192);

            paragraph192.Append(paragraphProperties192);

            tableCell78.Append(tableCellProperties78);
            tableCell78.Append(paragraph192);

            TableCell tableCell79 = new TableCell();

            TableCellProperties tableCellProperties79 = new TableCellProperties();
            TableCellWidth tableCellWidth79 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties79.Append(tableCellWidth79);

            Paragraph paragraph193 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties193 = new ParagraphProperties();
            WidowControl widowControl159 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE184 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN184 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent184 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines184 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification167 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties193 = new ParagraphMarkRunProperties();
            RunFonts runFonts358 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color358 = new Color() { Val = "000000" };
            FontSize fontSize358 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript358 = new FontSizeComplexScript() { Val = "24" };
            Languages languages350 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties193.Append(runFonts358);
            paragraphMarkRunProperties193.Append(color358);
            paragraphMarkRunProperties193.Append(fontSize358);
            paragraphMarkRunProperties193.Append(fontSizeComplexScript358);
            paragraphMarkRunProperties193.Append(languages350);

            paragraphProperties193.Append(widowControl159);
            paragraphProperties193.Append(autoSpaceDE184);
            paragraphProperties193.Append(autoSpaceDN184);
            paragraphProperties193.Append(adjustRightIndent184);
            paragraphProperties193.Append(spacingBetweenLines184);
            paragraphProperties193.Append(justification167);
            paragraphProperties193.Append(paragraphMarkRunProperties193);

            paragraph193.Append(paragraphProperties193);

            tableCell79.Append(tableCellProperties79);
            tableCell79.Append(paragraph193);

            TableCell tableCell80 = new TableCell();

            TableCellProperties tableCellProperties80 = new TableCellProperties();
            TableCellWidth tableCellWidth80 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties80.Append(tableCellWidth80);

            Paragraph paragraph194 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties194 = new ParagraphProperties();
            WidowControl widowControl160 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE185 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN185 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent185 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines185 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification168 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties194 = new ParagraphMarkRunProperties();
            RunFonts runFonts359 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color359 = new Color() { Val = "000000" };
            FontSize fontSize359 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript359 = new FontSizeComplexScript() { Val = "24" };
            Languages languages351 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties194.Append(runFonts359);
            paragraphMarkRunProperties194.Append(color359);
            paragraphMarkRunProperties194.Append(fontSize359);
            paragraphMarkRunProperties194.Append(fontSizeComplexScript359);
            paragraphMarkRunProperties194.Append(languages351);

            paragraphProperties194.Append(widowControl160);
            paragraphProperties194.Append(autoSpaceDE185);
            paragraphProperties194.Append(autoSpaceDN185);
            paragraphProperties194.Append(adjustRightIndent185);
            paragraphProperties194.Append(spacingBetweenLines185);
            paragraphProperties194.Append(justification168);
            paragraphProperties194.Append(paragraphMarkRunProperties194);

            paragraph194.Append(paragraphProperties194);

            tableCell80.Append(tableCellProperties80);
            tableCell80.Append(paragraph194);

            TableCell tableCell81 = new TableCell();

            TableCellProperties tableCellProperties81 = new TableCellProperties();
            TableCellWidth tableCellWidth81 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties81.Append(tableCellWidth81);

            Paragraph paragraph195 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties195 = new ParagraphProperties();
            WidowControl widowControl161 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE186 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN186 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent186 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines186 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification169 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties195 = new ParagraphMarkRunProperties();
            RunFonts runFonts360 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color360 = new Color() { Val = "000000" };
            FontSize fontSize360 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript360 = new FontSizeComplexScript() { Val = "24" };
            Languages languages352 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties195.Append(runFonts360);
            paragraphMarkRunProperties195.Append(color360);
            paragraphMarkRunProperties195.Append(fontSize360);
            paragraphMarkRunProperties195.Append(fontSizeComplexScript360);
            paragraphMarkRunProperties195.Append(languages352);

            paragraphProperties195.Append(widowControl161);
            paragraphProperties195.Append(autoSpaceDE186);
            paragraphProperties195.Append(autoSpaceDN186);
            paragraphProperties195.Append(adjustRightIndent186);
            paragraphProperties195.Append(spacingBetweenLines186);
            paragraphProperties195.Append(justification169);
            paragraphProperties195.Append(paragraphMarkRunProperties195);

            paragraph195.Append(paragraphProperties195);

            tableCell81.Append(tableCellProperties81);
            tableCell81.Append(paragraph195);

            tableRow25.Append(tableRowProperties10);
            tableRow25.Append(tableCell73);
            tableRow25.Append(tableCell74);
            tableRow25.Append(tableCell75);
            tableRow25.Append(tableCell76);
            tableRow25.Append(tableCell77);
            tableRow25.Append(tableCell78);
            tableRow25.Append(tableCell79);
            tableRow25.Append(tableCell80);
            tableRow25.Append(tableCell81);

            TableRow tableRow26 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties11 = new TableRowProperties();
            TableRowHeight tableRowHeight11 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties11.Append(tableRowHeight11);

            TableCell tableCell82 = new TableCell();

            TableCellProperties tableCellProperties82 = new TableCellProperties();
            TableCellWidth tableCellWidth82 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties82.Append(tableCellWidth82);

            Paragraph paragraph196 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties196 = new ParagraphProperties();
            WidowControl widowControl162 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE187 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN187 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent187 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines187 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification170 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties196 = new ParagraphMarkRunProperties();
            RunFonts runFonts361 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color361 = new Color() { Val = "000000" };
            FontSize fontSize361 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript361 = new FontSizeComplexScript() { Val = "24" };
            Languages languages353 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties196.Append(runFonts361);
            paragraphMarkRunProperties196.Append(color361);
            paragraphMarkRunProperties196.Append(fontSize361);
            paragraphMarkRunProperties196.Append(fontSizeComplexScript361);
            paragraphMarkRunProperties196.Append(languages353);

            paragraphProperties196.Append(widowControl162);
            paragraphProperties196.Append(autoSpaceDE187);
            paragraphProperties196.Append(autoSpaceDN187);
            paragraphProperties196.Append(adjustRightIndent187);
            paragraphProperties196.Append(spacingBetweenLines187);
            paragraphProperties196.Append(justification170);
            paragraphProperties196.Append(paragraphMarkRunProperties196);

            paragraph196.Append(paragraphProperties196);

            tableCell82.Append(tableCellProperties82);
            tableCell82.Append(paragraph196);

            TableCell tableCell83 = new TableCell();

            TableCellProperties tableCellProperties83 = new TableCellProperties();
            TableCellWidth tableCellWidth83 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties83.Append(tableCellWidth83);

            Paragraph paragraph197 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties197 = new ParagraphProperties();
            WidowControl widowControl163 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE188 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN188 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent188 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines188 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification171 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties197 = new ParagraphMarkRunProperties();
            RunFonts runFonts362 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color362 = new Color() { Val = "000000" };
            FontSize fontSize362 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript362 = new FontSizeComplexScript() { Val = "24" };
            Languages languages354 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties197.Append(runFonts362);
            paragraphMarkRunProperties197.Append(color362);
            paragraphMarkRunProperties197.Append(fontSize362);
            paragraphMarkRunProperties197.Append(fontSizeComplexScript362);
            paragraphMarkRunProperties197.Append(languages354);

            paragraphProperties197.Append(widowControl163);
            paragraphProperties197.Append(autoSpaceDE188);
            paragraphProperties197.Append(autoSpaceDN188);
            paragraphProperties197.Append(adjustRightIndent188);
            paragraphProperties197.Append(spacingBetweenLines188);
            paragraphProperties197.Append(justification171);
            paragraphProperties197.Append(paragraphMarkRunProperties197);

            paragraph197.Append(paragraphProperties197);

            tableCell83.Append(tableCellProperties83);
            tableCell83.Append(paragraph197);

            TableCell tableCell84 = new TableCell();

            TableCellProperties tableCellProperties84 = new TableCellProperties();
            TableCellWidth tableCellWidth84 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties84.Append(tableCellWidth84);

            Paragraph paragraph198 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties198 = new ParagraphProperties();
            WidowControl widowControl164 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE189 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN189 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent189 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines189 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification172 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties198 = new ParagraphMarkRunProperties();
            RunFonts runFonts363 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color363 = new Color() { Val = "000000" };
            FontSize fontSize363 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript363 = new FontSizeComplexScript() { Val = "24" };
            Languages languages355 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties198.Append(runFonts363);
            paragraphMarkRunProperties198.Append(color363);
            paragraphMarkRunProperties198.Append(fontSize363);
            paragraphMarkRunProperties198.Append(fontSizeComplexScript363);
            paragraphMarkRunProperties198.Append(languages355);

            paragraphProperties198.Append(widowControl164);
            paragraphProperties198.Append(autoSpaceDE189);
            paragraphProperties198.Append(autoSpaceDN189);
            paragraphProperties198.Append(adjustRightIndent189);
            paragraphProperties198.Append(spacingBetweenLines189);
            paragraphProperties198.Append(justification172);
            paragraphProperties198.Append(paragraphMarkRunProperties198);

            paragraph198.Append(paragraphProperties198);

            tableCell84.Append(tableCellProperties84);
            tableCell84.Append(paragraph198);

            TableCell tableCell85 = new TableCell();

            TableCellProperties tableCellProperties85 = new TableCellProperties();
            TableCellWidth tableCellWidth85 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties85.Append(tableCellWidth85);

            Paragraph paragraph199 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties199 = new ParagraphProperties();
            WidowControl widowControl165 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE190 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN190 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent190 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines190 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification173 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties199 = new ParagraphMarkRunProperties();
            RunFonts runFonts364 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color364 = new Color() { Val = "000000" };
            FontSize fontSize364 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript364 = new FontSizeComplexScript() { Val = "24" };
            Languages languages356 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties199.Append(runFonts364);
            paragraphMarkRunProperties199.Append(color364);
            paragraphMarkRunProperties199.Append(fontSize364);
            paragraphMarkRunProperties199.Append(fontSizeComplexScript364);
            paragraphMarkRunProperties199.Append(languages356);

            paragraphProperties199.Append(widowControl165);
            paragraphProperties199.Append(autoSpaceDE190);
            paragraphProperties199.Append(autoSpaceDN190);
            paragraphProperties199.Append(adjustRightIndent190);
            paragraphProperties199.Append(spacingBetweenLines190);
            paragraphProperties199.Append(justification173);
            paragraphProperties199.Append(paragraphMarkRunProperties199);

            paragraph199.Append(paragraphProperties199);

            tableCell85.Append(tableCellProperties85);
            tableCell85.Append(paragraph199);

            TableCell tableCell86 = new TableCell();

            TableCellProperties tableCellProperties86 = new TableCellProperties();
            TableCellWidth tableCellWidth86 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties86.Append(tableCellWidth86);

            Paragraph paragraph200 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties200 = new ParagraphProperties();
            WidowControl widowControl166 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE191 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN191 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent191 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines191 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification174 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties200 = new ParagraphMarkRunProperties();
            RunFonts runFonts365 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color365 = new Color() { Val = "000000" };
            FontSize fontSize365 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript365 = new FontSizeComplexScript() { Val = "24" };
            Languages languages357 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties200.Append(runFonts365);
            paragraphMarkRunProperties200.Append(color365);
            paragraphMarkRunProperties200.Append(fontSize365);
            paragraphMarkRunProperties200.Append(fontSizeComplexScript365);
            paragraphMarkRunProperties200.Append(languages357);

            paragraphProperties200.Append(widowControl166);
            paragraphProperties200.Append(autoSpaceDE191);
            paragraphProperties200.Append(autoSpaceDN191);
            paragraphProperties200.Append(adjustRightIndent191);
            paragraphProperties200.Append(spacingBetweenLines191);
            paragraphProperties200.Append(justification174);
            paragraphProperties200.Append(paragraphMarkRunProperties200);

            paragraph200.Append(paragraphProperties200);

            tableCell86.Append(tableCellProperties86);
            tableCell86.Append(paragraph200);

            TableCell tableCell87 = new TableCell();

            TableCellProperties tableCellProperties87 = new TableCellProperties();
            TableCellWidth tableCellWidth87 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties87.Append(tableCellWidth87);

            Paragraph paragraph201 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties201 = new ParagraphProperties();
            WidowControl widowControl167 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE192 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN192 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent192 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines192 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification175 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties201 = new ParagraphMarkRunProperties();
            RunFonts runFonts366 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color366 = new Color() { Val = "000000" };
            FontSize fontSize366 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript366 = new FontSizeComplexScript() { Val = "24" };
            Languages languages358 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties201.Append(runFonts366);
            paragraphMarkRunProperties201.Append(color366);
            paragraphMarkRunProperties201.Append(fontSize366);
            paragraphMarkRunProperties201.Append(fontSizeComplexScript366);
            paragraphMarkRunProperties201.Append(languages358);

            paragraphProperties201.Append(widowControl167);
            paragraphProperties201.Append(autoSpaceDE192);
            paragraphProperties201.Append(autoSpaceDN192);
            paragraphProperties201.Append(adjustRightIndent192);
            paragraphProperties201.Append(spacingBetweenLines192);
            paragraphProperties201.Append(justification175);
            paragraphProperties201.Append(paragraphMarkRunProperties201);

            paragraph201.Append(paragraphProperties201);

            tableCell87.Append(tableCellProperties87);
            tableCell87.Append(paragraph201);

            TableCell tableCell88 = new TableCell();

            TableCellProperties tableCellProperties88 = new TableCellProperties();
            TableCellWidth tableCellWidth88 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties88.Append(tableCellWidth88);

            Paragraph paragraph202 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties202 = new ParagraphProperties();
            WidowControl widowControl168 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE193 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN193 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent193 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines193 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification176 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties202 = new ParagraphMarkRunProperties();
            RunFonts runFonts367 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color367 = new Color() { Val = "000000" };
            FontSize fontSize367 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript367 = new FontSizeComplexScript() { Val = "24" };
            Languages languages359 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties202.Append(runFonts367);
            paragraphMarkRunProperties202.Append(color367);
            paragraphMarkRunProperties202.Append(fontSize367);
            paragraphMarkRunProperties202.Append(fontSizeComplexScript367);
            paragraphMarkRunProperties202.Append(languages359);

            paragraphProperties202.Append(widowControl168);
            paragraphProperties202.Append(autoSpaceDE193);
            paragraphProperties202.Append(autoSpaceDN193);
            paragraphProperties202.Append(adjustRightIndent193);
            paragraphProperties202.Append(spacingBetweenLines193);
            paragraphProperties202.Append(justification176);
            paragraphProperties202.Append(paragraphMarkRunProperties202);

            paragraph202.Append(paragraphProperties202);

            tableCell88.Append(tableCellProperties88);
            tableCell88.Append(paragraph202);

            TableCell tableCell89 = new TableCell();

            TableCellProperties tableCellProperties89 = new TableCellProperties();
            TableCellWidth tableCellWidth89 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties89.Append(tableCellWidth89);

            Paragraph paragraph203 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties203 = new ParagraphProperties();
            WidowControl widowControl169 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE194 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN194 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent194 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines194 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification177 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties203 = new ParagraphMarkRunProperties();
            RunFonts runFonts368 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color368 = new Color() { Val = "000000" };
            FontSize fontSize368 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript368 = new FontSizeComplexScript() { Val = "24" };
            Languages languages360 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties203.Append(runFonts368);
            paragraphMarkRunProperties203.Append(color368);
            paragraphMarkRunProperties203.Append(fontSize368);
            paragraphMarkRunProperties203.Append(fontSizeComplexScript368);
            paragraphMarkRunProperties203.Append(languages360);

            paragraphProperties203.Append(widowControl169);
            paragraphProperties203.Append(autoSpaceDE194);
            paragraphProperties203.Append(autoSpaceDN194);
            paragraphProperties203.Append(adjustRightIndent194);
            paragraphProperties203.Append(spacingBetweenLines194);
            paragraphProperties203.Append(justification177);
            paragraphProperties203.Append(paragraphMarkRunProperties203);

            paragraph203.Append(paragraphProperties203);

            tableCell89.Append(tableCellProperties89);
            tableCell89.Append(paragraph203);

            TableCell tableCell90 = new TableCell();

            TableCellProperties tableCellProperties90 = new TableCellProperties();
            TableCellWidth tableCellWidth90 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties90.Append(tableCellWidth90);

            Paragraph paragraph204 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties204 = new ParagraphProperties();
            WidowControl widowControl170 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE195 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN195 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent195 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines195 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification178 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties204 = new ParagraphMarkRunProperties();
            RunFonts runFonts369 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color369 = new Color() { Val = "000000" };
            FontSize fontSize369 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript369 = new FontSizeComplexScript() { Val = "24" };
            Languages languages361 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties204.Append(runFonts369);
            paragraphMarkRunProperties204.Append(color369);
            paragraphMarkRunProperties204.Append(fontSize369);
            paragraphMarkRunProperties204.Append(fontSizeComplexScript369);
            paragraphMarkRunProperties204.Append(languages361);

            paragraphProperties204.Append(widowControl170);
            paragraphProperties204.Append(autoSpaceDE195);
            paragraphProperties204.Append(autoSpaceDN195);
            paragraphProperties204.Append(adjustRightIndent195);
            paragraphProperties204.Append(spacingBetweenLines195);
            paragraphProperties204.Append(justification178);
            paragraphProperties204.Append(paragraphMarkRunProperties204);

            paragraph204.Append(paragraphProperties204);

            tableCell90.Append(tableCellProperties90);
            tableCell90.Append(paragraph204);

            tableRow26.Append(tableRowProperties11);
            tableRow26.Append(tableCell82);
            tableRow26.Append(tableCell83);
            tableRow26.Append(tableCell84);
            tableRow26.Append(tableCell85);
            tableRow26.Append(tableCell86);
            tableRow26.Append(tableCell87);
            tableRow26.Append(tableCell88);
            tableRow26.Append(tableCell89);
            tableRow26.Append(tableCell90);

            TableRow tableRow27 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties12 = new TableRowProperties();
            TableRowHeight tableRowHeight12 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties12.Append(tableRowHeight12);

            TableCell tableCell91 = new TableCell();

            TableCellProperties tableCellProperties91 = new TableCellProperties();
            TableCellWidth tableCellWidth91 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties91.Append(tableCellWidth91);

            Paragraph paragraph205 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties205 = new ParagraphProperties();
            WidowControl widowControl171 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE196 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN196 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent196 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines196 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification179 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties205 = new ParagraphMarkRunProperties();
            RunFonts runFonts370 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color370 = new Color() { Val = "000000" };
            FontSize fontSize370 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript370 = new FontSizeComplexScript() { Val = "24" };
            Languages languages362 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties205.Append(runFonts370);
            paragraphMarkRunProperties205.Append(color370);
            paragraphMarkRunProperties205.Append(fontSize370);
            paragraphMarkRunProperties205.Append(fontSizeComplexScript370);
            paragraphMarkRunProperties205.Append(languages362);

            paragraphProperties205.Append(widowControl171);
            paragraphProperties205.Append(autoSpaceDE196);
            paragraphProperties205.Append(autoSpaceDN196);
            paragraphProperties205.Append(adjustRightIndent196);
            paragraphProperties205.Append(spacingBetweenLines196);
            paragraphProperties205.Append(justification179);
            paragraphProperties205.Append(paragraphMarkRunProperties205);

            paragraph205.Append(paragraphProperties205);

            tableCell91.Append(tableCellProperties91);
            tableCell91.Append(paragraph205);

            TableCell tableCell92 = new TableCell();

            TableCellProperties tableCellProperties92 = new TableCellProperties();
            TableCellWidth tableCellWidth92 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties92.Append(tableCellWidth92);

            Paragraph paragraph206 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties206 = new ParagraphProperties();
            WidowControl widowControl172 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE197 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN197 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent197 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines197 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification180 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties206 = new ParagraphMarkRunProperties();
            RunFonts runFonts371 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color371 = new Color() { Val = "000000" };
            FontSize fontSize371 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript371 = new FontSizeComplexScript() { Val = "24" };
            Languages languages363 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties206.Append(runFonts371);
            paragraphMarkRunProperties206.Append(color371);
            paragraphMarkRunProperties206.Append(fontSize371);
            paragraphMarkRunProperties206.Append(fontSizeComplexScript371);
            paragraphMarkRunProperties206.Append(languages363);

            paragraphProperties206.Append(widowControl172);
            paragraphProperties206.Append(autoSpaceDE197);
            paragraphProperties206.Append(autoSpaceDN197);
            paragraphProperties206.Append(adjustRightIndent197);
            paragraphProperties206.Append(spacingBetweenLines197);
            paragraphProperties206.Append(justification180);
            paragraphProperties206.Append(paragraphMarkRunProperties206);

            paragraph206.Append(paragraphProperties206);

            tableCell92.Append(tableCellProperties92);
            tableCell92.Append(paragraph206);

            TableCell tableCell93 = new TableCell();

            TableCellProperties tableCellProperties93 = new TableCellProperties();
            TableCellWidth tableCellWidth93 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties93.Append(tableCellWidth93);

            Paragraph paragraph207 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties207 = new ParagraphProperties();
            WidowControl widowControl173 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE198 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN198 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent198 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines198 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification181 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties207 = new ParagraphMarkRunProperties();
            RunFonts runFonts372 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color372 = new Color() { Val = "000000" };
            FontSize fontSize372 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript372 = new FontSizeComplexScript() { Val = "24" };
            Languages languages364 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties207.Append(runFonts372);
            paragraphMarkRunProperties207.Append(color372);
            paragraphMarkRunProperties207.Append(fontSize372);
            paragraphMarkRunProperties207.Append(fontSizeComplexScript372);
            paragraphMarkRunProperties207.Append(languages364);

            paragraphProperties207.Append(widowControl173);
            paragraphProperties207.Append(autoSpaceDE198);
            paragraphProperties207.Append(autoSpaceDN198);
            paragraphProperties207.Append(adjustRightIndent198);
            paragraphProperties207.Append(spacingBetweenLines198);
            paragraphProperties207.Append(justification181);
            paragraphProperties207.Append(paragraphMarkRunProperties207);

            paragraph207.Append(paragraphProperties207);

            tableCell93.Append(tableCellProperties93);
            tableCell93.Append(paragraph207);

            TableCell tableCell94 = new TableCell();

            TableCellProperties tableCellProperties94 = new TableCellProperties();
            TableCellWidth tableCellWidth94 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties94.Append(tableCellWidth94);

            Paragraph paragraph208 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties208 = new ParagraphProperties();
            WidowControl widowControl174 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE199 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN199 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent199 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines199 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification182 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties208 = new ParagraphMarkRunProperties();
            RunFonts runFonts373 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color373 = new Color() { Val = "000000" };
            FontSize fontSize373 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript373 = new FontSizeComplexScript() { Val = "24" };
            Languages languages365 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties208.Append(runFonts373);
            paragraphMarkRunProperties208.Append(color373);
            paragraphMarkRunProperties208.Append(fontSize373);
            paragraphMarkRunProperties208.Append(fontSizeComplexScript373);
            paragraphMarkRunProperties208.Append(languages365);

            paragraphProperties208.Append(widowControl174);
            paragraphProperties208.Append(autoSpaceDE199);
            paragraphProperties208.Append(autoSpaceDN199);
            paragraphProperties208.Append(adjustRightIndent199);
            paragraphProperties208.Append(spacingBetweenLines199);
            paragraphProperties208.Append(justification182);
            paragraphProperties208.Append(paragraphMarkRunProperties208);

            paragraph208.Append(paragraphProperties208);

            tableCell94.Append(tableCellProperties94);
            tableCell94.Append(paragraph208);

            TableCell tableCell95 = new TableCell();

            TableCellProperties tableCellProperties95 = new TableCellProperties();
            TableCellWidth tableCellWidth95 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties95.Append(tableCellWidth95);

            Paragraph paragraph209 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties209 = new ParagraphProperties();
            WidowControl widowControl175 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE200 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN200 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent200 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines200 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification183 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties209 = new ParagraphMarkRunProperties();
            RunFonts runFonts374 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color374 = new Color() { Val = "000000" };
            FontSize fontSize374 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript374 = new FontSizeComplexScript() { Val = "24" };
            Languages languages366 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties209.Append(runFonts374);
            paragraphMarkRunProperties209.Append(color374);
            paragraphMarkRunProperties209.Append(fontSize374);
            paragraphMarkRunProperties209.Append(fontSizeComplexScript374);
            paragraphMarkRunProperties209.Append(languages366);

            paragraphProperties209.Append(widowControl175);
            paragraphProperties209.Append(autoSpaceDE200);
            paragraphProperties209.Append(autoSpaceDN200);
            paragraphProperties209.Append(adjustRightIndent200);
            paragraphProperties209.Append(spacingBetweenLines200);
            paragraphProperties209.Append(justification183);
            paragraphProperties209.Append(paragraphMarkRunProperties209);

            paragraph209.Append(paragraphProperties209);

            tableCell95.Append(tableCellProperties95);
            tableCell95.Append(paragraph209);

            TableCell tableCell96 = new TableCell();

            TableCellProperties tableCellProperties96 = new TableCellProperties();
            TableCellWidth tableCellWidth96 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties96.Append(tableCellWidth96);

            Paragraph paragraph210 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties210 = new ParagraphProperties();
            WidowControl widowControl176 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE201 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN201 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent201 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines201 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification184 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties210 = new ParagraphMarkRunProperties();
            RunFonts runFonts375 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color375 = new Color() { Val = "000000" };
            FontSize fontSize375 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript375 = new FontSizeComplexScript() { Val = "24" };
            Languages languages367 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties210.Append(runFonts375);
            paragraphMarkRunProperties210.Append(color375);
            paragraphMarkRunProperties210.Append(fontSize375);
            paragraphMarkRunProperties210.Append(fontSizeComplexScript375);
            paragraphMarkRunProperties210.Append(languages367);

            paragraphProperties210.Append(widowControl176);
            paragraphProperties210.Append(autoSpaceDE201);
            paragraphProperties210.Append(autoSpaceDN201);
            paragraphProperties210.Append(adjustRightIndent201);
            paragraphProperties210.Append(spacingBetweenLines201);
            paragraphProperties210.Append(justification184);
            paragraphProperties210.Append(paragraphMarkRunProperties210);

            paragraph210.Append(paragraphProperties210);

            tableCell96.Append(tableCellProperties96);
            tableCell96.Append(paragraph210);

            TableCell tableCell97 = new TableCell();

            TableCellProperties tableCellProperties97 = new TableCellProperties();
            TableCellWidth tableCellWidth97 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties97.Append(tableCellWidth97);

            Paragraph paragraph211 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties211 = new ParagraphProperties();
            WidowControl widowControl177 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE202 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN202 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent202 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines202 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification185 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties211 = new ParagraphMarkRunProperties();
            RunFonts runFonts376 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color376 = new Color() { Val = "000000" };
            FontSize fontSize376 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript376 = new FontSizeComplexScript() { Val = "24" };
            Languages languages368 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties211.Append(runFonts376);
            paragraphMarkRunProperties211.Append(color376);
            paragraphMarkRunProperties211.Append(fontSize376);
            paragraphMarkRunProperties211.Append(fontSizeComplexScript376);
            paragraphMarkRunProperties211.Append(languages368);

            paragraphProperties211.Append(widowControl177);
            paragraphProperties211.Append(autoSpaceDE202);
            paragraphProperties211.Append(autoSpaceDN202);
            paragraphProperties211.Append(adjustRightIndent202);
            paragraphProperties211.Append(spacingBetweenLines202);
            paragraphProperties211.Append(justification185);
            paragraphProperties211.Append(paragraphMarkRunProperties211);

            paragraph211.Append(paragraphProperties211);

            tableCell97.Append(tableCellProperties97);
            tableCell97.Append(paragraph211);

            TableCell tableCell98 = new TableCell();

            TableCellProperties tableCellProperties98 = new TableCellProperties();
            TableCellWidth tableCellWidth98 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties98.Append(tableCellWidth98);

            Paragraph paragraph212 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties212 = new ParagraphProperties();
            WidowControl widowControl178 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE203 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN203 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent203 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines203 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification186 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties212 = new ParagraphMarkRunProperties();
            RunFonts runFonts377 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color377 = new Color() { Val = "000000" };
            FontSize fontSize377 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript377 = new FontSizeComplexScript() { Val = "24" };
            Languages languages369 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties212.Append(runFonts377);
            paragraphMarkRunProperties212.Append(color377);
            paragraphMarkRunProperties212.Append(fontSize377);
            paragraphMarkRunProperties212.Append(fontSizeComplexScript377);
            paragraphMarkRunProperties212.Append(languages369);

            paragraphProperties212.Append(widowControl178);
            paragraphProperties212.Append(autoSpaceDE203);
            paragraphProperties212.Append(autoSpaceDN203);
            paragraphProperties212.Append(adjustRightIndent203);
            paragraphProperties212.Append(spacingBetweenLines203);
            paragraphProperties212.Append(justification186);
            paragraphProperties212.Append(paragraphMarkRunProperties212);

            paragraph212.Append(paragraphProperties212);

            tableCell98.Append(tableCellProperties98);
            tableCell98.Append(paragraph212);

            TableCell tableCell99 = new TableCell();

            TableCellProperties tableCellProperties99 = new TableCellProperties();
            TableCellWidth tableCellWidth99 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties99.Append(tableCellWidth99);

            Paragraph paragraph213 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties213 = new ParagraphProperties();
            WidowControl widowControl179 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE204 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN204 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent204 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines204 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification187 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties213 = new ParagraphMarkRunProperties();
            RunFonts runFonts378 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color378 = new Color() { Val = "000000" };
            FontSize fontSize378 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript378 = new FontSizeComplexScript() { Val = "24" };
            Languages languages370 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties213.Append(runFonts378);
            paragraphMarkRunProperties213.Append(color378);
            paragraphMarkRunProperties213.Append(fontSize378);
            paragraphMarkRunProperties213.Append(fontSizeComplexScript378);
            paragraphMarkRunProperties213.Append(languages370);

            paragraphProperties213.Append(widowControl179);
            paragraphProperties213.Append(autoSpaceDE204);
            paragraphProperties213.Append(autoSpaceDN204);
            paragraphProperties213.Append(adjustRightIndent204);
            paragraphProperties213.Append(spacingBetweenLines204);
            paragraphProperties213.Append(justification187);
            paragraphProperties213.Append(paragraphMarkRunProperties213);

            paragraph213.Append(paragraphProperties213);

            tableCell99.Append(tableCellProperties99);
            tableCell99.Append(paragraph213);

            tableRow27.Append(tableRowProperties12);
            tableRow27.Append(tableCell91);
            tableRow27.Append(tableCell92);
            tableRow27.Append(tableCell93);
            tableRow27.Append(tableCell94);
            tableRow27.Append(tableCell95);
            tableRow27.Append(tableCell96);
            tableRow27.Append(tableCell97);
            tableRow27.Append(tableCell98);
            tableRow27.Append(tableCell99);

            TableRow tableRow28 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties13 = new TableRowProperties();
            TableRowHeight tableRowHeight13 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties13.Append(tableRowHeight13);

            TableCell tableCell100 = new TableCell();

            TableCellProperties tableCellProperties100 = new TableCellProperties();
            TableCellWidth tableCellWidth100 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties100.Append(tableCellWidth100);

            Paragraph paragraph214 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties214 = new ParagraphProperties();
            WidowControl widowControl180 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE205 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN205 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent205 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines205 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification188 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties214 = new ParagraphMarkRunProperties();
            RunFonts runFonts379 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color379 = new Color() { Val = "000000" };
            FontSize fontSize379 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript379 = new FontSizeComplexScript() { Val = "24" };
            Languages languages371 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties214.Append(runFonts379);
            paragraphMarkRunProperties214.Append(color379);
            paragraphMarkRunProperties214.Append(fontSize379);
            paragraphMarkRunProperties214.Append(fontSizeComplexScript379);
            paragraphMarkRunProperties214.Append(languages371);

            paragraphProperties214.Append(widowControl180);
            paragraphProperties214.Append(autoSpaceDE205);
            paragraphProperties214.Append(autoSpaceDN205);
            paragraphProperties214.Append(adjustRightIndent205);
            paragraphProperties214.Append(spacingBetweenLines205);
            paragraphProperties214.Append(justification188);
            paragraphProperties214.Append(paragraphMarkRunProperties214);

            paragraph214.Append(paragraphProperties214);

            tableCell100.Append(tableCellProperties100);
            tableCell100.Append(paragraph214);

            TableCell tableCell101 = new TableCell();

            TableCellProperties tableCellProperties101 = new TableCellProperties();
            TableCellWidth tableCellWidth101 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties101.Append(tableCellWidth101);

            Paragraph paragraph215 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties215 = new ParagraphProperties();
            WidowControl widowControl181 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE206 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN206 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent206 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines206 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification189 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties215 = new ParagraphMarkRunProperties();
            RunFonts runFonts380 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color380 = new Color() { Val = "000000" };
            FontSize fontSize380 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript380 = new FontSizeComplexScript() { Val = "24" };
            Languages languages372 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties215.Append(runFonts380);
            paragraphMarkRunProperties215.Append(color380);
            paragraphMarkRunProperties215.Append(fontSize380);
            paragraphMarkRunProperties215.Append(fontSizeComplexScript380);
            paragraphMarkRunProperties215.Append(languages372);

            paragraphProperties215.Append(widowControl181);
            paragraphProperties215.Append(autoSpaceDE206);
            paragraphProperties215.Append(autoSpaceDN206);
            paragraphProperties215.Append(adjustRightIndent206);
            paragraphProperties215.Append(spacingBetweenLines206);
            paragraphProperties215.Append(justification189);
            paragraphProperties215.Append(paragraphMarkRunProperties215);

            paragraph215.Append(paragraphProperties215);

            tableCell101.Append(tableCellProperties101);
            tableCell101.Append(paragraph215);

            TableCell tableCell102 = new TableCell();

            TableCellProperties tableCellProperties102 = new TableCellProperties();
            TableCellWidth tableCellWidth102 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties102.Append(tableCellWidth102);

            Paragraph paragraph216 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties216 = new ParagraphProperties();
            WidowControl widowControl182 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE207 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN207 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent207 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines207 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification190 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties216 = new ParagraphMarkRunProperties();
            RunFonts runFonts381 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color381 = new Color() { Val = "000000" };
            FontSize fontSize381 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript381 = new FontSizeComplexScript() { Val = "24" };
            Languages languages373 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties216.Append(runFonts381);
            paragraphMarkRunProperties216.Append(color381);
            paragraphMarkRunProperties216.Append(fontSize381);
            paragraphMarkRunProperties216.Append(fontSizeComplexScript381);
            paragraphMarkRunProperties216.Append(languages373);

            paragraphProperties216.Append(widowControl182);
            paragraphProperties216.Append(autoSpaceDE207);
            paragraphProperties216.Append(autoSpaceDN207);
            paragraphProperties216.Append(adjustRightIndent207);
            paragraphProperties216.Append(spacingBetweenLines207);
            paragraphProperties216.Append(justification190);
            paragraphProperties216.Append(paragraphMarkRunProperties216);

            paragraph216.Append(paragraphProperties216);

            tableCell102.Append(tableCellProperties102);
            tableCell102.Append(paragraph216);

            TableCell tableCell103 = new TableCell();

            TableCellProperties tableCellProperties103 = new TableCellProperties();
            TableCellWidth tableCellWidth103 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties103.Append(tableCellWidth103);

            Paragraph paragraph217 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties217 = new ParagraphProperties();
            WidowControl widowControl183 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE208 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN208 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent208 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines208 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification191 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties217 = new ParagraphMarkRunProperties();
            RunFonts runFonts382 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color382 = new Color() { Val = "000000" };
            FontSize fontSize382 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript382 = new FontSizeComplexScript() { Val = "24" };
            Languages languages374 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties217.Append(runFonts382);
            paragraphMarkRunProperties217.Append(color382);
            paragraphMarkRunProperties217.Append(fontSize382);
            paragraphMarkRunProperties217.Append(fontSizeComplexScript382);
            paragraphMarkRunProperties217.Append(languages374);

            paragraphProperties217.Append(widowControl183);
            paragraphProperties217.Append(autoSpaceDE208);
            paragraphProperties217.Append(autoSpaceDN208);
            paragraphProperties217.Append(adjustRightIndent208);
            paragraphProperties217.Append(spacingBetweenLines208);
            paragraphProperties217.Append(justification191);
            paragraphProperties217.Append(paragraphMarkRunProperties217);

            paragraph217.Append(paragraphProperties217);

            tableCell103.Append(tableCellProperties103);
            tableCell103.Append(paragraph217);

            TableCell tableCell104 = new TableCell();

            TableCellProperties tableCellProperties104 = new TableCellProperties();
            TableCellWidth tableCellWidth104 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties104.Append(tableCellWidth104);

            Paragraph paragraph218 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties218 = new ParagraphProperties();
            WidowControl widowControl184 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE209 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN209 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent209 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines209 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification192 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties218 = new ParagraphMarkRunProperties();
            RunFonts runFonts383 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color383 = new Color() { Val = "000000" };
            FontSize fontSize383 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript383 = new FontSizeComplexScript() { Val = "24" };
            Languages languages375 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties218.Append(runFonts383);
            paragraphMarkRunProperties218.Append(color383);
            paragraphMarkRunProperties218.Append(fontSize383);
            paragraphMarkRunProperties218.Append(fontSizeComplexScript383);
            paragraphMarkRunProperties218.Append(languages375);

            paragraphProperties218.Append(widowControl184);
            paragraphProperties218.Append(autoSpaceDE209);
            paragraphProperties218.Append(autoSpaceDN209);
            paragraphProperties218.Append(adjustRightIndent209);
            paragraphProperties218.Append(spacingBetweenLines209);
            paragraphProperties218.Append(justification192);
            paragraphProperties218.Append(paragraphMarkRunProperties218);

            paragraph218.Append(paragraphProperties218);

            tableCell104.Append(tableCellProperties104);
            tableCell104.Append(paragraph218);

            TableCell tableCell105 = new TableCell();

            TableCellProperties tableCellProperties105 = new TableCellProperties();
            TableCellWidth tableCellWidth105 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties105.Append(tableCellWidth105);

            Paragraph paragraph219 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties219 = new ParagraphProperties();
            WidowControl widowControl185 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE210 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN210 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent210 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines210 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification193 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties219 = new ParagraphMarkRunProperties();
            RunFonts runFonts384 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color384 = new Color() { Val = "000000" };
            FontSize fontSize384 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript384 = new FontSizeComplexScript() { Val = "24" };
            Languages languages376 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties219.Append(runFonts384);
            paragraphMarkRunProperties219.Append(color384);
            paragraphMarkRunProperties219.Append(fontSize384);
            paragraphMarkRunProperties219.Append(fontSizeComplexScript384);
            paragraphMarkRunProperties219.Append(languages376);

            paragraphProperties219.Append(widowControl185);
            paragraphProperties219.Append(autoSpaceDE210);
            paragraphProperties219.Append(autoSpaceDN210);
            paragraphProperties219.Append(adjustRightIndent210);
            paragraphProperties219.Append(spacingBetweenLines210);
            paragraphProperties219.Append(justification193);
            paragraphProperties219.Append(paragraphMarkRunProperties219);

            paragraph219.Append(paragraphProperties219);

            tableCell105.Append(tableCellProperties105);
            tableCell105.Append(paragraph219);

            TableCell tableCell106 = new TableCell();

            TableCellProperties tableCellProperties106 = new TableCellProperties();
            TableCellWidth tableCellWidth106 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties106.Append(tableCellWidth106);

            Paragraph paragraph220 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties220 = new ParagraphProperties();
            WidowControl widowControl186 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE211 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN211 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent211 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines211 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification194 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties220 = new ParagraphMarkRunProperties();
            RunFonts runFonts385 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color385 = new Color() { Val = "000000" };
            FontSize fontSize385 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript385 = new FontSizeComplexScript() { Val = "24" };
            Languages languages377 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties220.Append(runFonts385);
            paragraphMarkRunProperties220.Append(color385);
            paragraphMarkRunProperties220.Append(fontSize385);
            paragraphMarkRunProperties220.Append(fontSizeComplexScript385);
            paragraphMarkRunProperties220.Append(languages377);

            paragraphProperties220.Append(widowControl186);
            paragraphProperties220.Append(autoSpaceDE211);
            paragraphProperties220.Append(autoSpaceDN211);
            paragraphProperties220.Append(adjustRightIndent211);
            paragraphProperties220.Append(spacingBetweenLines211);
            paragraphProperties220.Append(justification194);
            paragraphProperties220.Append(paragraphMarkRunProperties220);

            paragraph220.Append(paragraphProperties220);

            tableCell106.Append(tableCellProperties106);
            tableCell106.Append(paragraph220);

            TableCell tableCell107 = new TableCell();

            TableCellProperties tableCellProperties107 = new TableCellProperties();
            TableCellWidth tableCellWidth107 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties107.Append(tableCellWidth107);

            Paragraph paragraph221 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties221 = new ParagraphProperties();
            WidowControl widowControl187 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE212 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN212 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent212 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines212 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification195 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties221 = new ParagraphMarkRunProperties();
            RunFonts runFonts386 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color386 = new Color() { Val = "000000" };
            FontSize fontSize386 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript386 = new FontSizeComplexScript() { Val = "24" };
            Languages languages378 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties221.Append(runFonts386);
            paragraphMarkRunProperties221.Append(color386);
            paragraphMarkRunProperties221.Append(fontSize386);
            paragraphMarkRunProperties221.Append(fontSizeComplexScript386);
            paragraphMarkRunProperties221.Append(languages378);

            paragraphProperties221.Append(widowControl187);
            paragraphProperties221.Append(autoSpaceDE212);
            paragraphProperties221.Append(autoSpaceDN212);
            paragraphProperties221.Append(adjustRightIndent212);
            paragraphProperties221.Append(spacingBetweenLines212);
            paragraphProperties221.Append(justification195);
            paragraphProperties221.Append(paragraphMarkRunProperties221);

            paragraph221.Append(paragraphProperties221);

            tableCell107.Append(tableCellProperties107);
            tableCell107.Append(paragraph221);

            TableCell tableCell108 = new TableCell();

            TableCellProperties tableCellProperties108 = new TableCellProperties();
            TableCellWidth tableCellWidth108 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties108.Append(tableCellWidth108);

            Paragraph paragraph222 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties222 = new ParagraphProperties();
            WidowControl widowControl188 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE213 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN213 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent213 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines213 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification196 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties222 = new ParagraphMarkRunProperties();
            RunFonts runFonts387 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color387 = new Color() { Val = "000000" };
            FontSize fontSize387 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript387 = new FontSizeComplexScript() { Val = "24" };
            Languages languages379 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties222.Append(runFonts387);
            paragraphMarkRunProperties222.Append(color387);
            paragraphMarkRunProperties222.Append(fontSize387);
            paragraphMarkRunProperties222.Append(fontSizeComplexScript387);
            paragraphMarkRunProperties222.Append(languages379);

            paragraphProperties222.Append(widowControl188);
            paragraphProperties222.Append(autoSpaceDE213);
            paragraphProperties222.Append(autoSpaceDN213);
            paragraphProperties222.Append(adjustRightIndent213);
            paragraphProperties222.Append(spacingBetweenLines213);
            paragraphProperties222.Append(justification196);
            paragraphProperties222.Append(paragraphMarkRunProperties222);

            paragraph222.Append(paragraphProperties222);

            tableCell108.Append(tableCellProperties108);
            tableCell108.Append(paragraph222);

            tableRow28.Append(tableRowProperties13);
            tableRow28.Append(tableCell100);
            tableRow28.Append(tableCell101);
            tableRow28.Append(tableCell102);
            tableRow28.Append(tableCell103);
            tableRow28.Append(tableCell104);
            tableRow28.Append(tableCell105);
            tableRow28.Append(tableCell106);
            tableRow28.Append(tableCell107);
            tableRow28.Append(tableCell108);

            TableRow tableRow29 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties14 = new TableRowProperties();
            TableRowHeight tableRowHeight14 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties14.Append(tableRowHeight14);

            TableCell tableCell109 = new TableCell();

            TableCellProperties tableCellProperties109 = new TableCellProperties();
            TableCellWidth tableCellWidth109 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties109.Append(tableCellWidth109);

            Paragraph paragraph223 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties223 = new ParagraphProperties();
            WidowControl widowControl189 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE214 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN214 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent214 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines214 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification197 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties223 = new ParagraphMarkRunProperties();
            RunFonts runFonts388 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color388 = new Color() { Val = "000000" };
            FontSize fontSize388 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript388 = new FontSizeComplexScript() { Val = "24" };
            Languages languages380 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties223.Append(runFonts388);
            paragraphMarkRunProperties223.Append(color388);
            paragraphMarkRunProperties223.Append(fontSize388);
            paragraphMarkRunProperties223.Append(fontSizeComplexScript388);
            paragraphMarkRunProperties223.Append(languages380);

            paragraphProperties223.Append(widowControl189);
            paragraphProperties223.Append(autoSpaceDE214);
            paragraphProperties223.Append(autoSpaceDN214);
            paragraphProperties223.Append(adjustRightIndent214);
            paragraphProperties223.Append(spacingBetweenLines214);
            paragraphProperties223.Append(justification197);
            paragraphProperties223.Append(paragraphMarkRunProperties223);

            paragraph223.Append(paragraphProperties223);

            tableCell109.Append(tableCellProperties109);
            tableCell109.Append(paragraph223);

            TableCell tableCell110 = new TableCell();

            TableCellProperties tableCellProperties110 = new TableCellProperties();
            TableCellWidth tableCellWidth110 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties110.Append(tableCellWidth110);

            Paragraph paragraph224 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties224 = new ParagraphProperties();
            WidowControl widowControl190 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE215 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN215 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent215 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines215 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification198 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties224 = new ParagraphMarkRunProperties();
            RunFonts runFonts389 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color389 = new Color() { Val = "000000" };
            FontSize fontSize389 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript389 = new FontSizeComplexScript() { Val = "24" };
            Languages languages381 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties224.Append(runFonts389);
            paragraphMarkRunProperties224.Append(color389);
            paragraphMarkRunProperties224.Append(fontSize389);
            paragraphMarkRunProperties224.Append(fontSizeComplexScript389);
            paragraphMarkRunProperties224.Append(languages381);

            paragraphProperties224.Append(widowControl190);
            paragraphProperties224.Append(autoSpaceDE215);
            paragraphProperties224.Append(autoSpaceDN215);
            paragraphProperties224.Append(adjustRightIndent215);
            paragraphProperties224.Append(spacingBetweenLines215);
            paragraphProperties224.Append(justification198);
            paragraphProperties224.Append(paragraphMarkRunProperties224);

            paragraph224.Append(paragraphProperties224);

            tableCell110.Append(tableCellProperties110);
            tableCell110.Append(paragraph224);

            TableCell tableCell111 = new TableCell();

            TableCellProperties tableCellProperties111 = new TableCellProperties();
            TableCellWidth tableCellWidth111 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties111.Append(tableCellWidth111);

            Paragraph paragraph225 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties225 = new ParagraphProperties();
            WidowControl widowControl191 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE216 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN216 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent216 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines216 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification199 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties225 = new ParagraphMarkRunProperties();
            RunFonts runFonts390 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color390 = new Color() { Val = "000000" };
            FontSize fontSize390 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript390 = new FontSizeComplexScript() { Val = "24" };
            Languages languages382 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties225.Append(runFonts390);
            paragraphMarkRunProperties225.Append(color390);
            paragraphMarkRunProperties225.Append(fontSize390);
            paragraphMarkRunProperties225.Append(fontSizeComplexScript390);
            paragraphMarkRunProperties225.Append(languages382);

            paragraphProperties225.Append(widowControl191);
            paragraphProperties225.Append(autoSpaceDE216);
            paragraphProperties225.Append(autoSpaceDN216);
            paragraphProperties225.Append(adjustRightIndent216);
            paragraphProperties225.Append(spacingBetweenLines216);
            paragraphProperties225.Append(justification199);
            paragraphProperties225.Append(paragraphMarkRunProperties225);

            paragraph225.Append(paragraphProperties225);

            tableCell111.Append(tableCellProperties111);
            tableCell111.Append(paragraph225);

            TableCell tableCell112 = new TableCell();

            TableCellProperties tableCellProperties112 = new TableCellProperties();
            TableCellWidth tableCellWidth112 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties112.Append(tableCellWidth112);

            Paragraph paragraph226 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties226 = new ParagraphProperties();
            WidowControl widowControl192 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE217 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN217 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent217 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines217 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification200 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties226 = new ParagraphMarkRunProperties();
            RunFonts runFonts391 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color391 = new Color() { Val = "000000" };
            FontSize fontSize391 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript391 = new FontSizeComplexScript() { Val = "24" };
            Languages languages383 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties226.Append(runFonts391);
            paragraphMarkRunProperties226.Append(color391);
            paragraphMarkRunProperties226.Append(fontSize391);
            paragraphMarkRunProperties226.Append(fontSizeComplexScript391);
            paragraphMarkRunProperties226.Append(languages383);

            paragraphProperties226.Append(widowControl192);
            paragraphProperties226.Append(autoSpaceDE217);
            paragraphProperties226.Append(autoSpaceDN217);
            paragraphProperties226.Append(adjustRightIndent217);
            paragraphProperties226.Append(spacingBetweenLines217);
            paragraphProperties226.Append(justification200);
            paragraphProperties226.Append(paragraphMarkRunProperties226);

            paragraph226.Append(paragraphProperties226);

            tableCell112.Append(tableCellProperties112);
            tableCell112.Append(paragraph226);

            TableCell tableCell113 = new TableCell();

            TableCellProperties tableCellProperties113 = new TableCellProperties();
            TableCellWidth tableCellWidth113 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties113.Append(tableCellWidth113);

            Paragraph paragraph227 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties227 = new ParagraphProperties();
            WidowControl widowControl193 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE218 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN218 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent218 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines218 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification201 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties227 = new ParagraphMarkRunProperties();
            RunFonts runFonts392 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color392 = new Color() { Val = "000000" };
            FontSize fontSize392 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript392 = new FontSizeComplexScript() { Val = "24" };
            Languages languages384 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties227.Append(runFonts392);
            paragraphMarkRunProperties227.Append(color392);
            paragraphMarkRunProperties227.Append(fontSize392);
            paragraphMarkRunProperties227.Append(fontSizeComplexScript392);
            paragraphMarkRunProperties227.Append(languages384);

            paragraphProperties227.Append(widowControl193);
            paragraphProperties227.Append(autoSpaceDE218);
            paragraphProperties227.Append(autoSpaceDN218);
            paragraphProperties227.Append(adjustRightIndent218);
            paragraphProperties227.Append(spacingBetweenLines218);
            paragraphProperties227.Append(justification201);
            paragraphProperties227.Append(paragraphMarkRunProperties227);

            paragraph227.Append(paragraphProperties227);

            tableCell113.Append(tableCellProperties113);
            tableCell113.Append(paragraph227);

            TableCell tableCell114 = new TableCell();

            TableCellProperties tableCellProperties114 = new TableCellProperties();
            TableCellWidth tableCellWidth114 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties114.Append(tableCellWidth114);

            Paragraph paragraph228 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties228 = new ParagraphProperties();
            WidowControl widowControl194 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE219 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN219 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent219 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines219 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification202 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties228 = new ParagraphMarkRunProperties();
            RunFonts runFonts393 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color393 = new Color() { Val = "000000" };
            FontSize fontSize393 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript393 = new FontSizeComplexScript() { Val = "24" };
            Languages languages385 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties228.Append(runFonts393);
            paragraphMarkRunProperties228.Append(color393);
            paragraphMarkRunProperties228.Append(fontSize393);
            paragraphMarkRunProperties228.Append(fontSizeComplexScript393);
            paragraphMarkRunProperties228.Append(languages385);

            paragraphProperties228.Append(widowControl194);
            paragraphProperties228.Append(autoSpaceDE219);
            paragraphProperties228.Append(autoSpaceDN219);
            paragraphProperties228.Append(adjustRightIndent219);
            paragraphProperties228.Append(spacingBetweenLines219);
            paragraphProperties228.Append(justification202);
            paragraphProperties228.Append(paragraphMarkRunProperties228);

            paragraph228.Append(paragraphProperties228);

            tableCell114.Append(tableCellProperties114);
            tableCell114.Append(paragraph228);

            TableCell tableCell115 = new TableCell();

            TableCellProperties tableCellProperties115 = new TableCellProperties();
            TableCellWidth tableCellWidth115 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties115.Append(tableCellWidth115);

            Paragraph paragraph229 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties229 = new ParagraphProperties();
            WidowControl widowControl195 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE220 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN220 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent220 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines220 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification203 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties229 = new ParagraphMarkRunProperties();
            RunFonts runFonts394 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color394 = new Color() { Val = "000000" };
            FontSize fontSize394 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript394 = new FontSizeComplexScript() { Val = "24" };
            Languages languages386 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties229.Append(runFonts394);
            paragraphMarkRunProperties229.Append(color394);
            paragraphMarkRunProperties229.Append(fontSize394);
            paragraphMarkRunProperties229.Append(fontSizeComplexScript394);
            paragraphMarkRunProperties229.Append(languages386);

            paragraphProperties229.Append(widowControl195);
            paragraphProperties229.Append(autoSpaceDE220);
            paragraphProperties229.Append(autoSpaceDN220);
            paragraphProperties229.Append(adjustRightIndent220);
            paragraphProperties229.Append(spacingBetweenLines220);
            paragraphProperties229.Append(justification203);
            paragraphProperties229.Append(paragraphMarkRunProperties229);

            paragraph229.Append(paragraphProperties229);

            tableCell115.Append(tableCellProperties115);
            tableCell115.Append(paragraph229);

            TableCell tableCell116 = new TableCell();

            TableCellProperties tableCellProperties116 = new TableCellProperties();
            TableCellWidth tableCellWidth116 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties116.Append(tableCellWidth116);

            Paragraph paragraph230 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties230 = new ParagraphProperties();
            WidowControl widowControl196 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE221 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN221 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent221 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines221 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification204 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties230 = new ParagraphMarkRunProperties();
            RunFonts runFonts395 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color395 = new Color() { Val = "000000" };
            FontSize fontSize395 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript395 = new FontSizeComplexScript() { Val = "24" };
            Languages languages387 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties230.Append(runFonts395);
            paragraphMarkRunProperties230.Append(color395);
            paragraphMarkRunProperties230.Append(fontSize395);
            paragraphMarkRunProperties230.Append(fontSizeComplexScript395);
            paragraphMarkRunProperties230.Append(languages387);

            paragraphProperties230.Append(widowControl196);
            paragraphProperties230.Append(autoSpaceDE221);
            paragraphProperties230.Append(autoSpaceDN221);
            paragraphProperties230.Append(adjustRightIndent221);
            paragraphProperties230.Append(spacingBetweenLines221);
            paragraphProperties230.Append(justification204);
            paragraphProperties230.Append(paragraphMarkRunProperties230);

            paragraph230.Append(paragraphProperties230);

            tableCell116.Append(tableCellProperties116);
            tableCell116.Append(paragraph230);

            TableCell tableCell117 = new TableCell();

            TableCellProperties tableCellProperties117 = new TableCellProperties();
            TableCellWidth tableCellWidth117 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties117.Append(tableCellWidth117);

            Paragraph paragraph231 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties231 = new ParagraphProperties();
            WidowControl widowControl197 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE222 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN222 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent222 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines222 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification205 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties231 = new ParagraphMarkRunProperties();
            RunFonts runFonts396 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color396 = new Color() { Val = "000000" };
            FontSize fontSize396 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript396 = new FontSizeComplexScript() { Val = "24" };
            Languages languages388 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties231.Append(runFonts396);
            paragraphMarkRunProperties231.Append(color396);
            paragraphMarkRunProperties231.Append(fontSize396);
            paragraphMarkRunProperties231.Append(fontSizeComplexScript396);
            paragraphMarkRunProperties231.Append(languages388);

            paragraphProperties231.Append(widowControl197);
            paragraphProperties231.Append(autoSpaceDE222);
            paragraphProperties231.Append(autoSpaceDN222);
            paragraphProperties231.Append(adjustRightIndent222);
            paragraphProperties231.Append(spacingBetweenLines222);
            paragraphProperties231.Append(justification205);
            paragraphProperties231.Append(paragraphMarkRunProperties231);

            paragraph231.Append(paragraphProperties231);

            tableCell117.Append(tableCellProperties117);
            tableCell117.Append(paragraph231);

            tableRow29.Append(tableRowProperties14);
            tableRow29.Append(tableCell109);
            tableRow29.Append(tableCell110);
            tableRow29.Append(tableCell111);
            tableRow29.Append(tableCell112);
            tableRow29.Append(tableCell113);
            tableRow29.Append(tableCell114);
            tableRow29.Append(tableCell115);
            tableRow29.Append(tableCell116);
            tableRow29.Append(tableCell117);

            TableRow tableRow30 = new TableRow() { RsidTableRowAddition = "006852F2", RsidTableRowProperties = "004525A9" };

            TableRowProperties tableRowProperties15 = new TableRowProperties();
            TableRowHeight tableRowHeight15 = new TableRowHeight() { Val = (UInt32Value)273U };

            tableRowProperties15.Append(tableRowHeight15);

            TableCell tableCell118 = new TableCell();

            TableCellProperties tableCellProperties118 = new TableCellProperties();
            TableCellWidth tableCellWidth118 = new TableCellWidth() { Width = "979", Type = TableWidthUnitValues.Dxa };

            tableCellProperties118.Append(tableCellWidth118);

            Paragraph paragraph232 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties232 = new ParagraphProperties();
            WidowControl widowControl198 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE223 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN223 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent223 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines223 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification206 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties232 = new ParagraphMarkRunProperties();
            RunFonts runFonts397 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color397 = new Color() { Val = "000000" };
            FontSize fontSize397 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript397 = new FontSizeComplexScript() { Val = "24" };
            Languages languages389 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties232.Append(runFonts397);
            paragraphMarkRunProperties232.Append(color397);
            paragraphMarkRunProperties232.Append(fontSize397);
            paragraphMarkRunProperties232.Append(fontSizeComplexScript397);
            paragraphMarkRunProperties232.Append(languages389);

            paragraphProperties232.Append(widowControl198);
            paragraphProperties232.Append(autoSpaceDE223);
            paragraphProperties232.Append(autoSpaceDN223);
            paragraphProperties232.Append(adjustRightIndent223);
            paragraphProperties232.Append(spacingBetweenLines223);
            paragraphProperties232.Append(justification206);
            paragraphProperties232.Append(paragraphMarkRunProperties232);

            paragraph232.Append(paragraphProperties232);

            tableCell118.Append(tableCellProperties118);
            tableCell118.Append(paragraph232);

            TableCell tableCell119 = new TableCell();

            TableCellProperties tableCellProperties119 = new TableCellProperties();
            TableCellWidth tableCellWidth119 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties119.Append(tableCellWidth119);

            Paragraph paragraph233 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties233 = new ParagraphProperties();
            WidowControl widowControl199 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE224 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN224 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent224 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines224 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification207 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties233 = new ParagraphMarkRunProperties();
            RunFonts runFonts398 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color398 = new Color() { Val = "000000" };
            FontSize fontSize398 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript398 = new FontSizeComplexScript() { Val = "24" };
            Languages languages390 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties233.Append(runFonts398);
            paragraphMarkRunProperties233.Append(color398);
            paragraphMarkRunProperties233.Append(fontSize398);
            paragraphMarkRunProperties233.Append(fontSizeComplexScript398);
            paragraphMarkRunProperties233.Append(languages390);

            paragraphProperties233.Append(widowControl199);
            paragraphProperties233.Append(autoSpaceDE224);
            paragraphProperties233.Append(autoSpaceDN224);
            paragraphProperties233.Append(adjustRightIndent224);
            paragraphProperties233.Append(spacingBetweenLines224);
            paragraphProperties233.Append(justification207);
            paragraphProperties233.Append(paragraphMarkRunProperties233);

            paragraph233.Append(paragraphProperties233);

            tableCell119.Append(tableCellProperties119);
            tableCell119.Append(paragraph233);

            TableCell tableCell120 = new TableCell();

            TableCellProperties tableCellProperties120 = new TableCellProperties();
            TableCellWidth tableCellWidth120 = new TableCellWidth() { Width = "851", Type = TableWidthUnitValues.Dxa };

            tableCellProperties120.Append(tableCellWidth120);

            Paragraph paragraph234 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties234 = new ParagraphProperties();
            WidowControl widowControl200 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE225 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN225 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent225 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines225 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification208 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties234 = new ParagraphMarkRunProperties();
            RunFonts runFonts399 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color399 = new Color() { Val = "000000" };
            FontSize fontSize399 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript399 = new FontSizeComplexScript() { Val = "24" };
            Languages languages391 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties234.Append(runFonts399);
            paragraphMarkRunProperties234.Append(color399);
            paragraphMarkRunProperties234.Append(fontSize399);
            paragraphMarkRunProperties234.Append(fontSizeComplexScript399);
            paragraphMarkRunProperties234.Append(languages391);

            paragraphProperties234.Append(widowControl200);
            paragraphProperties234.Append(autoSpaceDE225);
            paragraphProperties234.Append(autoSpaceDN225);
            paragraphProperties234.Append(adjustRightIndent225);
            paragraphProperties234.Append(spacingBetweenLines225);
            paragraphProperties234.Append(justification208);
            paragraphProperties234.Append(paragraphMarkRunProperties234);

            paragraph234.Append(paragraphProperties234);

            tableCell120.Append(tableCellProperties120);
            tableCell120.Append(paragraph234);

            TableCell tableCell121 = new TableCell();

            TableCellProperties tableCellProperties121 = new TableCellProperties();
            TableCellWidth tableCellWidth121 = new TableCellWidth() { Width = "850", Type = TableWidthUnitValues.Dxa };

            tableCellProperties121.Append(tableCellWidth121);

            Paragraph paragraph235 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties235 = new ParagraphProperties();
            WidowControl widowControl201 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE226 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN226 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent226 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines226 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification209 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties235 = new ParagraphMarkRunProperties();
            RunFonts runFonts400 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color400 = new Color() { Val = "000000" };
            FontSize fontSize400 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript400 = new FontSizeComplexScript() { Val = "24" };
            Languages languages392 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties235.Append(runFonts400);
            paragraphMarkRunProperties235.Append(color400);
            paragraphMarkRunProperties235.Append(fontSize400);
            paragraphMarkRunProperties235.Append(fontSizeComplexScript400);
            paragraphMarkRunProperties235.Append(languages392);

            paragraphProperties235.Append(widowControl201);
            paragraphProperties235.Append(autoSpaceDE226);
            paragraphProperties235.Append(autoSpaceDN226);
            paragraphProperties235.Append(adjustRightIndent226);
            paragraphProperties235.Append(spacingBetweenLines226);
            paragraphProperties235.Append(justification209);
            paragraphProperties235.Append(paragraphMarkRunProperties235);

            paragraph235.Append(paragraphProperties235);

            tableCell121.Append(tableCellProperties121);
            tableCell121.Append(paragraph235);

            TableCell tableCell122 = new TableCell();

            TableCellProperties tableCellProperties122 = new TableCellProperties();
            TableCellWidth tableCellWidth122 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties122.Append(tableCellWidth122);

            Paragraph paragraph236 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties236 = new ParagraphProperties();
            WidowControl widowControl202 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE227 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN227 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent227 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines227 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification210 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties236 = new ParagraphMarkRunProperties();
            RunFonts runFonts401 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color401 = new Color() { Val = "000000" };
            FontSize fontSize401 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript401 = new FontSizeComplexScript() { Val = "24" };
            Languages languages393 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties236.Append(runFonts401);
            paragraphMarkRunProperties236.Append(color401);
            paragraphMarkRunProperties236.Append(fontSize401);
            paragraphMarkRunProperties236.Append(fontSizeComplexScript401);
            paragraphMarkRunProperties236.Append(languages393);

            paragraphProperties236.Append(widowControl202);
            paragraphProperties236.Append(autoSpaceDE227);
            paragraphProperties236.Append(autoSpaceDN227);
            paragraphProperties236.Append(adjustRightIndent227);
            paragraphProperties236.Append(spacingBetweenLines227);
            paragraphProperties236.Append(justification210);
            paragraphProperties236.Append(paragraphMarkRunProperties236);

            paragraph236.Append(paragraphProperties236);

            tableCell122.Append(tableCellProperties122);
            tableCell122.Append(paragraph236);

            TableCell tableCell123 = new TableCell();

            TableCellProperties tableCellProperties123 = new TableCellProperties();
            TableCellWidth tableCellWidth123 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties123.Append(tableCellWidth123);

            Paragraph paragraph237 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties237 = new ParagraphProperties();
            WidowControl widowControl203 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE228 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN228 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent228 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines228 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification211 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties237 = new ParagraphMarkRunProperties();
            RunFonts runFonts402 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color402 = new Color() { Val = "000000" };
            FontSize fontSize402 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript402 = new FontSizeComplexScript() { Val = "24" };
            Languages languages394 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties237.Append(runFonts402);
            paragraphMarkRunProperties237.Append(color402);
            paragraphMarkRunProperties237.Append(fontSize402);
            paragraphMarkRunProperties237.Append(fontSizeComplexScript402);
            paragraphMarkRunProperties237.Append(languages394);

            paragraphProperties237.Append(widowControl203);
            paragraphProperties237.Append(autoSpaceDE228);
            paragraphProperties237.Append(autoSpaceDN228);
            paragraphProperties237.Append(adjustRightIndent228);
            paragraphProperties237.Append(spacingBetweenLines228);
            paragraphProperties237.Append(justification211);
            paragraphProperties237.Append(paragraphMarkRunProperties237);

            paragraph237.Append(paragraphProperties237);

            tableCell123.Append(tableCellProperties123);
            tableCell123.Append(paragraph237);

            TableCell tableCell124 = new TableCell();

            TableCellProperties tableCellProperties124 = new TableCellProperties();
            TableCellWidth tableCellWidth124 = new TableCellWidth() { Width = "1985", Type = TableWidthUnitValues.Dxa };

            tableCellProperties124.Append(tableCellWidth124);

            Paragraph paragraph238 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties238 = new ParagraphProperties();
            WidowControl widowControl204 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE229 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN229 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent229 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines229 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification212 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties238 = new ParagraphMarkRunProperties();
            RunFonts runFonts403 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color403 = new Color() { Val = "000000" };
            FontSize fontSize403 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript403 = new FontSizeComplexScript() { Val = "24" };
            Languages languages395 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties238.Append(runFonts403);
            paragraphMarkRunProperties238.Append(color403);
            paragraphMarkRunProperties238.Append(fontSize403);
            paragraphMarkRunProperties238.Append(fontSizeComplexScript403);
            paragraphMarkRunProperties238.Append(languages395);

            paragraphProperties238.Append(widowControl204);
            paragraphProperties238.Append(autoSpaceDE229);
            paragraphProperties238.Append(autoSpaceDN229);
            paragraphProperties238.Append(adjustRightIndent229);
            paragraphProperties238.Append(spacingBetweenLines229);
            paragraphProperties238.Append(justification212);
            paragraphProperties238.Append(paragraphMarkRunProperties238);

            paragraph238.Append(paragraphProperties238);

            tableCell124.Append(tableCellProperties124);
            tableCell124.Append(paragraph238);

            TableCell tableCell125 = new TableCell();

            TableCellProperties tableCellProperties125 = new TableCellProperties();
            TableCellWidth tableCellWidth125 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties125.Append(tableCellWidth125);

            Paragraph paragraph239 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties239 = new ParagraphProperties();
            WidowControl widowControl205 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE230 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN230 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent230 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines230 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification213 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties239 = new ParagraphMarkRunProperties();
            RunFonts runFonts404 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color404 = new Color() { Val = "000000" };
            FontSize fontSize404 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript404 = new FontSizeComplexScript() { Val = "24" };
            Languages languages396 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties239.Append(runFonts404);
            paragraphMarkRunProperties239.Append(color404);
            paragraphMarkRunProperties239.Append(fontSize404);
            paragraphMarkRunProperties239.Append(fontSizeComplexScript404);
            paragraphMarkRunProperties239.Append(languages396);

            paragraphProperties239.Append(widowControl205);
            paragraphProperties239.Append(autoSpaceDE230);
            paragraphProperties239.Append(autoSpaceDN230);
            paragraphProperties239.Append(adjustRightIndent230);
            paragraphProperties239.Append(spacingBetweenLines230);
            paragraphProperties239.Append(justification213);
            paragraphProperties239.Append(paragraphMarkRunProperties239);

            paragraph239.Append(paragraphProperties239);

            tableCell125.Append(tableCellProperties125);
            tableCell125.Append(paragraph239);

            TableCell tableCell126 = new TableCell();

            TableCellProperties tableCellProperties126 = new TableCellProperties();
            TableCellWidth tableCellWidth126 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            tableCellProperties126.Append(tableCellWidth126);

            Paragraph paragraph240 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            ParagraphProperties paragraphProperties240 = new ParagraphProperties();
            WidowControl widowControl206 = new WidowControl() { Val = false };
            AutoSpaceDE autoSpaceDE231 = new AutoSpaceDE() { Val = false };
            AutoSpaceDN autoSpaceDN231 = new AutoSpaceDN() { Val = false };
            AdjustRightIndent adjustRightIndent231 = new AdjustRightIndent() { Val = false };
            SpacingBetweenLines spacingBetweenLines231 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            Justification justification214 = new Justification() { Val = JustificationValues.Both };

            ParagraphMarkRunProperties paragraphMarkRunProperties240 = new ParagraphMarkRunProperties();
            RunFonts runFonts405 = new RunFonts() { Ascii = "Georgia", HighAnsi = "Georgia", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Color color405 = new Color() { Val = "000000" };
            FontSize fontSize405 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript405 = new FontSizeComplexScript() { Val = "24" };
            Languages languages397 = new Languages() { Val = "ru" };

            paragraphMarkRunProperties240.Append(runFonts405);
            paragraphMarkRunProperties240.Append(color405);
            paragraphMarkRunProperties240.Append(fontSize405);
            paragraphMarkRunProperties240.Append(fontSizeComplexScript405);
            paragraphMarkRunProperties240.Append(languages397);

            paragraphProperties240.Append(widowControl206);
            paragraphProperties240.Append(autoSpaceDE231);
            paragraphProperties240.Append(autoSpaceDN231);
            paragraphProperties240.Append(adjustRightIndent231);
            paragraphProperties240.Append(spacingBetweenLines231);
            paragraphProperties240.Append(justification214);
            paragraphProperties240.Append(paragraphMarkRunProperties240);

            paragraph240.Append(paragraphProperties240);

            tableCell126.Append(tableCellProperties126);
            tableCell126.Append(paragraph240);

            tableRow30.Append(tableRowProperties15);
            tableRow30.Append(tableCell118);
            tableRow30.Append(tableCell119);
            tableRow30.Append(tableCell120);
            tableRow30.Append(tableCell121);
            tableRow30.Append(tableCell122);
            tableRow30.Append(tableCell123);
            tableRow30.Append(tableCell124);
            tableRow30.Append(tableCell125);
            tableRow30.Append(tableCell126);

            table7.Append(tableProperties7);
            table7.Append(tableGrid7);
            table7.Append(tableRow22);
            table7.Append(tableRow23);
            table7.Append(tableRow24);
            table7.Append(tableRow25);
            table7.Append(tableRow26);
            table7.Append(tableRow27);
            table7.Append(tableRow28);
            table7.Append(tableRow29);
            table7.Append(tableRow30);
            Paragraph paragraph241 = new Paragraph() { RsidParagraphAddition = "009B27E8", RsidRunAdditionDefault = "009B27E8" };

            SectionProperties sectionProperties1 = new SectionProperties() { RsidR = "009B27E8" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)12240U, Height = (UInt32Value)15840U };
            PageMargin pageMargin1 = new PageMargin() { Top = 1134, Right = (UInt32Value)850U, Bottom = 1134, Left = (UInt32Value)1701U, Header = (UInt32Value)720U, Footer = (UInt32Value)720U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "720" };
            NoEndnote noEndnote1 = new NoEndnote();

            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(noEndnote1);

            body1.Append(table1);
            body1.Append(paragraph5);
            body1.Append(table2);
            body1.Append(paragraph11);
            body1.Append(paragraph12);
            body1.Append(paragraph13);
            body1.Append(paragraph14);
            body1.Append(paragraph15);
            body1.Append(paragraph16);
            body1.Append(paragraph17);
            body1.Append(paragraph18);
            body1.Append(paragraph19);
            body1.Append(paragraph20);
            body1.Append(paragraph21);
            body1.Append(paragraph22);
            body1.Append(paragraph23);
            body1.Append(paragraph24);
            body1.Append(paragraph25);
            body1.Append(paragraph26);
            body1.Append(paragraph27);
            body1.Append(paragraph28);
            body1.Append(paragraph29);
            body1.Append(paragraph30);
            body1.Append(paragraph31);
            body1.Append(paragraph32);
            body1.Append(paragraph33);
            body1.Append(paragraph34);
            body1.Append(paragraph35);
            body1.Append(paragraph36);
            body1.Append(paragraph37);
            body1.Append(paragraph38);
            body1.Append(paragraph39);
            body1.Append(paragraph40);
            body1.Append(paragraph41);
            body1.Append(paragraph42);
            body1.Append(paragraph43);
            body1.Append(paragraph44);
            body1.Append(paragraph45);
            body1.Append(paragraph46);
            body1.Append(paragraph47);
            body1.Append(paragraph48);
            body1.Append(paragraph49);
            body1.Append(paragraph50);
            body1.Append(paragraph51);
            body1.Append(paragraph52);
            body1.Append(paragraph53);
            body1.Append(paragraph54);
            body1.Append(paragraph55);
            body1.Append(paragraph56);
            body1.Append(paragraph57);
            body1.Append(paragraph58);
            body1.Append(paragraph59);
            body1.Append(paragraph60);
            body1.Append(paragraph61);
            body1.Append(paragraph62);
            body1.Append(paragraph63);
            body1.Append(paragraph64);
            body1.Append(paragraph65);
            body1.Append(paragraph66);
            body1.Append(paragraph67);
            body1.Append(paragraph68);
            body1.Append(paragraph69);
            body1.Append(paragraph70);
            body1.Append(paragraph71);
            body1.Append(paragraph72);
            body1.Append(paragraph73);
            body1.Append(paragraph74);
            body1.Append(paragraph75);
            body1.Append(paragraph76);
            body1.Append(paragraph77);
            body1.Append(paragraph78);
            body1.Append(paragraph79);
            body1.Append(paragraph80);
            body1.Append(paragraph81);
            body1.Append(paragraph82);
            body1.Append(paragraph83);
            body1.Append(paragraph84);
            body1.Append(paragraph85);
            body1.Append(paragraph86);
            body1.Append(paragraph87);
            body1.Append(paragraph88);
            body1.Append(paragraph89);
            body1.Append(table3);
            body1.Append(paragraph111);
            body1.Append(paragraph112);
            body1.Append(paragraph113);
            body1.Append(table4);
            body1.Append(paragraph131);
            body1.Append(paragraph132);
            body1.Append(paragraph133);
            body1.Append(paragraph134);
            body1.Append(paragraph135);
            body1.Append(paragraph136);
            body1.Append(paragraph137);
            body1.Append(paragraph138);
            body1.Append(paragraph139);
            body1.Append(paragraph140);
            body1.Append(paragraph141);
            body1.Append(paragraph142);
            body1.Append(paragraph143);
            body1.Append(paragraph144);
            body1.Append(paragraph145);
            body1.Append(paragraph146);
            body1.Append(paragraph147);
            body1.Append(paragraph148);
            body1.Append(paragraph149);
            body1.Append(paragraph150);
            body1.Append(table6);
            body1.Append(paragraph159);
            body1.Append(paragraph160);
            body1.Append(paragraph161);
            body1.Append(paragraph162);
            body1.Append(table7);
            body1.Append(paragraph241);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of webSettingsPart1.
        private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            webSettings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            webSettings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            AllowPNG allowPNG1 = new AllowPNG();

            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(allowPNG1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        // Generates content of documentSettingsPart1.
        private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            Settings settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            settings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Percent = "100" };
            EmbedSystemFonts embedSystemFonts1 = new EmbedSystemFonts();
            BordersDoNotSurroundHeader bordersDoNotSurroundHeader1 = new BordersDoNotSurroundHeader();
            BordersDoNotSurroundFooter bordersDoNotSurroundFooter1 = new BordersDoNotSurroundFooter();
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 720 };
            DrawingGridHorizontalSpacing drawingGridHorizontalSpacing1 = new DrawingGridHorizontalSpacing() { Val = "120" };
            DrawingGridVerticalSpacing drawingGridVerticalSpacing1 = new DrawingGridVerticalSpacing() { Val = "120" };
            DisplayHorizontalDrawingGrid displayHorizontalDrawingGrid1 = new DisplayHorizontalDrawingGrid() { Val = 0 };
            DisplayVerticalDrawingGrid displayVerticalDrawingGrid1 = new DisplayVerticalDrawingGrid() { Val = 3 };
            DoNotUseMarginsForDrawingGridOrigin doNotUseMarginsForDrawingGridOrigin1 = new DoNotUseMarginsForDrawingGridOrigin();
            DoNotShadeFormData doNotShadeFormData1 = new DoNotShadeFormData();
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.CompressPunctuation };
            DoNotValidateAgainstSchema doNotValidateAgainstSchema1 = new DoNotValidateAgainstSchema();
            DoNotDemarcateInvalidXml doNotDemarcateInvalidXml1 = new DoNotDemarcateInvalidXml();

            Compatibility compatibility1 = new Compatibility();
            SpaceForUnderline spaceForUnderline1 = new SpaceForUnderline();
            BalanceSingleByteDoubleByteWidth balanceSingleByteDoubleByteWidth1 = new BalanceSingleByteDoubleByteWidth();
            DoNotLeaveBackslashAlone doNotLeaveBackslashAlone1 = new DoNotLeaveBackslashAlone();
            UnderlineTrailingSpaces underlineTrailingSpaces1 = new UnderlineTrailingSpaces();
            DoNotExpandShiftReturn doNotExpandShiftReturn1 = new DoNotExpandShiftReturn();
            AdjustLineHeightInTable adjustLineHeightInTable1 = new AdjustLineHeightInTable();
            UseFarEastLayout useFarEastLayout1 = new UseFarEastLayout();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "15" };
            CompatibilitySetting compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting5 = new CompatibilitySetting() { Name = CompatSettingNameValues.DifferentiateMultirowTableHeaders, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

            compatibility1.Append(spaceForUnderline1);
            compatibility1.Append(balanceSingleByteDoubleByteWidth1);
            compatibility1.Append(doNotLeaveBackslashAlone1);
            compatibility1.Append(underlineTrailingSpaces1);
            compatibility1.Append(doNotExpandShiftReturn1);
            compatibility1.Append(adjustLineHeightInTable1);
            compatibility1.Append(useFarEastLayout1);
            compatibility1.Append(compatibilitySetting1);
            compatibility1.Append(compatibilitySetting2);
            compatibility1.Append(compatibilitySetting3);
            compatibility1.Append(compatibilitySetting4);
            compatibility1.Append(compatibilitySetting5);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "00966DE2" };
            Rsid rsid1 = new Rsid() { Val = "00060844" };
            Rsid rsid2 = new Rsid() { Val = "00067D40" };
            Rsid rsid3 = new Rsid() { Val = "000B1615" };
            Rsid rsid4 = new Rsid() { Val = "000C3E09" };
            Rsid rsid5 = new Rsid() { Val = "001E02D3" };
            Rsid rsid6 = new Rsid() { Val = "0026275A" };
            Rsid rsid7 = new Rsid() { Val = "003106D5" };
            Rsid rsid8 = new Rsid() { Val = "0031269F" };
            Rsid rsid9 = new Rsid() { Val = "003678C0" };
            Rsid rsid10 = new Rsid() { Val = "004525A9" };
            Rsid rsid11 = new Rsid() { Val = "00524100" };
            Rsid rsid12 = new Rsid() { Val = "006852F2" };
            Rsid rsid13 = new Rsid() { Val = "00706F3D" };
            Rsid rsid14 = new Rsid() { Val = "008342BF" };
            Rsid rsid15 = new Rsid() { Val = "008A11BA" };
            Rsid rsid16 = new Rsid() { Val = "00900A3F" };
            Rsid rsid17 = new Rsid() { Val = "00913E98" };
            Rsid rsid18 = new Rsid() { Val = "00966DE2" };
            Rsid rsid19 = new Rsid() { Val = "009B27E8" };
            Rsid rsid20 = new Rsid() { Val = "009C74B9" };
            Rsid rsid21 = new Rsid() { Val = "00BC312A" };
            Rsid rsid22 = new Rsid() { Val = "00C8780D" };
            Rsid rsid23 = new Rsid() { Val = "00D73B0F" };
            Rsid rsid24 = new Rsid() { Val = "00DA092C" };
            Rsid rsid25 = new Rsid() { Val = "00DC45A7" };
            Rsid rsid26 = new Rsid() { Val = "00E21CEE" };
            Rsid rsid27 = new Rsid() { Val = "00E43A47" };
            Rsid rsid28 = new Rsid() { Val = "00E60584" };
            Rsid rsid29 = new Rsid() { Val = "00E769EC" };
            Rsid rsid30 = new Rsid() { Val = "00EC1B6C" };
            Rsid rsid31 = new Rsid() { Val = "00F369AA" };
            Rsid rsid32 = new Rsid() { Val = "00FC168C" };
            Rsid rsid33 = new Rsid() { Val = "00FF310F" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid1);
            rsids1.Append(rsid2);
            rsids1.Append(rsid3);
            rsids1.Append(rsid4);
            rsids1.Append(rsid5);
            rsids1.Append(rsid6);
            rsids1.Append(rsid7);
            rsids1.Append(rsid8);
            rsids1.Append(rsid9);
            rsids1.Append(rsid10);
            rsids1.Append(rsid11);
            rsids1.Append(rsid12);
            rsids1.Append(rsid13);
            rsids1.Append(rsid14);
            rsids1.Append(rsid15);
            rsids1.Append(rsid16);
            rsids1.Append(rsid17);
            rsids1.Append(rsid18);
            rsids1.Append(rsid19);
            rsids1.Append(rsid20);
            rsids1.Append(rsid21);
            rsids1.Append(rsid22);
            rsids1.Append(rsid23);
            rsids1.Append(rsid24);
            rsids1.Append(rsid25);
            rsids1.Append(rsid26);
            rsids1.Append(rsid27);
            rsids1.Append(rsid28);
            rsids1.Append(rsid29);
            rsids1.Append(rsid30);
            rsids1.Append(rsid31);
            rsids1.Append(rsid32);
            rsids1.Append(rsid33);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "ru-RU" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };
            DoNotIncludeSubdocsInStats doNotIncludeSubdocsInStats1 = new DoNotIncludeSubdocsInStats();
            DoNotAutoCompressPictures doNotAutoCompressPictures1 = new DoNotAutoCompressPictures();

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };
            W14.DocumentId documentId1 = new W14.DocumentId() { Val = "047A5B70" };
            W14.DefaultImageDpi defaultImageDpi1 = new W14.DefaultImageDpi() { Val = 0 };
            W15.PersistentDocumentId persistentDocumentId1 = new W15.PersistentDocumentId() { Val = "{5A6F66A9-DE62-45BB-B2DE-7ED722D3923E}" };

            settings1.Append(zoom1);
            settings1.Append(embedSystemFonts1);
            settings1.Append(bordersDoNotSurroundHeader1);
            settings1.Append(bordersDoNotSurroundFooter1);
            settings1.Append(defaultTabStop1);
            settings1.Append(drawingGridHorizontalSpacing1);
            settings1.Append(drawingGridVerticalSpacing1);
            settings1.Append(displayHorizontalDrawingGrid1);
            settings1.Append(displayVerticalDrawingGrid1);
            settings1.Append(doNotUseMarginsForDrawingGridOrigin1);
            settings1.Append(doNotShadeFormData1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(doNotValidateAgainstSchema1);
            settings1.Append(doNotDemarcateInvalidXml1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(doNotIncludeSubdocsInStats1);
            settings1.Append(doNotAutoCompressPictures1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);
            settings1.Append(documentId1);
            settings1.Append(defaultImageDpi1);
            settings1.Append(persistentDocumentId1);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of styleDefinitionsPart1.
        private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            styles1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts406 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize406 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript406 = new FontSizeComplexScript() { Val = "22" };
            Languages languages398 = new Languages() { Val = "ru-RU", EastAsia = "ru-RU", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts406);
            runPropertiesBaseStyle1.Append(fontSize406);
            runPropertiesBaseStyle1.Append(fontSizeComplexScript406);
            runPropertiesBaseStyle1.Append(languages398);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);

            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines232 = new SpacingBetweenLines() { After = "160", Line = "259", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle1.Append(spacingBetweenLines232);

            paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = false, DefaultUnhideWhenUsed = false, DefaultPrimaryStyle = false, Count = 371 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "index 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "index 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "index 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "index 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "index 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "index 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "index 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "index 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "index 9", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Normal Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "footnote text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "annotation text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "header", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "footer", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "index heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "table of figures", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "envelope address", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "envelope return", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "footnote reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "annotation reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "line number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "page number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "endnote reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "endnote text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "table of authorities", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "macro", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "toa heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "List", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "List Bullet", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "List 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "List 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "List Bullet 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "List Bullet 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "List Bullet 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "List Bullet 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "List Number 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "List Number 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "List Number 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "List Number 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Closing", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Signature", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Body Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Body Text Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "List Continue", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "List Continue 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "List Continue 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "List Continue 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "List Continue 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Message Header", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Salutation", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Date", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Note Heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Body Text 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Body Text 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Block Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Hyperlink", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "FollowedHyperlink", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Document Map", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Plain Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "E-mail Signature", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "HTML Top of Form", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "HTML Bottom of Form", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Normal (Web)", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "HTML Acronym", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "HTML Address", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "HTML Cite", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "HTML Code", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "HTML Definition", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "HTML Keyboard", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "HTML Preformatted", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "HTML Sample", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "HTML Typewriter", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "HTML Variable", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Normal Table", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "annotation subject", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "No List", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Outline List 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Outline List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Outline List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Table Simple 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Table Simple 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Table Simple 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Table Classic 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Table Classic 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Table Classic 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Table Classic 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Table Colorful 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Table Colorful 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Table Colorful 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Table Columns 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Table Columns 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Table Columns 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Table Columns 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Table Columns 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Table Grid 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Table Grid 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Table Grid 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Table Grid 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Table Grid 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Table Grid 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Table Grid 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Table Grid 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Table List 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Table List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "Table List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Table List 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "Table List 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "Table List 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "Table List 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "Table List 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "Table Contemporary", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "Table Elegant", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "Table Professional", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "Table Subtle 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "Table Subtle 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "Table Web 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "Table Web 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "Table Web 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "Balloon Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "Table Theme", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Revision", SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Plain Table 1", UiPriority = 41 };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Plain Table 2", UiPriority = 42 };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Plain Table 3", UiPriority = 43 };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Plain Table 4", UiPriority = 44 };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Plain Table 5", UiPriority = 45 };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Grid Table Light", UiPriority = 40 };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo275 = new LatentStyleExceptionInfo() { Name = "Grid Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo276 = new LatentStyleExceptionInfo() { Name = "Grid Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo277 = new LatentStyleExceptionInfo() { Name = "Grid Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo278 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo279 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo280 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo281 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo282 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo283 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo284 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo285 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo286 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo287 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo288 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo289 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo290 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo291 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo292 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo293 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo294 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo295 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo296 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo297 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo298 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo299 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo300 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo301 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo302 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo303 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo304 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo305 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo306 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo307 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo308 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo309 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo310 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo311 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo312 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo313 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo314 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo315 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo316 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo317 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo318 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo319 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo320 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo321 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo322 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 6", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo323 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo324 = new LatentStyleExceptionInfo() { Name = "List Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo325 = new LatentStyleExceptionInfo() { Name = "List Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo326 = new LatentStyleExceptionInfo() { Name = "List Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo327 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo328 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo329 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo330 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo331 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo332 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo333 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo334 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo335 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo336 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo337 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo338 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo339 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo340 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo341 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo342 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo343 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo344 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo345 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo346 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo347 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo348 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo349 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo350 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo351 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo352 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo353 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo354 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo355 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo356 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo357 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo358 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo359 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo360 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo361 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo362 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo363 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo364 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo365 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo366 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo367 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo368 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo369 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo370 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo371 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 6", UiPriority = 52 };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);
            latentStyles1.Append(latentStyleExceptionInfo138);
            latentStyles1.Append(latentStyleExceptionInfo139);
            latentStyles1.Append(latentStyleExceptionInfo140);
            latentStyles1.Append(latentStyleExceptionInfo141);
            latentStyles1.Append(latentStyleExceptionInfo142);
            latentStyles1.Append(latentStyleExceptionInfo143);
            latentStyles1.Append(latentStyleExceptionInfo144);
            latentStyles1.Append(latentStyleExceptionInfo145);
            latentStyles1.Append(latentStyleExceptionInfo146);
            latentStyles1.Append(latentStyleExceptionInfo147);
            latentStyles1.Append(latentStyleExceptionInfo148);
            latentStyles1.Append(latentStyleExceptionInfo149);
            latentStyles1.Append(latentStyleExceptionInfo150);
            latentStyles1.Append(latentStyleExceptionInfo151);
            latentStyles1.Append(latentStyleExceptionInfo152);
            latentStyles1.Append(latentStyleExceptionInfo153);
            latentStyles1.Append(latentStyleExceptionInfo154);
            latentStyles1.Append(latentStyleExceptionInfo155);
            latentStyles1.Append(latentStyleExceptionInfo156);
            latentStyles1.Append(latentStyleExceptionInfo157);
            latentStyles1.Append(latentStyleExceptionInfo158);
            latentStyles1.Append(latentStyleExceptionInfo159);
            latentStyles1.Append(latentStyleExceptionInfo160);
            latentStyles1.Append(latentStyleExceptionInfo161);
            latentStyles1.Append(latentStyleExceptionInfo162);
            latentStyles1.Append(latentStyleExceptionInfo163);
            latentStyles1.Append(latentStyleExceptionInfo164);
            latentStyles1.Append(latentStyleExceptionInfo165);
            latentStyles1.Append(latentStyleExceptionInfo166);
            latentStyles1.Append(latentStyleExceptionInfo167);
            latentStyles1.Append(latentStyleExceptionInfo168);
            latentStyles1.Append(latentStyleExceptionInfo169);
            latentStyles1.Append(latentStyleExceptionInfo170);
            latentStyles1.Append(latentStyleExceptionInfo171);
            latentStyles1.Append(latentStyleExceptionInfo172);
            latentStyles1.Append(latentStyleExceptionInfo173);
            latentStyles1.Append(latentStyleExceptionInfo174);
            latentStyles1.Append(latentStyleExceptionInfo175);
            latentStyles1.Append(latentStyleExceptionInfo176);
            latentStyles1.Append(latentStyleExceptionInfo177);
            latentStyles1.Append(latentStyleExceptionInfo178);
            latentStyles1.Append(latentStyleExceptionInfo179);
            latentStyles1.Append(latentStyleExceptionInfo180);
            latentStyles1.Append(latentStyleExceptionInfo181);
            latentStyles1.Append(latentStyleExceptionInfo182);
            latentStyles1.Append(latentStyleExceptionInfo183);
            latentStyles1.Append(latentStyleExceptionInfo184);
            latentStyles1.Append(latentStyleExceptionInfo185);
            latentStyles1.Append(latentStyleExceptionInfo186);
            latentStyles1.Append(latentStyleExceptionInfo187);
            latentStyles1.Append(latentStyleExceptionInfo188);
            latentStyles1.Append(latentStyleExceptionInfo189);
            latentStyles1.Append(latentStyleExceptionInfo190);
            latentStyles1.Append(latentStyleExceptionInfo191);
            latentStyles1.Append(latentStyleExceptionInfo192);
            latentStyles1.Append(latentStyleExceptionInfo193);
            latentStyles1.Append(latentStyleExceptionInfo194);
            latentStyles1.Append(latentStyleExceptionInfo195);
            latentStyles1.Append(latentStyleExceptionInfo196);
            latentStyles1.Append(latentStyleExceptionInfo197);
            latentStyles1.Append(latentStyleExceptionInfo198);
            latentStyles1.Append(latentStyleExceptionInfo199);
            latentStyles1.Append(latentStyleExceptionInfo200);
            latentStyles1.Append(latentStyleExceptionInfo201);
            latentStyles1.Append(latentStyleExceptionInfo202);
            latentStyles1.Append(latentStyleExceptionInfo203);
            latentStyles1.Append(latentStyleExceptionInfo204);
            latentStyles1.Append(latentStyleExceptionInfo205);
            latentStyles1.Append(latentStyleExceptionInfo206);
            latentStyles1.Append(latentStyleExceptionInfo207);
            latentStyles1.Append(latentStyleExceptionInfo208);
            latentStyles1.Append(latentStyleExceptionInfo209);
            latentStyles1.Append(latentStyleExceptionInfo210);
            latentStyles1.Append(latentStyleExceptionInfo211);
            latentStyles1.Append(latentStyleExceptionInfo212);
            latentStyles1.Append(latentStyleExceptionInfo213);
            latentStyles1.Append(latentStyleExceptionInfo214);
            latentStyles1.Append(latentStyleExceptionInfo215);
            latentStyles1.Append(latentStyleExceptionInfo216);
            latentStyles1.Append(latentStyleExceptionInfo217);
            latentStyles1.Append(latentStyleExceptionInfo218);
            latentStyles1.Append(latentStyleExceptionInfo219);
            latentStyles1.Append(latentStyleExceptionInfo220);
            latentStyles1.Append(latentStyleExceptionInfo221);
            latentStyles1.Append(latentStyleExceptionInfo222);
            latentStyles1.Append(latentStyleExceptionInfo223);
            latentStyles1.Append(latentStyleExceptionInfo224);
            latentStyles1.Append(latentStyleExceptionInfo225);
            latentStyles1.Append(latentStyleExceptionInfo226);
            latentStyles1.Append(latentStyleExceptionInfo227);
            latentStyles1.Append(latentStyleExceptionInfo228);
            latentStyles1.Append(latentStyleExceptionInfo229);
            latentStyles1.Append(latentStyleExceptionInfo230);
            latentStyles1.Append(latentStyleExceptionInfo231);
            latentStyles1.Append(latentStyleExceptionInfo232);
            latentStyles1.Append(latentStyleExceptionInfo233);
            latentStyles1.Append(latentStyleExceptionInfo234);
            latentStyles1.Append(latentStyleExceptionInfo235);
            latentStyles1.Append(latentStyleExceptionInfo236);
            latentStyles1.Append(latentStyleExceptionInfo237);
            latentStyles1.Append(latentStyleExceptionInfo238);
            latentStyles1.Append(latentStyleExceptionInfo239);
            latentStyles1.Append(latentStyleExceptionInfo240);
            latentStyles1.Append(latentStyleExceptionInfo241);
            latentStyles1.Append(latentStyleExceptionInfo242);
            latentStyles1.Append(latentStyleExceptionInfo243);
            latentStyles1.Append(latentStyleExceptionInfo244);
            latentStyles1.Append(latentStyleExceptionInfo245);
            latentStyles1.Append(latentStyleExceptionInfo246);
            latentStyles1.Append(latentStyleExceptionInfo247);
            latentStyles1.Append(latentStyleExceptionInfo248);
            latentStyles1.Append(latentStyleExceptionInfo249);
            latentStyles1.Append(latentStyleExceptionInfo250);
            latentStyles1.Append(latentStyleExceptionInfo251);
            latentStyles1.Append(latentStyleExceptionInfo252);
            latentStyles1.Append(latentStyleExceptionInfo253);
            latentStyles1.Append(latentStyleExceptionInfo254);
            latentStyles1.Append(latentStyleExceptionInfo255);
            latentStyles1.Append(latentStyleExceptionInfo256);
            latentStyles1.Append(latentStyleExceptionInfo257);
            latentStyles1.Append(latentStyleExceptionInfo258);
            latentStyles1.Append(latentStyleExceptionInfo259);
            latentStyles1.Append(latentStyleExceptionInfo260);
            latentStyles1.Append(latentStyleExceptionInfo261);
            latentStyles1.Append(latentStyleExceptionInfo262);
            latentStyles1.Append(latentStyleExceptionInfo263);
            latentStyles1.Append(latentStyleExceptionInfo264);
            latentStyles1.Append(latentStyleExceptionInfo265);
            latentStyles1.Append(latentStyleExceptionInfo266);
            latentStyles1.Append(latentStyleExceptionInfo267);
            latentStyles1.Append(latentStyleExceptionInfo268);
            latentStyles1.Append(latentStyleExceptionInfo269);
            latentStyles1.Append(latentStyleExceptionInfo270);
            latentStyles1.Append(latentStyleExceptionInfo271);
            latentStyles1.Append(latentStyleExceptionInfo272);
            latentStyles1.Append(latentStyleExceptionInfo273);
            latentStyles1.Append(latentStyleExceptionInfo274);
            latentStyles1.Append(latentStyleExceptionInfo275);
            latentStyles1.Append(latentStyleExceptionInfo276);
            latentStyles1.Append(latentStyleExceptionInfo277);
            latentStyles1.Append(latentStyleExceptionInfo278);
            latentStyles1.Append(latentStyleExceptionInfo279);
            latentStyles1.Append(latentStyleExceptionInfo280);
            latentStyles1.Append(latentStyleExceptionInfo281);
            latentStyles1.Append(latentStyleExceptionInfo282);
            latentStyles1.Append(latentStyleExceptionInfo283);
            latentStyles1.Append(latentStyleExceptionInfo284);
            latentStyles1.Append(latentStyleExceptionInfo285);
            latentStyles1.Append(latentStyleExceptionInfo286);
            latentStyles1.Append(latentStyleExceptionInfo287);
            latentStyles1.Append(latentStyleExceptionInfo288);
            latentStyles1.Append(latentStyleExceptionInfo289);
            latentStyles1.Append(latentStyleExceptionInfo290);
            latentStyles1.Append(latentStyleExceptionInfo291);
            latentStyles1.Append(latentStyleExceptionInfo292);
            latentStyles1.Append(latentStyleExceptionInfo293);
            latentStyles1.Append(latentStyleExceptionInfo294);
            latentStyles1.Append(latentStyleExceptionInfo295);
            latentStyles1.Append(latentStyleExceptionInfo296);
            latentStyles1.Append(latentStyleExceptionInfo297);
            latentStyles1.Append(latentStyleExceptionInfo298);
            latentStyles1.Append(latentStyleExceptionInfo299);
            latentStyles1.Append(latentStyleExceptionInfo300);
            latentStyles1.Append(latentStyleExceptionInfo301);
            latentStyles1.Append(latentStyleExceptionInfo302);
            latentStyles1.Append(latentStyleExceptionInfo303);
            latentStyles1.Append(latentStyleExceptionInfo304);
            latentStyles1.Append(latentStyleExceptionInfo305);
            latentStyles1.Append(latentStyleExceptionInfo306);
            latentStyles1.Append(latentStyleExceptionInfo307);
            latentStyles1.Append(latentStyleExceptionInfo308);
            latentStyles1.Append(latentStyleExceptionInfo309);
            latentStyles1.Append(latentStyleExceptionInfo310);
            latentStyles1.Append(latentStyleExceptionInfo311);
            latentStyles1.Append(latentStyleExceptionInfo312);
            latentStyles1.Append(latentStyleExceptionInfo313);
            latentStyles1.Append(latentStyleExceptionInfo314);
            latentStyles1.Append(latentStyleExceptionInfo315);
            latentStyles1.Append(latentStyleExceptionInfo316);
            latentStyles1.Append(latentStyleExceptionInfo317);
            latentStyles1.Append(latentStyleExceptionInfo318);
            latentStyles1.Append(latentStyleExceptionInfo319);
            latentStyles1.Append(latentStyleExceptionInfo320);
            latentStyles1.Append(latentStyleExceptionInfo321);
            latentStyles1.Append(latentStyleExceptionInfo322);
            latentStyles1.Append(latentStyleExceptionInfo323);
            latentStyles1.Append(latentStyleExceptionInfo324);
            latentStyles1.Append(latentStyleExceptionInfo325);
            latentStyles1.Append(latentStyleExceptionInfo326);
            latentStyles1.Append(latentStyleExceptionInfo327);
            latentStyles1.Append(latentStyleExceptionInfo328);
            latentStyles1.Append(latentStyleExceptionInfo329);
            latentStyles1.Append(latentStyleExceptionInfo330);
            latentStyles1.Append(latentStyleExceptionInfo331);
            latentStyles1.Append(latentStyleExceptionInfo332);
            latentStyles1.Append(latentStyleExceptionInfo333);
            latentStyles1.Append(latentStyleExceptionInfo334);
            latentStyles1.Append(latentStyleExceptionInfo335);
            latentStyles1.Append(latentStyleExceptionInfo336);
            latentStyles1.Append(latentStyleExceptionInfo337);
            latentStyles1.Append(latentStyleExceptionInfo338);
            latentStyles1.Append(latentStyleExceptionInfo339);
            latentStyles1.Append(latentStyleExceptionInfo340);
            latentStyles1.Append(latentStyleExceptionInfo341);
            latentStyles1.Append(latentStyleExceptionInfo342);
            latentStyles1.Append(latentStyleExceptionInfo343);
            latentStyles1.Append(latentStyleExceptionInfo344);
            latentStyles1.Append(latentStyleExceptionInfo345);
            latentStyles1.Append(latentStyleExceptionInfo346);
            latentStyles1.Append(latentStyleExceptionInfo347);
            latentStyles1.Append(latentStyleExceptionInfo348);
            latentStyles1.Append(latentStyleExceptionInfo349);
            latentStyles1.Append(latentStyleExceptionInfo350);
            latentStyles1.Append(latentStyleExceptionInfo351);
            latentStyles1.Append(latentStyleExceptionInfo352);
            latentStyles1.Append(latentStyleExceptionInfo353);
            latentStyles1.Append(latentStyleExceptionInfo354);
            latentStyles1.Append(latentStyleExceptionInfo355);
            latentStyles1.Append(latentStyleExceptionInfo356);
            latentStyles1.Append(latentStyleExceptionInfo357);
            latentStyles1.Append(latentStyleExceptionInfo358);
            latentStyles1.Append(latentStyleExceptionInfo359);
            latentStyles1.Append(latentStyleExceptionInfo360);
            latentStyles1.Append(latentStyleExceptionInfo361);
            latentStyles1.Append(latentStyleExceptionInfo362);
            latentStyles1.Append(latentStyleExceptionInfo363);
            latentStyles1.Append(latentStyleExceptionInfo364);
            latentStyles1.Append(latentStyleExceptionInfo365);
            latentStyles1.Append(latentStyleExceptionInfo366);
            latentStyles1.Append(latentStyleExceptionInfo367);
            latentStyles1.Append(latentStyleExceptionInfo368);
            latentStyles1.Append(latentStyleExceptionInfo369);
            latentStyles1.Append(latentStyleExceptionInfo370);
            latentStyles1.Append(latentStyleExceptionInfo371);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();

            style1.Append(styleName1);
            style1.Append(primaryStyle1);

            Style style2 = new Style() { Type = StyleValues.Character, StyleId = "a0", Default = true };
            StyleName styleName2 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority1 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden1 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();

            style2.Append(styleName2);
            style2.Append(uIPriority1);
            style2.Append(semiHidden1);
            style2.Append(unhideWhenUsed1);

            Style style3 = new Style() { Type = StyleValues.Table, StyleId = "a1", Default = true };
            StyleName styleName3 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority2 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden2 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation7 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault8 = new TableCellMarginDefault();
            TopMargin topMargin8 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin8 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin8 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin8 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault8.Append(topMargin8);
            tableCellMarginDefault8.Append(tableCellLeftMargin8);
            tableCellMarginDefault8.Append(bottomMargin8);
            tableCellMarginDefault8.Append(tableCellRightMargin8);

            styleTableProperties1.Append(tableIndentation7);
            styleTableProperties1.Append(tableCellMarginDefault8);

            style3.Append(styleName3);
            style3.Append(uIPriority2);
            style3.Append(semiHidden2);
            style3.Append(unhideWhenUsed2);
            style3.Append(styleTableProperties1);

            Style style4 = new Style() { Type = StyleValues.Numbering, StyleId = "a2", Default = true };
            StyleName styleName4 = new StyleName() { Val = "No List" };
            UIPriority uIPriority3 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden3 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();

            style4.Append(styleName4);
            style4.Append(uIPriority3);
            style4.Append(semiHidden3);
            style4.Append(unhideWhenUsed3);

            Style style5 = new Style() { Type = StyleValues.Paragraph, StyleId = "a3" };
            StyleName styleName5 = new StyleName() { Val = "List Paragraph" };
            BasedOn basedOn1 = new BasedOn() { Val = "a" };
            UIPriority uIPriority4 = new UIPriority() { Val = 34 };
            PrimaryStyle primaryStyle2 = new PrimaryStyle();
            Rsid rsid34 = new Rsid() { Val = "00E21CEE" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();
            Indentation indentation3 = new Indentation() { Start = "720" };
            ContextualSpacing contextualSpacing1 = new ContextualSpacing();

            styleParagraphProperties1.Append(indentation3);
            styleParagraphProperties1.Append(contextualSpacing1);

            style5.Append(styleName5);
            style5.Append(basedOn1);
            style5.Append(uIPriority4);
            style5.Append(primaryStyle2);
            style5.Append(rsid34);
            style5.Append(styleParagraphProperties1);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);

            styleDefinitionsPart1.Styles = styles1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Тема Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Стандартная" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "44546A" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "E7E6E6" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "5B9BD5" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "ED7D31" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "A5A5A5" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "FFC000" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4472C4" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "70AD47" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0563C1" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "954F72" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Стандартная" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Calibri Light", Panose = "020F0302020204030204" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游ゴシック Light" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线 Light" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri", Panose = "020F0502020204030204" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Стандартная" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation1 = new A.LuminanceModulation() { Val = 110000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 105000 };
            A.Tint tint1 = new A.Tint() { Val = 67000 };

            schemeColor2.Append(luminanceModulation1);
            schemeColor2.Append(saturationModulation1);
            schemeColor2.Append(tint1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation2 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 103000 };
            A.Tint tint2 = new A.Tint() { Val = 73000 };

            schemeColor3.Append(luminanceModulation2);
            schemeColor3.Append(saturationModulation2);
            schemeColor3.Append(tint2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation3 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 109000 };
            A.Tint tint3 = new A.Tint() { Val = 81000 };

            schemeColor4.Append(luminanceModulation3);
            schemeColor4.Append(saturationModulation3);
            schemeColor4.Append(tint3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 103000 };
            A.LuminanceModulation luminanceModulation4 = new A.LuminanceModulation() { Val = 102000 };
            A.Tint tint4 = new A.Tint() { Val = 94000 };

            schemeColor5.Append(saturationModulation4);
            schemeColor5.Append(luminanceModulation4);
            schemeColor5.Append(tint4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 110000 };
            A.LuminanceModulation luminanceModulation5 = new A.LuminanceModulation() { Val = 100000 };
            A.Shade shade1 = new A.Shade() { Val = 100000 };

            schemeColor6.Append(saturationModulation5);
            schemeColor6.Append(luminanceModulation5);
            schemeColor6.Append(shade1);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation6 = new A.LuminanceModulation() { Val = 99000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 120000 };
            A.Shade shade2 = new A.Shade() { Val = 78000 };

            schemeColor7.Append(luminanceModulation6);
            schemeColor7.Append(saturationModulation6);
            schemeColor7.Append(shade2);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline2 = new A.Outline() { Width = 6350, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter1 = new A.Miter() { Limit = 800000 };

            outline2.Append(solidFill2);
            outline2.Append(presetDash1);
            outline2.Append(miter1);

            A.Outline outline3 = new A.Outline() { Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter2 = new A.Miter() { Limit = 800000 };

            outline3.Append(solidFill3);
            outline3.Append(presetDash2);
            outline3.Append(miter2);

            A.Outline outline4 = new A.Outline() { Width = 19050, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter3 = new A.Miter() { Limit = 800000 };

            outline4.Append(solidFill4);
            outline4.Append(presetDash3);
            outline4.Append(miter3);

            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);
            lineStyleList1.Append(outline4);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();
            A.EffectList effectList1 = new A.EffectList();

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();
            A.EffectList effectList2 = new A.EffectList();

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 57150L, Distance = 19050L, Direction = 5400000, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 63000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList3.Append(outerShadow1);

            effectStyle3.Append(effectList3);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.SolidFill solidFill6 = new A.SolidFill();

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 170000 };

            schemeColor12.Append(tint5);
            schemeColor12.Append(saturationModulation7);

            solidFill6.Append(schemeColor12);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 93000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 150000 };
            A.Shade shade3 = new A.Shade() { Val = 98000 };
            A.LuminanceModulation luminanceModulation7 = new A.LuminanceModulation() { Val = 102000 };

            schemeColor13.Append(tint6);
            schemeColor13.Append(saturationModulation8);
            schemeColor13.Append(shade3);
            schemeColor13.Append(luminanceModulation7);

            gradientStop7.Append(schemeColor13);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint7 = new A.Tint() { Val = 98000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 130000 };
            A.Shade shade4 = new A.Shade() { Val = 90000 };
            A.LuminanceModulation luminanceModulation8 = new A.LuminanceModulation() { Val = 103000 };

            schemeColor14.Append(tint7);
            schemeColor14.Append(saturationModulation9);
            schemeColor14.Append(shade4);
            schemeColor14.Append(luminanceModulation8);

            gradientStop8.Append(schemeColor14);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade5 = new A.Shade() { Val = 63000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 120000 };

            schemeColor15.Append(shade5);
            schemeColor15.Append(saturationModulation10);

            gradientStop9.Append(schemeColor15);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);
            A.LinearGradientFill linearGradientFill3 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(linearGradientFill3);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(solidFill6);
            backgroundFillStyleList1.Append(gradientFill3);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            A.OfficeStyleSheetExtensionList officeStyleSheetExtensionList1 = new A.OfficeStyleSheetExtensionList();

            A.OfficeStyleSheetExtension officeStyleSheetExtension1 = new A.OfficeStyleSheetExtension() { Uri = "{05A4C25C-085E-4340-85A3-A5531E510DB2}" };

            Thm15.ThemeFamily themeFamily1 = new Thm15.ThemeFamily() { Name = "Office Theme", Id = "{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}", Vid = "{4A3C46E8-61CC-4603-A589-7422A47A8E4A}" };
            themeFamily1.AddNamespaceDeclaration("thm15", "http://schemas.microsoft.com/office/thememl/2012/main");

            officeStyleSheetExtension1.Append(themeFamily1);

            officeStyleSheetExtensionList1.Append(officeStyleSheetExtension1);

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);
            theme1.Append(officeStyleSheetExtensionList1);

            themePart1.Theme = theme1;
        }

        // Generates content of fontTablePart1.
        private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            fonts1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            fonts1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            Font font1 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007841", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Georgia" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "02040502050405020303" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "00000287", UnicodeSignature1 = "00000000", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000009F", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            Font font4 = new Font() { Name = "Calibri Light" };
            Panose1Number panose1Number4 = new Panose1Number() { Val = "020F0302020204030204" };
            FontCharSet fontCharSet4 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily4 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch4 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature4 = new FontSignature() { UnicodeSignature0 = "A00002EF", UnicodeSignature1 = "4000207B", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font4.Append(panose1Number4);
            font4.Append(fontCharSet4);
            font4.Append(fontFamily4);
            font4.Append(pitch4);
            font4.Append(fontSignature4);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);

            fontTablePart1.Fonts = fonts1;
        }

        // Generates content of imagePart1.
        private void GenerateImagePart1Content(ImagePart imagePart1)
        {
            System.IO.Stream data = GetBinaryDataStream(imagePart1Data);
            imagePart1.FeedData(data);
            data.Close();
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Win7 64 SP1";
            document.PackageProperties.Title = "";
            document.PackageProperties.Subject = "";
            document.PackageProperties.Keywords = "";
            document.PackageProperties.Description = "";
            document.PackageProperties.Revision = "31";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2021-09-22T17:15:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2021-09-22T17:46:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Win7 64 SP1";
        }

        #region Binary Data
        private string imagePart1Data = "iVBORw0KGgoAAAANSUhEUgAAAEAAAAA/CAIAAADff1mdAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAABGZSURBVGhDrZoHWNNXtMAvCYGEvZGN7OUAFBVbrRahilJ8Wqn1WVxt1VpbreO1toXaZW3VlmoroIAsWVYQZDhAlCHIXjJkyN4jJIGQwTtJrhgwQIL9fXx8Oec/z733nHvOvX+p8fFx9B8Bd+odZLZ3M553MNq6R/qpTDZ7HEkhWRJBQ0VWT1vOSEdOR4OiqiSDL/gv+A8MqG8ZzizqSUhvrW4crm2iogEmTwt3JUkhGSLvxxgHsbnwLERAJC05K2PFBWbKW10NnezU9bQo/HvMnbkb0Nk3kprdeTm6Lr+sd7xrBKmTjecrWRkqmhopWpsoWhopGenKDw6PkUgEsgyxvplW3UStbqTCj6dN1E6wk86m6MmvWaa9f5s5/FegSOP7SshcDGjpYgTGPvsronbw2RDSlXNdPg/ewHOtvrGOPFmWiE9CKDmr/cSZQjUVsv9pJ2sTZaxFiMZgVzUMxae3Zjzpfvy4E1FZpvYaR7wtvT1N52CGZAYMM9iXImt+C3raXzNotERz92bT7euNLIwU8WEhGlppVpuSrIyV+geZJAqxLG6DopyIlyuo7A9Pagq6WT9cN2ixfN6Jfba7PecTpKTwYXEAA8QEWtTaPRGpBeiuvnEhvHqINoYPiKK0pp9gE/HxD/nuhx4oOsd294/gA6Jo62ac8iulLL6ONK+8vftecc0APiAGYhnAHOMcP1eEDEOQRdjXf5b0DTHxgemBS8w9kpDOVaR99d2jj7B2Rupbh72/zkG6QdI2EX6RNVg7G7Mb0NpNX/9JOlL2d9yS/Li8F2tnw9e/HBmFOGxLMXnnFtk6PDK1CR+Yjdi7zXqrbiCNwAM/5DNZHKydnlkMgN40d0tAqgEfnsodos80ZoQJvtUADWnuGt/dP1pQ1UdZGEmyjcgu7cGHZ6Opg/7Wh3ehydw+ut8zMIq10zCTAU+q+uY5xyK9oJ+uVGKVGOSW9cjaRsjbRxVV9ws0MXebYfgZv32zvYch0MzKCJO9z+cxUglw8krt6p/JhmkNqKgf1FkZhwyCA248wyox6B9iWoCjGwTH3mvGKj4+l8uhGzcdzuRwuVglBkfB8VQDlm9P6xua1gbRBkDXW29MRDpB/pK8PbDH9zFSDoAHY/kFHA73nYMZSD3wfEQ1VonH52cLoR88Dmdyp7FchAFsNhdiH1zm808ZVolHfEYr2Lzk/VTGKBurhGhqp2msiJW1i6xpGsIq8fifo4/gZY6dL8byZEQY8M3fZdBxXsezsCwew/QxI7d4okVYfmUfVr0Cz7m1rrh9moFl8RigMh22pqB5V2PuPMcqIaYakF3cTTANtXC/NfM89SqnLpWC2V/8PnXwTMFlfzq8yr/3J3nIrFTWDyksjNRaGdfxShiYZADMPg5eKRC/0590YZV4tHTSFRyj5626MTDbHFdc3U8wD7PyTGKJEeOF+SuqFlxo5ze5WH7BJAMg4CC1wAM/P8Gy2BwGV1MP/Ot6LZZnZLdPHqQMwQn1WBYPcGJn77vIOCS7ZNJ88tIAiICGLvGKjlHNHTSsEo/mDrqSU7ShWwJ9hIVVM/KseZhsF7FgazKLLVknZBZ0Ib1g1wMZwgGJgHM6hCJuNzUXdB/9yNZgnjxWiUfgv8+odUMHt5vLkcVKhk0NFN5xNSx/1BF3rwWrxGOVo5bnNtM78Y0wwrEKQY3Ehz7C/i20WsVC5ZMtpgKN+AzR2Igs7R9Rm5LVjlUzcjGqNjerAxGlBqljWCU2X+60QtJSl6LrsAwIOiI1ux3Sxv0/STz6gWE66+CPTyD9OvxrIVbNyErIcwyC/aJqIWZglSS8secesgyreU4ViLgHrt5sQBTizg3GAlEiFOSkN7sYQCfISItViMhAoawmu/ddExnSywEsPtvdDFHvaOqL3ubdYojGSsvttHHQcl6sIdBKCmOEDf9lSMS27pH7OZ1ZxT15FX0FVf1UGgv09S00+J1T0ns/r6t3gMmzcxxBv/EvlRjPNfoUI8XQ288FlSTPgKKn/dRG6mpHTb5mrkghZSWZ8NtNLm/dfHNT0vItKU6bkzMgbiC0+cijpesSVm5KdHFLSMluV1IgCa6YG7qalOVLtEor+2HyAZFnwK3MNnj8u2/p8U+YO3QGe62T9rEfl504Zr/EUWucOjbG4oJ+i4vBLm+rzw4tPP6dk4O1GmOUIzh/zry5WIPdRi+sGuAJ4Aer996TXRLdNzh7oTgdCZDG6QcfO/cy3zpztQqmtpg0EdnL2n3paGFkZ+9MVfLMPCrqhgLjID/kEFjs8cY2urGegpL8HFdmJhBeTBgd40CvEoki3FqiNQeR2JgokbUpVQ1U+E2g0sZa2+nGunLS0nOJCQJ4Q2WACVk0lkHD5iLOOIMpYrRQwX0HmTCZYlly5CkkHU1KV98o3IIAt+MOjWmpkfHBOWFnpvzN904eq/WxzG8kaVXyab+y+3mdWPWCg17m3550UJSfuyvLyPAWW7sHmKPQQLzxpB/87UXJapdZgd5Y8F4K1DfIJuLkuaLXGfEi2fDpA6kFkVA5Egb487mO5mv1gDCQlUQmN7nsvV9e2I00ybJy0r/+XGjrmfyVX2lNE2/U/icoyZPG6Swmi0OAjBDk13EAAbQRdlZJz/Hzxdbv3t6x535Ofpebi0Ga/5qyuPUnv10Ktz/zQ4HVxiT3Aw9CExsb22j4srnCCw+QiHCRNIEfEyBB5eslBmZWyOEeFvXczmzraKSiEY7eQvXDny/a6WGyxFZNcM6Zzxcd97a6md4anfI8ObMtGdIWTfIyW/XtHsaHvCxERqpZ4YUAKQAhnpPpB0u08iNMcHw9lIjILNTBK/WzXwogKcQHpqGhdfhiZM3OU7nm6+LX7Ls/JmFdNsG7XzxE1uEdvSOounEIcsN9vvn4iIT0DIymP+6AmwjE2udU/7g6we8p9A6M/hlWDW4nEFlsLkO8AkgkUJ0prowbprEIvA0fBRLcF/eNhEA4W7NsnqWxkkD8I6Lmk73pN9JFVCp+12s/35/Bm7P5SBOlKOIVQK8CxsPQ1VKVlZMjEsCdNbTlWroYc3YDYU7utlYxV9lzIje3rBer+FxPfX76bJHtOsOt6wyw6jUYYXI6+0bBAIKUFIEsSzTVV6hvpUH4w8fnRHpe55GfCqLvtIRfeIM6yHzb+x70BozRuubh//uz9IMDmaracjHnVqooyrC549UNQ/gyIeij7FN+pRCjsDw9zR0MahfDRF+BJ8B48v4mF82/Vlg17YLUDIww2X9H1S6BOcsgGLI36UXXIctNetSm5BiFNK9QnGIIi68jtUCbTUl1LcNw/rWEeievFGQZvvrDO9GpTRwOrs/jM1ptNyUiJX/N1f929c0y610Ir4YC8Mq/vGVPoq+vL4vDjY2q0zZWWrNUm2+huMTcafY6khUaWNnD5Oz70GrrFrO7t5tGpAlHdlhudjWkS0l1dDL0NShHDy/8+mPbh0+6tx/NCgqo7Bzj2i9Qf1zSG3e97l55H5QHPwRUfuv7ZJAzvvYdw4qCbto42vimLn6GKH4PrX7aTPvlmL2mKpnXA+3dDBn7qJW77/HNE4v23pGtRx5CGU2yizxxvqixlde6gIVHEmXRdZinBCKLxSms7PsxoEL7Td6eherymKNnC2FQwaGqhqGPffOICyORcQjE8fWfpFc8GwS9vVeKlElozvSbCTQGS+Otf43dbwlKalzUr9x1V8Yu8hm/l2clu7THbF08DBj3gxnldZP2s3jTgsaVU3+Vwu+c0t69PnmkhbydLxO3hLNXK6eMDRabY7gunmQV7h/7MvLyFn8MQ1bsvDPdFBF3txlpXzn5B649sAHBCfXwQqf9ywXiDCQ+bCXbRUCz/RokYu7jcrmmGxPVVsSuP/gAmYYinatO76deS2iAZsNn8FcxSmsHwHLfy+UwCfpcnvrQXT55SC1gun0Jr5PZ4G95Lza7sAHQNnJLo802JopcGZ8gJaedaBkmYxMRN3n/QgCHy70YVaPgEIWMQpBV+IYDGalZ7RNuCgzRxqCNDNfe5J1gGIL0gmQco5vapy4EtnbS1Zxi1J1jIYhh1QtgopS1jbDfngZTgUCDDQB42yFqgdcSG7H8CsXV/cr2UbJW4ak5HVg1mar6QWQR9pb3XVPXeLstyVj7gvj0FosNt+AROmtv7vgqZ/d3jzfuz7iV2Spy48Lveg2MiD3f52H5BUfPF0PnhCY2YFnYAMh15RZGmm9MFO7uCfqHmLYeSSTzsORXsh0YEm3dDHj7X4OrYNgcu1C8xCvVZEPixNJnQWWf1/EsXqvbRJw4V9w7OMu+HQDXOr6fiuZPWsqta6bK2kVYbEoUXvqftFN/0q/0rE/+n/+sPvy+BVbxgTb69KeCyxfLXTabHNxmVt1A7R1k9lPHBobGOntHmzvpHV0jCOZBmMshteSOy6vKhpxx3uqCJ909PnnB50sWv2MY/quzrdA3BzPzsKh79ZZUxxXz8iPWCfbud/vmhVyqiAh1+WC9keAcYJIBUDct9kyG8FSS4G6k83KJt6RmwN49CY1ykAwBQfkLKTgk+GQiUZaookSap07RUSdraZDNDBTgSacvluloUcrj3Sc+q2loozl4JmtpkotubJDoa4jPfy/y+634wvk3vthhmZ7f9fZ7KctW6WVfcyEKagAB/H54SRDEQc0rGw89wDKfvsHRQ78U7DmV+5VfyT8xdSnZ7YVV/ZCBwqQ7QGWyhdwUOBtShbSuun6cLhwHz8PcqRZw4OcCLItBRf3gps8ykUrA4m0pXb0jNh5JRLPQ3NKpO+1TDQA8IdVWCzx77SmWJed/v85Byv5fCm3LjTLZ9pBuzL82Ef5mACLhj5fLlZfGgEdtPfIIJjhesqMa+M3fIgp3EQaAR5rAPGUYkpDZilUSQqWPLdqSjHSDwpJffmGQnt8J8Rvy+Ck9NgV4+sodaRCC4PItX/I+srgUUwdv7/Jx+kToFEaEAUBeRR/FLgKCZl6FuB9HTAEyBUWHKMqCyCdCm5be3z2Gvg3kJ2HT4bo/A6a/T37IN3KNd9yeFpzQgEyumbolQL6Dz5iMaAOA62nPIfBprYgrmFOWCty43wJNDrG/50UVBj6j6hSj5hz36tc3z9tp8MdLE/SDBQ3/6S8FyCwMRpGqU/QM7zCtAUAgOLRhiOqymIwnnVglId9dLgMvhPoVy+Pjf0TyZqiPTr+sYG/ca1nlfRctiOT9WYYhw+BcfiZ34o9iSBYVl0RnzLhlOpMBQEhiAxTsBKvwmft9OiCP4FXfqgHfvdj0Z7O5iwTeXNFb3zq8FY7qBsF7ux96ANOz8460PyNrIHz5/lMO52g6xz4o7BZcOB2zGACk5naoL4+BrOvTn54MDku2+w1ALW+9IREGBowogSazsAsaBfJQxeWxSOuKx6HMfCFP6xsa3XAwAyobm02JJbWzf7o1uwFAdRN1xQdpEApsNiamTZMIzUDh0375BZEqDlHg2QLN3tN5SDnAeF18dOrL9XdIisBltVbwrPrgZPbMX9lMIJYBAMRmn3/KkEUo+OW2o49gIsMHxAPiKdIJst+SPMTvQxg8PpfKhD9dS81uX73rLtQSio7Rl2NEL8yIRFwDBEAp4/oR72MHyDp3ncp9WCjBFwm8bFclAAY6lvlA0gZZKiTeMMaQ8bWdJ7MFpbP4SGaAgISMVvA23gd9RiHLd6R9f7m8tGZAnD3T9758hOYFnQmqhIQXpuRj54qsPJJ4zWEc4nE4M3M2fxWJZN+NTgDXZOR1QV6UeL+V2UFHyrKW1qp25sqrHLRWLFJXkifJkYlyZGnBuieLzUslmGPcgqf9u07mMNnj+noKrc8GEYOtaqzo5W68x9NkqZ264M6SMkcDJmjuoGeV9Mbdac6v6Gtr4C3uIhIByUuT5EhK8B9+jyMmi0tjsFl0FmJCPkskyUsb68ovtVXb5mbkvFidt7LwGryuAROMsbjtPYzipwNPm4YhdHb3Mdt7RkfG2JDJy5OltSHfVpPV1ZRbYKa80FJFW41MEE6J5wxC/w9O3T4MXoVnsQAAAABJRU5ErkJggg==";

        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }

        #endregion

    }
}
