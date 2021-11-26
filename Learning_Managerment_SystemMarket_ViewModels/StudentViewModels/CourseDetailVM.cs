using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class CourseDetailVM
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
        public int Likes { get; set; }
        public int Dislike { get; set; }
        public int Share { get; set; }
        public int Views { get; set; }
        public string Requirements { get; set; }
        public DateTime CreatedDate { get; set; }
        public CourseContent CourseContent { get; set; }
        public CourseRate CourseRate { get; set; }

        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int LanguageId { get; set; }
        public Instructor Instructor { get; set; }
        public Language Language { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
