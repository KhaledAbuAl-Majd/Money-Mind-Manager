namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IHashingSettings
    {
        uint SaltSize { get; }
    }
}
