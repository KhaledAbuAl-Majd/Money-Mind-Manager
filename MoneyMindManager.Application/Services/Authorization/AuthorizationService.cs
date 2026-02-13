using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Domain.Abstractions;

namespace MoneyMindManager.Application.Services.Authorization
{
    public class AuthorizationService:IAuthorizationService
    {
        private readonly IPermissionService _permissionService;

        private readonly IUserRepository _userRepository;

        private readonly IResultFactory _resultFactory;

        public AuthorizationService(IPermissionService permissionService,IUserRepository userRepository,IResultFactory resultFactory)
        {
            this._permissionService = permissionService;
            this._userRepository = userRepository;
            this._resultFactory = resultFactory;
        }
        public async Task<IResult<bool>> CheckAccess(int userID, enPermissions permission)
        {
            var result =  await _userRepository.GetPermissions(userID);

            var handler = _resultFactory.Create<bool>();

            if (result is null || !result.IsSuccess)
                return handler.Failure("failed to get permissions");


            if (_permissionService.IsHasPermission(result.Data, permission))
                return handler.Success(true);
            else
                return handler.Failure($"المستخدم صاحب معرف {userID} ليس لدية صلاحية");
        }
    }
}
