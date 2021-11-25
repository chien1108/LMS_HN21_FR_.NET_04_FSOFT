using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Student : BaseEntity
    {
        //public string StudentName { get; set; }
        public StatusStudent Status { get; set; }

        public string Image { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        //public ICollection<ChatGroup> ChatGroups { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<SubScription> SubCriptions { get; set; }
    }
}