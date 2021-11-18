using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class ModelHasRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; } // ID User

        public string ModelType { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
