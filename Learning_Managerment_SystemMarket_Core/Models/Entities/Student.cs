using Learning_Managerment_SystemMarket_Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        //public int Status { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        //public ICollection<ChatGroup> ChatGroups { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<SubScription> SubCriptions { get; set; }
    }
}
