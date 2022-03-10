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

        internal static byte[] GetBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        internal static string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        //internal static string Protect(string text)
        //{
        //    return GetString(Protect(GetBytes(text)));
        //}

        //internal static string Unprotect(string text)
        //{
        //    System.Diagnostics.Trace.WriteLine(text);
        //    System.Diagnostics.Trace.WriteLine(text is null);
        //    byte[] b = GetBytes(text);
        //    System.Diagnostics.Trace.WriteLine(b);
        //    System.Diagnostics.Trace.WriteLine(b is null);
        //    byte[] un = Unprotect(b);
        //    System.Diagnostics.Trace.WriteLine(un);
        //    System.Diagnostics.Trace.WriteLine(un is null);
        //    string lol = GetString(un);
        //    System.Diagnostics.Trace.WriteLine(lol);
        //    System.Diagnostics.Trace.WriteLine(lol is null);
        //    return lol;
        //    //return GetString(Unprotect(GetBytes(text)));
        //}

        internal static byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
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
                throw e;
                return null;
            }
        }
    }
}