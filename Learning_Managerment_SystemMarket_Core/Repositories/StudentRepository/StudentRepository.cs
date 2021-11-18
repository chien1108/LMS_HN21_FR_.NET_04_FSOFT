using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepository;

namespace Learning_Managerment_SystemMarket_Core.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        private readonly LMSDbContext _context;

        public StudentRepository(LMSDbContext context) : base (context)
        {
            _context = context;
        }
    }
}
