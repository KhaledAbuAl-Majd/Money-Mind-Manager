using MoneyMindManager.Core.Enums;

namespace MoneyMindManager.Core.Extensions
{
    public static class PermissionsExtensions
    {
        public static bool IsHasPermission(this int userPermission, enPermissions checkedPermission)
        {
            int permissionFor = (int)checkedPermission;
            return (userPermission == (int)enPermissions.Admin) || ((permissionFor & userPermission) == permissionFor);
        }
    }
}
