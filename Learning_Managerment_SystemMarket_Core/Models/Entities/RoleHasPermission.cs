using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class RoleHasPermission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
