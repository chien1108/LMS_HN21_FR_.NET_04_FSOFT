using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class PaytabsInvoice : BaseEntity
    {
        public int OrderId { get; set; }
        public string Result { get; set; }
        public int ResponseCode { get; set; }
        public decimal Amount { get; set; }
        public string Curency { get; set; }

        public Order Order { get; set; }
    }
}
