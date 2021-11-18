using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepository;
using System;

namespace Learning_Managerment_SystemMarket_Core.Repositories.SpecialDiscountRepository
{
    public class SpecialDiscountRepository : GenericRepository<SpecialDiscount>,ISpecialDiscountRepository
    {
        private readonly LMSDbContext _context;

        public SpecialDiscountRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }


        // check 
        public string StatusDate(DateTime startDate , DateTime endDate)
        {
            var now = DateTime.Now;
            int result = DateTime.Compare(startDate, now);
            if(result > 0)
            {
                var diffStart = startDate.Subtract(now);
                return $"Active after {diffStart} days";
            }
            var diffEnd = endDate.Subtract(now);
            if(diffEnd.Days > 0)
            {
                return $"Expired in {diffEnd} days";
            }
            else
            {
                return $"Expired {diffEnd} days ago";
            }
        }
    }
}
