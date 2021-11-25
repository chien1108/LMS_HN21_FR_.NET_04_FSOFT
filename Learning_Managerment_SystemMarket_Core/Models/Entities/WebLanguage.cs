using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class WebLanguage : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int IsRtl { get; set; }
    }
}