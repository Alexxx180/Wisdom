using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using Wisdom.AutoGenerating;
using Wisdom.Model;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        private static void TruncateFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        public static void WriteDoc(string fileName, DisciplineProgram program)
        {
            TruncateFile(fileName);
            try
            {
                AutoFiller.WriteDocX(fileName, program);
            }
            catch (IOException exception)
            {
                string message = "Файл открыт в другой программе или используется другим процессом. Дальнейшая запись в файл невозможна.\nПолное сообщение:\n";
                _ = MessageBox.Show(message + exception.Message);
            }
        }

        public static void WriteJson(string fileName, DisciplineProgram program)
        {
            TruncateFile(fileName);
            string testFile = @"Resources\Templates\" + fileName + ".json";
            string executingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fullName = $"{executingDirectory}\\{testFile}";
            AutoFiller.WriteUserInput(fullName, program);
        }

        public static void CallWriter(string fileName, DisciplineProgram program)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = $"{fileName}.docx",
                Filter =
                "Документ Microsoft Word (*.docx)|*.docx|" +
                "Документ Word 97-2003 (*.doc)|*.doc|" +
                "Текст в формате RTF (*.rtf)|*.rtf"
            };
            if (dialog.ShowDialog().Value)
                WriteDoc(dialog.FileName, program);
        }
    }
}