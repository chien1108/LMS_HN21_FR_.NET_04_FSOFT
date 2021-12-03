using Learning_Managerment_SystemMarket_Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class SubScriptionVM: BaseEntityNotId
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public string ReturnUrl { get; set; }
    }
}
