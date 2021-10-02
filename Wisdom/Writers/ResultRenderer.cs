namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        public static void WriteDoc(string filename)
        {
            GeneratedClass class1 = new GeneratedClass();
            class1.CreatePackage(filename);
        }

        //Write document method used for tests
        public static void WriteDoc()
        {
            GeneratedClass class1 = new GeneratedClass();
            string testDirectory = @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\Wisdom\Wisdom\TestResources\Output\Result.docx";
            class1.CreatePackage(testDirectory);
        }
    }
}