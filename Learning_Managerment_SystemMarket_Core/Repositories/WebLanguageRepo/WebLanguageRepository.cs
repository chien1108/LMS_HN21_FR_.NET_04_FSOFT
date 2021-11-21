using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.WebLanguageRepo
{
    public class WebLanguageRepository : GenericRepository<WebLanguage>, IWebLanguageRepository
    {
        private readonly LMSDbContext _context;

        public WebLanguageRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}