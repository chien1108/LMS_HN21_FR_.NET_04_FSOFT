using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class CourseRate : BaseEntityNotId
    {
        public string Messge { get; set; }
        public int Star { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}