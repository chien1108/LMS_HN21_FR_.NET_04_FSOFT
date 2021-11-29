using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel
{
    public class CourseVm
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive

        public DateTime ModifiedDate { get; set; }

        public int Sales { get; set; }

        public decimal Price { get; set; }

        public int Parts { get; set; }

        public string CategoryName { get; set; }

        public string SubTitile { get; set; }

        public string Description { get; set; }

        public decimal DiscountPrice { get; set; }

        public bool IsFree { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsBestseller { get; set; }

        public int CoverImage { get; set; }// default img.png

        public string PromotionVideo { get; set; } // null

        public int Likes { get; set; }

        public int Dislike { get; set; }

        public int Share { get; set; }

        public int Views { get; set; }

        public int InstructorId { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        public int LanguageId { get; set; }

        public LanguageVm Language { get; set; }

        public SubCategoryVm SubCategory { get; set; }

        public InstructorVm Instructor { get; set; }

        public ICollection<CourseContentVm> CourseContent { get; set; }
    }
    public class CreateCourseTest
    {
        public string Title { get; set; }

        public string SubTitile { get; set; }

        public string Description { get; set; }

        public bool IsFree { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        public int LanguageId { get; set; }

    }
    public class CreateCourseVm
    {
        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Title { get; set; }

        [DisplayName("SubTitile")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string SubTitile { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        [DisplayName("Is Free")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public bool IsFree { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsBestseller { get; set; }

        //[Required]
        public int CoverImage { get; set; }// default img.png

        public string PromotionVideo { get; set; } // null

        public StatusCourse Status { get; set; } // 0 Draft, 1 Active , 2 WaitFor Approced, 3 Block, 4 Deactive

        public int Likes { get; set; }

        public int Dislike { get; set; }

        public int Share { get; set; }

        public int Views { get; set; }

        //[Required]
        public int InstructorId { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        public int LanguageId { get; set; }

        public IEnumerable<CreateCourseContentVm> CourseContent { get; set; }
    }

    public class ViewCourseVm
    {
        public IEnumerable<CourseVm> Courses { get; set; }
        public IEnumerable<CourseVm> DraftCourses { get; set; }
        public IEnumerable<CourseVm> UpcomingCourses { get; set; }
        public IEnumerable<DisCountCourseVm> DisCountCourses { get; set; }
    }

    public class DisCountCourseVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CourseName { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public IEnumerable<CourseVm> Courses { get; set; }
        public int CourseId { get; set; }
    }
}
