using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class AdminSetting : BaseEntity
    {
        public string KeyNameID { get; set; }// key
        public string Value { get; set; }
    }
}