using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.DebtPayment;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IDebtPaymentApiClient
    {
        Task<IResult<DebtTransactionDTO>> Add(DebtTransactionDTO debtPayment, int currentUserID);
        Task<IResult<bool>> Update(DebtTransactionDTO debtPayment, int currentUserID);
        Task<IResult<bool>> Delete(int transactionID, int currentUserID);
        Task<IResult<DebtTransactionDTO>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithValueDTO<DebtTransactionsViewSummary>>> GetAllPagedForDebt(int debtID, int currentUserID, int pageNumber);
        Task<IResult<IEnumerable<DebtTransactionsExportSummary>>> GetAllForDebt(int debtID, int currentUserID);
    }
}
