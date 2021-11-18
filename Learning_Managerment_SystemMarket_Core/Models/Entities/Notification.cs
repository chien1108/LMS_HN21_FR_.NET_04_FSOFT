using Learning_Managerment_SystemMarket_Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public int WhoIs { get; set; } // 0 student, 1 instructor
        public string Title { get; set; }
    }
}
