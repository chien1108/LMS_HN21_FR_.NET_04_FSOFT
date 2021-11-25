using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Instructor : BaseEntity
    {
        //public string InstructorName { get; set; }
        public string HeadLine { get; set; } = null;

        public string Website { get; set; } = null;
        public string Facebook { get; set; } = null;
        public string LinkedIn { get; set; } = null;
        public string Youtube { get; set; } = null;
        public string Description { get; set; } = null;
        public int EmailNotification { get; set; } = 1;// nhận thông báo
        public int PushNotification { get; set; } = 1;
        public DateTime? EmailVerifiedAt { get; set; }
        public StatusIns Status { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        //public ICollection<ChatGroup> ChatGroups { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Course> Courses { get; set; }

        public ICollection<InstructorDiscusstion> InstructorDiscusstions { get; set; }
        public ICollection<SubScription> SubScriptions { get; set; }
    }
}