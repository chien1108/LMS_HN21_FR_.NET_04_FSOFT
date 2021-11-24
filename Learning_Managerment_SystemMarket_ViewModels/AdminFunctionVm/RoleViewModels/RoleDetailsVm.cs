using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels
{
    public class RoleDetailsVm
    {
        public Role Role { get; set; }
        public IList<Claim> Claim { get; set; }
    }
}
