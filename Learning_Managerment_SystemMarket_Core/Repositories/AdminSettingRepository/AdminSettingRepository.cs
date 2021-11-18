using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepository;

namespace Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepository
{
    public class AdminSettingRepository : GenericRepository<AdminSetting>, IAdminSettingRepository
    {
        private readonly LMSDbContext _context;

        public AdminSettingRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
