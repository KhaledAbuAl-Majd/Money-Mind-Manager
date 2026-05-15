using System;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Criteria.Debt;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.Debt;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    internal class DebtMapper : IDebtMapper
    {
        private readonly IFormateHelper _formateHelper;

        public DebtMapper(IFormateHelper formateHelper)
        {
            this._formateHelper = formateHelper;
        }

        public Debt DTOToEntity(DebtDTO DTO)
        {
            if (DTO is null)
                return null;

            return new Debt()
            {
                AccountID = DTO.AccountID,
                CreatedByUserID = DTO.CreatedByUserID,
                CreatedByUserName = DTO.CreatedByUserName,
                CreatedDate = DTO.CreatedDate,
                DebtID = DTO.DebtID,
                IsLending = DTO.IsLending,
                IsLocked = DTO.IsLocked,
                PaymentDueDate = DTO.PaymentDueDate,
                PersonID = DTO.PersonID,
                RemainingAmount = DTO.RemainingAmount,
                Notes = DTO.Notes,
                DebtDate = DTO.DebtDate,
                TotalPaid = DTO.TotalPaid,
                TotalValue = DTO.TotalValue
            };
        }
        public DebtDTO EntityToDTO(Debt entity)
        {
            if (entity is null)
                return null;

            return new DebtDTO(Convert.ToInt32(entity.DebtID), entity.IsLending, Convert.ToInt32(entity.PersonID), entity.PaymentDueDate, entity.AccountID,
                entity.CreatedByUserID, entity.CreatedByUserName, entity.IsLocked, entity.TotalValue, entity.TotalPaid, entity.RemainingAmount,
                entity.DebtDate, entity.CreatedDate, entity.Notes);
        }
        public DebtSearchCriteria ToSearchCriteria(DebtFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            DateTime? fromCreatedDate = null, toCreatedDate = null,
               fromDebtDate = null, toDebtDate = null;

            if (DTO.IsByCreatedDate)
            {
                fromCreatedDate = _formateHelper.TryConvertToDateTime(DTO.FromDateString);
                toCreatedDate = _formateHelper.TryConvertToDateTime(DTO.ToDateString);

                fromDebtDate = null;
                toDebtDate = null;
            }
            else
            {
                fromDebtDate = _formateHelper.TryConvertToDateTime(DTO.FromDateString);
                toDebtDate = _formateHelper.TryConvertToDateTime(DTO.ToDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            return new DebtSearchCriteria()
            {
                IsLending = DTO.IsLending,
                DebtID = DTO.DebtID,
                IsPaid = DTO.IsPaid,
                PersonName = DTO.PersonName,
                FromCreatedDate = fromCreatedDate,
                FromDebtDate = fromDebtDate,
                ToCreatedDate = toCreatedDate,
                ToDebtDate = toDebtDate,
                TextSearchMode = (byte)DTO.TextSearchMode,
                UserName = DTO.UserName
            };
        }
        public DebtPagedSearchCriteria ToPagedSearchCriteria(DebtPagedFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            var result = ToSearchCriteria(DTO);
            return new DebtPagedSearchCriteria(result)
            {
                PageNumber = DTO.PageNumber
            };
        }
    }
}
