using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        private readonly LMSDbContext _context;

        public StudentRepository(LMSDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<ICollection<SubScription>> GetAllSubInstructorByStudentId(int studentId)
        {
            var subInstructor = await _context.SubScriptions
                .Include(x => x.Instructor)
                .Where(x => x.StudentId == studentId)
                .ToListAsync();
            return subInstructor;
        }
    }
}
