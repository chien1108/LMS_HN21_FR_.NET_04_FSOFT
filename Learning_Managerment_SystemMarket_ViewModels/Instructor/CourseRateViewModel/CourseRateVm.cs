<<<<<<< HEAD
﻿using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.StudentViewModel;
>>>>>>> fa393df7ed82a59c951d589481922dff5e0b6633

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel
{
    public class CourseRateVm
    {
        public string Messge { get; set; }

        public int Star { get; set; } // default = 0;

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public StudentVm Student { get; set; }

        public CourseVm Course { get; set; }
    }
}