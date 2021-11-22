using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class FeedBack : BaseEntity
    {
        public string Name { get; set; }
        public string FeedBackName { get; set; }
        public string Document { get; set; }
        public string Message { get; set; }
    }
}
