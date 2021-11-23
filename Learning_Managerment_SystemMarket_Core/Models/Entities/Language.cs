using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Language : BaseEntity
    {
        public string LanguageName { get; set; }

        public Status Status { get; set; }
    }
}