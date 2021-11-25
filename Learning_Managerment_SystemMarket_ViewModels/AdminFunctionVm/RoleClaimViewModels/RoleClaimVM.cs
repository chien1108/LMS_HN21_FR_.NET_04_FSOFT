using System.Collections.Generic;
namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleClaimViewModels
{
    public class RoleClaimVM
    {
        public RoleClaimVM()
        {
            Cliams = new List<RoleClaim>();
        }
        public int RoleId { get; set; } 
        public List<RoleClaim> Cliams{ get; set; }
    }
}
