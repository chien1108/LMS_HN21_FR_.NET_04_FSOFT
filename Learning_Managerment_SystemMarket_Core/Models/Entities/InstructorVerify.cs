using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class InstructorVerify : BaseEntity
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public StatusInsVerify Status { get; set; }

        public Instructor Instructor { get; set; }
    }
}