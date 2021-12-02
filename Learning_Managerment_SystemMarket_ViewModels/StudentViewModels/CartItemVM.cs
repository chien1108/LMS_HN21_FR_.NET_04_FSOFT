using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.StudentViewModels
{
   public class CartItemVM
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //public Student Student { get; set; }
        public CourseDetailVM Course { get; set; }
    }
    public class CartVM
    {
        public ICollection<CartItemVM> Carts { get; set; }
        public decimal Total { get; set; }
    }
}
