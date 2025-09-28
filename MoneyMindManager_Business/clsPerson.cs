using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;
using MoneyMindManagerGlobal;
using static MoneyMindManagerGlobal.clsDataColumns.PersonClasses;

namespace MoneyMindManager_Business
{
    public class clsPerson : clsPersonColumns
    {
        enum enMode { AddNew, Update };
        private enMode Mode { get; set; } = enMode.AddNew;
        public clsAccount AccountInfo { get; private set; }
        //public clsUser CreatedByUserInfo { get; private set; }

        public bool EnterAccountIDAtAddMode(short accountID)
        {
            if (Mode == enMode.Update)
                return false;

            this.AccountID = accountID;

            return true;
        }
        public bool EnterCreatedByUserIDAtAddMode(int createdByUserID)
        {
            if (Mode == enMode.Update)
                return false;

            this.CreatedByUserID = createdByUserID;

            return true;
        }
        public async Task<clsUser> GetCreatedbyUserInfo(int currentUserID)
        {
          return  await clsUser.FindUserByUserID(Convert.ToInt32(CreatedByUserID),currentUserID);
        }

        public clsPerson() : base()
        {
            Mode = enMode.AddNew;
            AccountInfo = null;
        }

        private clsPerson(int? personID, string personName, string address, string email, string phone, short accountID,
            string notes, clsAccount accountInfo, int? createdByUserID, DateTime createdDate) :
            base(personID, personName, address, email, phone, accountID, notes,createdByUserID,createdDate)
        {
            Mode = enMode.Update;
            this.AccountInfo = accountInfo;
            //this.CreatedByUserInfo = createdByUserInfo;
        }

        private async Task<bool> _AddNewPerson()
        {
            this.CreatedDate = DateTime.Now;

            PersonID = await clsPersonData.AddNewPerson(PersonName, Address, Email, Phone,
                Convert.ToInt16(AccountID), Notes, Convert.ToInt32(CreatedByUserID));

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
                            await _RefeshCompositionObjects();
                            return true;
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
        public static async Task<clsPerson> FindPersonByID(int personID,int currentUserID)
        {
            clsPersonColumns personColumns = await clsPersonData.GetPersonInfoByID(personID,currentUserID);

            if (personColumns == null)
                return null;

            clsAccount accountInfo = await clsAccount.FindAccountByAccountID(Convert.ToInt16(personColumns.AccountID));


            if (accountInfo == null )
                return null;

            return new clsPerson(personColumns.PersonID, personColumns.PersonName, personColumns.Address, personColumns.Email,
                personColumns.Phone, Convert.ToInt16(personColumns.AccountID), personColumns.Notes, accountInfo,
                personColumns.CreatedByUserID, personColumns.CreatedDate);
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
        /// Get All People For Account Using Paging [10 rows per page],  if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeople( short pageNumber,int currentUserID)
        {
            return await clsPersonData.GetAllPeople(null, null, null, null, pageNumber, currentUserID);
        }

        /// <summary>
        /// Get All People For Account Using Paging [10 rows per page], if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByPersonID(int personID,short pageNumber, int currentUserID)
        {
            return await clsPersonData.GetAllPeople(personID, null, null, null, pageNumber, currentUserID);
        }

        /// <summary>
        /// Get All People By Person Name For Account Using Paging [10 rows per page],  if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByPersonName(string personName, short pageNumber, int currentUserID)
        {
            return await clsPersonData.GetAllPeople(null, personName, null, null, pageNumber, currentUserID);
        }

        /// <summary>
        /// Get All People By phone For Account Using Paging [10 rows per page],  if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByEmail(string email, short pageNumber, int currentUserID)
        {
            return await clsPersonData.GetAllPeople(null, null, email, null, pageNumber, currentUserID);
        }

        /// <summary>
        /// Get All People By phone For Account Using Paging [10 rows per page],  if variable null will not filter by it.
        /// </summary>
        /// <returns>object of clsGetAllPeople : if error happend, return null</returns>
        public static async Task<clsGetAllPeople> GetAllPeopleByPhone(string phone, short pageNumber, int currentUserID)
        {
            return await clsPersonData.GetAllPeople(null, null, null, phone, pageNumber, currentUserID);
        }

        public async Task<bool> RefreshData(int currentUserID)
        {
            clsPerson freshPerson = await clsPerson.FindPersonByID(Convert.ToInt32(PersonID),currentUserID);

            if (freshPerson == null)
                return false;

            this.PersonName = freshPerson.PersonName;
            this.Address = freshPerson.Address;
            this.Email = freshPerson.Email;
            this.Phone = freshPerson.Phone;
            this.AccountID = freshPerson.AccountID;
            this.Notes = freshPerson.Notes;
            this.CreatedByUserID = freshPerson.CreatedByUserID;
            this.CreatedDate = freshPerson.CreatedDate;

            this.AccountInfo = freshPerson.AccountInfo;

            return true;
        }
    }
}
