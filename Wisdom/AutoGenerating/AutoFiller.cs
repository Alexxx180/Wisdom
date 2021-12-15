using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Thm15 = DocumentFormat.OpenXml.Office2013.Theme;
using Ds = DocumentFormat.OpenXml.CustomXmlDataProperties;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using W14 = DocumentFormat.OpenXml.Office2010.Word;
using W15 = DocumentFormat.OpenXml.Office2013.Word;
using System.IO;
using static Wisdom.Model.ProgramContent;
using static Wisdom.Writers.Markup;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using System.Diagnostics;
using static Wisdom.Customing.ResourceHelper;
//using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using Wisdom.Binds;
using Microsoft.Win32;
using System.Collections.Generic;
using Wisdom.Model;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.Tests.TotalTest;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Wisdom.AutoGenerating
{
    public static class AutoFiller
    {
        private const string fileName = @"\TestResources\Templates\BaseTemplate.docx";
        private static string _template => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + fileName;

        public static void WriteDocX(string filepath)
        {
            FastProcessing(_template, filepath);
        }

        // Bad work with couple of <w:t></w:t>
        //public static string RegexReplace(string template, string original, string toReplace)
        //{
        //    Regex regexText = new Regex(template);
        //    return regexText.Replace(original, toReplace);
        //}

        //docText = RegexReplace(discipline, docText, DisciplineName);

        private static void ReplaceInParagraphs(IEnumerable<Paragraph> paragraphs, string find, string replaceWith)
        {
            foreach (var p in paragraphs)
                ReplaceText(p, find, replaceWith);
        }

        private static void ReplaceInCells(IEnumerable<TableCell> cells, string find, string replaceWith)
        {
            foreach (TableCell cell in cells)
                foreach (var cellData in cell)
                {
                    Paragraph p = cellData as Paragraph;
                    if (p != null)
                        ReplaceText(p, find, replaceWith);
                }
        }

        private static void FastProcessing(string templatePath, string generatePath)
        {
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, Convert.ToInt32(byteArray.Length));
                using (WordprocessingDocument template = WordprocessingDocument.Open(stream, true))
                {
                    string docText = null;
                    using (StreamReader sr = new StreamReader(template.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    var body = template.MainDocumentPart.Document.Body;
                    var paragraphs = body.Elements<Paragraph>();
                    var cells = body.Descendants<TableCell>();

                    string discipline = "#DISCIPLINE";
                    ReplaceInParagraphs(paragraphs, discipline, DisciplineName);

                    string speciality = "#SPECIALITY";
                    ReplaceInParagraphs(paragraphs, speciality, ProfessionName);
                    ReplaceInCells(cells, speciality, ProfessionName);

                    string max = "#MAX-HOURS";
                    ReplaceInParagraphs(paragraphs, max, MaxHours);

                    string auditory = "#AUD-HOURS";
                    ReplaceInParagraphs(paragraphs, auditory, EduHours);

                    string meta = "#META-";
                    for (byte i = 0; i < MetaDataCollection.Count; i++)
                        ReplaceInParagraphs(paragraphs, meta + i, MetaDataCollection[i]);

                    string hours = "#HOURS-";
                    for (byte i = 0; i < HoursCollection.Count; i++)
                    {
                        ReplaceInParagraphs(paragraphs, hours + i, HoursCollection[i]);
                        ReplaceInCells(cells, hours + i, HoursCollection[i]);
                    }

                    using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                }
                // Save the file with the new name
                File.WriteAllBytes(generatePath, stream.ToArray());
            }
        }

        static Match IsMatch(IEnumerable<Text> texts, int t, int c, string find)
        {
            int ix = 0;
            for (int i = t; i < texts.Count(); i++)
            {
                for (int j = c; j < texts.ElementAt(i).Text.Length; j++)
                {
                    if (find[ix] != texts.ElementAt(i).Text[j])
                    {
                        return null; // element mismatch
                    }
                    ix++; // match; go to next character
                    if (ix == find.Length)
                        return new Match() { EndElementIndex = i, EndCharIndex = j }; // full match with no issues
                }
                c = 0; // reset char index for next text element
            }
            return null; // ran out of text, not a string match
        }

        public static void ReplaceText(Paragraph paragraph, string find, string replaceWith)
        {
            var texts = paragraph.Descendants<Text>();
            for (int t = 0; t < texts.Count(); t++)
            {   // figure out which Text element within the paragraph contains the starting point of the search string
                Text txt = texts.ElementAt(t);
                for (int c = 0; c < txt.Text.Length; c++)
                {
                    var match = IsMatch(texts, t, c, find);
                    if (match != null)
                    {   // now replace the text
                        string[] lines = replaceWith.Replace(Environment.NewLine, "\r").Split('\n', '\r'); // handle any lone n/r returns, plus newline.

                        int skip = lines[lines.Length - 1].Length - 1; // will jump to end of the replacement text, it has been processed.

                        if (c > 0)
                            lines[0] = txt.Text.Substring(0, c) + lines[0];  // has a prefix
                        if (match.EndCharIndex + 1 < texts.ElementAt(match.EndElementIndex).Text.Length)
                            lines[lines.Length - 1] = lines[lines.Length - 1] + texts.ElementAt(match.EndElementIndex).Text.Substring(match.EndCharIndex + 1);

                        txt.Space = new EnumValue<SpaceProcessingModeValues>(SpaceProcessingModeValues.Preserve); // in case your value starts/ends with whitespace
                        txt.Text = lines[0];

                        // remove any extra texts.
                        for (int i = t + 1; i <= match.EndElementIndex; i++)
                        {
                            texts.ElementAt(i).Text = string.Empty; // clear the text
                        }

                        // if 'with' contained line breaks we need to add breaks back...
                        if (lines.Count() > 1)
                        {
                            OpenXmlElement currEl = txt;
                            Break br;

                            // append more lines
                            var run = txt.Parent as Run;
                            for (int i = 1; i < lines.Count(); i++)
                            {
                                br = new Break();
                                run.InsertAfter<Break>(br, currEl);
                                currEl = br;
                                txt = new Text(lines[i]);
                                run.InsertAfter<Text>(txt, currEl);
                                t++; // skip to this next text element
                                currEl = txt;
                            }
                            c = skip; // new line
                        }
                        else
                        {   // continue to process same line
                            c += skip;
                        }
                    }
                }
            }
        }

        

        private static void DetailProcessing()
        {
            //WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filepath, true);
            //Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
        }

        class Match
        {
            /// <summary>
            /// Last matching element index containing part of the search text
            /// </summary>
            public int EndElementIndex { get; set; }
            /// <summary>
            /// Last matching char index of the search text in last matching element
            /// </summary>
            public int EndCharIndex { get; set; }
        }
    }

    
}

public static class OpenXmlTools
{
    // filters control characters but allows only properly-formed surrogate sequences
    private static Regex _invalidXMLChars = new Regex(
        @"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]",
        RegexOptions.Compiled);
    /// <summary>
    /// removes any unusual unicode characters that can't be encoded into XML which give exception on save
    /// </summary>
    public static string RemoveInvalidXMLChars(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        return _invalidXMLChars.Replace(text, "");
    }
}