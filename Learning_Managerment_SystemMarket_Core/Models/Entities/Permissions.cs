using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Permission : BaseEntity
    {
        public string PermissionName { get; set; }
        public string GuardName { get; set; }

    }
}
