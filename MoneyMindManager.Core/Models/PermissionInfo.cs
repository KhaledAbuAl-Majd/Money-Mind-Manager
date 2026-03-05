namespace MoneyMindManager.Shared.DTOs.Permissions
{
    public class PermissionInfo
    {
        public string ItemName { get; }
        public int ItemValue { get; }
        public bool Checked { get; set; }

        public PermissionInfo(string name, int value, bool isChecked)
        {
            this.ItemName = name;
            this.ItemValue = value;
            this.Checked = isChecked;
        }
    }
}
