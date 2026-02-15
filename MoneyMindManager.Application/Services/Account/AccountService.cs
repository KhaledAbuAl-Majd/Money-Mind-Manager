using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Shared.DTOs.Account;

namespace MoneyMindManager.Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IResultFactory _resultFactory;
        public AccountService(IAccountRepository accountRepository, IAccountMapper accountMapper, IAuthorizationService authorizationService,
            IPasswordHasher passwordHasher, IResultFactory resultFactory)
        {
            this._accountRepository = accountRepository;
            this._accountMapper = accountMapper;
            this._authorizationService = authorizationService;
            this._passwordHasher = passwordHasher;
            this._resultFactory = resultFactory;
        }

        public async Task<IResult<short?>> Add(CreateAccountDTO createAccountDTO)
        {
            var (person, user, account) = _accountMapper.CreateAccountDTOToEntities(createAccountDTO);
            string salt;
            var hashedPassword = _passwordHasher.HashPassword(user.Password, out salt);
            user.Password = hashedPassword;
            user.Salt = salt;

            return await _accountRepository.Add(person, user, account);
        }

        public async Task<IResult<bool>> Update(AccountBaseDTO accountBaseDTO, int currentUserID)
        {
            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.Admin);

            var handler = _resultFactory.Create<bool>();
            if (accessResult is null || !accessResult.IsSuccess)
                return accessResult;

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية تعديل بيانات الحساب.");

            var account = _accountMapper.DTOToEntity(accountBaseDTO);
            var updateResult = await _accountRepository.Update(account, currentUserID);

            if (updateResult is null)
                return handler.Failure("error ocurred while updating account!");

            return updateResult;

        }

        public async Task<IResult<AccountBaseDTO>> Get(short accountID)
        {
            var result = await _accountRepository.Get(accountID);

            var handler = _resultFactory.Create<AccountBaseDTO>();

            if (result is null)
                return handler.Failure("error ocurred while getting account!");

            if (result.Data is null && !result.IsSuccess)
                return handler.Failure("error ocurred while getting account!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return handler.Success(_accountMapper.EntityToDTO(result.Data));
        }

        public async Task<IResult<bool>> IsExistByAccountName(string accountName)
        {
            return await _accountRepository.IsExistByAccountName(accountName);
        }

        public async Task<IResult<bool>> Delete(short accountID, int currentUserID)
        {
            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.Admin);

            var handler = _resultFactory.Create<bool>();

            if (accessResult is null || !accessResult.IsSuccess)
                return accessResult;

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف الحساب.");

            var result= await _accountRepository.Delete(accountID);

            if (result is null)
                return handler.Failure("failed to delete account!");

            return result;
        }
    }
}
