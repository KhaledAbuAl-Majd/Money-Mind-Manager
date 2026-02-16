using System;
using System.Threading.Tasks;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager_Presentation.Global;

namespace MoneyMindManager.UI.Abstractions
{
    public interface IUserSession
    {
        UserDTO CurrentUser { get; }
        clsUserSettings CurrentUserSettings { get; }

        event Action OnSessionExpired;
        event Action OnUserRefreshed;

        Task<bool> StartSession(int userID);
        Task<bool> StartSession(UserDTO userDTO);
        void ClearSession();
        Task<bool> Refresh();
    }
}
