using MoneyMindManager.Application.Abstractions.Handlers;

namespace MoneyMindManager.Application.Services
{
    public class ResultFactory : IResultFactory
    {
        public IResultHandler<T> Create<T>()
        {
            return new ResultHandler<T>(default, default, default);
        }
    }
}
