using System;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Models
{
    public class PagingModel
    {
        public int CurrentPage { get; set; }
        public int CountPages { get; set; }
        public Func<int?, string> GenerateUrl { get; set; }
    }

}
