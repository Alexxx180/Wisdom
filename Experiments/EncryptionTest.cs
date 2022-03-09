using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Wisdom.Model.Tools.Security;

namespace Experiments
{
    /// <summary>
    /// Tests to check correct data conversion
    /// </summary>
    [TestClass]
    public class EncryptionTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            byte[] someData = { 0, 1, 2, 3, 4, 5 };
            Trace.Write("Original: ");
            Print(someData);

            byte[] encrypted = Encryption.Protect(someData);
            Trace.Write("\nEncrypted: ");
            Print(encrypted);

            byte[] decrypted = Encryption.Unprotect(encrypted);
            Trace.Write("\nDecrypted: ");
            Print(decrypted);
        }

        private static void Print(byte[] data)
        {
            Trace.WriteLine("");
            for (byte i = 0; i < data.Length; i++)
            {
                Trace.Write($"{data[i]}; ");
            }
        }
    }
}