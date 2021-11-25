using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class PayOut : BaseEntity
    {
        public int InstructorId { get; set; }
        public decimal Amount { get; set; }
        public StatusPayout StatusPay { get; set; }
        public int Remark { get; set; }

        public Instructor Instructor { get; set; }
    }
}