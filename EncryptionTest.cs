﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using static ControlMaterials.Tools.Security.Encryption;

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
            string someData = "Hello";
            Trace.Write("Original: ");
            Trace.Write(someData);

            byte[] encrypted = ProtectData(someData);
            Trace.Write("\nEncrypted: ");
            Print(encrypted);

            string decrypted = UnprotectData(encrypted);
            Trace.Write("\nDecrypted: ");
            Trace.Write(decrypted);
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