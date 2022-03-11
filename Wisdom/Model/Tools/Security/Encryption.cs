using Serilog;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

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

        private static byte[] GetBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        internal static byte[] ProtectData(string data)
        {
            byte[] protectedData = Protect(GetBytes(data));
            return protectedData;
        }

        internal static string UnprotectData(byte[] data)
        {
            if (data is null)
                return "";
            byte[] unprotectedData = Unprotect(data);
            return unprotectedData is null ? "" :
                GetString(unprotectedData);
        }

        private static byte[] Protect(byte[] data)
        {
            byte[] protectedData = null;
            try
            {
                protectedData = ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException exception)
            {
                Log.Error("Exception on decryption: " +
                    exception.Message);
                EncryptionMessage(exception.Message);
            }
            return protectedData;
        }

        private static byte[] Unprotect(byte[] data)
        {
            byte[] unprotectedData = null;
            try
            {
                unprotectedData = ProtectedData.Unprotect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException exception)
            {
                Log.Error("Exception on decryption: " +
                    exception.Message);
                EncryptionMessage(exception.Message);
            }
            return unprotectedData;
        }

        internal static void EncryptionMessage(string exception)
        {
            string message = "Похоже ваши учетные " +
                "данные устарели, войдите заново.\n" +
                "\nПолное сообщение:\n";
            _ = MessageBox.Show(message + exception);
        }
    }
}