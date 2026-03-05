using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.User
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }

        public string Password { get; protected set; }

        public LoginRequestDTO(string userName,string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
