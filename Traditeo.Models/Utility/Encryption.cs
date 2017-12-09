using System;
using System.Security.Cryptography;
using System.Text;

namespace Traditeo.Models.Utility
{
    public static class Encryption
    {
        private const string _cryptoKey = "ACRM";
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public static string Encrypt(string value)
        {
            if (value == null || value.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(value);
                TripleDESCryptoServiceProvider serviceProvider = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                serviceProvider.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_cryptoKey));
                serviceProvider.IV = IV;
                result = Convert.ToBase64String(serviceProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }
            return result;
        }

        public static string Decrypt(string value)
        {
            if (value == null || value.Length == 0) return string.Empty;

            string result = string.Empty;
            try
            {
                byte[] buffer = new byte[100];
                buffer = Convert.FromBase64String(value);
                TripleDESCryptoServiceProvider serviceProvider = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                serviceProvider.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_cryptoKey));
                serviceProvider.IV = IV;
                result = Encoding.ASCII.GetString(serviceProvider.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
