using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.InsInstructorService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    public class StatementController : Controller
    {
        private readonly IInsInstructorService _insInstructorService;
        private readonly UserManager<User> _userManager;
        public StatementController(IInsInstructorService insInstructorService, UserManager<User> userManager)
        {
            _insInstructorService = insInstructorService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Check = false;
            return View();
        }       

        public ActionResult Details(int id)
        {
            var order = _insInstructorService.GetOrderById(id).Result;
            return View(order);
        }

        [HttpPost]
        public ActionResult Index(int month, int year)
        {
            var instructor = _userManager.GetUserAsync(User).Result;
            var orders = _insInstructorService.GetOrdersByMonthAndYear(month, year, instructor.IdUser).Result;
            if(orders.Count == 0)
            {
                TempData["Message"] = "No orders";
                return View("Index");
            }    
            else
            {
                ViewBag.Check = true;
                return PartialView(orders);
            }               
        }
    }
}
