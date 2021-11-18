using Learning_Managerment_SystemMarket_Core.Models.Base;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class InstructorVerify : BaseEntity
    {
        public string InstructorId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        //public int Status { get; set; }

        public Instructor Instructor { get; set; }
    }
}
