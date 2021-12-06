using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.InsInstructorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    [Authorize]
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
            var countStudentSub = _insInstructorService.CountStudentSubByInstructorId(instructor.IdUser);

            ViewBag.Count = countStudentSub.ToString();
            ViewBag.Data = string.Join(",", listStudentSub.Select(s => string.Format("{0}", s)));
            ViewBag.Earning = string.Join(",", listOrderSum.Select(s => string.Format("{0}", s)));
            return View();
        }
    }
}
