using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Order : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Price { get; set; }
        public int PaymentMethod { get; set; }
        public int AdminCommission { get; set; }
        public StatusOrder Status { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}