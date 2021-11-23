using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel
{
    public class CategoryVm
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public Status Status { get; set; } //active/ deactive default 1
    }
}
