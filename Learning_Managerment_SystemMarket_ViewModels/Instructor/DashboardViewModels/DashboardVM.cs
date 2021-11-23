using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels
{
    public class DashboardVM
    {
        
        [Display(Name = "Total Sales")]
        public Decimal TotalSales { get; set; }
        
        [Display(Name = "Total Enroll")]
        public int TotalEnroll{ get; set; }
        
        [Display(Name = "Total Courses")]
        public int TotalCourses { get; set; }
        
        [Display(Name = "Total Students")]
        public int TotalStudents { get; set; }

        [Display(Name = "Total Views")]
        public int TotalViews { get; set; }
        public List<SubmitCoursesVM> SubmitCourses { get; set; }

        public List<LastSellCoursesVM> LastSellCourses { get; set; }
    }
}
