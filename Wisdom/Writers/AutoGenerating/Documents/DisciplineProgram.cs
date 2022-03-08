using System;
using System.IO;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static Wisdom.Writers.AutoGenerating.AutoFiller;
using static Wisdom.Writers.Markup.DisciplineProgramMarkup;
using Wisdom.Model;
using Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram;

namespace Wisdom.Writers.AutoGenerating.Documents
{
    public static class DisciplineProgram
    {
        public static readonly Pair<string, string>[]
            Expressions = new Pair<string, string>[]
            {
                new Pair<string, string>("Название дисциплины", "#DISCIPLINE"),
                new Pair<string, string>("Название специальности", "#SPECIALITY"),
                new Pair<string, string>("Максимальная нагрузка", "#MAX-HOURS"),
                new Pair<string, string>("Аудиторная нагрузка", "#AUD-HOURS"),
                new Pair<string, string>("Метаданные (Группа)", "#META-"),
                new Pair<string, string>("Общие часы (Группа)", "#HOURS-")
            };

        private const string fileName = @"\TestResources\Templates\BaseTemplate.docx";
        private static string _template => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + fileName;

        public static void WriteDocX(string filepath, Model.Documents.DisciplineProgram program)
        {
            FullProcessing(_template, filepath, program);
        }

        private static void FullProcessing(
            string templatePath, string generatePath,
            Model.Documents.DisciplineProgram program
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
            Model.Documents.DisciplineProgram program
            )
        {
            Dictionary<string, int>
                options = SettingsPart.DisciplineProgramProcessing.Options;

            string discipline = Expressions[0].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[discipline], discipline, program.Name);

            //ReplaceInParagraphs(paragraphs, discipline, program.Name);

            string speciality = Expressions[1].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[speciality], speciality, program.ProfessionName);

            //ReplaceInParagraphs(paragraphs, speciality, program.ProfessionName);
            //ReplaceInCells(cells, speciality, program.ProfessionName);

            string max = Expressions[2].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[max], max, program.MaxHours);

            //ReplaceInParagraphs(paragraphs, max, program.MaxHours);

            string auditory = Expressions[3].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[auditory], auditory, program.EduHours);

            //ReplaceInParagraphs(paragraphs, auditory, program.EduHours);

            string meta = Expressions[4].Value;
            //CustomizeableProcessing(paragraphs, cells,
            //    options[meta], meta, program.MetaData);

            for (byte i = 0; i < program.MetaData.Count; i++)
                ReplaceInParagraphs(paragraphs, meta + i, program.MetaData[i].Hours);

            string hours = Expressions[5].Value;
            for (byte i = 0; i < program.Hours.Count; i++)
            {
                ReplaceInParagraphs(paragraphs, hours + i, program.Hours[i].Count.ToString());
                ReplaceInCells(cells, hours + i, program.Hours[i].Count.ToString());
            }
        }

        private static void DetailProcessing(
            IEnumerable<Paragraph> paragraphs,
            Model.Documents.DisciplineProgram program
            )
        {
            string competetions = "#COMPETETIONS";
            ReplaceInParagraphs(paragraphs, competetions, CompetetionsTable(program));

            string themePlan = "#THEME-PLAN";
            ReplaceInParagraphs(paragraphs, themePlan, ThemePlanTable(program));

            string sources = "#SOURCES";
            ReplaceInParagraphs(paragraphs, sources, Literature(program.Sources));
        }
    }
}
