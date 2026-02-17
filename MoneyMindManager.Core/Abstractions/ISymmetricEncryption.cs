namespace MoneyMindManager.Core.Abstractions
{
    public interface ISymmetricEncryption
    {
        /// <summary>
        /// Encrypts a plain text string using AES 128-bit encryption with a fixed IV (not secure for production).
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>Base64-encoded encrypted string.</returns>
        string Encrypt(string plainText);

        /// <summary>
        /// Decrypts a Base64-encoded AES 128-bit encrypted string using a fixed IV (must match Encrypt method).
        /// </summary>
        /// <param name="cipherText">The Base64-encoded encrypted text.</param>
        /// <returns>The decrypted original plain text.</returns>
        string Decrypt(string cipherText);
    }
}
