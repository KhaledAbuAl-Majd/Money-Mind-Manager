namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, string salt);
        string HashPasswordOutSalt(string password, out string salt);
        bool VerifyPassword(string password, string storedHash, string storedSalt);
    }
}
