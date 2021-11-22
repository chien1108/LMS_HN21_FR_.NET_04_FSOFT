using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.NotificationTemplateRepo
{
    public class NotificationTemplateRepository: GenericRepository<NotificationTemplate>,INotificationTemplateRepository
    {
        private readonly LMSDbContext _context;

        public NotificationTemplateRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
