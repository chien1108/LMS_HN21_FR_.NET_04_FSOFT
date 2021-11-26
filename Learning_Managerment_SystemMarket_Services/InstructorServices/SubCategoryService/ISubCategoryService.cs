using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryVm>> GetSubCategoryByCategoryId(int id);
    }
}