using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class CardCourseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public byte[] CoverImage { get; set; }// default img.png
        public int Views { get; set; }
        public DateTime CreatedDate { get; set; }
        public Learning_Managerment_SystemMarket_Core.Models.Entities.Instructor Instructor { get; set; }
        public SubCategory SubCategory { get; set; }
        public string RelativeCreateDate => RelativeDate.ChangeDate(CreatedDate);
        public Category Category { get; set; }

    }
}
