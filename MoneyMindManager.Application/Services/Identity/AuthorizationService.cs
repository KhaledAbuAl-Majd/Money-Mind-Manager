using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Abstractions.Services;

namespace MoneyMindManager.Application.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IPermissionService _permissionService;

        private readonly IUserRepository _userRepository;

        private readonly IResultFactory _resultFactory;

        public AuthorizationService(IPermissionService permissionService, IUserRepository userRepository, IResultFactory resultFactory)
        {
            this._permissionService = permissionService;
            this._userRepository = userRepository;
            this._resultFactory = resultFactory;
        }
        public async Task<IResult<bool>> CheckAccess(int userID, enPermissions permission)
        {
            var result = await _userRepository.GetPermissions(userID);

            var handler = _resultFactory.Create<bool>();

            if (result is null)
                return handler.Failure("فشل الوصول لقاعدة البيانات للتحقق من الصلاحيات");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            bool hasPermission = _permissionService.IsHasPermission(result.Data, permission);
            return handler.Success(hasPermission);
        }
    }
}
