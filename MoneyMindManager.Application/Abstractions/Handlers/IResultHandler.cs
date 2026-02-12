using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Application.Abstractions.Handlers
{
    public interface IResultHandler<T> : IResult<T>
    {
        IResult<T> Success(T data);

        IResult<T> Failure(string errorMessage);
    }
}
