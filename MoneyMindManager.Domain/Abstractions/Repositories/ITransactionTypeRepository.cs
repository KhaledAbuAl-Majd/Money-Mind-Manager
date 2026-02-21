using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Entities;

namespace MoneyMindManager.Domain.Abstractions.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task<IResult<TransactionType>> GetByID(byte transactionTypeID);
        Task<IResult<TransactionType>> GetByName(string transactionName);
        Task<IResult<IEnumerable<TransactionType>>> GetAll();
    }
}
