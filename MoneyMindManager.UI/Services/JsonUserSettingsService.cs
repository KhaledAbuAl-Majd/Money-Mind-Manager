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
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // 2. دمج اسم الشركة واسم التطبيق (مهم جداً لتجنب التضارب)
            string appFolder = Path.Combine(
                appData,
                "KhaledAbuAlMajd",         // اسم المطور أو الشركة
                "MoneyMindManager"         // اسم التطبيق
            );

            string filePath = null;

            try
            {
                if (!Directory.Exists(appFolder))
                {
                    Directory.CreateDirectory(appFolder);
                }

                string fileName = $"_User_{userID}_Settings.json";
                filePath = Path.Combine(appFolder, fileName);
            }
            catch (Exception ex)
            {
                filePath = null;
                _logger.LogError(ex.Message);
                _messageBoxService.DisplayError(ex.Message);
                return null;
            }

            return filePath;
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
                    string jsonString = JsonConvert.SerializeObject(userSettings, Formatting.Indented);
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

        public UserSettings Clone(UserSettings userSettings)
        {
            return new UserSettings(userSettings.UserID)
            {
                AskBeforeDeletePerson = userSettings.AskBeforeDeletePerson,

                AskBeforeDeleteUser = userSettings.AskBeforeDeleteUser,

                AskBeforeDeleteIncomeVoucher = userSettings.AskBeforeDeleteIncomeVoucher,
                AskBeforeDeleteIncomeTransactions = userSettings.AskBeforeDeleteIncomeTransactions,
                Income_TodayAsDefaultDate = userSettings.Income_TodayAsDefaultDate,
                IncomeTransaction_AutoAddNewDefault = userSettings.IncomeTransaction_AutoAddNewDefault,

                AskBeforeDeleteExpenseVoucher = userSettings.AskBeforeDeleteExpenseVoucher,
                AskBeforeDeleteExpenseTransactions = userSettings.AskBeforeDeleteExpenseTransactions,
                Expense_TodayAsDefaultDate = userSettings.Expense_TodayAsDefaultDate,
                ExpenseTransaction_AutoAddNewDefault = userSettings.ExpenseTransaction_AutoAddNewDefault,

                AskBeforeDeleteExpenseReturnVoucher = userSettings.AskBeforeDeleteExpenseReturnVoucher,
                AskBeforeDeleteExpenseReturnTransactions = userSettings.AskBeforeDeleteExpenseReturnTransactions,
                ExpenseReturn_TodayAsDefaultDate = userSettings.ExpenseReturn_TodayAsDefaultDate,
                ExpenseReturnTransaction_AutoAddNewDefault = userSettings.ExpenseReturnTransaction_AutoAddNewDefault,

                AskBeforeDeleteDebts = userSettings.AskBeforeDeleteDebts,
                AskBeforeDeleteDebtPayments = userSettings.AskBeforeDeleteDebtPayments,
                Debts_TodayAsDefaultDate = userSettings.Debts_TodayAsDefaultDate,
                DebtPayments_TodayAsDefaultDate = userSettings.DebtPayments_TodayAsDefaultDate,
                DebtPayment_AutoAddNewDefault = userSettings.DebtPayment_AutoAddNewDefault,

                AskBeforeDeleteCategory = userSettings.AskBeforeDeleteCategory
            };
        }
    }
}
