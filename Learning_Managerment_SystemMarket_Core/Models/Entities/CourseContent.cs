using Learning_Managerment_SystemMarket_Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class CourseContent : BaseEntity
    {
        public int Position { get; set; } = 1;
        public string Title { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}