using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel
{
    public class CourseVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive
        public DateTime ModifiedDate { get; set; }
        public int Sales { get; set; }
        public decimal Price { get; set; }
        public int Parts { get; set; }
        public string CategoryName { get; set; }
    }
}
