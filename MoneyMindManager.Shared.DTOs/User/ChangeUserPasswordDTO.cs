using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class ChangeUserPasswordDTO
    {
        public int UserID { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

        public ChangeUserPasswordDTO(int userID, string oldPassword, string newPassword)
        {
            this.UserID = userID;
            this.oldPassword = oldPassword;
            this.newPassword = newPassword;
        }
    }
}
