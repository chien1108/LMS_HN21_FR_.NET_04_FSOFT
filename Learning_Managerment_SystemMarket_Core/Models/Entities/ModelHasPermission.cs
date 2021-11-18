using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class ModelHasPermission 
    {
        public int PermissionId { get; set; }
        public int UserId { get; set; }
        public string ModelType { get; set; }

        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
