using System;
using System.IO;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static Wisdom.Writers.AutoGenerating.AutoFiller;
using static Wisdom.Writers.AutoGenerating.Processors;

namespace Wisdom.Writers.AutoGenerating.Documents
{
    public abstract class EducationalProgram<TProgram>
    {
        public void WriteDocument(string templatePath,
             string filePath, TProgram program)
        {
            try
            {
                TruncateFile(filePath);
                FullProcessing(templatePath, filePath, program);
            }
            catch (IOException exception)
            {
                WriteMessage(exception.Message);
            }
        }

        private void FullProcessing(string templatePath,
            string generatePath, TProgram program)
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

        protected abstract void FastProcessing(
            IEnumerable<Paragraph> paragraphs,
            IEnumerable<TableCell> cells,
            TProgram program
            );

        protected abstract void DetailProcessing(
            IEnumerable<Paragraph> paragraphs, TProgram program
            );
    }
}