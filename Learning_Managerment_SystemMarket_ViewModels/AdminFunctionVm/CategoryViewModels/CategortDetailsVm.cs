using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels
{
    public class CategortDetailsVm : BaseEntity
    {

        [Required]
        public string CategoryName { get; set; }
        public Status Status { get; set; } //active/ deactive default 1

        public ICollection<SubCategoryDetailsVm> SubCategories { get; set; }
    }
}
