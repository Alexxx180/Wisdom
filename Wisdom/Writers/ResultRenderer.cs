using System.IO;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        public static void WriteDoc(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
            GeneratedClass class1 = new GeneratedClass();
            class1.CreatePackage(fileName);
        }

        //Write document method used for tests
        public static void WriteDoc()
        {
            string testFile = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\Wisdom\TestResources\Output\Result.docx";
            if (File.Exists(testFile))
                File.Delete(testFile);
            GeneratedClass class1 = new GeneratedClass();
            class1.CreatePackage(testFile);
        }
    }
}