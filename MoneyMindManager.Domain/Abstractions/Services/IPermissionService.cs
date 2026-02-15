using System.Collections.Generic;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Permissions;

namespace MoneyMindManager.Domain.Abstractions.Services
{
    public interface IPermissionService
    {
        List<PermissionInfo> GetPermissionMetadata(int userPermissions);

        int CalculatePermissions(IEnumerable<int> checkedItemsValues);

        bool IsHasPermission(int userPermission, enPermissions checkedPermission);
    }
}
