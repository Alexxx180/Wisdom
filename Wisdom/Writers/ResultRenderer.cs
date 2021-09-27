namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        public static void WriteDoc(System.Windows.Documents.FlowDocument doc, string filename)
        {
            GeneratedClass class1 = new GeneratedClass();
            class1.CreatePackage(@"C:\Users\Администратор\Desktop\Работы\Курсовая\Tests\Cool.docx");
        }
    }
}