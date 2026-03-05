using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Mappers_Implementaion;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.MainTransaction;
using MoneyMindManager.Domain.Abstractions.Repositories.Reports;
using MoneyMindManager.Shared.DTOs.MainTransaction;
using MoneyMindManager.Shared.DTOs.Paged_Result_DTOs;

namespace MoneyMindManager.Application.Services.MainTransaction
{
    public class MainTransactionService : IMainTransactionService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IMainTransactionRepository _mainTransactionRepository;
        private readonly IMainTransactionMapper _mainTransactionMapper;

        public MainTransactionService(IResultFactory resultFactory, IMainTransactionRepository mainTransactionRepository, IMainTransactionMapper mainTransactionMapper)
        {
            this._resultFactory = resultFactory;
            this._mainTransactionRepository = mainTransactionRepository;
            this._mainTransactionMapper = mainTransactionMapper;
        }

        public async Task<IResult<MainTransactionDTO>> Get(int transactionID, int currentUserID)
        {
            var result = await _mainTransactionRepository.Get(transactionID, currentUserID);

            var handler = _resultFactory.Create<MainTransactionDTO>();

            if (result is null)
                return handler.Failure("failed to get main transaction");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get main transaction");

            var dto = _mainTransactionMapper.EntityToDTO(result.Data);
            return handler.Success(dto);
        }

        public async Task<IResult<PagedResultWithTotal_CurrentDTO<MainTransactionViewSummary>>> GetAllPaged(MainTransactionPagedFilterDTO filterDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultWithTotal_CurrentDTO<MainTransactionViewSummary>>();

            if (filterDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _mainTransactionMapper.ToPagedSearchCriteria(filterDTO);
            criteria.RowsPerPage = 15;
            var result = await _mainTransactionRepository.GetAllPaged(criteria, currentUserID);


            if (result is null)
                return handler.Failure("failed to get main transactions list");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get main transactions list");

            return result;
        }

        public async Task<IResult<IEnumerable<MainTransactionExportSummary>>> GetAll(MainTransactionFilterDTO filterDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<IEnumerable<MainTransactionExportSummary>>();

            if (filterDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var criteria = _mainTransactionMapper.ToSearchCriteria(filterDTO);

            var result = await _mainTransactionRepository.GetAll(criteria, currentUserID);


            if (result is null)
                return handler.Failure("failed to get main transactions list");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get main transactions list");

            return result;
        }
    }
}
