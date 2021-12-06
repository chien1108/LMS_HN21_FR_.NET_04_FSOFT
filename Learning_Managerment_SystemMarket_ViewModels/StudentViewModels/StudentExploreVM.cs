
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class StudentExploreVM
    {
        public ICollection<CardCourseVM> Courses { get; set; }
        public string SearchString { get; set; }
        public ICollection<CardInstructorVM> Instructors { get; set; }
    }
    
}
