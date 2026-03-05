using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Domain.Entities.DebtPayment;
using MoneyMindManager.Shared.DTOs.DebtPayment;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class DebtPaymentMapper : IDebtPaymentMapper
    {
        public DebtPayment DTOToEntity(DebtPaymentDTO DTO)
        {
            if (DTO is null)
                return null;

            return new DebtPayment(DTO.MainTransactionID, DTO.Amount, DTO.CreatedDate, DTO.AccountID, DTO.CreatedByUserID, DTO.TransactionTypeID,
                DTO.Purpose, DTO.IsLocked, DTO.TransactionDate, DTO.TransactionTypeName, DTO.CreatedByUserName, DTO.DebtID);
        }
        public DebtPaymentDTO EntityToDTO(DebtPayment entity)
        {
            if (entity is null)
                return null;

            return new DebtPaymentDTO(entity.MainTransactionID, entity.Amount, entity.CreatedDate, entity.AccountID, entity.CreatedByUserID, entity.TransactionTypeID,
                entity.Purpose, entity.IsLocked, entity.TransactionDate, entity.TransactionTypeName, entity.CreatedByUserName, entity.DebtID);
        }
    }
}
