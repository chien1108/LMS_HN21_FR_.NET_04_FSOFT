using Learning_Managerment_SystemMarket_Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Instructor : BaseEntity
    {
        public string InstructorName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        public ICollection<Notification> Notifications { get; set; }
        //public ICollection<ChatGroup> ChatGroups { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<InstructorDiscusstion> InstructorDiscusstions { get; set; }
        public ICollection<SubScription> SubScriptions { get; set; }
    }
}
