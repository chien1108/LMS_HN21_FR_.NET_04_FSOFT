using Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.LanguageService
{
    public interface IInstructorLanguageService
    {
        Task<List<LanguageVm>> GetAllLanguage();
    }
}