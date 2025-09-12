using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KhaledUtils;

namespace MoneyMindManagerGlobal
{
    public static class clsSymmetricEncryption
    {
        private static string _key = "dk234)^&(*^dk234";

        /// <summary>
        /// Encrypts a plain text string using AES 128-bit encryption with a fixed IV (not secure for production).
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>Base64-encoded encrypted string.</returns>
        public static string Encrypt(string plainText)
        {
            return clsCryptography.clsSymmetricEncryption.clsText.Encrypt(plainText, _key);
        }


        /// <summary>
        /// Decrypts a Base64-encoded AES 128-bit encrypted string using a fixed IV (must match Encrypt method).
        /// </summary>
        /// <param name="cipherText">The Base64-encoded encrypted text.</param>
        /// <returns>The decrypted original plain text.</returns>
        public static string Decrypt(string cipherText)
        {
            return clsCryptography.clsSymmetricEncryption.clsText.Decrypt(cipherText, _key);
        }
    }
}
