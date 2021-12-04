using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.StudentViewModel;
using System;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel
{
    public class CourseRateVm
    {
        public string Messge { get; set; }

        public int Star { get; set; } // default = 0;

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public StudentVm Student { get; set; }

        public CourseVm Course { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PrettyDate { get; set; }
    }
}