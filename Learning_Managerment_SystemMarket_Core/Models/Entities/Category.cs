using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public Status Status { get; set; } //active/ deactive default 1

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
