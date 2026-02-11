using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMindManager.Shared.DTOs.Permissions
{
    public class PermissionItemDTO
    {
        public string ItemName { get; }
        public int ItemValue { get; }
        public bool Checked { get; }

        public PermissionItemDTO(string name, int value, bool isChecked)
        {
            this.ItemName = name;
            this.ItemValue = value;
            this.Checked = isChecked;
        }
    }
}
