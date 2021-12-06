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
        public int CountOrderByInstructorId(int id)
        {
            var count = _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor).Where(x => x.Course.InstructorId == id).Count();
            return count;
        }
        public int CountStudentSubByInstructorId(int id)
        {
            var count = _context.SubScriptions.Where(x => x.InstructorId == id).Count();
            return count;
        }
        public decimal SumOrderByInstructorIdOrderByDayOfMonth(int id, int day, int month, int year)
        {
            var sum = _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor)
                .Where(x => x.Course.InstructorId == id && x.CreatedDate.Day == day && x.CreatedDate.Month == month && x.CreatedDate.Year == year).Sum(x => x.Price);
            return sum;
        }
        public decimal SumOrderByInstructorIdOrderByMonth(int id, int number)
        {
            var sum = _context.Orders.Include(x => x.Course).ThenInclude(x => x.Instructor).Where(x => x.Course.InstructorId == id && x.CreatedDate.Month == number).Sum(x => x.Price);
            return sum;
        }
        public decimal SumStudentSubByInstructorIdOrderByMonth(int id, int number)
        {
            decimal sum = 0;
            var result = _context.SubScriptions.Where(x => x.InstructorId == id).ToList();
            foreach (var item in result)
            {
                if (item.CreatedDate.Month == number)
                {
                    sum = sum + 1;
                }
            }
            return sum;
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
