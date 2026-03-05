using System.Collections.Generic;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public int PersonID { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public IEnumerable<int> PermissionsList { get; set; }

        public CreateUserDTO(string userName, int personID, string password, bool isActive, string notest, int createdByUserID, IEnumerable<int> permissionsList)
        {
            this.UserName = userName;
            this.PersonID = personID;
            this.Password = password;
            this.IsActive = isActive;
            this.Notes = notest;
            this.CreatedByUserID = createdByUserID;
            this.PermissionsList = permissionsList;
        }
    }
}
