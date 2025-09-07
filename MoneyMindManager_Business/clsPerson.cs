using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.PersonClassess;

namespace MoneyMindManager_Business
{
    public class clsPerson : clsPersonColumns
    {
        enum enMode { AddNew, Update };
        private enMode Mode { get; set; } = enMode.AddNew;
        public clsAccount AccountInfo { get; private set; }

        public clsPerson() : base()
        {
            Mode = enMode.AddNew;
            AccountInfo = null;
        }

        private clsPerson(int? personID, string personName, string address, string email, string phone, short accountID,
            string notes, clsAccount accountInfo) : base(personID, personName, address, email, phone, accountID, notes)
        {
            Mode = enMode.Update;
            this.AccountInfo = accountInfo;
        }

        private async Task<bool> _AddNewPerson()
        {
            PersonID = await clsPersonData.AddNewPerson(PersonName, Address, Email, Phone, Convert.ToInt16(AccountID), Notes);

            return (PersonID != null);
        }

        private async Task<bool> _UpdatePerson()
        {
            return await clsPersonData.UpdatePerson(Convert.ToInt32(PersonID), PersonName, Address, Email, Phone, Notes);
        }

        async Task<bool> _RefeshCompositionObjects()
        {
            AccountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(AccountID));

            return (AccountInfo != null);
        }

        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewPerson())
                        {
                            Mode = enMode.Update;
                            return await _RefeshCompositionObjects();
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return await _UpdatePerson();
            }

            return false;
        }

        /// <returns>Object of clsUserColumns, if person is not found it will return null</returns>
        public static async Task<clsPerson> FindPersonByID(int personID)
        {
           clsPersonColumns personColumns = await clsPersonData.GetPersonInfoByID(personID);

            if (personColumns == null)
                return null;

            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(personColumns.AccountID));

            if (accountInfo == null)
                return null;

            return new clsPerson(personColumns.PersonID, personColumns.PersonName, personColumns.Address,
                personColumns.Email, personColumns.Phone, Convert.ToInt16(personColumns.AccountID), personColumns.Notes, accountInfo);
        }

        public static async Task<bool> DeletePersonByID(int personID)
        {
            return await clsPersonData.DeletePersonByID(personID);
        }

        public static async Task<bool> IsPersonExistByID(int personID)
        {
            return await clsPersonData.IsPersonExistByID(personID);
        }

        /// <summary>
        /// Get All People For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeople(short accountID, short pageNumber)
        {
            return await clsPersonData.GetAllPeople(accountID, pageNumber);
        }

        /// <summary>
        /// Get All People For Account Using Paging [10 rows per page]
        /// </summary>
        /// <param name="accountID">The current AccountID</param>
        /// <param name="pageNumber">The page Number you want to get rows of it</param>
        /// <param name="personID">The personID you want to search for</param>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByPersonID(short accountID, short pageNumber,int personID)
        {
            return await clsPersonData.GetAllPeopleByPersonID(accountID, pageNumber,personID);
        }
    }
}
