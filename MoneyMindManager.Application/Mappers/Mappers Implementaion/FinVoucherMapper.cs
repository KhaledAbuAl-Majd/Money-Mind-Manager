using System;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Domain.Criteria.FinVoucher;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.FinVoucher;

namespace MoneyMindManager.Application.Mappers.Mappers_Implementaion
{
    public class FinVoucherMapper : IFinVoucherMapper
    {
        private readonly IFormateHelper _formateHelper;

        public FinVoucherMapper(IFormateHelper formateHelper)
        {
            this._formateHelper = formateHelper;
        }

        public FinVoucher DTOToEntity(FinVoucherDTO DTO)
        {
            if (DTO is null)
                return null;

            return new FinVoucher()
            {
                AccountID = DTO.AccountID,
                CreatedByUserID = DTO.CreatedByUserID,
                CreatedDate = DTO.CreatedDate,
                IsIncome = DTO.IsIncome,
                IsLocked = DTO.IsLocked,
                IsReturn = DTO.IsReturn,
                Notes = DTO.Notes,
                VoucherDate = DTO.VoucherDate,
                VoucherID = DTO.VoucherID,
                VoucherName = DTO.VoucherName,
                VoucherValue = DTO.VoucherValue
            };
        }
        public FinVoucherDTO EntityToDTO(FinVoucher entity)
        {
            if (entity is null)
                return null;

            return new FinVoucherDTO(entity.VoucherID, entity.VoucherName, entity.Notes, entity.IsLocked, entity.CreatedDate,
                entity.VoucherDate, entity.AccountID, entity.CreatedByUserID, entity.IsIncome, entity.IsReturn, entity.VoucherValue);
        }
        public FinVoucherSearchCriteria ToSearchCriteria(FinVoucherFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            bool isIncome = false, isReturn = false;

            switch (DTO.VoucherType)
            {
                case enVoucherType.Incomes:
                    isIncome = true;
                    isReturn = false;
                    break;

                case enVoucherType.Expenses:
                    isIncome = false;
                    isReturn = false;
                    break;

                case enVoucherType.ExpensesReturn:
                    isIncome = false;
                    isReturn = true;
                    break;

                default:
                    return null;
            }

            DateTime? fromCreatedDate = null, toCreatedDate = null,
               fromVoucherDate = null, toVoucherDate = null;

            if (DTO.IsByCreatedDate)
            {
                fromCreatedDate = _formateHelper.TryConvertToDateTime(DTO.FromDateString);
                toCreatedDate = _formateHelper.TryConvertToDateTime(DTO.ToDateString);

                fromVoucherDate = null;
                toVoucherDate = null;
            }
            else
            {
                fromVoucherDate = _formateHelper.TryConvertToDateTime(DTO.FromDateString);
                toVoucherDate = _formateHelper.TryConvertToDateTime(DTO.ToDateString);

                fromCreatedDate = null;
                toCreatedDate = null;
            }

            return new FinVoucherSearchCriteria()
            {
                IsReturn = isReturn,
                IsIncome = isIncome,
                FromCreatedDate = fromCreatedDate,
                FromVoucherDate = fromVoucherDate,
                ToCreatedDate = toCreatedDate,
                ToVoucherDate = toVoucherDate,
                TextSearchMode = (byte)DTO.TextSearchMode,
                UserName = DTO.UserName,
                VoucherID = DTO.VoucherID,
                VoucherName = DTO.VoucherName
            };
        }
        public FinVoucherPagedSearchCriteria ToPagedSearchCriteria(FinVoucherPagedFilterDTO DTO)
        {
            if (DTO is null)
                return null;

            var result = ToSearchCriteria(DTO);
            return new FinVoucherPagedSearchCriteria(result)
            {
                PageNumber = DTO.PageNumber
            };
        }
    }
}
