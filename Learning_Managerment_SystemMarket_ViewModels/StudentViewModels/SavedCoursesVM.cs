using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class SavedCoursesVM
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public CourseDetailVM Student { get; set; }
        public StudentHomePageVM Course { get; set; }
    }
}
