using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class SubScription : BaseEntity
    {
        public string StudentId { get; set; }
        public string InstructorId { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}
