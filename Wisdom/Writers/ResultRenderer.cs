using Microsoft.Win32;
using System.IO;
using Wisdom.Model;
using Wisdom.Model.Documents;
using static Wisdom.Writers.AutoGenerating.Processors;

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

        internal static void TruncateFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static Pair<string, bool> UserAgreement(string fileName = "")
        {
            SaveFileDialog dialog = CallWriter(_documentFilter, fileName);

            bool isAgreed = dialog.ShowDialog().Value;
            Pair<string, bool> head = new Pair<string, bool>
                (dialog.FileName, isAgreed);

            return head;
        }

        public static void WriteTemplate
            (DisciplineProgram program, string fileName = "")
        {
            string filter = _templateFilter;

            SaveFileDialog dialog = CallWriter(filter, fileName);
            if (dialog.ShowDialog().Value)
            {
                TruncateFile(dialog.FileName);
                ProcessJson(dialog.FileName, program);
            }
        }
    }
}