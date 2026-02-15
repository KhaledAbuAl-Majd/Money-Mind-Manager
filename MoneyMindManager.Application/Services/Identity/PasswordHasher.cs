using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IHashingSettings _hashingSettings;
        private readonly IHashingService _hashingService;
        private readonly IRandomGenerator _randomGenerator;

        public PasswordHasher(IHashingSettings hashingSettings, IHashingService hashingService, IRandomGenerator randomGenerator)
        {
            this._hashingSettings = hashingSettings;
            this._hashingService = hashingService;
            this._randomGenerator = randomGenerator;
        }

        private string _GetSaltedPassword(string Password, string Salt) => Password + Salt;

        public string HashPassword(string password, string salt)
        {
            var saltedPassword = _GetSaltedPassword(password, salt);
            return _hashingService.ComputeHash(saltedPassword);
        }
        public string HashPasswordOutSalt(string password, out string salt)
        {
            salt = _randomGenerator.GenerateRandomString(_hashingSettings.SaltSize);
            return HashPassword(password, salt);
        }
        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltedPassword = _GetSaltedPassword(password, storedSalt);
            var hashedPassword = _hashingService.ComputeHash(saltedPassword);
            return storedHash == hashedPassword;
        }
    }
}
