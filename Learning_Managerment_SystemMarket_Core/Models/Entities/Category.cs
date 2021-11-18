using Learning_Managerment_SystemMarket_Core.Models.Base;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        //public string Status { get; set; } //active/ deactive

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
