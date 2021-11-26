using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class SpecialDiscount : BaseEntity
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }

        public Course Course { get; set; }
    }
}
