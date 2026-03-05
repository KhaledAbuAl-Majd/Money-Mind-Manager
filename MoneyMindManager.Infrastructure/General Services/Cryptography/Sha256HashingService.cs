using KhaledUtils;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Infrastructure.General_Services
{
    public class Sha256HashingService : IHashingService
    {
        public string ComputeHash(string input)
        {
            return clsHashing.ComputeHash(input);
        }
    }
}
