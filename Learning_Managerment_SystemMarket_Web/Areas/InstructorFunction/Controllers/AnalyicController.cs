using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.InsInstructorService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    public class AnalyicController : Controller
    {
        private readonly IInsInstructorService _insInstructorService;
        private readonly UserManager<User> _userManager;

        public AnalyicController(IInsInstructorService insInstructorService, UserManager<User> userManager)
        {
            _insInstructorService = insInstructorService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var instructor = _userManager.GetUserAsync(User).Result;
            var listStudentSub = _insInstructorService.SumStudentSubByInstructorIdOrderByMonth(instructor.IdUser);
            var listOrderSum = _insInstructorService.SumOrderByInstructorIdOrderByMonth(instructor.IdUser);

            ViewBag.Data = string.Join(",", listStudentSub.Select(s => string.Format("{0}", s)));
            ViewBag.Earning = string.Join(",", listOrderSum.Select(s => string.Format("{0}", s)));
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(int month, int year)
        //{
        //    var instructor = _userManager.GetUserAsync(User).Result;
        //    var sales = _insInstructorService.SumOrderByInstructorIdOrderByDayOfMonth(instructor.IdUser, month, year);
        //    if (sales == null)
        //    {
        //        TempData["Message"] = "No sales";
        //        return View("Index");
        //    }
        //    else
        //    {
        //        ViewBag.Month = string.Join(",", sales.Select(s => string.Format("{0}", s)));
        //        ViewBag.Check = true;
        //        return PartialView();
        //    }
        //}
    }
}
