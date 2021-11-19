using Learning_Managerment_SystemMarket_Core.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        //public string RoleName { get; set; }
        public string GuardName { get; set; }

    }
}
