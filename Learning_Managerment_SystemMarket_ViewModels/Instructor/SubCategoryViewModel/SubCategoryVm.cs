using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel
{
    public class SubCategoryVm
    {
        public int Id { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public Status Status { get; set; }
    }
}
