using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.OrderService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.OrderViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    public class EarningController : Controller
    {
        private readonly IInstructorOrderService _instructorOrderService;
        private readonly UserManager<User> _userManager;

        public EarningController(IInstructorOrderService instructorOrderService, UserManager<User> userManager)
        {
            _instructorOrderService = instructorOrderService;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetMonthYear()
        {
            User user = await _userManager.GetUserAsync(User);

            //var orders = await _instructorOrderService.FindAll(x => x.Course.InstructorId == user.IdUser);
            var orders = await _instructorOrderService.FindAll(x => x.Course.InstructorId == 1);

            var result = orders.GroupBy(x => new { x.CreatedDate.Month, x.CreatedDate.Year }).Select(c => new { Month = c.Key.Month, Year = c.Key.Year });

            return Json(result);
        }

        public async Task<IActionResult> Index(string dateTime)
        {
            User user = await _userManager.GetUserAsync(User);
            var orders = new List<OrderVm>();
            if (dateTime != null)
            {
                string[] date = dateTime.Split("-");

                orders = (List<OrderVm>)await _instructorOrderService
                    .FindAll(x => x.Course.InstructorId == 1 && x.CreatedDate.Month == Int32.Parse(date[0]) && x.CreatedDate.Year == Int32.Parse(date[1]), includes: new List<string>() { "Course" });

            }
            else
            {
                //var orders = await _instructorOrderService.FindAll(x => x.Course.InstructorId == user.IdUser);
                orders = (List<OrderVm>)await _instructorOrderService.FindAll(x => x.Course.InstructorId == 1, includes: new List<string>() { "Course" });
            }


            var salesEarnings = orders.Sum(x => x.Price);
            var adminCommission = orders.Sum(x => x.AdminCommission);
            ViewBag.DateTime = dateTime;

            //Top Course
            var topCourse = orders
                .GroupBy(x => new { x.Course.Title, x.CourseId })
                .Select(c => new TopCourseVm { Title = c.Key.Title, Amount = c.Count(), Earning = c.Sum(x => x.Price) })
                .OrderBy(n => n.Amount).Take(3);

            //List Sale 
            var itemSalses = orders.GroupBy(x => new { x.CreatedDate }).Select(c => new ItemSalesVm
            {
                Day = c.Key.CreatedDate,
                ItemSalesCount = c.Count(),
                Earning = c.Sum(x => x.Price)
            });

            var model = new InfomationListOrderVM
            {
                SalesEarnings = salesEarnings,
                AdminCommission = adminCommission,
                ItemSales = itemSalses,
                TopCourses = topCourse
            };
            return View(model);
        }
    }
}
