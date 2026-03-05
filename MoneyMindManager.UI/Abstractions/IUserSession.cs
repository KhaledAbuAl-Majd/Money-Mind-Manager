using System;
using System.Threading.Tasks;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Models;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IUserSession
    {
        UserDTO CurrentUser { get; }

        int? UserID { get; }
        UserSettings CurrentUserSettings { get; }

        event Action OnSessionExpired;
        event Action OnUserRefreshed;

        Task<bool> StartSession(int userID);
        Task<bool> StartSession(UserDTO userDTO);
        void ClearSession();
        Task<bool> Refresh();
        bool IsHasPermissions(enPermissions permissions);
        void RefreshSettings(UserSettings userSettings);
    }
}
