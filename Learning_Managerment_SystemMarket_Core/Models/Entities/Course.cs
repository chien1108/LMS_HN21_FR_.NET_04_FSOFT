using Learning_Managerment_SystemMarket_Core.Models.Base;
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
        public int CoverImage { get; set; }
        public int PromotionVideo { get; set; }
        //public int Status { get; set; }
        public int Likes { get; set; }
        public int Dislike { get; set; }
        public int Shares { get; set; }
        public int Views { get; set; }
        public int ReportAbuseId { get; set; }

        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int LanguageId { get; set; }
        public Instructor Instructor { get; set; }
        public Language Language { get; set; }
        public SubCategory SubCategory { get; set; }

        //public ICollection<Order> Orders { get; set; }
        public ICollection<CourseRate> CourseRates { get; set; }

        public ICollection<CourseContent> CourseContent { get; set; }

    }
}