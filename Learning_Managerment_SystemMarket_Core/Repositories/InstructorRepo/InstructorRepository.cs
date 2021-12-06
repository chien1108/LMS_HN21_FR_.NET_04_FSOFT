using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly LMSDbContext _context;

        public InstructorRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// KhanhPC1 GetSubscrierByInstructorId
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns></returns>
          public async Task<ICollection<SubScription>> GetSubcriptionByInstructorId(int instructorId)
        {
            var subScription = await _context.SubScriptions
                 .Include(x => x.Instructor)
                 .Where(x => x.InstructorId == instructorId)
                 .ToListAsync();
            return subScription;
        }
    
    }
}
