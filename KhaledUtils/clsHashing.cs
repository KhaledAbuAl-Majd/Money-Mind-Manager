using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KhaledUtils
{
    public static class clsHashing
    {
        /// <summary>
        /// Add Salt To Password Before Hashing
        /// </summary>
        /// <returns>Passowrd + Salt</returns>
        public static string GetSaltedPassword(string Password, string Salt) => Password + Salt;

        /// <summary>
        /// Generate A Salt For Hashing 
        /// </summary>
        /// <returns>
        /// Generated Salt With Lenght = 24
        /// </returns>
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hashing Input Using SHA256
        /// </summary>
        /// <param name="input">The Input (Password + Salt) Will be Hashed</param>
        /// <returns>Hashed String With Length = 64</returns>
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Verify if entered password (with salt) matches hashed password
        /// </summary>
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string EnteredHashedPassword = ComputeHash(GetSaltedPassword(enteredPassword, storedSalt));

            return (EnteredHashedPassword == storedHash);
        }

        /// <summary>
        /// Generates a new cryptographic salt and computes the SHA256 hash of the provided password with the salt appended.
        /// </summary>
        /// <param name="password">The plain text password to be hashed</param>
        /// <returns>
        /// A tuple containing:
        /// - <c>Salt</c>: A randomly generated salt (Base64 string, 24 characters).
        /// - <c>HashedPassword</c>: The SHA256 hash of the password combined with the salt (Hex string, 64 characters).
        /// </returns>
        public static (string Salt, string HashedPassword) HashPasswordWithSalt(string password)
        {
            string salt = GenerateSalt();
            string hashedPassword = ComputeHash(GetSaltedPassword(password, salt));
            return (salt, hashedPassword);
        }

    }
}
