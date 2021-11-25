using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels
{
    public class RoleVM 
    {
        public RoleVM()
        {
            ClaimsFake = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string GuardName { get; set; }

        public ICollection<Claim> Claims { get; set; }
        public ICollection<string> ClaimsFake { get; set; }
    }
}
