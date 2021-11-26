using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        public string GuardName { get; set; }

    }
}