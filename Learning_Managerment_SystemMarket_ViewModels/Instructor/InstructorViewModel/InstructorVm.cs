using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel
{
    public class InstructorVm
    {
        public string InstructorName { get; set; }

        public string HeadLine { get; set; } = null;
        public string Image { get; set; } = null;

        public string Website { get; set; } = null;

        public string Facebook { get; set; } = null;

        public string LinkedIn { get; set; } = null;

        public string Youtube { get; set; } = null;

        public string Description { get; set; } = null;

        public int EmailNotification { get; set; } = 1;// nhận thông báo

        public int PushNotification { get; set; } = 1;

        public DateTime? EmailVerifiedAt { get; set; }

        public StatusIns Status { get; set; }

        public decimal Balance { get; set; }

        public ICollection<CourseVm> Courses { get; set; }
    }

    public class EarningView
    {
        public decimal Balance { get; set; }
        public decimal Earning { get; set; }
        public decimal Fee { get; set; }
    }

    public class OrderVM
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CourseName { get; set; }
    }
}
