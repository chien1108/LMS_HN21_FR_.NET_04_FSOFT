using Microsoft.AspNetCore.Identity;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class User : IdentityUser<int>
    {
        //ID => role
        public string FullName { get; set; }

        //public string LastName { get; set; }
        //public string Image { get; set; }
        public int WhoIs { get; set; } // 0 student, 1 instructor, 2 admin
        public int IdUser { get; set; } // => istrucor or student
    }
}
