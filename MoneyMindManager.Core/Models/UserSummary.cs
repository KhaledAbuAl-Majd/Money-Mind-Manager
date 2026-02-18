namespace MoneyMindManager.Core
{
    public class UserSummary
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public UserSummary(int userID, string userName, string personName, string email, string phone, bool isActive)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.PersonName = personName;
            this.Email = email;
            this.Phone = phone;
            this.IsActive = isActive;
        }

        public UserSummary()
        {

        }
    }
}
