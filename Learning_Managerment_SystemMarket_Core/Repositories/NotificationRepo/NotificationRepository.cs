using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.NotificationRepo
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly LMSDbContext _context;

        public NotificationRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}