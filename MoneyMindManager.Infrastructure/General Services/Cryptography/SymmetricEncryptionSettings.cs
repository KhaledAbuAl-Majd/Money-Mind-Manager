using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Infrastructure.General_Services.Cryptography
{
    public class SymmetricEncryptionSettings : ISymmetricEncryptionSettings
    {
        public string Key { get; } = "dk234)^&(*^dk234";
    }
}
