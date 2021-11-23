using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel
{
    public class CourseContentVm
    {
        public int Position { get; set; } = 1;

        public string Title { get; set; }

        public int CourseId { get; set; }

        public CourseVm Course { get; set; }
    }

    public class CreateCourseContentVm
    {
        [Required]
        public int Position { get; set; } = 1;

        [Required]
        public string Title { get; set; }

        [Required]
        public int CourseId { get; set; }

        List<CreateLectureVm> Lecture { get; set; }
    }
}
