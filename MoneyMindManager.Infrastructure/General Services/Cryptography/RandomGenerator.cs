using System;
using System.Security.Cryptography;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Infrastructure.General_Services
{
    public class RandomGenerator : IRandomGenerator
    {
        public string GenerateRandomString(uint byteLength)
        {
            byte[] saltBytes = new byte[byteLength];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
    }
}
