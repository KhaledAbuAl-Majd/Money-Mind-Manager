using System;
using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using MoneyMindManagerGlobal;
using Newtonsoft.Json;

namespace MoneyMindManager_Presentation.Global
{
    [Serializable]
    public class clsUserSettings
    {
        public int UserID { get; }
        private string UserSettingsFilePath { get; set; }

        //
        public bool AskBeforeDeletePerson { get; set; }//done
        //
        public bool AskBeforeDeleteUser { get; set; }//done
        //
        public bool AskBeforeDeleteIncomeVoucher { get; set; }//done
        public bool AskBeforeDeleteIncomeTransactions { get; set; }//done
        public bool Income_TodayAsDefaultDate { get; set; }//done
        public bool IncomeTransaction_AutoAddNewDefault { get; set; }//done
        //
        public bool AskBeforeDeleteExpenseVoucher { get; set; }//done
        public bool AskBeforeDeleteExpenseTransactions { get; set; }//done
        public bool Expense_TodayAsDefaultDate { get; set; }//done
        public bool ExpenseTransaction_AutoAddNewDefault { get; set; }//done
        //
        public bool AskBeforeDeleteExpenseReturnVoucher { get; set; }//done
        public bool AskBeforeDeleteExpenseReturnTransactions { get; set; }//done
        public bool ExpenseReturn_TodayAsDefaultDate { get; set; }//done
        public bool ExpenseReturnTransaction_AutoAddNewDefault { get; set; }//done
        //
        public bool AskBeforeDeleteDebts { get; set; }//done
        public bool AskBeforeDeleteDebtPayments { get; set; }//done
        public bool Debts_TodayAsDefaultDate { get; set; }//done
        public bool DebtPayments_TodayAsDefaultDate { get; set; }//done
        public bool DebtPayment_AutoAddNewDefault { get; set; }//done
        //
        public bool AskBeforeDeleteCategory { get; set; }//done

        public clsUserSettings(int userID)
        {
            this.UserID = userID;
            this.UserSettingsFilePath = _GetUserSettingsFilePath(userID);
            ResetSettings();
        }

        private clsUserSettings(clsUserSettings original)
        {
            this.UserID = original.UserID;
            this.UserSettingsFilePath = original.UserSettingsFilePath;
            AssingNewSettings(original);
        }

        public clsUserSettings Clone()
        {
            return new clsUserSettings(this);
        }

        public static async Task<clsUserSettings> GetUserSettings(int userID, bool defaultIfFailed = true)
        {
            clsUserSettings deserializedSettings = null;

            await Task.Run(() =>
            {
                string path = _GetUserSettingsFilePath(userID);

                if (!File.Exists(path))
                {
                    deserializedSettings = (defaultIfFailed) ? new clsUserSettings(userID) : null;
                    return;
                }

                try
                {
                    string jsonString = File.ReadAllText(path);
                    deserializedSettings = JsonConvert.DeserializeObject<clsUserSettings>(jsonString);
                }
                catch (Exception ex)
                {
                    deserializedSettings = (defaultIfFailed) ? new clsUserSettings(userID) : null;
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
            IncomeTransaction_AutoAddNewDefault = false;

            AskBeforeDeleteExpenseVoucher = true;
            AskBeforeDeleteExpenseTransactions = true;
            Expense_TodayAsDefaultDate = true;
            ExpenseTransaction_AutoAddNewDefault = false;

            AskBeforeDeleteExpenseReturnVoucher = true;
            AskBeforeDeleteExpenseReturnTransactions = true;
            ExpenseReturn_TodayAsDefaultDate = true;
            ExpenseReturnTransaction_AutoAddNewDefault = false;

            AskBeforeDeleteDebts = true;
            AskBeforeDeleteDebtPayments = true;
            Debts_TodayAsDefaultDate = true;
            DebtPayments_TodayAsDefaultDate = true;
            DebtPayment_AutoAddNewDefault = false;

            AskBeforeDeleteCategory = true;
        }

        public void AssingNewSettings(clsUserSettings newSettings)
        {
            this.AskBeforeDeletePerson = newSettings.AskBeforeDeletePerson;

            this.AskBeforeDeleteUser = newSettings.AskBeforeDeleteUser;

            this.AskBeforeDeleteIncomeVoucher = newSettings.AskBeforeDeleteIncomeVoucher;
            this.AskBeforeDeleteIncomeTransactions = newSettings.AskBeforeDeleteIncomeTransactions;
            this.Income_TodayAsDefaultDate = newSettings.Income_TodayAsDefaultDate;
            this.IncomeTransaction_AutoAddNewDefault = newSettings.IncomeTransaction_AutoAddNewDefault;

            this.AskBeforeDeleteExpenseVoucher = newSettings.AskBeforeDeleteExpenseVoucher;
            this.AskBeforeDeleteExpenseTransactions = newSettings.AskBeforeDeleteExpenseTransactions;
            this.Expense_TodayAsDefaultDate = newSettings.Expense_TodayAsDefaultDate;
            this.ExpenseTransaction_AutoAddNewDefault = newSettings.ExpenseTransaction_AutoAddNewDefault;

            this.AskBeforeDeleteExpenseReturnVoucher = newSettings.AskBeforeDeleteExpenseReturnVoucher;
            this.AskBeforeDeleteExpenseReturnTransactions = newSettings.AskBeforeDeleteExpenseReturnTransactions;
            this.ExpenseReturn_TodayAsDefaultDate = newSettings.ExpenseReturn_TodayAsDefaultDate;
            this.ExpenseReturnTransaction_AutoAddNewDefault = newSettings.ExpenseReturnTransaction_AutoAddNewDefault;

            this.AskBeforeDeleteDebts = newSettings.AskBeforeDeleteDebts;
            this.AskBeforeDeleteDebtPayments = newSettings.AskBeforeDeleteDebtPayments;
            this.Debts_TodayAsDefaultDate = newSettings.Debts_TodayAsDefaultDate;
            this.DebtPayments_TodayAsDefaultDate = newSettings.DebtPayments_TodayAsDefaultDate;
            this.DebtPayment_AutoAddNewDefault = newSettings.DebtPayment_AutoAddNewDefault;

            this.AskBeforeDeleteCategory = newSettings.AskBeforeDeleteCategory;
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
