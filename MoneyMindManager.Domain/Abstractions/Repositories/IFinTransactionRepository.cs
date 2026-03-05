using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.FinTransaction;
using MoneyMindManager.Core.Models.FinVoucher;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Entities.FinTransaction;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IFinTransactionRepository
    {
        Task<IResult<int?>> Add(FinTransaction finTransaction);
        Task<IResult<bool>> Update(FinTransaction finTransaction, int currentUserID);
        Task<IResult<bool>> Delete(int transactionID, int currentUserID);
        Task<IResult<FinTransactionShort>> Get(int transactionID, int currentUserID);
        Task<IResult<PagedResultWithValueDTO<FinTransactionViewSummary>>> GetAllPagedForVoucher(int voucherID, int currentUserID, int pageNumber, byte rowsPerPage);
        Task<IResult<IEnumerable<FinTransactionExportSummary>>> GetAllForVoucher(int voucherID, int currentUserID);
    }
}
