using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Application.Mappers.Abstractions;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Domain.Abstractions.Repositories;
using MoneyMindManager.Shared.DTOs.TransactionTypes;

namespace MoneyMindManager.Application.Services.TransactionType
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IResultFactory _resultFactory;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly ITransactionTypeMapper _transactionTypeMapper;

        public TransactionTypeService(IResultFactory resultFactory, ITransactionTypeRepository transactionTypeRepository, ITransactionTypeMapper transactionTypeMapper)
        {
            this._resultFactory = resultFactory;
            this._transactionTypeRepository = transactionTypeRepository;
            this._transactionTypeMapper = transactionTypeMapper;
        }

        public async Task<IResult<TransactionTypeDTO>> GetByID(byte transactionTypeID)
        {
            var handler = _resultFactory.Create<TransactionTypeDTO>();

            var result = await _transactionTypeRepository.GetByID(transactionTypeID);

            if (result is null)
                return handler.Failure("failed to get transaction type!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get transaction type!");

            var DTO = _transactionTypeMapper.EntityToDTO(result.Data);
            return handler.Success(DTO);

        }

        public async Task<IResult<TransactionTypeDTO>> GetByName(string transactionName)
        {
            var handler = _resultFactory.Create<TransactionTypeDTO>();

            var result = await _transactionTypeRepository.GetByName(transactionName);

            if (result is null)
                return handler.Failure("failed to get transaction type!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get transaction type!");

            var DTO = _transactionTypeMapper.EntityToDTO(result.Data);
            return handler.Success(DTO);
        }

        public async Task<IResult<IEnumerable<TransactionTypeDTO>>> GetAll()
        {
            var handler = _resultFactory.Create<IEnumerable<TransactionTypeDTO>>();

            var result = await _transactionTypeRepository.GetAll();

            if (result is null)
                return handler.Failure("failed to get transaction types list!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            if (result.Data is null)
                return handler.Failure("failed to get transaction types list!");

            var DTOList = result.Data.Select(entity => _transactionTypeMapper.EntityToDTO(entity));
            return handler.Success(DTOList);
        }
    }
}
