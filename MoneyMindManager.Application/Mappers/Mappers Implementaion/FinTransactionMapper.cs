using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Domain.Entities.FinTransaction;
using MoneyMindManager.Shared.DTOs.FinTransaction;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class FinTransactionMapper : IFinTransactionMapper
    {
        public FinTransaction DTOToEntity(FinTransactionDTO DTO)
        {
            if (DTO is null)
                return null;

            return new FinTransaction(DTO.MainTransactionID, DTO.Amount, DTO.CreatedDate, DTO.AccountID, DTO.CreatedByUserID, DTO.TransactionTypeID,
                DTO.Purpose, DTO.IsLocked, DTO.TransactionDate, DTO.TransactionTypeName, DTO.CreatedByUserName, DTO.VoucherID, DTO.CategoryID);
        }
        public FinTransactionDTO EntityToDTO(FinTransaction entity)
        {
            if (entity is null)
                return null;

            return new FinTransactionDTO(entity.MainTransactionID, entity.Amount, entity.CreatedDate, entity.AccountID, entity.CreatedByUserID, entity.TransactionTypeID,
                entity.Purpose, entity.IsLocked, entity.TransactionDate, entity.TransactionTypeName, entity.CreatedByUserName, entity.VoucherID, entity.CategoryID);
        }
    }
}
