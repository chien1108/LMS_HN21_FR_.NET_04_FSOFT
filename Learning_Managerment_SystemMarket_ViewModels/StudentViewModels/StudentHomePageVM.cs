using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class StudentHomePageVM
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsFree { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestseller { get; set; }
        public int CoverImage { get; set; }// default img.png
        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive
        public int Likes { get; set; }
        public int Dislike { get; set; }
        public int Share { get; set; }
        public int Views { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public Instructor Instructor { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
