using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class StudentExploreVM
    {
        public ICollection<Course> Courses { get; set; }
        public string SearchString { get; set; }
    }
}
