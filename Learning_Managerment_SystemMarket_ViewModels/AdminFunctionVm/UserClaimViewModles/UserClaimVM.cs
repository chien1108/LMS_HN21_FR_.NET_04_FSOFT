using System.Collections.Generic;
namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserClaimViewModles
{
    public class UserClaimVM
    {
        public UserClaimVM()
        {
            Cliams = new List<UserClaim>();
        }
        public int UserId { get; set; }
        public List<UserClaim> Cliams{ get; set; }
    }
}
