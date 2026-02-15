using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Extensions;
using MoneyMindManager.Domain.Abstractions.Services;
using MoneyMindManager.Shared.DTOs.Permissions;

namespace MoneyMindManager.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        public List<PermissionInfo> GetPermissionMetadata(int userPermissions)
        {
            List<PermissionInfo> items = new List<PermissionInfo>();

            var fileds = typeof(enPermissions).GetFields(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Static).Where(x => x.Name != nameof(enPermissions.Admin));

            int val;
            bool isChecked = false;
            string name;

            foreach (var field in fileds)
            {
                val = Convert.ToInt32(field.GetRawConstantValue());
                isChecked = IsHasPermission(userPermissions, (enPermissions)val);
                var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();

                name = (descriptionAttribute != null) ? descriptionAttribute.Description : field.Name;

                items.Add(new PermissionInfo(name, val, isChecked));
            }

            return items;
        }

        public int CalculatePermissions(IEnumerable<int> checkedItemsValues)
        {
            if (checkedItemsValues is null)
                return 0;

            int permission = 0;

            foreach (var item in checkedItemsValues)
            {
                permission |= item;
            }

            return permission;
        }

        public bool IsHasPermission(int userPermission, enPermissions checkedPermission)
        {
            return userPermission.IsHasPermission(checkedPermission);
        }
    }
}
