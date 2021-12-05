using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels
{
    public class LastSellCoursesVM
    {
        private DateTime? _createdDate;

        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.Now; }
            set { _createdDate = value; }
        }

        public DateTime? ModifiedDate { get; set; }
        public string Title { get; set; }
        public string SubTitile { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsBestseller { get; set; }
        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive
        public int Views { get; set; }
    }
}