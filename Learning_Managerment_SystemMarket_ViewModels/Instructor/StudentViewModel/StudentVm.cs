using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.StudentViewModel
{
    public class StudentVm
    {
        public string StudentName { get; set; }

        public StatusStudent Status { get; set; }

        public byte[] Image { get; set; }
    }
}