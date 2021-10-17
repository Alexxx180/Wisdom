using Microsoft.Win32;
using System.IO;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        private static readonly GeneratedClass renderer = new GeneratedClass();

        public static void WriteDoc(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
            renderer.CreatePackage(fileName);
        }

        //Write document method used for tests
        public static void WriteDoc()
        {
            string testFile = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\Wisdom\TestResources\Output\Result.docx";
            WriteDoc(testFile);
        }

        public static void CallWriter(string fileName)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = fileName,
                Filter =
                "Документ Microsoft Word (*.docx)|*.docx|" +
                "Документ Word 97-2003 (*.doc)|*.doc|" +
                "Текст в формате RTF (*.rtf)|*.rtf"
            };
            if (dialog.ShowDialog().Value)
                WriteDoc(dialog.FileName);
        }
    }
}