namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IRandomGenerator
    {
        string GenerateRandomString(uint length);
    }
}
