using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class FAQ : BaseEntity
    {
        public int FAQFor { get; set; } // 0 for student, 1 for Instrutor default 0
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}