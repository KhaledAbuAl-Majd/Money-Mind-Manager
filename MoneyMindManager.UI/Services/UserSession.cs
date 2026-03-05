using System;
using System.Threading.Tasks;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Core.Extensions;
using MoneyMindManager.Shared.DTOs.User;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Models;

namespace MoneyMindManager.UI.Services
{
    public class UserSession : IUserSession
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserApiClient _userApiClient;
        private readonly IUserSettingsService _userSettingsService;

        private static System.Timers.Timer _refreshTimer;
        public UserSession(IMessageBoxService messageBoxService, IUserApiClient userApiClient, IUserSettingsService userSettingsService)
        {
            this._messageBoxService = messageBoxService;
            this._userApiClient = userApiClient;
            this._userSettingsService = userSettingsService;
        }

        public UserDTO CurrentUser { get; private set; }

        public int? UserID { get => CurrentUser?.UserID; }
        public UserSettings CurrentUserSettings { get; private set; }

        public event Action OnSessionExpired;

        public event Action OnUserRefreshed;

        private void _StartTimer()
        {
            _refreshTimer = new System.Timers.Timer(300000);
            _refreshTimer.Elapsed += async (s, e) => await Refresh();
            _refreshTimer.AutoReset = true;
            _refreshTimer.Enabled = true;
            _refreshTimer.Start();
        }

        private void _StopTimer()
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            _refreshTimer = null;
        }

        public async Task<bool> StartSession(int userID)
        {
            var userResult = await _userApiClient.GetByUserID(userID, userID);

            if (userResult == null || userResult.Data is null)
            {
                ClearSession();
                return false;
            }

            CurrentUser = userResult.Data;


            CurrentUserSettings = await _userSettingsService.Get(Convert.ToInt32(CurrentUser.UserID), true);

            if (CurrentUserSettings == null)
            {
                ClearSession();
                return false;
            }

            _StartTimer();

            return true;
        }

        public async Task<bool> StartSession(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                ClearSession();
                return false;
            }

            CurrentUser = userDTO;


            CurrentUserSettings = await _userSettingsService.Get(Convert.ToInt32(CurrentUser.UserID), true);

            if (CurrentUserSettings == null)
            {
                ClearSession();
                return false;
            }

            _StartTimer();

            return true;
        }

        public void ClearSession()
        {
            _StopTimer();
            CurrentUser = null;
            CurrentUserSettings = null;

            OnSessionExpired?.Invoke();

            //if (MainForm != null && !MainForm.IsDisposed)
            //{
            //    MainForm.Invoke(new Action(() =>
            //    {
            //        ActiveForm = null;
            //        MainForm?.Close();
            //        MainForm = null;
            //    }
            //    ));
            //}
        }

        public async Task<bool> Refresh()
        {
            _refreshTimer.Stop();

            string oldUserName = CurrentUser.UserName;

            if (CurrentUser == null || CurrentUser?.UserID == null)
                CurrentUser = null;
            else
            {
                var result = await _userApiClient.GetByUserID(Convert.ToInt32(CurrentUser?.UserID), Convert.ToInt32(CurrentUser?.UserID));

                if (!result.IsSuccess || result.Data is null)
                {

                    _messageBoxService.DisplayError("المستخدم الحالي غير موجود سيتم تسجيل خروجك !");
                    ClearSession();
                    return false;
                }

                CurrentUser = result.Data;
            }

            if (CurrentUser?.IsActive == false)
            {
                _messageBoxService.DisplayError("المستخدم الحالي موقوف, سيتم تسجيل خروجك !");
                ClearSession();
                return false;
            }

            if (oldUserName != CurrentUser.UserName)
                OnUserRefreshed.Invoke();

            _refreshTimer.Start();

            return true;
        }

        public bool IsHasPermissions(enPermissions permissions)
        {
            if (CurrentUser is null)
                return false;

            return CurrentUser.Permissions.IsHasPermission(permissions);
        }

        public void RefreshSettings(UserSettings userSettings)
        {
            if (userSettings is null)
                return;

            this.CurrentUserSettings = userSettings;
        }
    }
}
