using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
    public class CardCourseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }// default img.png
        public int Views { get; set; }
        public DateTime CreatedDate { get; set; }
        public Learning_Managerment_SystemMarket_Core.Models.Entities.Instructor Instructor { get; set; }
        public SubCategory SubCategory { get; set; }
        public string RelativeCreateDate => RelativeDate.ChangeDate(CreatedDate);
    }
}
