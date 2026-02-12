using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.Permissions;

namespace MoneyMindManager.Application.Abstractions
{
    public interface IPermissionService
    {
        List<PermissionItemDTO> GetPermissionMetadata(int userPermissions);

        int CalculatePermissions(List<int> checkedItemsValues);

        bool IsHasPermission(int userPermission, enPermissions checkedPermission);
    }
}
