using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Models
{
    public class ExplorePagingModel
    {
        public int? CurrentPage { get; set; }
        public string SearchString { get; set; }
        public float NumSize { get; set; }
    }
}
