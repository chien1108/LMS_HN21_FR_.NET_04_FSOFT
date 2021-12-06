using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        decimal SumStudentSubByInstructorIdOrderByMonth(int id, int number);

        decimal SumOrderByInstructorIdOrderByMonth(int id, int number);

        decimal SumOrderByInstructorIdOrderByDayOfMonth(int id, int day, int month, int year);
    }
}