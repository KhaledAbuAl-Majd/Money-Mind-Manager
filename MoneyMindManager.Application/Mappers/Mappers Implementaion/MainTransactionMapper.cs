using System;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.MainTransaction;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class MainTransactionMapper : IMainTransactionMapper
    {
        private readonly IFormateHelper _formateHelper;

        public MainTransactionMapper(IFormateHelper formateHelper)
        {
            this._formateHelper = formateHelper;
        }

        public MainTransaction DTOToEntity(MainTransactionDTO DTO)
        {
            return new MainTransaction()
            {
                AccountID = DTO.AccountID,
                Amount = DTO.Amount,
                CreatedByUserID = DTO.CreatedByUserID,
                CreatedByUserName = DTO.CreatedByUserName,
                CreatedDate = DTO.CreatedDate,
                MainTransactionID = DTO.MainTransactionID,
                Purpose = DTO.Purpose,
                TransactionDate = DTO.TransactionDate,
                TransactionTypeID = DTO.TransactionTypeID,
                TransactionTypeName = DTO.TransactionTypeName,
                IsLocked = DTO.IsLocked
            };

        }

        public MainTransactionDTO EntityToDTO(MainTransaction entity)
        {
            if (entity is null)
                return null;

            return new MainTransactionDTO(entity.MainTransactionID, entity.Amount, entity.CreatedDate, entity.AccountID, entity.CreatedByUserID,
                entity.TransactionTypeID, entity.Purpose, entity.IsLocked, entity.TransactionDate, entity.TransactionTypeName, entity.CreatedByUserName);
        }

        public MainTransactionSearchCriteria ToSearchCriteria(MainTransactionFilterDTO filterDTO)
        {
            if (filterDTO is null)
                return null;


            DateTime? fromCreatedDate = null, toCreatedDate = null,
                fromTransactionDate = null, toTransactionDate = null;

            if (filterDTO.IsByCreatedDate)
            {
                fromCreatedDate = _formateHelper.TryConvertToDateTime(filterDTO.FromDateString);
                toCreatedDate = _formateHelper.TryConvertToDateTime(filterDTO.ToDateString);

                fromTransactionDate = null;
                toTransactionDate = null;
            }
            else
            {
                fromTransactionDate = _formateHelper.TryConvertToDateTime(filterDTO.FromDateString);
                toTransactionDate = _formateHelper.TryConvertToDateTime(filterDTO.ToDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            string transactionTypesString = string.Join(",", filterDTO.TransactionTypes);

            return new MainTransactionSearchCriteria()
            {
                CreatedByUserName = filterDTO.CreatedByUserName,
                FromCreatedDate = fromCreatedDate,
                FromTransactionDate = fromTransactionDate,
                ToTransactionDate = toTransactionDate,
                ToCreatedDate = toCreatedDate,
                TransactionTypes = transactionTypesString,
                Purpose = filterDTO.Purpose,
                TextSearchMode = (byte)filterDTO.TextSearchMode,
                TransactionID = filterDTO.TransactionID
            };
        }

        public MainTransactionPagedSearchCriteria ToPagedSearchCriteria(MainTransactionPagedFilterDTO filterDTO)
        {
            if (filterDTO is null)
                return null;

            var result = ToSearchCriteria(filterDTO);
            return new MainTransactionPagedSearchCriteria(result)
            {
                PageNumber = filterDTO.PageNumber
            };
        }
    }
}
