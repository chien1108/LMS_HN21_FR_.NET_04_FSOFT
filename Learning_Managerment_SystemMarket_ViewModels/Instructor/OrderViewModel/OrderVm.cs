using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.OrderViewModel
{
    public class OrderVm
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public decimal Price { get; set; }

        public int PaymentMethod { get; set; }

        public int AdminCommission { get; set; }

        public StatusOrder Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public CourseVm Course { get; set; }
    }

    public class InfomationListOrderVM
    {
        public decimal SalesEarnings { get; set; }

        public decimal AdminCommission { get; set; }

        public IEnumerable<ItemSalesVm> ItemSales { get; set; }

        public IEnumerable<TopCourseVm> TopCourses { get; set; }
    }

    public class ItemSalesVm
    {
        public DateTime Day { get; set; }

        public int ItemSalesCount { get; set; }

        public decimal Earning { get; set; }
    }

    public class TopCourseVm
    {
        public string Title { get; set; }

        public int Amount { get; set; }

        public decimal Earning { get; set; }
    }
}
