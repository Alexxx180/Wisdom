using Microsoft.Win32;
using System.IO;
using System.Windows;
using Wisdom.Model;
using static Wisdom.Writers.AutoGenerating.Documents.DisciplineProgram;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        private static readonly string _documentFilter = 
            "Документ Microsoft Word (*.docx)|*.docx|" +
            "Документ Word 97-2003 (*.doc)|*.doc|" +
            "Текст в формате RTF (*.rtf)|*.rtf";

        private static readonly string _templateFilter =
            "Шаблон пользовательских данных (*.json)|*.json";

        private static void TruncateFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        public static void WriteDocument(
            DisciplineProgram program,
            string fileName = "")
        {
            string filter = _documentFilter;

            SaveFileDialog dialog = CallWriter(filter, fileName);
            if (!dialog.ShowDialog().Value)
                return;
            TruncateFile(dialog.FileName);

            try
            {
                WriteDocX(dialog.FileName, program);
            }
            catch (IOException exception)
            {
                string message = "Файл открыт в другой " +
                    "программе или используется другим " +
                    "процессом. Дальнейшая запись в файл" +
                    " невозможна.\nПолное сообщение:\n";
                _ = MessageBox.Show(message + exception.Message);
            }
        }

        public static void WriteTemplate(
            DisciplineProgram program,
            string fileName = "")
        {
            string filter = _templateFilter;

            SaveFileDialog dialog = CallWriter(filter, fileName);
            if (dialog.ShowDialog().Value)
            {
                TruncateFile(dialog.FileName);
                ProcessJson(dialog.FileName, program);
            }
        }

        public static SaveFileDialog
            CallWriter(string filter, string fileName)
        {
            return new SaveFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }
    }
}