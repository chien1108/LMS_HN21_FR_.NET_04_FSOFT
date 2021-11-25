using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Lecture : BaseEntity
    {
        public int CourseContentId { get; set; }

        //public int CourseId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string File { get; set; }
        public int Volume { get; set; }
        public int Duration { get; set; }
        public int Positon { get; set; }

        public CourseContent CourseContent { get; set; }
        //public Course Course { get; set; }
    }
}