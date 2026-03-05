using KhaledUtils;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Infrastructure.General_Services.Cryptography
{
    public class SymmetricEncryption : ISymmetricEncryption
    {
        private readonly ISymmetricEncryptionSettings _symmetricEncryptionSettings;

        public SymmetricEncryption(ISymmetricEncryptionSettings symmetricEncryptionSettings)
        {
            this._symmetricEncryptionSettings = symmetricEncryptionSettings;
        }

        public string Encrypt(string plainText)
        {
            return clsCryptography.clsSymmetricEncryption.clsText.Encrypt(plainText, _symmetricEncryptionSettings.Key);
        }

        public string Decrypt(string cipherText)
        {
            return clsCryptography.clsSymmetricEncryption.clsText.Decrypt(cipherText, _symmetricEncryptionSettings.Key);
        }
    }
}
