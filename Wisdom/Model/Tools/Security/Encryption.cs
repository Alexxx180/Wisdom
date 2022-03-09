using System;
using System.Security.Cryptography;
using System.Text;

namespace Wisdom.Model.Tools.Security
{
    internal class Encryption
    {
        private static readonly byte[] s_additionalEntropy;

        static Encryption()
        {
            s_additionalEntropy = new byte[] {
                9, 8, 7, 6, 5, 8, 1, 2, 6,
                9, 4, 2, 0, 3, 5, 5, 8, 2
            };
        }

        internal static byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not encrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        internal static byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not decrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
