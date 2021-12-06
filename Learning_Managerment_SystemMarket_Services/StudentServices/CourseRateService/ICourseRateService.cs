using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.CourseRateService
{
    public interface ICourseRateService
    {
        Task<ServiceResponse<CourseRateVM>> CreateCourseRate(CourseRateVM courseRate, int studentId);
        Task<double> AvgCourseRate(int courseId);
        Task<int> CountStudentRate(int courseId);
    }
}