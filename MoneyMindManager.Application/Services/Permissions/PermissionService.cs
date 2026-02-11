using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Extensions;
using MoneyMindManager.Shared.DTOs.Permissions;

namespace MoneyMindManager.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        public List<PermissionItemDTO> GetPermissionMetadata(int userPermissions)
        {
            List<PermissionItemDTO> items = new List<PermissionItemDTO>();

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

                items.Add(new PermissionItemDTO(name, val, isChecked));
            }

            return items;
        }

        public int CalculatePermissions(List<int> checkedItemsValues)
        {
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
