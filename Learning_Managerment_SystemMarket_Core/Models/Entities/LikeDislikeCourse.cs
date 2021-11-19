using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class LikeDislikeCourse : BaseEntityNotId
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int ForWhat { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
