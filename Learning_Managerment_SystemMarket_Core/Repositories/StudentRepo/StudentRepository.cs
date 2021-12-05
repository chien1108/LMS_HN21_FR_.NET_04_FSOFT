using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly LMSDbContext _context;

        public StudentRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateSubcription(SubScription subScription)
        {
            await _context.SubScriptions.AddAsync(subScription);
        }

        public async Task DeleteSubcription(SubScription subScription)
        {
            _context.SubScriptions.Remove(subScription);
        }

        public async Task<ICollection<SubScription>> GetAllSubInstructorByStudentId(int studentId)
        {
            var subInstructor = await _context.SubScriptions
                .Include(x => x.Instructor)
                .Where(x => x.StudentId == studentId)
                .ToListAsync();
            return subInstructor;
        }

        public async Task<ICollection<SubScription>> GetSubByInstructorId(int instructorId)
        {
            var subInstructor = await _context.SubScriptions
                                .Include(x => x.Instructor)
                                .Where(x => x.Instructor.Id == instructorId)
                                .ToListAsync();
            return subInstructor;
        }

        public async Task<bool> IsSubcribleExist(int studentId, int instuctorId)
        {
            var result = await _context.SubScriptions.FirstOrDefaultAsync(x => x.StudentId == studentId && x.InstructorId == instuctorId);
            return result != null;
        }
    }
}
