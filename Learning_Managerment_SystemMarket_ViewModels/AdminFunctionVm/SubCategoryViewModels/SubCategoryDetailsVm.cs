using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels
{
    public class SubCategoryDetailsVm : BaseEntity
    {
        [Required]
        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }
        public Status Status { get; set; }

        public CategortDetailsVm Category { get; set; }
    }
}