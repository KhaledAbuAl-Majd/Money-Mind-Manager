using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Application.Mappers.Abstractions
{
    public interface IDebtPaymentMapper : IMapper<DebtPayment, DebtPaymentDTO>
    {
    }
}
