using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel
{
    public class LectureVm
    {
    }

    public class CreateLectureVm
    {
        public int CourseContentId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string File { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Positon { get; set; }
    }
}
