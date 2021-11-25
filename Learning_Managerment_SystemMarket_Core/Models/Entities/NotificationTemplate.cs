using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class NotificationTemplate : BaseEntity
    {
        public string ForWhat { get; set; }
        public int ForWho { get; set; }
        public string EmailTitle { get; set; }
        public string Subject { get; set; }
        public string NotificationTitle { get; set; }
    }
}