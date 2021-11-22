using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    //ChienDT9 Add for more job for student
    public class FailedJob : BaseEntity
    {
        public int UserId { get; set; }
        public string Connect { get; set; }
        public string Queue { get; set; }
        public string PayLoad { get; set; }
        public string Exception { get; set; }
        public User User { get; set; }
    }
}
