using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel
{
    public class LectureVm
    {
    }

    public class CreateLectureVm
    {
        [DisplayName("Lecture Title")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Title { get; set; }

        [DisplayName("Lecture Description")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string Description { get; set; }

        public string File { get; set; }

        [DisplayName("Volume")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public int Volume { get; set; }

        [DisplayName("Duration")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public int Duration { get; set; }

        [DisplayName("Positon")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public int Positon { get; set; }

        public int IdFake { get; set; }
    }
}
