using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager_DataAccess;

namespace MoneyMindManager_Business
{
    public class clsPerson : clsPersonData.clsPersonColumns
    {
        public enum enMode { AddNew, Update };
        public enMode Mode { get; private set; } = enMode.AddNew;

        public clsPerson() : base()
        {
            Mode = enMode.AddNew;
        }

        private clsPerson(int? personID, string personName, string address, string email, string phone, int? accountID, string notes)
            : base(personID, personName, address, email, phone, accountID, notes)
        {
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewPerson()
        {
            PersonID = await clsPersonData.AddNewPerson(PersonName, Address, Email, Phone, Convert.ToInt32(AccountID), Notes);

            return (PersonID != null);
        }

        private async Task<bool> _UpdatePerson()
        {
            return await clsPersonData.UpdatePerson(Convert.ToInt32(PersonID), PersonName, Address, Email, Phone, Notes);
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

        public static async Task<clsPerson> FindPersonByID(int personID)
        {
            clsPersonData.clsPersonColumns personColumns = await clsPersonData.GetPersonInfoByID(personID);

            if (personColumns == null)
                return null;

            return new clsPerson(personColumns.PersonID, personColumns.PersonName, personColumns.Address,
                personColumns.Email, personColumns.Phone, personColumns.AccountID, personColumns.Notes);
        }

        public static async Task<bool> DeletePersonByID(int personID)
        {
            return await clsPersonData.DeletePersonByID(personID);
        }

        public static async Task<bool> IsPersonExistByID(int personID)
        {
            return await clsPersonData.IsPersonExistByID(personID);
        }
    }
}
