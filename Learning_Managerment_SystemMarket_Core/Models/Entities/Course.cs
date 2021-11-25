using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System.Collections.Generic;

namespace Learning_Managerment_SystemMarket_Core.Models.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitile { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsFree { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestseller { get; set; }
        public string CoverImage { get; set; }// default img.png
        public string PromotionVideo { get; set; } // null
        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive
        public int Likes { get; set; }
        public int Dislike { get; set; }
        public int Share { get; set; }
        public int Views { get; set; }
        //public int ReportAbuseId { get; set; } // error


        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int LanguageId { get; set; }
        public Instructor Instructor { get; set; }
        public Language Language { get; set; }
        public SubCategory SubCategory { get; set; }



        //public ICollection<ReportAbuse> ReportAbuses { get; set; }
        public ICollection<CourseRate> CourseRates { get; set; }

        public ICollection<CourseContent> CourseContent { get; set; }
        public ICollection<Cart> Carts { get; set; }

    }
}