using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static Wisdom.Writers.AutoGenerating.AutoFiller;
using static Wisdom.Writers.Markup;

namespace Wisdom.Writers.AutoGenerating.Documents
{
    public static class DisciplineProgram
    {
        private const string fileName = @"\TestResources\Templates\BaseTemplate.docx";
        private static string _template => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + fileName;

        public static void ProcessJson(string path, Model.DisciplineProgram program)
        {
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(program);
            Save(path, jsonUtf8Bytes);
        }

        public static void WriteDocX(string filepath, Model.DisciplineProgram program)
        {
            FullProcessing(_template, filepath, program);
        }

        private static void FullProcessing(
            string templatePath, string generatePath,
            Model.DisciplineProgram program
            )
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

                    FastProcessing(paragraphs, cells, program);
                    DetailProcessing(paragraphs, program);

                    using (StreamWriter sw = new StreamWriter(template.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                }

                // Save the file with the new name
                Save(generatePath, stream);
            }
        }

        private static void FastProcessing(
            IEnumerable<Paragraph> paragraphs,
            IEnumerable<TableCell> cells,
            Model.DisciplineProgram program
            )
        {
#warning Config Feature
            // Make a config file with choose where to change
            // text expressions to necessary data

            string discipline = "#DISCIPLINE";
            ReplaceInParagraphs(paragraphs, discipline, program.Name);

            string speciality = "#SPECIALITY";
            ReplaceInParagraphs(paragraphs, speciality, program.ProfessionName);
            ReplaceInCells(cells, speciality, program.ProfessionName);

            string max = "#MAX-HOURS";
            ReplaceInParagraphs(paragraphs, max, program.MaxHours);

            string auditory = "#AUD-HOURS";
            ReplaceInParagraphs(paragraphs, auditory, program.EduHours);

            string meta = "#META-";
            for (byte i = 0; i < program.MetaData.Count; i++)
                ReplaceInParagraphs(paragraphs, meta + i, program.MetaData[i].Hours);

            string hours = "#HOURS-";
            for (byte i = 0; i < program.Hours.Count; i++)
            {
                ReplaceInParagraphs(paragraphs, hours + i, program.Hours[i].Value.ToString());
                ReplaceInCells(cells, hours + i, program.Hours[i].Value.ToString());
            }
        }

        private static void DetailProcessing(
            IEnumerable<Paragraph> paragraphs, 
            Model.DisciplineProgram program
            )
        {
            string competetions = "#COMPETETIONS";
            ReplaceInParagraphs(paragraphs, competetions, CompetetionsTable(program));

            string themePlan = "#THEME-PLAN";
            ReplaceInParagraphs(paragraphs, themePlan, ThemePlanTable(program));
        }
    }
}
