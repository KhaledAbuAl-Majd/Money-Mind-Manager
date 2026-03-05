using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Criteria.FinVoucher;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.FinVoucher;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IFinVoucherMapper : IMapper<FinVoucher, FinVoucherDTO>
    {
        FinVoucherSearchCriteria ToSearchCriteria(FinVoucherFilterDTO DTO);
        FinVoucherPagedSearchCriteria ToPagedSearchCriteria(FinVoucherPagedFilterDTO DTO);
    }
}
