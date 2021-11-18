using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class InstructorDiscusstion : BaseEntity
    {
        public string InstructorId { get; set; }
        public string StudentId { get; set; }
        public string Comment { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }

        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}