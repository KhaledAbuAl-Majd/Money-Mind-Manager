using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManagerGlobal
{
    public static class clsHashing
    {
        /// <summary>
        /// Add salt To password Before Hashing
        /// </summary>
        /// <returns>Passowrd + salt</returns>
        public static string GetSaltedPassword(string password, string salt)
            => KhaledUtils.clsHashing.GetSaltedPassword(password, salt);

        /// <summary>
        /// Generate A salt For Hashing 
        /// </summary>
        /// <returns>
        /// Generated salt With Lenght = 24
        /// </returns>
        public static string GenerateSalt() => KhaledUtils.clsHashing.GenerateSalt();

        /// <summary>
        /// Hashing Input Using SHA256
        /// </summary>
        /// <param name="input">The Input (password + salt) Will be Hashed</param>
        /// <returns>Hashed String With Length = 64</returns>
        public static string ComputeHash(string input) => KhaledUtils.clsHashing.ComputeHash(input);

        /// <summary>
        /// Verify if entered password (with salt) matches hashed password
        /// </summary>
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
            => KhaledUtils.clsHashing.VerifyPassword(enteredPassword, storedHash, storedSalt);

        /// <summary>
        /// Generates a new cryptographic salt and computes the SHA256 hash of the provided password with the salt appended.
        /// </summary>
        /// <param name="password">The plain text password to be hashed</param>
        /// <returns>
        /// A tuple containing:
        /// - <c>salt</c>: A randomly generated salt (Base64 string, 24 characters).
        /// - <c>HashedPassword</c>: The SHA256 hash of the password combined with the salt (Hex string, 64 characters).
        /// </returns>
        public static (string Salt, string HashedPassword) HashPasswordWithSalt(string password)
            => KhaledUtils.clsHashing.HashPasswordWithSalt(password);

    }
}
