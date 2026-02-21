using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.TransactionTypes;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class TransactionTypeMapper : ITransactionTypeMapper
    {
        public TransactionType DTOToEntity(TransactionTypeDTO DTO)
        {
            if (DTO is null)
                return null;

            return new TransactionType()
            {
                TransactionTypeID = DTO.TransactionTypeID,
                TransactionTypeName = DTO.TransactionTypeName
            };
        }

        public TransactionTypeDTO EntityToDTO(TransactionType entity)
        {
            if (entity is null)
                return null;

            return new TransactionTypeDTO(entity.TransactionTypeID, entity.TransactionTypeName);
        }
    }
}
