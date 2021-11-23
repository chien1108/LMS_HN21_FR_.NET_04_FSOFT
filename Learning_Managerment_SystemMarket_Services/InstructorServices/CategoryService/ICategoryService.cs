using Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAllCategory();
    }
}