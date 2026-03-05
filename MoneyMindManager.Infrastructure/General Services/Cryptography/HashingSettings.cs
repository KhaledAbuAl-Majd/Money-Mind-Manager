using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Application.Services
{
    public class HashingSettings : IHashingSettings
    {
        public uint SaltSize { get; } = 16;
    }
}
