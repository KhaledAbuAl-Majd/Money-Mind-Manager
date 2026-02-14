using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Core.Abstractions;

namespace MoneyMindManager.Application.Services
{
    public class ResultHandler<T> : IResultHandler<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string ErrorMessage { get; }

        public ResultHandler(bool isSuccess, T data, string errorMessage)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.ErrorMessage = errorMessage;
        }

        public IResult<T> Success(T data)
        {
            return new ResultHandler<T>(true, data, null);
        }

        public IResult<T> Failure(string errorMessage)
        {
            return new ResultHandler<T>(false, default, errorMessage);
        }
    }
}
