using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.FinTransaction;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IFinTransactionService
    {
        Task<IResult<FinTransactionDTO>> Add(FinTransactionDTO finTransaction, bool isReturn, int currentUserID);
        Task<IResult<bool>> Update(FinTransactionDTO finTransaction, int currentUserID);
        Task<IResult<bool>> Delete(int transactionID, int currentUserID);
        Task<IResult<FinTransactionDTO>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithValueDTO<FinTransactionViewSummary>>> GetAllPaged(int transactionID, int currentUserID, int pageNumber);
        Task<IResult<IEnumerable<FinTransactionExportSummary>>> GetAll(int transactionID, int currentUserID);
    }
}
