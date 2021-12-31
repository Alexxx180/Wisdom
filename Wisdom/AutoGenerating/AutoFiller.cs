using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Wisdom.Model;
using static Wisdom.Model.ProgramContent;
using static Wisdom.Writers.Markup;

namespace Wisdom.AutoGenerating
{
    public static class AutoFiller
    {
        private const string fileName = @"\TestResources\Templates\BaseTemplate.docx";
        private static string _template => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + fileName;

        public static void WriteUserInput(string path, DisciplineProgram program)
        {
            ProcessJson(path, program);
        }

        private static void ProcessJson(string path, DisciplineProgram program)
        {
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(program);
            Save(path, jsonUtf8Bytes);
        }

        public static void WriteDocX(string filepath)
        {
            FullProcessing(_template, filepath);
        }

        private static void FullProcessing(string templatePath, string generatePath)
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

                    FastProcessing(paragraphs, cells);
                    DetailProcessing(paragraphs);

                    using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                }
                // Save the file with the new name
                Save(generatePath, stream);
            }
        }

        private static void FastProcessing(IEnumerable<Paragraph> paragraphs, IEnumerable<TableCell> cells)
        {
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
        }

        private static void DetailProcessing(IEnumerable<Paragraph> paragraphs)
        {
            string competetions = "#COMPETETIONS";
            ReplaceInParagraphs(paragraphs, competetions, CompetetionsTable());

            string themePlan = "#THEME-PLAN";
            ReplaceInParagraphs(paragraphs, themePlan, ThemePlanTable());
        }

        private static void SaveMessage(string exception)
        {
            string noLoad = "Не удалось сохранить файл.";
            string message = "\nУбедитесь, что посторонние процессы не мешают операции.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        private static void Save(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (IOException exception)
            {
                SaveMessage(exception.Message);
            }
        }

        private static void Save(string path, MemoryStream stream)
        {
            Save(path, stream.ToArray());
        }

        private static void ReplaceInParagraphs(IEnumerable<Paragraph> paragraphs, string find, string replaceWith)
        {
            foreach (var p in paragraphs)
                ReplaceText(p, find, replaceWith);
        }

        private static void ReplaceInParagraphs(IEnumerable<Paragraph> paragraphs, string find, Table replaceWith)
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

                        txt.Space = new EnumValue<SpaceProcessingModeValues>(SpaceProcessingModeValues.Preserve); // in case value starts/ends with whitespace
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

        public static void ReplaceText(Paragraph paragraph, string find, Table replaceWith)
        {
            var texts = paragraph.Descendants<Text>();
            int count = texts.Count();
            for (int t = 0; t < count; t++)
            {   // figure out which Text element within the paragraph contains the starting point of the search string
                Text txt = texts.ElementAt(t);
                for (int c = 0; c < txt.Text.Length; c++)
                {
                    var match = IsMatch(texts, t, c, find);
                    if (match != null)
                    {   // now replace the text
                        OpenXmlElement parent = paragraph.Parent;
                        paragraph.InsertAfterSelf(replaceWith);
                        parent.RemoveChild(paragraph);
                        return;
                    }
                }
            }
        }   
    }
}