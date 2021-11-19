using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class SubScription : BaseEntityNotId
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}
