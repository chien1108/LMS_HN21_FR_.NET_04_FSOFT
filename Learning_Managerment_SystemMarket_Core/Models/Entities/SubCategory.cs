using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class SubCategory : BaseEntity
    {
        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public Status Status { get; set; }

        public Category Category { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}