using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.GenericRepo;

namespace Learning_Managerment_SystemMarket_Core.Repositories.PaytabsInvoiceRepo
{
    public class PaytabsInvoiceRepository : GenericRepository<PaytabsInvoice>, IPaytabsInvoiceRepository
    {
        private readonly LMSDbContext _context;

        public PaytabsInvoiceRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}