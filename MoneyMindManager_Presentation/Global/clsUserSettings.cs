using System;
using System.IO;
using System.Threading.Tasks;
using MoneyMindManagerGlobal;
using Newtonsoft.Json;

namespace MoneyMindManager_Presentation.Global
{
    [Serializable]
    public class clsUserSettings
    {
        public int UserID { get; }
        private string UserSettingsFilePath { get; set; }
        public bool AskBeforeDeletePerson { get; set; }
        public bool AskBeforeDeleteUser { get; set; }
        public bool AskBeforeDeleteIncomeVoucher { get; set; }
        public bool AskBeforeDeleteIncomeTransactions { get; set; }
        public bool Income_TodayAsDefaultDate { get; set; }
        public bool AskBeforeDeleteExpenseVoucher { get; set; }
        public bool AskBeforeDeleteExpenseTransactions { get; set; }
        public bool Expense_TodayAsDefaultDate { get; set; }
        public bool AskBeforeDeleteExpenseReturnVoucher { get; set; }
        public bool AskBeforeDeleteExpenseReturnTransactions { get; set; }
        public bool ExpenseReturn_TodayAsDefaultDate { get; set; }
        public bool AskBeforeDeleteDebts { get; set; }
        public bool AskBeforeDeleteDebtPayments { get; set; }
        public bool Debts_TodayAsDefaultDate { get; set; }
        public bool AskBeforeDeleteCategory { get; set; }

        public clsUserSettings(int userID)
        {
            this.UserID = userID;
            this.UserSettingsFilePath = _GetUserSettingsFilePath(userID);
            ResetSettings();
        }

        public static async Task<clsUserSettings> GetUserSettings(int userID)
        {
            clsUserSettings deserializedSettings = null;

            await Task.Run(() =>
            {
                string path = _GetUserSettingsFilePath(userID);
                try
                {
                    string jsonString = File.ReadAllText(path);
                    deserializedSettings = JsonConvert.DeserializeObject<clsUserSettings>(jsonString);
                }
                catch (Exception ex)
                {
                    deserializedSettings = null;
                    clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                }

            });

            return deserializedSettings;
        }

        public void ResetSettings()
        {
            AskBeforeDeletePerson = true;
            AskBeforeDeleteUser = true;
            AskBeforeDeleteIncomeVoucher = true;
            AskBeforeDeleteIncomeTransactions = true;
            Income_TodayAsDefaultDate = true;
            AskBeforeDeleteExpenseVoucher = true;
            AskBeforeDeleteExpenseTransactions = true;
            Expense_TodayAsDefaultDate = true;
            AskBeforeDeleteExpenseReturnVoucher = true;
            AskBeforeDeleteExpenseReturnTransactions = true;
            ExpenseReturn_TodayAsDefaultDate = true;
            AskBeforeDeleteDebts = true;
            AskBeforeDeleteDebtPayments = true;
            Debts_TodayAsDefaultDate = true;
            AskBeforeDeleteCategory = true;
        }

        private static string _GetUserSettingsFilePath(int userID)
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
                clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                return null;
            }

            return filePath;
        }

        private string _GetUserSettingsFilePath()
        {
            return _GetUserSettingsFilePath(UserID);
        }

        public async Task<bool> Save()
        {
            return await Task<bool>.Run(() =>
             {
                 if (this.UserSettingsFilePath == null)
                 {
                     this.UserSettingsFilePath = _GetUserSettingsFilePath();
                 }

                 string path = this.UserSettingsFilePath;

                 if (path == null)
                     return false;

                 try
                 {
                     string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
                     File.WriteAllText(path, jsonString);
                 }
                 catch (Exception ex)
                 {
                     clsGlobalEvents.RaiseErrorEvent(ex.Message, true);
                     return false;
                 }

                 return true;
             });
        }
    }
}
