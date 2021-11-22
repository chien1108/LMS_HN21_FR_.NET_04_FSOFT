using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.LanguageRepo
{
    public class LanguageRepository : GenericRepository<Language>,ILanguageRepository
    {
        private readonly LMSDbContext _context;

        public LanguageRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
