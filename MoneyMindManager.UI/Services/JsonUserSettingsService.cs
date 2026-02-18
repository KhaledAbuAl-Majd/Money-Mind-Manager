using System;
using System.IO;
using System.Threading.Tasks;
using MoneyMindManager.Core;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager.UI.Models;
using Newtonsoft.Json;

namespace MoneyMindManager.UI.Services
{
    public class JsonUserSettingsService : IUserSettingsService
    {
        private readonly ILogger _logger;
        private readonly IMessageBoxService _messageBoxService;

        public JsonUserSettingsService(ILogger logger, IMessageBoxService messageBoxService)
        {
            this._logger = logger;
            this._messageBoxService = messageBoxService;
        }
        private string _GetUserSettingsFilePath(int userID)
        {
            return _GetUserSettingsFilePath(userID);
        }
        public async Task<UserSettings> Get(int userID, bool defaultIfFailed = true)
        {
            UserSettings deserializedSettings = null;

            await Task.Run(() =>
            {
                string path = _GetUserSettingsFilePath(userID);

                if (!File.Exists(path))
                {
                    deserializedSettings = (defaultIfFailed) ? GetDefault(userID) : null;
                    return;
                }

                try
                {
                    string jsonString = File.ReadAllText(path);
                    deserializedSettings = JsonConvert.DeserializeObject<UserSettings>(jsonString);
                }
                catch (Exception ex)
                {
                    deserializedSettings = (defaultIfFailed) ? GetDefault(userID) : null;
                    _logger.LogError(ex.Message);
                    _messageBoxService.DisplayError(ex.Message);
                }

            });

            return deserializedSettings;
        }

        public async Task<bool> Save(UserSettings userSettings)
        {
            return await Task<bool>.Run(() =>
            {
                string path = _GetUserSettingsFilePath(userSettings.UserID);

                if (path == null)
                    return false;

                try
                {
                    string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
                    File.WriteAllText(path, jsonString);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    _messageBoxService.DisplayError(ex.Message);
                    return false;
                }

                return true;
            });
        }

        public UserSettings GetDefault(int userID)
        {
            UserSettings userSettings = new UserSettings(userID);

            userSettings.AskBeforeDeletePerson = true;

            userSettings.AskBeforeDeleteUser = true;

            userSettings.AskBeforeDeleteIncomeVoucher = true;
            userSettings.AskBeforeDeleteIncomeTransactions = true;
            userSettings.Income_TodayAsDefaultDate = true;
            userSettings.IncomeTransaction_AutoAddNewDefault = false;

            userSettings.AskBeforeDeleteExpenseVoucher = true;
            userSettings.AskBeforeDeleteExpenseTransactions = true;
            userSettings.Expense_TodayAsDefaultDate = true;
            userSettings.ExpenseTransaction_AutoAddNewDefault = false;

            userSettings.AskBeforeDeleteExpenseReturnVoucher = true;
            userSettings.AskBeforeDeleteExpenseReturnTransactions = true;
            userSettings.ExpenseReturn_TodayAsDefaultDate = true;
            userSettings.ExpenseReturnTransaction_AutoAddNewDefault = false;

            userSettings.AskBeforeDeleteDebts = true;
            userSettings.AskBeforeDeleteDebtPayments = true;
            userSettings.Debts_TodayAsDefaultDate = true;
            userSettings.DebtPayments_TodayAsDefaultDate = true;
            userSettings.DebtPayment_AutoAddNewDefault = false;

            userSettings.AskBeforeDeleteCategory = true;

            return userSettings;
        }
    }
}
