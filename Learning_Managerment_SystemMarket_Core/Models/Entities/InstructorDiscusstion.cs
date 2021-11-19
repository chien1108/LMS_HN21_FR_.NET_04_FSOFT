using Learning_Managerment_SystemMarket_Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class InstructorDiscusstion : BaseEntityNotId
    {
        
        public string Comment { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}