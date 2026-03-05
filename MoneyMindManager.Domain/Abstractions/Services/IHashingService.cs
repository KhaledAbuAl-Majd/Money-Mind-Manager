namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IHashingService
    {
        string ComputeHash(string input);
    }
}
